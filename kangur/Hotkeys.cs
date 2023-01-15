using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kangur
{
    public partial class Hotkeys : Form
    {
        // initializing components, ignore
        public Hotkeys() { InitializeComponent(); }

        // changing selected module to default
        public static string selectedModule = "hero";

        // determines which + button was clicked on hotkeys form
        public static int clickedPadRow = 0;

        // gamepad form
        GamepadButtonSelect formGamepadButtonSelect = new GamepadButtonSelect();

        // runs on form load
        private void Hotkeys_Load(object sender, EventArgs e)
        {
            // select oob control for better visuals and functionality
            ntjbah.Select();

            // load saved keys
            key0.Text = Properties.Settings.Default.hero_snapshotKeyText;
            key1.Text = Properties.Settings.Default.hero_loadKeyText;
            key2.Text = Properties.Settings.Default.hero_boostKeyText;
        }

        // save pressed key to variable and display on form
        private void key1_KeyDown(object sender, KeyEventArgs e)
        {
            // write and save to settings
            if (selectedModule == "hero")
            {
                Properties.Settings.Default.hero_snapshotKeyText = e.KeyCode.ToString();
                Properties.Settings.Default.hero_snapshotKeyCode = e.KeyValue;
            }
            else if (selectedModule == "environment")
            {
                Properties.Settings.Default.environment_loadLevelText = e.KeyCode.ToString();
                Properties.Settings.Default.environment_loadLevelKeyCode = e.KeyValue;
            }

            // save changes
            Properties.Settings.Default.Save();

            // show pressed key in textbox
            key0.Text = e.KeyCode.ToString();
        }

        // save pressed key to variable and display on form
        private void key2_KeyDown(object sender, KeyEventArgs e)
        {
            // write and save to settings
            if (selectedModule == "hero")
            {
                // write and save to settings
                Properties.Settings.Default.hero_loadKeyText = e.KeyCode.ToString();
                Properties.Settings.Default.hero_loadKeyCode = e.KeyValue;
            }

            // write and save to settings
            else if (selectedModule == "environment")
            {
                Properties.Settings.Default.environment_forceLoadAllTexturesText = e.KeyCode.ToString();
                Properties.Settings.Default.environment_forceLoadAllTexturesKeyCode = e.KeyValue;
            }

            // save changes    
            Properties.Settings.Default.Save();

            // show pressed key in textbox
            key1.Text = e.KeyCode.ToString();
        }

        // save pressed key to variable and display on form
        private void key3_KeyDown(object sender, KeyEventArgs e)
        {
            // write and save to settings
            if (selectedModule == "hero")
            {
                // write and save to settings
                Properties.Settings.Default.hero_boostKeyText = e.KeyCode.ToString();
                Properties.Settings.Default.hero_boostKeyCode = e.KeyValue;
            }

            // write and save to settings
            else if (selectedModule == "environment")
            {
                Properties.Settings.Default.environment_loadLastCheckpointText = e.KeyCode.ToString();
                Properties.Settings.Default.environment_loadLastCheckpointKeyCode = e.KeyValue;
            }

            // save changes
            Properties.Settings.Default.Save();

            // show pressed key in textbox
            key2.Text = e.KeyCode.ToString();
        }

        // makes sure we're not closing form, only hiding
        private void Hotkeys_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        // clearing snapshot hotkey
        private void buttonClear1_Click(object sender, EventArgs e)
        {
            if (selectedModule == "hero")
            {
                Properties.Settings.Default.hero_snapshotKeyText = "";
                Properties.Settings.Default.hero_snapshotKeyCode = 0;
            }
            else if (selectedModule == "environment")
            {
                Properties.Settings.Default.environment_loadLevelText = "";
                Properties.Settings.Default.environment_loadLevelKeyCode = 0;
            }

            // save changes and clear text
            Properties.Settings.Default.Save();
            key0.Text = "";
        }

        // clearing load hotkey
        private void buttonClear2_Click(object sender, EventArgs e)
        {
            if (selectedModule == "hero")
            {
                Properties.Settings.Default.hero_loadKeyText = "";
                Properties.Settings.Default.hero_loadKeyCode = 0;
            }
            else if (selectedModule == "environment")
            {
                Properties.Settings.Default.environment_forceLoadAllTexturesText = "";
                Properties.Settings.Default.environment_forceLoadAllTexturesKeyCode = 0;
            }

            // save changes and clear text
            Properties.Settings.Default.Save();
            key1.Text = "";
        }

        // clearing boost hotkey
        private void buttonClear3_Click(object sender, EventArgs e)
        {
            if (selectedModule == "hero")
            {
                Properties.Settings.Default.hero_boostKeyText = "";
                Properties.Settings.Default.hero_boostKeyCode = 0;
            }
            else if (selectedModule == "environment")
            {
                Properties.Settings.Default.environment_loadLastCheckpointText = "";
                Properties.Settings.Default.environment_loadLastCheckpointKeyCode = 0;
            }

            // save changes and clear text
            Properties.Settings.Default.Save();
            key2.Text = "";
        }

        // select hero module
        private void buttonSelectHero_Click(object sender, EventArgs e)
        {
            // change selected module for code view
            selectedModule = "hero";

            // description
            text0.Text = "position snapshot";
            text1.Text = "load saved position";
            text2.Text = "boost height";

            // key text
            key0.Text = Properties.Settings.Default.hero_snapshotKeyText;
            key1.Text = Properties.Settings.Default.hero_loadKeyText;
            key2.Text = Properties.Settings.Default.hero_boostKeyText;

            // select oob control for better visuals and functionality
            ntjbah.Select();

            // change controls visibility, if we have
            // too many options for the module we just 
            // hide the hotkey columns that are not required
            key0.Visible = true;            key1.Visible = true;            key2.Visible = true;
            buttonClear0.Visible = true;    buttonClear1.Visible = true;    buttonClear2.Visible = true;
            pad0.Visible = true;            pad1.Visible = true;            pad2.Visible = true;

            // change buttons visuals
            SelectButtonVisually("buttonSelectHero");
        }

        // select environment module
        private void buttonSelectEnvironment_Click(object sender, EventArgs e)
        {
            // change selected module for code view
            selectedModule = "environment";

            // description
            text0.Text = "load level";
            text1.Text = "force-load all textures";
            text2.Text = "load last checkpoint";

            // key text
            key0.Text = Properties.Settings.Default.environment_loadLevelText;
            key1.Text = Properties.Settings.Default.environment_forceLoadAllTexturesText;
            key2.Text = Properties.Settings.Default.environment_loadLastCheckpointText;

            // select oob control for better visuals and functionality
            ntjbah.Select();

            // change controls visibility, if we have
            // too many options for the module we just 
            // hide the hotkey columns that are not required
            key0.Visible = true;            key1.Visible = true;            key2.Visible = true;
            buttonClear0.Visible = true;    buttonClear1.Visible = true;    buttonClear2.Visible = true;
            pad0.Visible = true;            pad1.Visible = true;            pad2.Visible = true;

            // change buttons visuals
            SelectButtonVisually("buttonSelectEnvironment");
        }

        // changes color of selected button and clears the rest
        private void SelectButtonVisually(string name)
        {
            // go through each buttons and reset their color to default
            // ignore the button we just clicked on
            foreach (var control in Controls.OfType<Button>())
            {
                if (control.Name != name)
                {
                    control.Enabled = true;
                    control.BackColor = Color.FromKnownColor(KnownColor.Control);
                    control.UseVisualStyleBackColor = true;
                }

                // make sure these are not clear buttons too
                else if (control.Text != "clear")
                {
                    control.Enabled = false;
                    control.BackColor = Color.SkyBlue;
                }
            }
        }

        // hotkey pad add button
        private void pad_Click(object sender, EventArgs e)
        {
            // getting clicked button name
            Button clicked = sender as Button;

            // removing pad from name and converting to int
            // assigning to static hotkey row value
            clickedPadRow = int.Parse(clicked.Name.Replace("pad", ""));

            // show gamepad form
            formGamepadButtonSelect.ShowDialog();
        }
    }
}
