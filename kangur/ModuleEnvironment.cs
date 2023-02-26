using System;
using System.Windows.Forms;

namespace kangur
{
    public partial class ModuleEnvironment : Form
    {
        // initializing component, ignore
        public ModuleEnvironment()
        { InitializeComponent(); }

        // runs on form load
        private void ModuleEnvironment_Load(object sender, EventArgs e)
        { comboBoxLevelSelect.SelectedIndex = 0; }

        // loads selected level
        private void buttonLoadLevel_Click(object sender, EventArgs e)
        {
            // we add 1 because levels start from 1 in kao, not 0
            if (comboBoxLevelSelect.SelectedIndex != -1)
                Main.module_environment_ACTION_loadLevel = comboBoxLevelSelect.SelectedIndex + 1;
        }

        // unlocks all levels and disable button
        private void buttonUnlockAllLevels_Click(object sender, EventArgs e)
        {
            Main.module_environment_ACTION_unlock_all_levels = "TRUE";
            buttonUnlockAllLevels.Enabled = false;
        }

        // force load all textures
        private void checkBoxForceLoadTextures_CheckedChanged(object sender, EventArgs e)
        { Main.module_environment_ACTION_force_load_textures = checkBoxForceLoadTextures.Checked.ToString().ToUpper(); }

        // loads last checkpoint
        private void buttonLoadLastCheckpoint_Click(object sender, EventArgs e)
        { Main.module_environment_ACTION_load_last_checkpoint = "TRUE"; }

        // imitates button click, function for usage from another forms
        public void ImitateButtonClick(string name)
        {
            // go through all controls
            foreach (Control control in Controls)
            {
                // make sure we're looking at buttons
                if (control.GetType() == typeof(Button) && control.Name == name)
                {
                    // imitate 
                    Button tempButton = control as Button;
                    tempButton.PerformClick();
                }
            }
        }

        // imitates checkbox click, function for usage from another forms
        public void ImitateCheckboxClick(string name)
        {
            // go through all controls
            foreach (Control control in Controls)
            {
                // make sure we're looking at checkboxes
                if (control.GetType() == typeof(CheckBox) && control.Name == name)
                {
                    // imitate checkbox click
                    CheckBox tempCheckbox = control as CheckBox;
                    tempCheckbox.Checked = !tempCheckbox.Checked;
                }
            }
        }

        // makes sure we're not closing form, only hiding
        private void ModuleEnvironment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
