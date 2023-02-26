using System;
using System.Numerics;
using System.Windows.Forms;

namespace kangur
{
    public partial class ModuleHero : Form
    {
        private TextBox[] _transformTextBoxes;

        // initializing component, ignore
        public ModuleHero()
        {
            InitializeComponent();

            _transformTextBoxes = new TextBox[]
            {
                textBoxRotX,
                textBoxRotY,
                textBoxPosX,
                textBoxPosY,
                textBoxPosZ
            };
        }

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

        private void buttonSnapshot_Click(object sender, EventArgs e) => Main.MainWindow.Hero.SaveHeroTransformToMemory();

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            var playerPos = Main.MainWindow.Hero.HeroPosition;
            var playerRot = Main.MainWindow.Hero.HeroRotation;

            LoadPositionToForm(playerRot.X, playerRot.Y, playerPos.X, playerPos.Y, playerPos.Z);
        }

        private void buttonBoost_Click(object sender, EventArgs e)
        { Main.module_hero_ACTION_boost = "TRUE"; }

        private void buttonStars_Click(object sender, EventArgs e)
        { Main.module_hero_ACTION_stars = "TRUE"; }

        // loads position to form between form classes
        public void LoadPositionToForm(float rotX, float rotY, float posX, float posY, float posZ)
        {
            textBoxRotX.Text = rotX.ToString();
            textBoxRotY.Text = rotY.ToString();
            textBoxPosX.Text = posX.ToString();
            textBoxPosY.Text = posY.ToString();
            textBoxPosZ.Text = posZ.ToString();
        }

        // gets position from form between form classes
        public string[] GetPositionFromForm ()
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
        public int GetNumericBoost ()
        {  return (int)numericBoost.Value; }

        // get numeric stars value
        public int GetNumericStars()
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

        private bool TryParseTextBoxes()
        {
            foreach (TextBox textBox in _transformTextBoxes)
            {
                if(string.IsNullOrEmpty(textBox.Text)) return false;

                try
                {
                    float.TryParse(textBox.Text, out _);
                }
                catch (Exception e)
                { 
                    Toolkit.ShowError(e.ToString());
                    return false;
                }
            }

            return true;
        }

        private void TransformTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!TryParseTextBoxes()) return;

            var heroPos = new Vector3(float.Parse(textBoxPosX.Text), float.Parse(textBoxPosY.Text), float.Parse(textBoxPosZ.Text));
            var heroRot = new Vector2(float.Parse(textBoxRotX.Text), float.Parse(textBoxRotY.Text));

            Main.MainWindow.Hero.HeroPosition = heroPos;
            Main.MainWindow.Hero.HeroRotation = heroRot;

            Main.MainWindow.Hero.SaveHeroTransformToMemory();
        }

        private void TransformTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
