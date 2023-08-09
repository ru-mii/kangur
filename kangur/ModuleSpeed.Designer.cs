
namespace kangur
{
    partial class ModuleSpeed
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_speedMain = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_MainSpeed = new System.ComponentModel.BackgroundWorker();
            this.label_maxSpeed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_toReach = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_lastReached = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_ready = new System.Windows.Forms.Button();
            this.checkBox_excludeHeight = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_stop = new System.Windows.Forms.Button();
            this.selector = new System.Windows.Forms.Label();
            this.button_resetMax = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_speedMain
            // 
            this.label_speedMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_speedMain.Location = new System.Drawing.Point(12, 12);
            this.label_speedMain.Name = "label_speedMain";
            this.label_speedMain.Size = new System.Drawing.Size(183, 36);
            this.label_speedMain.TabIndex = 0;
            this.label_speedMain.Text = "0.000m/s";
            this.label_speedMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // backgroundWorker_MainSpeed
            // 
            this.backgroundWorker_MainSpeed.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_MainSpeed_DoWork);
            // 
            // label_maxSpeed
            // 
            this.label_maxSpeed.AutoSize = true;
            this.label_maxSpeed.Location = new System.Drawing.Point(19, 44);
            this.label_maxSpeed.Name = "label_maxSpeed";
            this.label_maxSpeed.Size = new System.Drawing.Size(77, 13);
            this.label_maxSpeed.TabIndex = 1;
            this.label_maxSpeed.Text = "max: 0.000m/s";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "to reach distance";
            // 
            // textBox_toReach
            // 
            this.textBox_toReach.Location = new System.Drawing.Point(107, 140);
            this.textBox_toReach.Name = "textBox_toReach";
            this.textBox_toReach.Size = new System.Drawing.Size(67, 20);
            this.textBox_toReach.TabIndex = 4;
            this.textBox_toReach.Text = "30";
            this.textBox_toReach.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(-50, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(500, 2);
            this.label2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "last time reached in";
            // 
            // textBox_lastReached
            // 
            this.textBox_lastReached.Location = new System.Drawing.Point(116, 163);
            this.textBox_lastReached.Name = "textBox_lastReached";
            this.textBox_lastReached.Size = new System.Drawing.Size(67, 20);
            this.textBox_lastReached.TabIndex = 7;
            this.textBox_lastReached.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "seconds";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(180, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "m";
            // 
            // button_ready
            // 
            this.button_ready.Location = new System.Drawing.Point(12, 81);
            this.button_ready.Name = "button_ready";
            this.button_ready.Size = new System.Drawing.Size(303, 23);
            this.button_ready.TabIndex = 11;
            this.button_ready.Text = "ready";
            this.button_ready.UseVisualStyleBackColor = true;
            this.button_ready.Click += new System.EventHandler(this.button_ready_Click);
            // 
            // checkBox_excludeHeight
            // 
            this.checkBox_excludeHeight.AutoSize = true;
            this.checkBox_excludeHeight.Checked = true;
            this.checkBox_excludeHeight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_excludeHeight.Location = new System.Drawing.Point(220, 12);
            this.checkBox_excludeHeight.Name = "checkBox_excludeHeight";
            this.checkBox_excludeHeight.Size = new System.Drawing.Size(95, 17);
            this.checkBox_excludeHeight.TabIndex = 12;
            this.checkBox_excludeHeight.Text = "exclude height";
            this.checkBox_excludeHeight.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(14, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "timer will start on first position change";
            // 
            // button_stop
            // 
            this.button_stop.Enabled = false;
            this.button_stop.Location = new System.Drawing.Point(12, 109);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(303, 23);
            this.button_stop.TabIndex = 14;
            this.button_stop.Text = "stop current";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // selector
            // 
            this.selector.AutoSize = true;
            this.selector.Location = new System.Drawing.Point(32000, 32000);
            this.selector.Name = "selector";
            this.selector.Size = new System.Drawing.Size(0, 13);
            this.selector.TabIndex = 15;
            // 
            // button_resetMax
            // 
            this.button_resetMax.Location = new System.Drawing.Point(217, 34);
            this.button_resetMax.Name = "button_resetMax";
            this.button_resetMax.Size = new System.Drawing.Size(98, 23);
            this.button_resetMax.TabIndex = 16;
            this.button_resetMax.Text = "reset max speed";
            this.button_resetMax.UseVisualStyleBackColor = true;
            this.button_resetMax.Click += new System.EventHandler(this.button_resetMax_Click);
            // 
            // ModuleSpeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 212);
            this.Controls.Add(this.button_resetMax);
            this.Controls.Add(this.selector);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox_excludeHeight);
            this.Controls.Add(this.button_ready);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_lastReached);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_toReach);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_maxSpeed);
            this.Controls.Add(this.label_speedMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ModuleSpeed";
            this.Text = "speed";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModuleSpeed_FormClosing);
            this.Load += new System.EventHandler(this.ModuleSpeed_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_speedMain;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.ComponentModel.BackgroundWorker backgroundWorker_MainSpeed;
        private System.Windows.Forms.Label label_maxSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_toReach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_lastReached;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_ready;
        private System.Windows.Forms.CheckBox checkBox_excludeHeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Label selector;
        private System.Windows.Forms.Button button_resetMax;
    }
}