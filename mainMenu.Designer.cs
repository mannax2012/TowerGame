namespace TowerGame
{
    partial class mainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCharacterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newCharacterToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.characterName = new System.Windows.Forms.Label();
            this.CharacterLevel = new System.Windows.Forms.Label();
            this.characterEXP = new System.Windows.Forms.Label();
            this.characterMAGIC = new System.Windows.Forms.Label();
            this.characterHEALTH = new System.Windows.Forms.Label();
            this.characterSTAM = new System.Windows.Forms.Label();
            this.characterINTEL = new System.Windows.Forms.Label();
            this.characterDEX = new System.Windows.Forms.Label();
            this.characterSTR = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.characterClass = new System.Windows.Forms.Label();
            this.progressBarHealth = new System.Windows.Forms.ProgressBar();
            this.progressBarMagic = new System.Windows.Forms.ProgressBar();
            this.progressBarEXP = new System.Windows.Forms.ProgressBar();
            this.mindBarPictureBox = new System.Windows.Forms.PictureBox();
            this.healthBarPictureBox = new System.Windows.Forms.PictureBox();
            this.expBTN = new System.Windows.Forms.Button();
            this.characterEXPMAX = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.characterHEALTHMax = new System.Windows.Forms.Label();
            this.characterMAGICMax = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mindBarPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.healthBarPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCharacterToolStripMenuItem,
            this.newCharacterToolStripMenuItem1,
            this.newCharacterToolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newCharacterToolStripMenuItem
            // 
            this.newCharacterToolStripMenuItem.Name = "newCharacterToolStripMenuItem";
            this.newCharacterToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.newCharacterToolStripMenuItem.Text = "New Game";
            this.newCharacterToolStripMenuItem.Click += new System.EventHandler(this.newCharacterToolStripMenuItem_Click);
            // 
            // newCharacterToolStripMenuItem1
            // 
            this.newCharacterToolStripMenuItem1.Enabled = false;
            this.newCharacterToolStripMenuItem1.Name = "newCharacterToolStripMenuItem1";
            this.newCharacterToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.newCharacterToolStripMenuItem1.Text = "Save Game";
            this.newCharacterToolStripMenuItem1.Click += new System.EventHandler(this.newCharacterToolStripMenuItem1_Click);
            // 
            // newCharacterToolStripMenuItem2
            // 
            this.newCharacterToolStripMenuItem2.Name = "newCharacterToolStripMenuItem2";
            this.newCharacterToolStripMenuItem2.Size = new System.Drawing.Size(134, 22);
            this.newCharacterToolStripMenuItem2.Text = "Load Game";
            this.newCharacterToolStripMenuItem2.Click += new System.EventHandler(this.newCharacterToolStripMenuItem2_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.exitToolStripMenuItem.Text = "Exit Game";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // characterName
            // 
            this.characterName.AutoSize = true;
            this.characterName.Location = new System.Drawing.Point(108, 126);
            this.characterName.Name = "characterName";
            this.characterName.Size = new System.Drawing.Size(67, 13);
            this.characterName.TabIndex = 1;
            this.characterName.Text = "defaultName";
            // 
            // CharacterLevel
            // 
            this.CharacterLevel.AutoSize = true;
            this.CharacterLevel.Location = new System.Drawing.Point(295, 154);
            this.CharacterLevel.Name = "CharacterLevel";
            this.CharacterLevel.Size = new System.Drawing.Size(13, 13);
            this.CharacterLevel.TabIndex = 2;
            this.CharacterLevel.Text = "1";
            // 
            // characterEXP
            // 
            this.characterEXP.AutoSize = true;
            this.characterEXP.Location = new System.Drawing.Point(295, 180);
            this.characterEXP.Name = "characterEXP";
            this.characterEXP.Size = new System.Drawing.Size(13, 13);
            this.characterEXP.TabIndex = 40;
            this.characterEXP.Text = "0";
            // 
            // characterMAGIC
            // 
            this.characterMAGIC.AutoSize = true;
            this.characterMAGIC.Location = new System.Drawing.Point(108, 180);
            this.characterMAGIC.Name = "characterMAGIC";
            this.characterMAGIC.Size = new System.Drawing.Size(13, 13);
            this.characterMAGIC.TabIndex = 39;
            this.characterMAGIC.Text = "0";
            // 
            // characterHEALTH
            // 
            this.characterHEALTH.AutoSize = true;
            this.characterHEALTH.Location = new System.Drawing.Point(108, 154);
            this.characterHEALTH.Name = "characterHEALTH";
            this.characterHEALTH.Size = new System.Drawing.Size(13, 13);
            this.characterHEALTH.TabIndex = 38;
            this.characterHEALTH.Text = "0";
            // 
            // characterSTAM
            // 
            this.characterSTAM.AutoSize = true;
            this.characterSTAM.Location = new System.Drawing.Point(108, 283);
            this.characterSTAM.Name = "characterSTAM";
            this.characterSTAM.Size = new System.Drawing.Size(13, 13);
            this.characterSTAM.TabIndex = 37;
            this.characterSTAM.Text = "0";
            // 
            // characterINTEL
            // 
            this.characterINTEL.AutoSize = true;
            this.characterINTEL.Location = new System.Drawing.Point(108, 258);
            this.characterINTEL.Name = "characterINTEL";
            this.characterINTEL.Size = new System.Drawing.Size(13, 13);
            this.characterINTEL.TabIndex = 36;
            this.characterINTEL.Text = "0";
            // 
            // characterDEX
            // 
            this.characterDEX.AutoSize = true;
            this.characterDEX.Location = new System.Drawing.Point(108, 233);
            this.characterDEX.Name = "characterDEX";
            this.characterDEX.Size = new System.Drawing.Size(13, 13);
            this.characterDEX.TabIndex = 35;
            this.characterDEX.Text = "0";
            // 
            // characterSTR
            // 
            this.characterSTR.AutoSize = true;
            this.characterSTR.Location = new System.Drawing.Point(108, 206);
            this.characterSTR.Name = "characterSTR";
            this.characterSTR.Size = new System.Drawing.Size(13, 13);
            this.characterSTR.TabIndex = 34;
            this.characterSTR.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(209, 180);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "Experience:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 282);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Stamina:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 257);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Intellect:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Dexterity:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Strength:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Magic Points:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Health Points:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Level:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Class:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Character Name:";
            // 
            // characterClass
            // 
            this.characterClass.AutoSize = true;
            this.characterClass.Location = new System.Drawing.Point(257, 126);
            this.characterClass.Name = "characterClass";
            this.characterClass.Size = new System.Drawing.Size(67, 13);
            this.characterClass.TabIndex = 49;
            this.characterClass.Text = "defaultName";
            // 
            // progressBarHealth
            // 
            this.progressBarHealth.Location = new System.Drawing.Point(358, 394);
            this.progressBarHealth.Name = "progressBarHealth";
            this.progressBarHealth.Size = new System.Drawing.Size(117, 12);
            this.progressBarHealth.TabIndex = 52;
            // 
            // progressBarMagic
            // 
            this.progressBarMagic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.progressBarMagic.Location = new System.Drawing.Point(358, 412);
            this.progressBarMagic.Name = "progressBarMagic";
            this.progressBarMagic.Size = new System.Drawing.Size(117, 12);
            this.progressBarMagic.TabIndex = 53;
            // 
            // progressBarEXP
            // 
            this.progressBarEXP.Location = new System.Drawing.Point(358, 430);
            this.progressBarEXP.Name = "progressBarEXP";
            this.progressBarEXP.Size = new System.Drawing.Size(117, 12);
            this.progressBarEXP.TabIndex = 54;
            // 
            // mindBarPictureBox
            // 
            this.mindBarPictureBox.Location = new System.Drawing.Point(337, 272);
            this.mindBarPictureBox.Name = "mindBarPictureBox";
            this.mindBarPictureBox.Size = new System.Drawing.Size(100, 50);
            this.mindBarPictureBox.TabIndex = 55;
            this.mindBarPictureBox.TabStop = false;
            // 
            // healthBarPictureBox
            // 
            this.healthBarPictureBox.Location = new System.Drawing.Point(337, 205);
            this.healthBarPictureBox.Name = "healthBarPictureBox";
            this.healthBarPictureBox.Size = new System.Drawing.Size(100, 50);
            this.healthBarPictureBox.TabIndex = 56;
            this.healthBarPictureBox.TabStop = false;
            // 
            // expBTN
            // 
            this.expBTN.Location = new System.Drawing.Point(223, 252);
            this.expBTN.Name = "expBTN";
            this.expBTN.Size = new System.Drawing.Size(75, 23);
            this.expBTN.TabIndex = 57;
            this.expBTN.Text = "ADD EXP";
            this.expBTN.UseVisualStyleBackColor = true;
            this.expBTN.Click += new System.EventHandler(this.expBTN_Click);
            // 
            // characterEXPMAX
            // 
            this.characterEXPMAX.AutoSize = true;
            this.characterEXPMAX.Location = new System.Drawing.Point(295, 206);
            this.characterEXPMAX.Name = "characterEXPMAX";
            this.characterEXPMAX.Size = new System.Drawing.Size(13, 13);
            this.characterEXPMAX.TabIndex = 58;
            this.characterEXPMAX.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(209, 205);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 59;
            this.label12.Text = "Next Level:";
            // 
            // characterHEALTHMax
            // 
            this.characterHEALTHMax.AutoSize = true;
            this.characterHEALTHMax.Location = new System.Drawing.Point(162, 154);
            this.characterHEALTHMax.Name = "characterHEALTHMax";
            this.characterHEALTHMax.Size = new System.Drawing.Size(13, 13);
            this.characterHEALTHMax.TabIndex = 60;
            this.characterHEALTHMax.Text = "0";
            // 
            // characterMAGICMax
            // 
            this.characterMAGICMax.AutoSize = true;
            this.characterMAGICMax.Location = new System.Drawing.Point(162, 180);
            this.characterMAGICMax.Name = "characterMAGICMax";
            this.characterMAGICMax.Size = new System.Drawing.Size(13, 13);
            this.characterMAGICMax.TabIndex = 61;
            this.characterMAGICMax.Text = "0";
            // 
            // mainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.characterMAGICMax);
            this.Controls.Add(this.characterHEALTHMax);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.characterEXPMAX);
            this.Controls.Add(this.expBTN);
            this.Controls.Add(this.healthBarPictureBox);
            this.Controls.Add(this.mindBarPictureBox);
            this.Controls.Add(this.progressBarEXP);
            this.Controls.Add(this.progressBarMagic);
            this.Controls.Add(this.progressBarHealth);
            this.Controls.Add(this.characterClass);
            this.Controls.Add(this.characterEXP);
            this.Controls.Add(this.characterMAGIC);
            this.Controls.Add(this.characterHEALTH);
            this.Controls.Add(this.characterSTAM);
            this.Controls.Add(this.characterINTEL);
            this.Controls.Add(this.characterDEX);
            this.Controls.Add(this.characterSTR);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CharacterLevel);
            this.Controls.Add(this.characterName);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainMenu";
            this.Text = "mainMenu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mindBarPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.healthBarPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCharacterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCharacterToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label characterName;
        private System.Windows.Forms.Label characterMAGIC;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label characterClass;
        public System.Windows.Forms.ProgressBar progressBarHealth;
        public System.Windows.Forms.ProgressBar progressBarMagic;
        public System.Windows.Forms.Label characterHEALTH;
        private System.Windows.Forms.PictureBox mindBarPictureBox;
        private System.Windows.Forms.PictureBox healthBarPictureBox;
        private System.Windows.Forms.Button expBTN;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label characterHEALTHMax;
        public System.Windows.Forms.Label characterMAGICMax;
        public System.Windows.Forms.ToolStripMenuItem newCharacterToolStripMenuItem1;
        public System.Windows.Forms.Label CharacterLevel;
        public System.Windows.Forms.Label characterEXP;
        public System.Windows.Forms.Label characterSTAM;
        public System.Windows.Forms.Label characterINTEL;
        public System.Windows.Forms.Label characterDEX;
        public System.Windows.Forms.Label characterSTR;
        public System.Windows.Forms.Label characterEXPMAX;
        public System.Windows.Forms.ProgressBar progressBarEXP;
    }
}