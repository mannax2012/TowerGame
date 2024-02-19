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
            this.label4 = new System.Windows.Forms.Label();
            this.characterHEALTHMAX = new System.Windows.Forms.Label();
            this.characterMAGICMAX = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.characterEXPMAX = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.characterClass = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
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
            this.newCharacterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newCharacterToolStripMenuItem.Text = "New Game";
            this.newCharacterToolStripMenuItem.Click += new System.EventHandler(this.newCharacterToolStripMenuItem_Click);
            // 
            // newCharacterToolStripMenuItem1
            // 
            this.newCharacterToolStripMenuItem1.Name = "newCharacterToolStripMenuItem1";
            this.newCharacterToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.newCharacterToolStripMenuItem1.Text = "Save Game";
            this.newCharacterToolStripMenuItem1.Click += new System.EventHandler(this.newCharacterToolStripMenuItem1_Click);
            // 
            // newCharacterToolStripMenuItem2
            // 
            this.newCharacterToolStripMenuItem2.Name = "newCharacterToolStripMenuItem2";
            this.newCharacterToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.newCharacterToolStripMenuItem2.Text = "Load Game";
            this.newCharacterToolStripMenuItem2.Click += new System.EventHandler(this.newCharacterToolStripMenuItem2_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit Game";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // characterName
            // 
            this.characterName.AutoSize = true;
            this.characterName.Location = new System.Drawing.Point(108, 33);
            this.characterName.Name = "characterName";
            this.characterName.Size = new System.Drawing.Size(67, 13);
            this.characterName.TabIndex = 1;
            this.characterName.Text = "defaultName";
            // 
            // CharacterLevel
            // 
            this.CharacterLevel.AutoSize = true;
            this.CharacterLevel.Location = new System.Drawing.Point(310, 61);
            this.CharacterLevel.Name = "CharacterLevel";
            this.CharacterLevel.Size = new System.Drawing.Size(13, 13);
            this.CharacterLevel.TabIndex = 2;
            this.CharacterLevel.Text = "1";
            // 
            // characterEXP
            // 
            this.characterEXP.AutoSize = true;
            this.characterEXP.Location = new System.Drawing.Point(346, 87);
            this.characterEXP.Name = "characterEXP";
            this.characterEXP.Size = new System.Drawing.Size(13, 13);
            this.characterEXP.TabIndex = 40;
            this.characterEXP.Text = "0";
            // 
            // characterMAGIC
            // 
            this.characterMAGIC.AutoSize = true;
            this.characterMAGIC.Location = new System.Drawing.Point(124, 87);
            this.characterMAGIC.Name = "characterMAGIC";
            this.characterMAGIC.Size = new System.Drawing.Size(13, 13);
            this.characterMAGIC.TabIndex = 39;
            this.characterMAGIC.Text = "0";
            // 
            // characterHEALTH
            // 
            this.characterHEALTH.AutoSize = true;
            this.characterHEALTH.Location = new System.Drawing.Point(124, 61);
            this.characterHEALTH.Name = "characterHEALTH";
            this.characterHEALTH.Size = new System.Drawing.Size(13, 13);
            this.characterHEALTH.TabIndex = 38;
            this.characterHEALTH.Text = "0";
            // 
            // characterSTAM
            // 
            this.characterSTAM.AutoSize = true;
            this.characterSTAM.Location = new System.Drawing.Point(71, 189);
            this.characterSTAM.Name = "characterSTAM";
            this.characterSTAM.Size = new System.Drawing.Size(13, 13);
            this.characterSTAM.TabIndex = 37;
            this.characterSTAM.Text = "0";
            // 
            // characterINTEL
            // 
            this.characterINTEL.AutoSize = true;
            this.characterINTEL.Location = new System.Drawing.Point(71, 164);
            this.characterINTEL.Name = "characterINTEL";
            this.characterINTEL.Size = new System.Drawing.Size(13, 13);
            this.characterINTEL.TabIndex = 36;
            this.characterINTEL.Text = "0";
            // 
            // characterDEX
            // 
            this.characterDEX.AutoSize = true;
            this.characterDEX.Location = new System.Drawing.Point(71, 139);
            this.characterDEX.Name = "characterDEX";
            this.characterDEX.Size = new System.Drawing.Size(13, 13);
            this.characterDEX.TabIndex = 35;
            this.characterDEX.Text = "0";
            // 
            // characterSTR
            // 
            this.characterSTR.AutoSize = true;
            this.characterSTR.Location = new System.Drawing.Point(71, 112);
            this.characterSTR.Name = "characterSTR";
            this.characterSTR.Size = new System.Drawing.Size(13, 13);
            this.characterSTR.TabIndex = 34;
            this.characterSTR.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(260, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "Experience:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 189);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Stamina:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 164);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Intellect:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Dexterity:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Strength:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Magic Points:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Health Points:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Level:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Class:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Character Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(143, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "/";
            // 
            // characterHEALTHMAX
            // 
            this.characterHEALTHMAX.AutoSize = true;
            this.characterHEALTHMAX.Location = new System.Drawing.Point(162, 61);
            this.characterHEALTHMAX.Name = "characterHEALTHMAX";
            this.characterHEALTHMAX.Size = new System.Drawing.Size(13, 13);
            this.characterHEALTHMAX.TabIndex = 42;
            this.characterHEALTHMAX.Text = "0";
            // 
            // characterMAGICMAX
            // 
            this.characterMAGICMAX.AutoSize = true;
            this.characterMAGICMAX.Location = new System.Drawing.Point(162, 87);
            this.characterMAGICMAX.Name = "characterMAGICMAX";
            this.characterMAGICMAX.Size = new System.Drawing.Size(13, 13);
            this.characterMAGICMAX.TabIndex = 44;
            this.characterMAGICMAX.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(143, 87);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(12, 13);
            this.label14.TabIndex = 43;
            this.label14.Text = "/";
            // 
            // characterEXPMAX
            // 
            this.characterEXPMAX.AutoSize = true;
            this.characterEXPMAX.Location = new System.Drawing.Point(382, 87);
            this.characterEXPMAX.Name = "characterEXPMAX";
            this.characterEXPMAX.Size = new System.Drawing.Size(13, 13);
            this.characterEXPMAX.TabIndex = 48;
            this.characterEXPMAX.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(363, 87);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(12, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "/";
            // 
            // characterClass
            // 
            this.characterClass.AutoSize = true;
            this.characterClass.Location = new System.Drawing.Point(308, 33);
            this.characterClass.Name = "characterClass";
            this.characterClass.Size = new System.Drawing.Size(67, 13);
            this.characterClass.TabIndex = 49;
            this.characterClass.Text = "defaultName";
            // 
            // mainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.characterClass);
            this.Controls.Add(this.characterEXPMAX);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.characterMAGICMAX);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.characterHEALTHMAX);
            this.Controls.Add(this.label4);
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
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainMenu";
            this.Text = "mainMenu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCharacterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCharacterToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newCharacterToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label characterName;
        private System.Windows.Forms.Label CharacterLevel;
        private System.Windows.Forms.Label characterEXP;
        private System.Windows.Forms.Label characterMAGIC;
        private System.Windows.Forms.Label characterHEALTH;
        private System.Windows.Forms.Label characterSTAM;
        private System.Windows.Forms.Label characterINTEL;
        private System.Windows.Forms.Label characterDEX;
        private System.Windows.Forms.Label characterSTR;
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label characterHEALTHMAX;
        private System.Windows.Forms.Label characterMAGICMAX;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label characterEXPMAX;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label characterClass;
    }
}