namespace kangur
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.labelProcessStatus = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.buttonModuleOpenSettingsHero = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.keyStateThread = new System.ComponentModel.BackgroundWorker();
            this.buttonHotkeys = new System.Windows.Forms.Button();
            this.rrcrxo = new System.Windows.Forms.Label();
            this.buttonModuleOpenSettingsEnvironment = new System.Windows.Forms.Button();
            this.buttonStateThread = new System.ComponentModel.BackgroundWorker();
            this.FormStyleBackChange = new System.ComponentModel.BackgroundWorker();
            this.checkForUpdatesThread = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // labelProcessStatus
            // 
            this.labelProcessStatus.BackColor = System.Drawing.SystemColors.Control;
            this.labelProcessStatus.ForeColor = System.Drawing.Color.Red;
            this.labelProcessStatus.Location = new System.Drawing.Point(15, 111);
            this.labelProcessStatus.Name = "labelProcessStatus";
            this.labelProcessStatus.Size = new System.Drawing.Size(210, 13);
            this.labelProcessStatus.TabIndex = 1;
            this.labelProcessStatus.Text = "waiting for kao2";
            this.labelProcessStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // buttonModuleOpenSettingsHero
            // 
            this.buttonModuleOpenSettingsHero.Location = new System.Drawing.Point(12, 12);
            this.buttonModuleOpenSettingsHero.Name = "buttonModuleOpenSettingsHero";
            this.buttonModuleOpenSettingsHero.Size = new System.Drawing.Size(213, 23);
            this.buttonModuleOpenSettingsHero.TabIndex = 3;
            this.buttonModuleOpenSettingsHero.Text = "hero";
            this.buttonModuleOpenSettingsHero.UseVisualStyleBackColor = true;
            this.buttonModuleOpenSettingsHero.Click += new System.EventHandler(this.buttonModuleOpenSettingsHero_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(18, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 2);
            this.label1.TabIndex = 4;
            // 
            // keyStateThread
            // 
            this.keyStateThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.keyStateThread_DoWork);
            // 
            // buttonHotkeys
            // 
            this.buttonHotkeys.Location = new System.Drawing.Point(12, 70);
            this.buttonHotkeys.Name = "buttonHotkeys";
            this.buttonHotkeys.Size = new System.Drawing.Size(213, 23);
            this.buttonHotkeys.TabIndex = 6;
            this.buttonHotkeys.Text = "hotkeys";
            this.buttonHotkeys.UseVisualStyleBackColor = true;
            this.buttonHotkeys.Click += new System.EventHandler(this.buttonHotkeys_Click);
            // 
            // rrcrxo
            // 
            this.rrcrxo.AutoSize = true;
            this.rrcrxo.Location = new System.Drawing.Point(32000, 86);
            this.rrcrxo.Name = "rrcrxo";
            this.rrcrxo.Size = new System.Drawing.Size(0, 13);
            this.rrcrxo.TabIndex = 7;
            // 
            // buttonModuleOpenSettingsEnvironment
            // 
            this.buttonModuleOpenSettingsEnvironment.Location = new System.Drawing.Point(12, 41);
            this.buttonModuleOpenSettingsEnvironment.Name = "buttonModuleOpenSettingsEnvironment";
            this.buttonModuleOpenSettingsEnvironment.Size = new System.Drawing.Size(213, 23);
            this.buttonModuleOpenSettingsEnvironment.TabIndex = 8;
            this.buttonModuleOpenSettingsEnvironment.Text = "environment";
            this.buttonModuleOpenSettingsEnvironment.UseVisualStyleBackColor = true;
            this.buttonModuleOpenSettingsEnvironment.Click += new System.EventHandler(this.buttonModuleOpenSettingsEnvironment_Click);
            // 
            // buttonStateThread
            // 
            this.buttonStateThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.buttonStateThread_DoWork);
            // 
            // checkForUpdatesThread
            // 
            this.checkForUpdatesThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.checkForUpdatesThread_DoWork);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 132);
            this.Controls.Add(this.buttonModuleOpenSettingsEnvironment);
            this.Controls.Add(this.rrcrxo);
            this.Controls.Add(this.buttonHotkeys);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonModuleOpenSettingsHero);
            this.Controls.Add(this.labelProcessStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "kangur";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelProcessStatus;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button buttonModuleOpenSettingsHero;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker keyStateThread;
        private System.Windows.Forms.Button buttonHotkeys;
        private System.Windows.Forms.Label rrcrxo;
        private System.Windows.Forms.Button buttonModuleOpenSettingsEnvironment;
        private System.ComponentModel.BackgroundWorker buttonStateThread;
        private System.ComponentModel.BackgroundWorker FormStyleBackChange;
        private System.ComponentModel.BackgroundWorker checkForUpdatesThread;
    }
}

