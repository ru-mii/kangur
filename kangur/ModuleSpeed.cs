using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kangur
{
    public partial class ModuleSpeed : Form
    {
        bool timerOn = false;

        long startTime = 0;
        long finalTime = 0;

        Vector3 startPosition = null;
        Vector3 lastPosition = null;
        double lastDistance;
        double finalDistance;

        float maxSpeed = 0;
        float toReach = 0;

        long lastCalculateSpeedTime = 0;

        // initiate main object for functions
        Toolkit toolkit = new Toolkit();

        // initializing component, ignore
        public ModuleSpeed()
        { InitializeComponent(); }

        private void ModuleSpeed_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void ModuleSpeed_Load(object sender, EventArgs e)
        {
            selector.Select();
            backgroundWorker.RunWorkerAsync();
            backgroundWorker_MainSpeed.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (button_ready.Enabled == false)
                {
                    // get required pointer
                    uint gameletPointer = toolkit.ReadMemoryInt32(Main.moduleAddress + 0x73D868);
                    uint heroPointer = toolkit.ReadMemoryInt32(gameletPointer + 0x38C);

                    // read position address
                    Vector3 currentPosition3D = new Vector3();
                    Vector2 currentPosition2D = new Vector2();
                    currentPosition3D.X = toolkit.ReadMemoryFloat(heroPointer + 0x58);
                    currentPosition3D.Y = toolkit.ReadMemoryFloat(heroPointer + 0x5C);
                    currentPosition3D.Z = toolkit.ReadMemoryFloat(heroPointer + 0x60);
                    currentPosition2D.X = currentPosition3D.X;
                    currentPosition2D.Y = currentPosition3D.Y;

                    if (currentPosition3D != startPosition && startTime == 0)
                        startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();

                    if (checkBox_excludeHeight.Checked)
                    {
                        if (CalculateDistance(new Vector2(startPosition.X, startPosition.Y), currentPosition2D) > toReach * 50f)
                        {
                            float final = (DateTimeOffset.Now.ToUnixTimeMilliseconds() - startTime) / 1000f;
                            textBox_lastReached.Text = final.ToString("F3", CultureInfo.InvariantCulture);
                            button_ready.Enabled = true;
                            button_stop.Enabled = false;
                            startTime = 0;
                        }
                    }
                    else
                    {
                        if (CalculateDistance(startPosition, currentPosition3D) > toReach * 50f)
                        {
                            float final = (DateTimeOffset.Now.ToUnixTimeMilliseconds() - startTime) / 1000f;
                            textBox_lastReached.Text = final.ToString("F3", CultureInfo.InvariantCulture);
                            button_ready.Enabled = true;
                            button_stop.Enabled = false;
                            startTime = 0;
                        }
                    }
                }

                Thread.Sleep(1);
            }
        }

        private void backgroundWorker_MainSpeed_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                long currentMilliseconds = DateTimeOffset.Now.ToUnixTimeMilliseconds();

                if (currentMilliseconds > lastCalculateSpeedTime + 500)
                {
                    // get required pointer
                    uint gameletPointer = toolkit.ReadMemoryInt32(Main.moduleAddress + 0x73D868);
                    uint heroPointer = toolkit.ReadMemoryInt32(gameletPointer + 0x38C);

                    // read position address
                    Vector3 currentPosition3D = new Vector3();
                    Vector2 currentPosition2D = new Vector2();
                    currentPosition3D.X = toolkit.ReadMemoryFloat(heroPointer + 0x58);
                    currentPosition3D.Y = toolkit.ReadMemoryFloat(heroPointer + 0x5C);
                    currentPosition3D.Z = toolkit.ReadMemoryFloat(heroPointer + 0x60);
                    currentPosition2D.X = currentPosition3D.X;
                    currentPosition2D.Y = currentPosition3D.Y;

                    if (lastPosition == null) lastPosition = currentPosition3D;
                    else
                    {
                        float currentSpeed = 0;

                        if (!checkBox_excludeHeight.Checked) currentSpeed = CalculateDistance(lastPosition, currentPosition3D) / 50f;
                        else currentSpeed = CalculateDistance(new Vector2(lastPosition.X, lastPosition.Y), currentPosition2D) / 50f;

                        if (currentSpeed > maxSpeed) maxSpeed = currentSpeed;

                        label_speedMain.Text = currentSpeed.ToString("F3", CultureInfo.InvariantCulture) + "m/s";
                        label_maxSpeed.Text = "max: " + maxSpeed.ToString("F3", CultureInfo.InvariantCulture) + "m/s";

                        lastPosition = currentPosition3D;
                    }

                    lastCalculateSpeedTime = currentMilliseconds;
                }

                Thread.Sleep(1);
            }
        }

        public float CalculateDistance(Vector2 v1, Vector2 v2)
        {
            float dx = v2.X - v1.X;
            float dy = v2.Y - v1.Y;

            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        public float CalculateDistance(Vector3 v1, Vector3 v2)
        {
            float dx = v2.X - v1.X;
            float dy = v2.Y - v1.Y;
            float dz = v2.Z - v1.Z;

            return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        private void button_ready_Click(object sender, EventArgs e)
        {
            float toReachTemp = 0;
            if (float.TryParse(textBox_toReach.Text, out toReachTemp))
            {
                toReach = toReachTemp;
                startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();

                // get required pointer
                uint gameletPointer = toolkit.ReadMemoryInt32(Main.moduleAddress + 0x73D868);
                uint heroPointer = toolkit.ReadMemoryInt32(gameletPointer + 0x38C);

                // read position address
                Vector3 currentPosition3D = new Vector3();
                Vector3 currentPosition2D = new Vector3();
                currentPosition3D.X = toolkit.ReadMemoryFloat(heroPointer + 0x58);
                currentPosition3D.Y = toolkit.ReadMemoryFloat(heroPointer + 0x5C);
                currentPosition3D.Z = toolkit.ReadMemoryFloat(heroPointer + 0x60);
                currentPosition2D.X = currentPosition3D.X;
                currentPosition2D.Y = currentPosition3D.Y;

                startPosition = currentPosition3D;
                button_ready.Enabled = false;
                button_stop.Enabled = true;
            }
            else Main.ShowError("reach distance is either empty or incorrect");
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            button_ready.Enabled = true;
            button_stop.Enabled = false;
            startTime = 0;
        }

        private void button_resetMax_Click(object sender, EventArgs e)
        {
            maxSpeed = 0;
            label_maxSpeed.Text = "max: 0.000m/s";
        }
    }
}
