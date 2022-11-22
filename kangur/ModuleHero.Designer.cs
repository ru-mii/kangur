﻿namespace kangur
{
    partial class ModuleHero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuleHero));
            this.checkBoxImmortality = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRotX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxRotY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPosX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPosY = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPosZ = new System.Windows.Forms.TextBox();
            this.buttonSnapshot = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.checkBoxUnlimitedBoomerangs = new System.Windows.Forms.CheckBox();
            this.buttonBoost = new System.Windows.Forms.Button();
            this.numericBoost = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericBoost)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxImmortality
            // 
            this.checkBoxImmortality.AutoSize = true;
            this.checkBoxImmortality.Location = new System.Drawing.Point(18, 193);
            this.checkBoxImmortality.Name = "checkBoxImmortality";
            this.checkBoxImmortality.Size = new System.Drawing.Size(74, 17);
            this.checkBoxImmortality.TabIndex = 0;
            this.checkBoxImmortality.Text = "immortality";
            this.checkBoxImmortality.UseVisualStyleBackColor = true;
            this.checkBoxImmortality.CheckedChanged += new System.EventHandler(this.checkBoxImmortality_CheckedChanged);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(-20, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 2);
            this.label1.TabIndex = 5;
            // 
            // textBoxRotX
            // 
            this.textBoxRotX.Location = new System.Drawing.Point(63, 12);
            this.textBoxRotX.Name = "textBoxRotX";
            this.textBoxRotX.Size = new System.Drawing.Size(84, 20);
            this.textBoxRotX.TabIndex = 6;
            this.textBoxRotX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "rot_x";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "rot_y";
            // 
            // textBoxRotY
            // 
            this.textBoxRotY.Location = new System.Drawing.Point(63, 38);
            this.textBoxRotY.Name = "textBoxRotY";
            this.textBoxRotY.Size = new System.Drawing.Size(84, 20);
            this.textBoxRotY.TabIndex = 8;
            this.textBoxRotY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "pos_x";
            // 
            // textBoxPosX
            // 
            this.textBoxPosX.Location = new System.Drawing.Point(63, 64);
            this.textBoxPosX.Name = "textBoxPosX";
            this.textBoxPosX.Size = new System.Drawing.Size(84, 20);
            this.textBoxPosX.TabIndex = 10;
            this.textBoxPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "pos_y";
            // 
            // textBoxPosY
            // 
            this.textBoxPosY.Location = new System.Drawing.Point(63, 90);
            this.textBoxPosY.Name = "textBoxPosY";
            this.textBoxPosY.Size = new System.Drawing.Size(84, 20);
            this.textBoxPosY.TabIndex = 12;
            this.textBoxPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "pos_z";
            // 
            // textBoxPosZ
            // 
            this.textBoxPosZ.Location = new System.Drawing.Point(63, 116);
            this.textBoxPosZ.Name = "textBoxPosZ";
            this.textBoxPosZ.Size = new System.Drawing.Size(84, 20);
            this.textBoxPosZ.TabIndex = 14;
            this.textBoxPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonSnapshot
            // 
            this.buttonSnapshot.Location = new System.Drawing.Point(153, 12);
            this.buttonSnapshot.Name = "buttonSnapshot";
            this.buttonSnapshot.Size = new System.Drawing.Size(76, 58);
            this.buttonSnapshot.TabIndex = 16;
            this.buttonSnapshot.Text = "take position snapshot";
            this.buttonSnapshot.UseVisualStyleBackColor = true;
            this.buttonSnapshot.Click += new System.EventHandler(this.buttonSnapshot_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(153, 76);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(76, 58);
            this.buttonLoad.TabIndex = 17;
            this.buttonLoad.Text = "load position from snapshot";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // checkBoxUnlimitedBoomerangs
            // 
            this.checkBoxUnlimitedBoomerangs.AutoSize = true;
            this.checkBoxUnlimitedBoomerangs.Location = new System.Drawing.Point(18, 216);
            this.checkBoxUnlimitedBoomerangs.Name = "checkBoxUnlimitedBoomerangs";
            this.checkBoxUnlimitedBoomerangs.Size = new System.Drawing.Size(128, 17);
            this.checkBoxUnlimitedBoomerangs.TabIndex = 19;
            this.checkBoxUnlimitedBoomerangs.Text = "unlimited boomerangs";
            this.checkBoxUnlimitedBoomerangs.UseVisualStyleBackColor = true;
            this.checkBoxUnlimitedBoomerangs.CheckedChanged += new System.EventHandler(this.checkBoxUnlimitedBoomerangs_CheckedChanged);
            // 
            // buttonBoost
            // 
            this.buttonBoost.Location = new System.Drawing.Point(18, 161);
            this.buttonBoost.Name = "buttonBoost";
            this.buttonBoost.Size = new System.Drawing.Size(139, 23);
            this.buttonBoost.TabIndex = 20;
            this.buttonBoost.Text = "boost vertical position by";
            this.buttonBoost.UseVisualStyleBackColor = true;
            this.buttonBoost.Click += new System.EventHandler(this.buttonBoost_Click);
            // 
            // numericBoost
            // 
            this.numericBoost.Location = new System.Drawing.Point(164, 163);
            this.numericBoost.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericBoost.Name = "numericBoost";
            this.numericBoost.Size = new System.Drawing.Size(65, 20);
            this.numericBoost.TabIndex = 21;
            this.numericBoost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericBoost.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // ModuleHero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 243);
            this.Controls.Add(this.numericBoost);
            this.Controls.Add(this.buttonBoost);
            this.Controls.Add(this.checkBoxUnlimitedBoomerangs);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSnapshot);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxPosZ);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxPosY);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPosX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxRotY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxRotX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxImmortality);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModuleHero";
            this.Text = "hero";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModuleHero_FormClosing);
            this.Load += new System.EventHandler(this.ModuleHero_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericBoost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxImmortality;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRotX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxRotY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPosX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPosY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPosZ;
        private System.Windows.Forms.Button buttonSnapshot;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.CheckBox checkBoxUnlimitedBoomerangs;
        private System.Windows.Forms.Button buttonBoost;
        private System.Windows.Forms.NumericUpDown numericBoost;
    }
}