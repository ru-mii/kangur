namespace kangur
{
    partial class Hotkeys
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hotkeys));
            this.liner_pooura = new System.Windows.Forms.Label();
            this.buttonSelectHero = new System.Windows.Forms.Button();
            this.jwvlha = new System.Windows.Forms.Label();
            this.heroSnapshotKey = new System.Windows.Forms.TextBox();
            this.heroLoadKey = new System.Windows.Forms.TextBox();
            this.ioiktn = new System.Windows.Forms.Label();
            this.ntjbah = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonHeroLoadClear = new System.Windows.Forms.Button();
            this.buttonHeroSnapshotClear = new System.Windows.Forms.Button();
            this.lrxfmw = new System.Windows.Forms.Label();
            this.heroBoostKey = new System.Windows.Forms.TextBox();
            this.buttonHeroBoostClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // liner_pooura
            // 
            this.liner_pooura.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.liner_pooura.Location = new System.Drawing.Point(129, -11);
            this.liner_pooura.Name = "liner_pooura";
            this.liner_pooura.Size = new System.Drawing.Size(2, 400);
            this.liner_pooura.TabIndex = 19;
            // 
            // buttonSelectHero
            // 
            this.buttonSelectHero.BackColor = System.Drawing.Color.Lime;
            this.buttonSelectHero.Enabled = false;
            this.buttonSelectHero.Location = new System.Drawing.Point(12, 12);
            this.buttonSelectHero.Name = "buttonSelectHero";
            this.buttonSelectHero.Size = new System.Drawing.Size(102, 23);
            this.buttonSelectHero.TabIndex = 20;
            this.buttonSelectHero.Text = "hero";
            this.buttonSelectHero.UseVisualStyleBackColor = false;
            // 
            // jwvlha
            // 
            this.jwvlha.AutoSize = true;
            this.jwvlha.Location = new System.Drawing.Point(150, 18);
            this.jwvlha.Name = "jwvlha";
            this.jwvlha.Size = new System.Drawing.Size(89, 13);
            this.jwvlha.TabIndex = 23;
            this.jwvlha.Text = "position snapshot";
            // 
            // heroSnapshotKey
            // 
            this.heroSnapshotKey.Location = new System.Drawing.Point(325, 15);
            this.heroSnapshotKey.Name = "heroSnapshotKey";
            this.heroSnapshotKey.ReadOnly = true;
            this.heroSnapshotKey.Size = new System.Drawing.Size(79, 20);
            this.heroSnapshotKey.TabIndex = 26;
            this.heroSnapshotKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.heroSnapshotKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.snapshotKey_KeyDown);
            // 
            // heroLoadKey
            // 
            this.heroLoadKey.Location = new System.Drawing.Point(325, 42);
            this.heroLoadKey.Name = "heroLoadKey";
            this.heroLoadKey.ReadOnly = true;
            this.heroLoadKey.Size = new System.Drawing.Size(79, 20);
            this.heroLoadKey.TabIndex = 32;
            this.heroLoadKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.heroLoadKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loadPositionKey_KeyDown);
            // 
            // ioiktn
            // 
            this.ioiktn.AutoSize = true;
            this.ioiktn.Location = new System.Drawing.Point(150, 45);
            this.ioiktn.Name = "ioiktn";
            this.ioiktn.Size = new System.Drawing.Size(98, 13);
            this.ioiktn.TabIndex = 29;
            this.ioiktn.Text = "load saved position";
            // 
            // ntjbah
            // 
            this.ntjbah.AutoSize = true;
            this.ntjbah.Location = new System.Drawing.Point(32000, 32000);
            this.ntjbah.Name = "ntjbah";
            this.ntjbah.Size = new System.Drawing.Size(0, 13);
            this.ntjbah.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 87);
            this.label1.TabIndex = 34;
            this.label1.Text = "each module window has to be open for hotkeys to work as it will reflect on the f" +
    "ields in a window as well";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonHeroLoadClear
            // 
            this.buttonHeroLoadClear.Location = new System.Drawing.Point(410, 40);
            this.buttonHeroLoadClear.Name = "buttonHeroLoadClear";
            this.buttonHeroLoadClear.Size = new System.Drawing.Size(75, 23);
            this.buttonHeroLoadClear.TabIndex = 35;
            this.buttonHeroLoadClear.Text = "clear";
            this.buttonHeroLoadClear.UseVisualStyleBackColor = true;
            this.buttonHeroLoadClear.Click += new System.EventHandler(this.buttonHeroLoadClear_Click);
            // 
            // buttonHeroSnapshotClear
            // 
            this.buttonHeroSnapshotClear.Location = new System.Drawing.Point(410, 13);
            this.buttonHeroSnapshotClear.Name = "buttonHeroSnapshotClear";
            this.buttonHeroSnapshotClear.Size = new System.Drawing.Size(75, 23);
            this.buttonHeroSnapshotClear.TabIndex = 36;
            this.buttonHeroSnapshotClear.Text = "clear";
            this.buttonHeroSnapshotClear.UseVisualStyleBackColor = true;
            this.buttonHeroSnapshotClear.Click += new System.EventHandler(this.buttonHeroSnapshotClear_Click);
            // 
            // lrxfmw
            // 
            this.lrxfmw.AutoSize = true;
            this.lrxfmw.Location = new System.Drawing.Point(150, 72);
            this.lrxfmw.Name = "lrxfmw";
            this.lrxfmw.Size = new System.Drawing.Size(65, 13);
            this.lrxfmw.TabIndex = 37;
            this.lrxfmw.Text = "boost height";
            // 
            // heroBoostKey
            // 
            this.heroBoostKey.Location = new System.Drawing.Point(325, 69);
            this.heroBoostKey.Name = "heroBoostKey";
            this.heroBoostKey.ReadOnly = true;
            this.heroBoostKey.Size = new System.Drawing.Size(79, 20);
            this.heroBoostKey.TabIndex = 38;
            this.heroBoostKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.heroBoostKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.heroBoostKey_KeyDown);
            // 
            // buttonHeroBoostClear
            // 
            this.buttonHeroBoostClear.Location = new System.Drawing.Point(410, 67);
            this.buttonHeroBoostClear.Name = "buttonHeroBoostClear";
            this.buttonHeroBoostClear.Size = new System.Drawing.Size(75, 23);
            this.buttonHeroBoostClear.TabIndex = 39;
            this.buttonHeroBoostClear.Text = "clear";
            this.buttonHeroBoostClear.UseVisualStyleBackColor = true;
            this.buttonHeroBoostClear.Click += new System.EventHandler(this.buttonHeroBoostClear_Click);
            // 
            // Hotkeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 131);
            this.Controls.Add(this.buttonHeroBoostClear);
            this.Controls.Add(this.heroBoostKey);
            this.Controls.Add(this.lrxfmw);
            this.Controls.Add(this.buttonHeroSnapshotClear);
            this.Controls.Add(this.buttonHeroLoadClear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ntjbah);
            this.Controls.Add(this.heroLoadKey);
            this.Controls.Add(this.ioiktn);
            this.Controls.Add(this.heroSnapshotKey);
            this.Controls.Add(this.jwvlha);
            this.Controls.Add(this.buttonSelectHero);
            this.Controls.Add(this.liner_pooura);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Hotkeys";
            this.Text = "(changes will save automatically)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Hotkeys_FormClosing);
            this.Load += new System.EventHandler(this.Hotkeys_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label liner_pooura;
        private System.Windows.Forms.Button buttonSelectHero;
        private System.Windows.Forms.Label jwvlha;
        private System.Windows.Forms.TextBox heroSnapshotKey;
        private System.Windows.Forms.TextBox heroLoadKey;
        private System.Windows.Forms.Label ioiktn;
        private System.Windows.Forms.Label ntjbah;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonHeroLoadClear;
        private System.Windows.Forms.Button buttonHeroSnapshotClear;
        private System.Windows.Forms.Label lrxfmw;
        private System.Windows.Forms.TextBox heroBoostKey;
        private System.Windows.Forms.Button buttonHeroBoostClear;
    }
}