using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kangur
{
    public partial class Main : Form
    {
        // build version, adding new line because github adds it to their file
        // and the version is being compared with one written in github file in repo
        public static string softwareVersion = "1\n";

        // start time of a process, helps detecting
        // if the game reopened and we need to patch again
        public static string processSession = "";
        public static string lastProcessSession = "";

        // all module static related variables
        // will start with "module" and its name
        public static string module_Hero_ACTION_immortality = "";
        public static string module_Hero_ACTION_unlimitedBoomerangs = "";
        public static string module_Hero_ACTION_snapshot = "";
        public static string module_hero_ACTION_load = "";
        public static string module_hero_ACTION_boost = "";

        // allocating forms
        ModuleHero formModuleHero = new ModuleHero();
        Hotkeys formHotkeys = new Hotkeys();

        // global game process
        public static Process mainGameProcess = new Process();
        public static uint moduleAddress = 0;

        // initiate main object for functions
        Toolkit toolkit = new Toolkit();

        // initializing component, ignore
        public Main() { InitializeComponent(); }

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

            // check for new updates
            Updates.CheckForUpdates();

            // start background thread
            backgroundWorker.RunWorkerAsync();

            // might be required later
            KeyPreview = true;

            // hotkey thread checker
            keyStateThread.RunWorkerAsync();
        }

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

                //  alert for new session and assign
                // new to last after operation
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
                    }
                    // new session but no process open
                    // meaning game was open and you closed it
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
                    if (module_Hero_ACTION_immortality != "")
                    {
                        // change memory section protection
                        toolkit.DisableMemoryProtection(moduleAddress + 0xF8B88, 3);

                        // old instruction moves your new damaged hp to the pointer
                        // new instruction doesn't move your hp subtracted by damage
                        byte[] oldInstr = { 0x89, 0x46, 0x1C }; // mov [esi+1C],eax
                        byte[] newInstr = { 0x90, 0x90, 0x90 }; // nop nop nop

                        // patch instructions
                        if (module_Hero_ACTION_immortality == "TRUE") toolkit.WriteMemory(moduleAddress + 0xF8B88, newInstr);
                        else toolkit.WriteMemory(moduleAddress + 0xF8B88, oldInstr); // FALSE

                        // reset action variable
                        module_Hero_ACTION_immortality = "";
                    }

                    // you can use boomerangs limitlessly
                    else if (module_Hero_ACTION_unlimitedBoomerangs != "")
                    {
                        // change memory section protection
                        toolkit.DisableMemoryProtection(moduleAddress + 0xF88AB, 4);
                        toolkit.DisableMemoryProtection(moduleAddress + 0xFAF38, 3);

                        // old instruction checks if you don't have enough boomerangs to throw
                        // new instructions changes compared number to -70 so the flag never occurs
                        byte[] oldInstr1 = { 0x83, 0x7F, 0x4C, 0x00 }; // cmp dword ptr [edi+4c],00
                        byte[] newInstr1 = { 0x83, 0x7F, 0x4C, 0x90 }; //cmp dword ptr [edi+4c],-70

                        // old instruction takes 1 boomerang when you throw
                        // new instruction doesn't take anything when you throw
                        byte[] oldInstr2 = { 0x01, 0x6E, 0x4C };
                        byte[] newInstr2 = { 0x90, 0x90, 0x90 };

                        // patch instructions
                        if (module_Hero_ACTION_unlimitedBoomerangs == "TRUE")
                        {
                            toolkit.WriteMemory(moduleAddress + 0xF88AB, newInstr1);
                            toolkit.WriteMemory(moduleAddress + 0xFAF38, newInstr2);
                        }
                        else // FALSE
                        {
                            toolkit.WriteMemory(moduleAddress + 0xF88AB, oldInstr1);
                            toolkit.WriteMemory(moduleAddress + 0xFAF38, oldInstr2);
                        }

                        // reset action variable
                        module_Hero_ACTION_unlimitedBoomerangs = "";
                    }

                    // take position snapshot
                    else if (module_Hero_ACTION_snapshot != "")
                    {
                        // get required pointer
                        uint gameletPointer = toolkit.ReadMemory32(moduleAddress + 0x73D868);
                        uint heroPointer = toolkit.ReadMemory32(gameletPointer + 0x38C);

                        // read position address
                        float rotX = toolkit.ReadMemoryFloat(heroPointer + 0x50);
                        float rotY = toolkit.ReadMemoryFloat(heroPointer + 0x54);
                        float posX = toolkit.ReadMemoryFloat(heroPointer + 0x58);
                        float posY = toolkit.ReadMemoryFloat(heroPointer + 0x5C);
                        float posZ = toolkit.ReadMemoryFloat(heroPointer + 0x60);

                        // load values to hero module form
                        formModuleHero.loadPositionToForm(rotX, rotY, posX, posY, posZ);

                        // reset action variable
                        module_Hero_ACTION_snapshot = "";
                    }

                    // load new position
                    else if (module_hero_ACTION_load != "")
                    {
                        // get required pointer
                        uint gameletPointer = toolkit.ReadMemory32(moduleAddress + 0x73D868);
                        uint positionPointer = toolkit.ReadMemory32(gameletPointer + 0x38C) + 0x50;

                        // get positions from form
                        string[] rawStringValues = formModuleHero.getPositionFromForm();

                        // go through each text and replace coma for culture
                        for (int i = 0; i < rawStringValues.Length; i++)
                            rawStringValues[i] = rawStringValues[i].Replace(',', '.');

                        // try parse each value first and throw error if there's one
                        bool parseFailed = false;
                        foreach (string raw in rawStringValues)
                            if (!float.TryParse(raw, NumberStyles.Any, CultureInfo.InvariantCulture, out float zero))
                                parseFailed = true;

                        // make sure position values are correct
                        if (!parseFailed)
                        {
                            // convert to byte array for faster writings and single execution style
                            byte[] rotX = BitConverter.GetBytes(float.Parse(rawStringValues[0], CultureInfo.InvariantCulture.NumberFormat));
                            byte[] rotY = BitConverter.GetBytes(float.Parse(rawStringValues[1], CultureInfo.InvariantCulture.NumberFormat));
                            byte[] posX = BitConverter.GetBytes(float.Parse(rawStringValues[2], CultureInfo.InvariantCulture.NumberFormat));
                            byte[] posY = BitConverter.GetBytes(float.Parse(rawStringValues[3], CultureInfo.InvariantCulture.NumberFormat));
                            byte[] posZ = BitConverter.GetBytes(float.Parse(rawStringValues[4], CultureInfo.InvariantCulture.NumberFormat));

                            // merge byte arrays
                            byte[] fullByteTable = toolkit.MergeByteArrays(rotX, rotY, posX, posY, posZ);

                            // write full vector5 position as byte arary
                            toolkit.WriteMemory(positionPointer, fullByteTable);

                            // reset action variable
                            module_hero_ACTION_load = "";
                        }
                        else ShowError("one of the position values is not in correct format");
                    }

                    // boosts vertical position by a number
                    else if (module_hero_ACTION_boost != "")
                    {
                        // get required pointer
                        uint gameletPointer = toolkit.ReadMemory32(moduleAddress + 0x73D868);
                        uint positionPointer = toolkit.ReadMemory32(gameletPointer + 0x38C) + 0x50;

                        // read current height and increase by chosen number
                        float newHeroHeight = toolkit.ReadMemoryFloat(positionPointer + 0x10) + formModuleHero.getNumericBoost();

                        // write new height position into memory
                        toolkit.WriteMemory(positionPointer + 0x10, BitConverter.GetBytes(newHeroHeight));

                        // reset action variable
                        module_hero_ACTION_boost = "";

                    }
                    #endregion // ends region
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
        {
            // check if window is not already open
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
                if (!toolkit.IsFormOpen("ModuleHero")) formModuleHero.Show();
                else if (!formModuleHero.Visible) formModuleHero.Show();
            }
            else ShowError("kao2 needs to be open");
        }

        // open hotkeys form
        private void buttonHotkeys_Click(object sender, EventArgs e)
        {
            if (!toolkit.IsFormOpen("Hotkeys")) formHotkeys.Show();
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
                // take position snapshot with hotkey
                if (toolkit.IsKeyPressed(Properties.Settings.Default.hero_snapshotKeyCode) &&
                toolkit.IsFormOpen("ModuleHero")) formModuleHero.imitateButtonClick("buttonSnapshot");

                // load position snapshot with hotkey
                else if (toolkit.IsKeyPressed(Properties.Settings.Default.hero_loadKeyCode) &&
                toolkit.IsFormOpen("ModuleHero")) formModuleHero.imitateButtonClick("buttonLoad");

                // boost height position
                else if (toolkit.IsKeyPressed(Properties.Settings.Default.hero_boostKeyCode) &&
                toolkit.IsFormOpen("ModuleHero")) formModuleHero.imitateButtonClick("buttonBoost");

                // sleep for performance
                Thread.Sleep(1);
            }
        }

        // show custom message box with warning or error icon
        public static void ShowError(string message) { MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        public static void ShowInfo(string message) { MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); }
    }
}
