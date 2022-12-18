using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kangur.Properties;

namespace kangur
{
    public partial class ModuleHero : Form
    {
        // initializing component, ignore
        public ModuleHero() { InitializeComponent(); }

        // runs on form load
        private void ModuleHero_Load(object sender, EventArgs e)
        {  }

        // makes sure we're not closing form, only hiding
        private void ModuleHero_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        // assigning flags to specific functions
        private void checkBoxImmortality_CheckedChanged(object sender, EventArgs e)
        { Main.module_hero_ACTION_immortality = checkBoxImmortality.Checked.ToString().ToUpper(); }

        private void checkBoxUnlimitedBoomerangs_CheckedChanged(object sender, EventArgs e)
        { Main.module_hero_ACTION_unlimitedBoomerangs = checkBoxUnlimitedBoomerangs.Checked.ToString().ToUpper(); }

        private void buttonSnapshot_Click(object sender, EventArgs e)
        { Main.module_hero_ACTION_snapshot = "TRUE"; }

        private void buttonLoad_Click(object sender, EventArgs e)
        { Main.module_hero_ACTION_load = "TRUE"; }

        private void buttonBoost_Click(object sender, EventArgs e)
        { Main.module_hero_ACTION_boost = "TRUE"; }

        private void buttonStars_Click(object sender, EventArgs e)
        { Main.module_hero_ACTION_stars = "TRUE"; }

        // loads position to form between form classes
        public void loadPositionToForm(float rotX, float rotY, float posX, float posY, float posZ)
        {
            textBoxRotX.Text = rotX.ToString();
            textBoxRotY.Text = rotY.ToString();
            textBoxPosX.Text = posX.ToString();
            textBoxPosY.Text = posY.ToString();
            textBoxPosZ.Text = posZ.ToString();
        }

        // gets position from form between form classes
        public string[] getPositionFromForm ()
        {
            string[] vectors = new string[5];

            vectors[0] = textBoxRotX.Text;
            vectors[1] = textBoxRotY.Text;
            vectors[2] = textBoxPosX.Text;
            vectors[3] = textBoxPosY.Text;
            vectors[4] = textBoxPosZ.Text;

            return vectors;
        }

        // get numeric boost value
        public int getNumericBoost ()
        {  return (int)numericBoost.Value; }

        // get numeric stars value
        public int getNumericStars()
        { return (int)numericStars.Value; }

        // imitates button click, function for usage from another forms
        public void ImitateButtonClick (string name)
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
