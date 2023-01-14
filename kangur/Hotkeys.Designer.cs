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
            this.text0 = new System.Windows.Forms.Label();
            this.key0 = new System.Windows.Forms.TextBox();
            this.key1 = new System.Windows.Forms.TextBox();
            this.text1 = new System.Windows.Forms.Label();
            this.ntjbah = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClear1 = new System.Windows.Forms.Button();
            this.buttonClear0 = new System.Windows.Forms.Button();
            this.text2 = new System.Windows.Forms.Label();
            this.key2 = new System.Windows.Forms.TextBox();
            this.buttonClear2 = new System.Windows.Forms.Button();
            this.buttonSelectEnvironment = new System.Windows.Forms.Button();
            this.pad0 = new System.Windows.Forms.Button();
            this.pad1 = new System.Windows.Forms.Button();
            this.pad2 = new System.Windows.Forms.Button();
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
            this.buttonSelectHero.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonSelectHero.Enabled = false;
            this.buttonSelectHero.Location = new System.Drawing.Point(12, 12);
            this.buttonSelectHero.Name = "buttonSelectHero";
            this.buttonSelectHero.Size = new System.Drawing.Size(102, 23);
            this.buttonSelectHero.TabIndex = 20;
            this.buttonSelectHero.Text = "hero";
            this.buttonSelectHero.UseVisualStyleBackColor = false;
            this.buttonSelectHero.Click += new System.EventHandler(this.buttonSelectHero_Click);
            // 
            // text0
            // 
            this.text0.AutoSize = true;
            this.text0.Location = new System.Drawing.Point(150, 18);
            this.text0.Name = "text0";
            this.text0.Size = new System.Drawing.Size(89, 13);
            this.text0.TabIndex = 23;
            this.text0.Text = "position snapshot";
            // 
            // key0
            // 
            this.key0.Location = new System.Drawing.Point(325, 15);
            this.key0.Name = "key0";
            this.key0.ReadOnly = true;
            this.key0.Size = new System.Drawing.Size(79, 20);
            this.key0.TabIndex = 26;
            this.key0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.key0.KeyDown += new System.Windows.Forms.KeyEventHandler(this.key1_KeyDown);
            // 
            // key1
            // 
            this.key1.Location = new System.Drawing.Point(325, 42);
            this.key1.Name = "key1";
            this.key1.ReadOnly = true;
            this.key1.Size = new System.Drawing.Size(79, 20);
            this.key1.TabIndex = 32;
            this.key1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.key1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.key2_KeyDown);
            // 
            // text1
            // 
            this.text1.AutoSize = true;
            this.text1.Location = new System.Drawing.Point(150, 45);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(98, 13);
            this.text1.TabIndex = 29;
            this.text1.Text = "load saved position";
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
            this.label1.Location = new System.Drawing.Point(12, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 87);
            this.label1.TabIndex = 34;
            this.label1.Text = "each module window has to be open for hotkeys to work as it will reflect on the f" +
    "ields in a window as well";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonClear1
            // 
            this.buttonClear1.Location = new System.Drawing.Point(410, 40);
            this.buttonClear1.Name = "buttonClear1";
            this.buttonClear1.Size = new System.Drawing.Size(75, 23);
            this.buttonClear1.TabIndex = 35;
            this.buttonClear1.Text = "clear";
            this.buttonClear1.UseVisualStyleBackColor = true;
            this.buttonClear1.Click += new System.EventHandler(this.buttonClear2_Click);
            // 
            // buttonClear0
            // 
            this.buttonClear0.Location = new System.Drawing.Point(410, 13);
            this.buttonClear0.Name = "buttonClear0";
            this.buttonClear0.Size = new System.Drawing.Size(75, 23);
            this.buttonClear0.TabIndex = 36;
            this.buttonClear0.Text = "clear";
            this.buttonClear0.UseVisualStyleBackColor = true;
            this.buttonClear0.Click += new System.EventHandler(this.buttonClear1_Click);
            // 
            // text2
            // 
            this.text2.AutoSize = true;
            this.text2.Location = new System.Drawing.Point(150, 72);
            this.text2.Name = "text2";
            this.text2.Size = new System.Drawing.Size(65, 13);
            this.text2.TabIndex = 37;
            this.text2.Text = "boost height";
            // 
            // key2
            // 
            this.key2.Location = new System.Drawing.Point(325, 69);
            this.key2.Name = "key2";
            this.key2.ReadOnly = true;
            this.key2.Size = new System.Drawing.Size(79, 20);
            this.key2.TabIndex = 38;
            this.key2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.key2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.key3_KeyDown);
            // 
            // buttonClear2
            // 
            this.buttonClear2.Location = new System.Drawing.Point(410, 67);
            this.buttonClear2.Name = "buttonClear2";
            this.buttonClear2.Size = new System.Drawing.Size(75, 23);
            this.buttonClear2.TabIndex = 39;
            this.buttonClear2.Text = "clear";
            this.buttonClear2.UseVisualStyleBackColor = true;
            this.buttonClear2.Click += new System.EventHandler(this.buttonClear3_Click);
            // 
            // buttonSelectEnvironment
            // 
            this.buttonSelectEnvironment.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSelectEnvironment.Location = new System.Drawing.Point(15, 45);
            this.buttonSelectEnvironment.Name = "buttonSelectEnvironment";
            this.buttonSelectEnvironment.Size = new System.Drawing.Size(99, 23);
            this.buttonSelectEnvironment.TabIndex = 41;
            this.buttonSelectEnvironment.Text = "environment";
            this.buttonSelectEnvironment.UseVisualStyleBackColor = true;
            this.buttonSelectEnvironment.Click += new System.EventHandler(this.buttonSelectEnvironment_Click);
            // 
            // pad0
            // 
            this.pad0.Location = new System.Drawing.Point(488, 13);
            this.pad0.Name = "pad0";
            this.pad0.Size = new System.Drawing.Size(23, 23);
            this.pad0.TabIndex = 42;
            this.pad0.Text = "c";
            this.pad0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.pad0.UseVisualStyleBackColor = true;
            this.pad0.Click += new System.EventHandler(this.pad_Click);
            // 
            // pad1
            // 
            this.pad1.Location = new System.Drawing.Point(488, 40);
            this.pad1.Name = "pad1";
            this.pad1.Size = new System.Drawing.Size(23, 23);
            this.pad1.TabIndex = 43;
            this.pad1.Text = "c";
            this.pad1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.pad1.UseVisualStyleBackColor = true;
            this.pad1.Click += new System.EventHandler(this.pad_Click);
            // 
            // pad2
            // 
            this.pad2.Location = new System.Drawing.Point(488, 66);
            this.pad2.Name = "pad2";
            this.pad2.Size = new System.Drawing.Size(23, 23);
            this.pad2.TabIndex = 44;
            this.pad2.Text = "c";
            this.pad2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.pad2.UseVisualStyleBackColor = true;
            this.pad2.Click += new System.EventHandler(this.pad_Click);
            // 
            // Hotkeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 182);
            this.Controls.Add(this.pad2);
            this.Controls.Add(this.pad1);
            this.Controls.Add(this.pad0);
            this.Controls.Add(this.buttonSelectEnvironment);
            this.Controls.Add(this.buttonClear2);
            this.Controls.Add(this.key2);
            this.Controls.Add(this.text2);
            this.Controls.Add(this.buttonClear0);
            this.Controls.Add(this.buttonClear1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ntjbah);
            this.Controls.Add(this.key1);
            this.Controls.Add(this.text1);
            this.Controls.Add(this.key0);
            this.Controls.Add(this.text0);
            this.Controls.Add(this.buttonSelectHero);
            this.Controls.Add(this.liner_pooura);
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
        private System.Windows.Forms.Label text0;
        private System.Windows.Forms.TextBox key0;
        private System.Windows.Forms.TextBox key1;
        private System.Windows.Forms.Label text1;
        private System.Windows.Forms.Label ntjbah;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClear1;
        private System.Windows.Forms.Button buttonClear0;
        private System.Windows.Forms.Label text2;
        private System.Windows.Forms.TextBox key2;
        private System.Windows.Forms.Button buttonClear2;
        private System.Windows.Forms.Button buttonSelectEnvironment;
        private System.Windows.Forms.Button pad0;
        private System.Windows.Forms.Button pad1;
        private System.Windows.Forms.Button pad2;
    }
}