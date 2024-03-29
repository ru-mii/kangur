﻿namespace kangur
{
    partial class ModuleEnvironment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuleEnvironment));
            this.comboBoxLevelSelect = new System.Windows.Forms.ComboBox();
            this.buttonLoadLevel = new System.Windows.Forms.Button();
            this.buttonUnlockAllLevels = new System.Windows.Forms.Button();
            this.checkBoxForceLoadTextures = new System.Windows.Forms.CheckBox();
            this.buttonLoadLastCheckpoint = new System.Windows.Forms.Button();
            this.checkBoxDisableCheckpointHitbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // comboBoxLevelSelect
            // 
            this.comboBoxLevelSelect.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxLevelSelect.FormattingEnabled = true;
            this.comboBoxLevelSelect.Items.AddRange(new object[] {
            "The Ship",
            "Dark Docks",
            "Beavers\' Forest",
            "The Great Escape",
            "Great Trees",
            "River Raid",
            "Shaman\'s Cave",
            "Igloo Village",
            "Ice Cave",
            "Down The Mountain",
            "Crystal Mines",
            "The Station",
            "The Race",
            "Hostile Reef",
            "Deep Ocean",
            "Lair of Poison",
            "Trip to Island",
            "Treasure Island",
            "The Volcano",
            "Pirate\'s Bay",
            "Abandoned Town",
            "Hunter\'s Galleon",
            "Final Duel",
            "Bonus: Rope",
            "Bonus: Trees",
            "Bonus: Shooting",
            "Bonus: Baseball",
            "Bonus: Race"});
            this.comboBoxLevelSelect.Location = new System.Drawing.Point(12, 12);
            this.comboBoxLevelSelect.Name = "comboBoxLevelSelect";
            this.comboBoxLevelSelect.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLevelSelect.TabIndex = 0;
            // 
            // buttonLoadLevel
            // 
            this.buttonLoadLevel.Location = new System.Drawing.Point(139, 10);
            this.buttonLoadLevel.Name = "buttonLoadLevel";
            this.buttonLoadLevel.Size = new System.Drawing.Size(106, 23);
            this.buttonLoadLevel.TabIndex = 1;
            this.buttonLoadLevel.Text = "load level";
            this.buttonLoadLevel.UseVisualStyleBackColor = true;
            this.buttonLoadLevel.Click += new System.EventHandler(this.buttonLoadLevel_Click);
            // 
            // buttonUnlockAllLevels
            // 
            this.buttonUnlockAllLevels.Location = new System.Drawing.Point(12, 39);
            this.buttonUnlockAllLevels.Name = "buttonUnlockAllLevels";
            this.buttonUnlockAllLevels.Size = new System.Drawing.Size(233, 23);
            this.buttonUnlockAllLevels.TabIndex = 2;
            this.buttonUnlockAllLevels.Text = "unlock all levels";
            this.buttonUnlockAllLevels.UseVisualStyleBackColor = true;
            this.buttonUnlockAllLevels.Click += new System.EventHandler(this.buttonUnlockAllLevels_Click);
            // 
            // checkBoxForceLoadTextures
            // 
            this.checkBoxForceLoadTextures.AutoSize = true;
            this.checkBoxForceLoadTextures.Location = new System.Drawing.Point(12, 97);
            this.checkBoxForceLoadTextures.Name = "checkBoxForceLoadTextures";
            this.checkBoxForceLoadTextures.Size = new System.Drawing.Size(126, 17);
            this.checkBoxForceLoadTextures.TabIndex = 3;
            this.checkBoxForceLoadTextures.Text = "force-load all textures";
            this.checkBoxForceLoadTextures.UseVisualStyleBackColor = true;
            this.checkBoxForceLoadTextures.CheckedChanged += new System.EventHandler(this.checkBoxForceLoadTextures_CheckedChanged);
            // 
            // buttonLoadLastCheckpoint
            // 
            this.buttonLoadLastCheckpoint.Location = new System.Drawing.Point(12, 68);
            this.buttonLoadLastCheckpoint.Name = "buttonLoadLastCheckpoint";
            this.buttonLoadLastCheckpoint.Size = new System.Drawing.Size(233, 23);
            this.buttonLoadLastCheckpoint.TabIndex = 4;
            this.buttonLoadLastCheckpoint.Text = "load last checkpoint";
            this.buttonLoadLastCheckpoint.UseVisualStyleBackColor = true;
            this.buttonLoadLastCheckpoint.Click += new System.EventHandler(this.buttonLoadLastCheckpoint_Click);
            // 
            // checkBoxDisableCheckpointHitbox
            // 
            this.checkBoxDisableCheckpointHitbox.AutoSize = true;
            this.checkBoxDisableCheckpointHitbox.Location = new System.Drawing.Point(12, 119);
            this.checkBoxDisableCheckpointHitbox.Name = "checkBoxDisableCheckpointHitbox";
            this.checkBoxDisableCheckpointHitbox.Size = new System.Drawing.Size(146, 17);
            this.checkBoxDisableCheckpointHitbox.TabIndex = 5;
            this.checkBoxDisableCheckpointHitbox.Text = "disable checkpoint hitbox";
            this.checkBoxDisableCheckpointHitbox.UseVisualStyleBackColor = true;
            this.checkBoxDisableCheckpointHitbox.CheckedChanged += new System.EventHandler(this.checkBoxDisableCheckpointHitbox_CheckedChanged);
            // 
            // ModuleEnvironment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 144);
            this.Controls.Add(this.checkBoxDisableCheckpointHitbox);
            this.Controls.Add(this.buttonLoadLastCheckpoint);
            this.Controls.Add(this.checkBoxForceLoadTextures);
            this.Controls.Add(this.buttonUnlockAllLevels);
            this.Controls.Add(this.buttonLoadLevel);
            this.Controls.Add(this.comboBoxLevelSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ModuleEnvironment";
            this.Text = "environment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModuleEnvironment_FormClosing);
            this.Load += new System.EventHandler(this.ModuleEnvironment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxLevelSelect;
        private System.Windows.Forms.Button buttonLoadLevel;
        private System.Windows.Forms.Button buttonUnlockAllLevels;
        private System.Windows.Forms.CheckBox checkBoxForceLoadTextures;
        private System.Windows.Forms.Button buttonLoadLastCheckpoint;
        private System.Windows.Forms.CheckBox checkBoxDisableCheckpointHitbox;
    }
}