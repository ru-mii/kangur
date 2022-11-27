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
    public partial class GamepadButtonSelect : Form
    {
        // initializing component
        public GamepadButtonSelect()
        { InitializeComponent(); }

        // runs on form load
        private void GamepadButtonSelect_Load(object sender, EventArgs e) { }

        // all gamepad buttons and their index
        enum buttons
        {
            p_ltrigger = 0,
            p_rtrigger = 1,
            p_lbumper = 2,
            p_rbumper = 3,
            p_lstick = 4,
            p_rstick = 5,
            p_back = 6,
            p_start = 7,
            p_ldpad = 8,
            p_udpad = 9,
            p_rdpad = 10,
            p_ddpad = 11,
            p_x = 12,
            p_y = 13,
            p_b = 14,
            p_a = 15
        }

        // selcted buttons
        private void buttonSelect_Click(object sender, EventArgs e)
        {
            // get hotkey textbox
            TextBox keyText = Application.OpenForms["Hotkeys"].Controls["key" + Hotkeys.clickedPadRow] as TextBox;

            // get pressed button
            Button pressed = sender as Button;

            // get pressed button values
            int code = 1000 + int.Parse(pressed.Name.Replace("button", ""));
            string name = ((buttons)code - 1000).ToString();

            // hero module selected
            if (Hotkeys.selectedModule == "hero")
            {
                if (Hotkeys.clickedPadRow == 0)
                {
                    Properties.Settings.Default.hero_snapshotKeyCode = code;
                    Properties.Settings.Default.hero_snapshotKeyText = name;
                }

                else if (Hotkeys.clickedPadRow == 1)
                {
                    Properties.Settings.Default.hero_loadKeyCode = code;
                    Properties.Settings.Default.hero_loadKeyText = name;
                }

                else if (Hotkeys.clickedPadRow == 2)
                {
                    Properties.Settings.Default.hero_boostKeyCode = code;
                    Properties.Settings.Default.hero_boostKeyText = name;
                }
            }

            // environment module selected
            if (Hotkeys.selectedModule == "environment")
            {
                if (Hotkeys.clickedPadRow == 0)
                {
                    Properties.Settings.Default.environment_loadLevelKeyCode = code;
                    Properties.Settings.Default.environment_loadLevelText = name;
                }
            }

            // update textbox showing hotkey
            keyText.Text = name;

            // save changes and close form
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
