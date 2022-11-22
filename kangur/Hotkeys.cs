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

        // runs on form load
        private void Hotkeys_Load(object sender, EventArgs e)
        {
            // select oob control for better visuals and functionality
            ntjbah.Select();

            // load saved keys
            heroSnapshotKey.Text = Properties.Settings.Default.hero_snapshotKeyText;
            heroLoadKey.Text = Properties.Settings.Default.hero_loadKeyText;
            heroBoostKey.Text = Properties.Settings.Default.hero_boostKeyText;
        }

        // save pressed key to variable and display on form
        private void snapshotKey_KeyDown(object sender, KeyEventArgs e)
        {
            // write and save to settings
            Properties.Settings.Default.hero_snapshotKeyText = e.KeyCode.ToString();
            Properties.Settings.Default.hero_snapshotKeyCode = e.KeyValue;
            Properties.Settings.Default.Save();

            // show pressed key in textbox
            heroSnapshotKey.Text = e.KeyCode.ToString();
        }

        // save pressed key to variable and display on form
        private void loadPositionKey_KeyDown(object sender, KeyEventArgs e)
        {
            // write and save to settings
            Properties.Settings.Default.hero_loadKeyText = e.KeyCode.ToString();
            Properties.Settings.Default.hero_loadKeyCode = e.KeyValue;
            Properties.Settings.Default.Save();

            // show pressed key in textbox
            heroLoadKey.Text = e.KeyCode.ToString();
        }

        // save pressed key to variable and display on form
        private void heroBoostKey_KeyDown(object sender, KeyEventArgs e)
        {
            // write and save to settings
            Properties.Settings.Default.hero_boostKeyText = e.KeyCode.ToString();
            Properties.Settings.Default.hero_boostKeyCode = e.KeyValue;
            Properties.Settings.Default.Save();

            // show pressed key in textbox
            heroBoostKey.Text = e.KeyCode.ToString();
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
        private void buttonHeroSnapshotClear_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.hero_snapshotKeyText = "";
            Properties.Settings.Default.hero_snapshotKeyCode = 0;
            Properties.Settings.Default.Save();
            heroSnapshotKey.Text = "";
        }

        // clearing load hotkey
        private void buttonHeroLoadClear_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.hero_loadKeyText = "";
            Properties.Settings.Default.hero_loadKeyCode = 0;
            Properties.Settings.Default.Save();
            heroLoadKey.Text = "";
        }

        // clearing boost hotkey
        private void buttonHeroBoostClear_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.hero_boostKeyText = "";
            Properties.Settings.Default.hero_boostKeyCode = 0;
            Properties.Settings.Default.Save();
            heroBoostKey.Text = "";
        }
    }
}
