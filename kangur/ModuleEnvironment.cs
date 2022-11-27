﻿using System;
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

        // unlocks all levels
        private void buttonUnlockAllLevels_Click(object sender, EventArgs e)
        { Main.module_environment_ACTION_unlock_all_levels = "TRUE"; }

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
    }
}