using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace kangur
{
    public partial class Main : Form
    {
        // build version, adding new line because github adds it to their file
        // and the version is being compared with one written in github file in repo
        public static string softwareVersion = "7" + "\n";

        // start time of a process, helps detecting
        // if the game reopened and we need to patch again
        public static string processSession = "";
        public static string lastProcessSession = "";

        // all module static related variables
        // will start with "module" and its name
        public static string module_hero_ACTION_immortality = "";
        public static string module_hero_ACTION_unlimitedBoomerangs = "";
        public static string module_hero_ACTION_snapshot = "";
        public static string module_hero_ACTION_load = "";
        public static string module_hero_ACTION_boost = "";
        public static string module_hero_ACTION_stars = "";

        public static int module_environment_ACTION_loadLevel = 0;
        public static string module_environment_ACTION_unlock_all_levels = "";
        public static string module_environment_ACTION_force_load_textures = "";
        public static string module_environment_ACTION_load_last_checkpoint = "";

        // allocating forms
        ModuleHero formModuleHero = new ModuleHero();
        ModuleEnvironment formModuleEnvironment = new ModuleEnvironment();
        Hotkeys formHotkeys = new Hotkeys();

        // global game process
        public static Process mainGameProcess = new Process();
        public static uint moduleAddress = 0;

        // holds all buttons, 0 = not pressed, 1 = pressed
        public int[] gamepadTable = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        // gamepad one time click forcers
        public int[] gamepadTableReady = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        // gamepad one time click forcers
        public static bool[] keybardTableReady = new bool[1500];

        public static Main MainWindow { get; private set; }

        public ActionsManager ActionsManager { get; private set; }
        public PointersData PointersData { get; private set; }
        public Hero Hero { get; private set; }

        /// <summary>
        /// Initializing component, ignore.
        /// </summary>
        public Main()
        {
            MainWindow = this;

            InitializeComponent();
            InitActions();
        }

        private void InitActions()
        {
            ActionsManager = new ActionsManager();

            ActionsManager.RegisterAction(Properties.Settings.Default.hero_snapshotKeyCode, () =>
            {
                // load values to hero module form
                var position = Hero.HeroPosition;
                var rotation = Hero.HeroRotation;

                formModuleHero.LoadPositionToForm(rotation.X, rotation.Y, position.X, position.Y, position.Z);

                // reset action variable
                module_hero_ACTION_snapshot = "";
            });

            ActionsManager.RegisterAction(Properties.Settings.Default.hero_loadKeyCode, () =>
            {
                Hero.SaveHeroTransformToMemory();
            });
        }

        // runs on form load
        private void Main_Load(object sender, EventArgs e)
        {
            // show version in the window title on the top
            // by using global variable that's used for update cheks
            Text = "kangur v" + softwareVersion;

            // disable north korean thread control, who cares
            CheckForIllegalCrossThreadCalls = false;

            // select oob control for better visuals
            rrcrxo.Select();

            // fill out keyboard ready table
            for (int i = 0; i < keybardTableReady.Length; i++)
                keybardTableReady[i] = true;

            // start background thread
            backgroundWorker.RunWorkerAsync();

            // might be required later
            KeyPreview = true;

            // check for updates thread
            checkForUpdatesThread.RunWorkerAsync();

            // key thread checker
            keyStateThread.RunWorkerAsync();

            // button thread checker
            buttonStateThread.RunWorkerAsync();
        }

        // looped thread
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // infinite loop
            while (true)
            {
                // checks process status before
                // we commit any actions
                bool newSession = false;
                processSession = "";
                foreach (Process process in Process.GetProcessesByName("kao2"))
                {
                    // if found process with kao2 name
                    if (process.MainWindowTitle == "Kao - Round 2")
                    {
                        // asigning process for future use
                        mainGameProcess = process;

                        // assign main module address
                        moduleAddress = (uint)process.MainModule.BaseAddress;

                        // grabbing its started time as session
                        // converting to milliseconds for better management
                        DateTimeOffset startTime = process.StartTime;
                        processSession = startTime.ToUnixTimeMilliseconds().ToString();
                    }
                }

                //  alert for new session and assign new to last after operation
                if (lastProcessSession != processSession)
                {
                    newSession = true;
                    lastProcessSession = processSession;
                }

                // close all of the forms
                if (newSession)
                {
                    // session changed and it's not empty
                    // meaning game ready to rumble
                    if (processSession != "")
                    {
                        ChangeStatus("kao2 found, have fun", Color.Green);

                        // allocate memory
                        uint allocated = Toolkit.AllocateMemory();
                        Toolkit.WriteMemory(allocated, BitConverter.GetBytes(41f));
                        Toolkit.WriteMemory(moduleAddress + 0xA165E, BitConverter.GetBytes(allocated));

                        PointersData = new PointersData(Toolkit.ReadMemoryInt32(moduleAddress + 0x73D868));
                        Hero = new Hero();
                    }
                    // new session but no process open meaning game was open and you closed it
                    else
                    {
                        ChangeStatus("waiting for kao2", Color.Red);
                        CloseModuleForms();
                    }
                }

                //check if there's an active process open
                if (processSession != "")
                {
                    #region MODULE_HERO

                    // makes you immortal to mobs
                    if (module_hero_ACTION_immortality != "")
                    {
                        // change memory section protection
                        //Toolkit.DisableMemoryProtection(moduleAddress + 0xF8B88, 3);

                        // old instruction moves your new damaged hp to the pointer
                        // new instruction doesn't move your hp subtracted by damage
                        byte[] oldInstr = { 0x89, 0x46, 0x1C }; // mov [esi+1C],eax
                        byte[] newInstr = { 0x90, 0x90, 0x90 }; // nop nop nop

                        // patch instructions
                        if (module_hero_ACTION_immortality == "TRUE") Toolkit.WriteMemory(moduleAddress + 0xF8B88, newInstr);
                        else Toolkit.WriteMemory(moduleAddress + 0xF8B88, oldInstr); // FALSE

                        // reset action variable
                        module_hero_ACTION_immortality = "";
                    }

                    // you can use boomerangs limitlessly
                    else if (module_hero_ACTION_unlimitedBoomerangs != "")
                    {
                        // change memory section protection
                        //Toolkit.DisableMemoryProtection(moduleAddress + 0xF88AB, 4);
                        //Toolkit.DisableMemoryProtection(moduleAddress + 0xFAF38, 3);

                        // old instruction checks if you don't have enough boomerangs to throw
                        // new instructions changes compared number to -70 so the flag never occurs
                        byte[] oldInstr1 = { 0x83, 0x7F, 0x4C, 0x00 }; // cmp dword ptr [edi+4c],00
                        byte[] newInstr1 = { 0x83, 0x7F, 0x4C, 0x90 }; //cmp dword ptr [edi+4c],-70

                        // old instruction takes 1 boomerang when you throw
                        // new instruction doesn't take anything when you throw
                        byte[] oldInstr2 = { 0x01, 0x6E, 0x4C }; // add [esi+4C],ebp
                        byte[] newInstr2 = { 0x90, 0x90, 0x90 }; // nop nop nop

                        // patch instructions
                        if (module_hero_ACTION_unlimitedBoomerangs == "TRUE")
                        {
                            Toolkit.WriteMemory(moduleAddress + 0xF88AB, newInstr1);
                            Toolkit.WriteMemory(moduleAddress + 0xFAF38, newInstr2);
                        }
                        else // FALSE
                        {
                            Toolkit.WriteMemory(moduleAddress + 0xF88AB, oldInstr1);
                            Toolkit.WriteMemory(moduleAddress + 0xFAF38, oldInstr2);
                        }

                        // reset action variable
                        module_hero_ACTION_unlimitedBoomerangs = "";
                    }
                    // boosts vertical position by a number
                    else if (module_hero_ACTION_boost != "")
                    {
                        // get required pointer
                        uint gameletPointer = Toolkit.ReadMemoryInt32(moduleAddress + 0x73D868);
                        uint positionPointer = Toolkit.ReadMemoryInt32(gameletPointer + 0x38C) + 0x50;

                        // read current height and increase by chosen number
                        float newHeroHeight = Toolkit.ReadMemoryFloat(positionPointer + 0x10) + formModuleHero.GetNumericBoost();

                        // write new height position into memory
                        Toolkit.WriteMemory(positionPointer + 0x10, BitConverter.GetBytes(newHeroHeight));

                        // reset action variable
                        module_hero_ACTION_boost = "";
                    }

                    // change player stars
                    else if (module_hero_ACTION_stars != "")
                    {
                        // read stars from numeric
                        int newStars = formModuleHero.GetNumericStars();

                        // write new stars into memory
                        Toolkit.WriteMemory(moduleAddress + 0x734DD0, BitConverter.GetBytes(newStars));

                        // reset action variable
                        module_hero_ACTION_stars = "";
                    }

                    #endregion // ends region
                    #region MODULE_ENVIRONMENT

                    // loads selected level
                    else if (module_environment_ACTION_loadLevel != 0)
                    {
                        // get required pointer
                        uint levelLoadAddress = Toolkit.ReadMemoryInt32(moduleAddress + 0x73D868) + 0x3754;

                        // make sure we got correct level address right
                        if (levelLoadAddress != 0)
                        {
                            // gets currently loading level
                            uint currentlyLoading = Toolkit.ReadMemoryInt32(levelLoadAddress);

                            // make sure level is not loading at the moment
                            if (currentlyLoading == 0)
                            {
                                Toolkit.WriteMemory(levelLoadAddress,
                                BitConverter.GetBytes(module_environment_ACTION_loadLevel));
                            }
                        }

                        // reset action variable
                        module_environment_ACTION_loadLevel = 0;
                    }

                    // unlocks all levels on the list
                    else if (module_environment_ACTION_unlock_all_levels != "")
                    {
                        // write bool true to one of the debug options
                        Toolkit.WriteMemory(moduleAddress + 0x734DE9, BitConverter.GetBytes(1));

                        // reset action variable
                        module_environment_ACTION_unlock_all_levels = "";
                    }

                    // force loads all textures
                    else if (module_environment_ACTION_force_load_textures != "")
                    {
                        // instructions
                        byte[] enable = { 0xEB }; // jmp [address]
                        byte[] disable = { 0x75 }; // jne [address]

                        // enable
                        if (module_environment_ACTION_force_load_textures == "TRUE")
                            Toolkit.WriteMemory(moduleAddress + 0x1B40C6, enable);

                        // disable
                        else Toolkit.WriteMemory(moduleAddress + 0x1B40C6, disable);

                        // reset action variable
                        module_environment_ACTION_force_load_textures = "";
                    }

                    // loads last checkpoint
                    else if (module_environment_ACTION_load_last_checkpoint == "TRUE")
                    {
                        // get checkpoint loader address
                        uint checkpoint = Toolkit.ReadMemoryInt32(moduleAddress + 0x73D868) + 0x3F0;

                        // write reload value = 2
                        Toolkit.WriteMemory(checkpoint, BitConverter.GetBytes(2));

                        // reset action variable
                        module_environment_ACTION_load_last_checkpoint = "";
                    }

                    #endregion
                }

                // sleep to protect performance
                Thread.Sleep(10);
            }
        }

        // changes displayed log message
        // on the bottom of the form
        void ChangeStatus(string text, Color color)
        {
            labelProcessStatus.Text = text;
            labelProcessStatus.ForeColor = color;
        }

        // open hero module form
        private void buttonModuleOpenSettingsHero_Click(object sender, EventArgs e)
        { OpenModuleForm("ModuleHero"); }

        // open environment module form
        private void buttonModuleOpenSettingsEnvironment_Click(object sender, EventArgs e)
        { OpenModuleForm("ModuleEnvironment"); }

        // opens module form
        private void OpenModuleForm(string moduleForm)
        {
            // check if window is not already openMain.module_H
            // if not, open new form = window
            // if already opened before but hidden
            // then just show again, makes sure
            // game is open too
            bool processFound = false;
            foreach (Process process in Process.GetProcessesByName("kao2"))
            {
                // if found process with kao2 name
                if (process.MainWindowTitle == "Kao - Round 2")
                    processFound = true;
            }

            // bool flagged as found
            if (processFound)
            {
                if (moduleForm == "ModuleHero")
                {
                    // check if form module has been disposed
                    if (!formModuleHero.IsDisposed)
                    {
                        if (!Toolkit.IsFormOpen(moduleForm)) formModuleHero.Show();
                        else if (!formModuleHero.Visible) formModuleHero.Show();
                    }
                    else
                    {
                        // initiate form and open
                        formModuleHero = new ModuleHero();
                        formModuleHero.Show();
                    }
                }
                else if (moduleForm == "ModuleEnvironment")
                {
                    // check if form module has been disposed
                    if (!formModuleEnvironment.IsDisposed)
                    {
                        if (!Toolkit.IsFormOpen(moduleForm)) formModuleEnvironment.Show();
                        else if (!formModuleEnvironment.Visible) formModuleEnvironment.Show();
                    }
                    else
                    {
                        // initiate form and open
                        formModuleEnvironment = new ModuleEnvironment();
                        formModuleEnvironment.Show();
                    }
                }
            }
            else Toolkit.ShowError("kao2 needs to be open");
        }

        // open hotkeys form
        private void buttonHotkeys_Click(object sender, EventArgs e)
        {
            if (!Toolkit.IsFormOpen("Hotkeys")) formHotkeys.Show();
            else if (!formHotkeys.Visible) formHotkeys.Show();
        }

        // closes all forms that are not the main form
        void CloseModuleForms()
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "Main")
                    Application.OpenForms[i].Close();
            }
        }

        // check all hotkeys and see if one of them is pressed
        private void keyStateThread_DoWork(object sender, DoWorkEventArgs e)
        {
            // infinite loop
            while (true)
            {
                if (Toolkit.IsKeyPressed(Properties.Settings.Default.hero_snapshotKeyCode))
                    ActionsManager.CallAction(Properties.Settings.Default.hero_snapshotKeyCode);

                // load position snapshot with hotkey
                if (Toolkit.IsKeyPressed(Properties.Settings.Default.hero_loadKeyCode))
                    ActionsManager.CallAction(Properties.Settings.Default.hero_loadKeyCode);

                // check keyboard press
                if (Toolkit.IsFormVisible("ModuleHero"))
                {
                    // boost height position
                    if (Toolkit.IsKeyPressed(Properties.Settings.Default.hero_boostKeyCode))
                        formModuleHero.ImitateButtonClick("buttonBoost");
                }

                if (Toolkit.IsFormVisible("ModuleEnvironment"))
                {
                    // load level
                    if (Toolkit.IsKeyPressed(Properties.Settings.Default.environment_loadLevelKeyCode))
                        formModuleEnvironment.ImitateButtonClick("buttonLoadLevel");

                    // extract key and compare with ready table
                    int foreLoadTexturesExtracted = Properties.Settings.Default.environment_forceLoadAllTexturesKeyCode;
                    if (Toolkit.IsKeyPressed(foreLoadTexturesExtracted))
                    {
                        if (!keybardTableReady[foreLoadTexturesExtracted])
                        {
                            keybardTableReady[foreLoadTexturesExtracted] = true;
                            formModuleEnvironment.ImitateCheckboxClick("checkBoxForceLoadTextures");
                        }
                    }
                    else keybardTableReady[foreLoadTexturesExtracted] = false;

                    // load last checkpoint
                    if (Toolkit.IsKeyPressed(Properties.Settings.Default.environment_loadLastCheckpointKeyCode))
                    {
                        formModuleEnvironment.ImitateButtonClick("buttonLoadLastCheckpoint");
                    }
                }

                // check gamepad press
                if (gamepadTable.Sum() > 0)
                {
                    if (Toolkit.IsFormVisible("ModuleHero"))
                    {
                        if (Properties.Settings.Default.hero_snapshotKeyCode >= 1000 &&
                            gamepadTable[Properties.Settings.Default.hero_snapshotKeyCode - 1000] > 0)
                            formModuleHero.ImitateButtonClick("buttonSnapshot");

                        // load position snapshot with hotkey
                        else if (Properties.Settings.Default.hero_loadKeyCode >= 1000 &&
                            gamepadTable[Properties.Settings.Default.hero_loadKeyCode - 1000] > 0)
                            formModuleHero.ImitateButtonClick("buttonLoad");

                        // boost height position
                        else if (Properties.Settings.Default.hero_boostKeyCode >= 1000 &&
                            gamepadTable[Properties.Settings.Default.hero_boostKeyCode - 1000] > 0)
                            formModuleHero.ImitateButtonClick("buttonBoost");
                    }

                    // take position snapshot with hotkey
                    if (Toolkit.IsFormVisible("ModuleEnvironment"))
                    {
                        // load level
                        if (Properties.Settings.Default.environment_loadLevelKeyCode >= 1000 &&
                            gamepadTable[Properties.Settings.Default.environment_loadLevelKeyCode - 1000] > 0)
                            formModuleEnvironment.ImitateButtonClick("buttonLoadLevel");

                        // force load all textures
                        if (Properties.Settings.Default.environment_forceLoadAllTexturesKeyCode >= 1000 &&
                        gamepadTable[Properties.Settings.Default.environment_forceLoadAllTexturesKeyCode - 1000] > 0)
                        {
                            // check if one time click is ready
                            if (gamepadTableReady[Properties.Settings.Default.environment_forceLoadAllTexturesKeyCode - 1000] == 0)
                            {
                                formModuleEnvironment.ImitateCheckboxClick("checkBoxForceLoadTextures");
                                gamepadTableReady[Properties.Settings.Default.environment_forceLoadAllTexturesKeyCode - 1000] = 1;
                            }
                        }

                        // force load all textures
                        if (Properties.Settings.Default.environment_loadLastCheckpointKeyCode >= 1000 &&
                        gamepadTable[Properties.Settings.Default.environment_loadLastCheckpointKeyCode - 1000] > 0)
                        {
                            // check if one time click is ready
                            if (gamepadTableReady[Properties.Settings.Default.environment_loadLastCheckpointKeyCode - 1000] == 0)
                            {
                                formModuleEnvironment.ImitateButtonClick("buttonLoadLastCheckpoint");
                                gamepadTableReady[Properties.Settings.Default.environment_loadLastCheckpointKeyCode - 1000] = 1;
                            }
                        }
                    }
                }

                // sleep for performance
                Thread.Sleep(1);
            }
        }

        // check all controller buttons and see if one of them is pressed
        private void buttonStateThread_DoWork(object sender, DoWorkEventArgs e)
        {
            // gamepad object
            X.Gamepad gamepad = X.Gamepad_1;

            // infinite loop
            while (true)
            {
                // syncs with actions on the gamepad
                // for all signs check https://github.com/ru-mii/kangur/blob/main/gamepadSigns.png?raw=true
                if (gamepad.Update())
                {
                    // 0
                    if (gamepad.LTrigger_N != 0) gamepadTable[0] = 1;
                    else { gamepadTable[0] = 0; gamepadTableReady[0] = 0; }

                    // 1
                    if (gamepad.RTrigger_N != 0) gamepadTable[1] = 1;
                    else { gamepadTable[1] = 0; gamepadTableReady[1] = 0; }

                    // 2
                    if (gamepad.LBumper_down) gamepadTable[2] = 1;
                    else { gamepadTable[2] = 0; gamepadTableReady[2] = 0; }

                    // 3
                    if (gamepad.RBumper_down) gamepadTable[3] = 1;
                    else { gamepadTable[3] = 0; gamepadTableReady[3] = 0; }

                    // 4
                    if (gamepad.LStick_down) gamepadTable[4] = 1;
                    else { gamepadTable[4] = 0; gamepadTableReady[4] = 0; }

                    // 5
                    if (gamepad.RStick_down) gamepadTable[5] = 1;
                    else { gamepadTable[5] = 0; gamepadTableReady[5] = 0; }

                    // 6
                    if (gamepad.Back_down) gamepadTable[6] = 1;
                    else { gamepadTable[6] = 0; gamepadTableReady[6] = 0; }

                    // 7
                    if (gamepad.Start_down) gamepadTable[7] = 1;
                    else { gamepadTable[7] = 0; gamepadTableReady[7] = 0; }

                    // 8
                    if (gamepad.Dpad_Left_down) gamepadTable[8] = 1;
                    else { gamepadTable[8] = 0; gamepadTableReady[8] = 0; }

                    // 9
                    if (gamepad.Dpad_Up_down) gamepadTable[9] = 1;
                    else { gamepadTable[9] = 0; gamepadTableReady[9] = 0; }

                    // 10
                    if (gamepad.Dpad_Right_down) gamepadTable[10] = 1;
                    else { gamepadTable[10] = 0; gamepadTableReady[10] = 0; }

                    // 11
                    if (gamepad.Dpad_Down_down)
                    {
                        gamepadTable[11] = 1;
                    }
                    else { gamepadTable[11] = 0; gamepadTableReady[11] = 0; }

                    // 12
                    if (gamepad.X_down) gamepadTable[12] = 1;
                    else { gamepadTable[12] = 0; gamepadTableReady[12] = 0; }

                    // 13
                    if (gamepad.Y_down)
                    {
                        gamepadTable[13] = 1;
                    }
                    else { gamepadTable[13] = 0; gamepadTableReady[13] = 0; }

                    // 14
                    if (gamepad.B_down) gamepadTable[14] = 1;
                    else { gamepadTable[14] = 0; gamepadTableReady[14] = 0; }

                    // 15
                    if (gamepad.A_down) gamepadTable[15] = 1;
                    else { gamepadTable[15] = 0; gamepadTableReady[15] = 0; }
                }

                // sleep for performance
                Thread.Sleep(1);
            }
        }

        // check for new updates
        private void checkForUpdatesThread_DoWork(object sender, DoWorkEventArgs e)
        { Updates.CheckForUpdates(); }
    }
}
