using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TowerGame
{
    public partial class mainMenu : Form
    {
        public static string connectionString { get; } = @"Data Source=characters.db;Version=3;";
        public mainMenu()
        {
            InitializeComponent();
            DatabaseManagement database = new DatabaseManagement();
            database.InitializeDatabase();
            CustomProgressBar customProgressBar = new CustomProgressBar();
            customProgressBar.Size = new Size(200, 20); // Set size as needed
            customProgressBar.Location = new Point(50, 50); // Set location as needed
            this.Controls.Add(customProgressBar);

        }

        public void updateCharacterData(characterDataManagement character)
        {
            characterName.Text = character.Name;
            CharacterLevel.Text = character.Level.ToString(); 
            characterClass.Text = character.pClassName;
            characterHEALTH.Text = character.Health.ToString() + " / " + character.HealthMax.ToString();

            characterMAGIC.Text = character.Magic.ToString() + " / " + character.MagicMax.ToString();
            
            characterSTR.Text = character.Strength.ToString();
            characterDEX.Text = character.Dexterity.ToString();
            characterINTEL.Text = character.Intellect.ToString();
            characterSTAM.Text = character.Stamina.ToString();

            characterEXP.Text = character.playerExP.ToString() + " / " + character.playerExPMAX.ToString();
          

            progressBarHealth.Minimum = 0;
            progressBarHealth.Maximum = character.HealthMax;
            progressBarHealth.Value = character.Health;

            progressBarMagic.ForeColor = Color.Blue;
            progressBarMagic.Minimum = 0;
            progressBarMagic.Maximum = character.MagicMax;
            progressBarMagic.Value = character.Magic;

            progressBarEXP.ForeColor = Color.Purple;
            progressBarEXP.Minimum = 0;
            progressBarEXP.Maximum = character.playerExPMAX;
            //progressBarEXP.Value = character.playerExP;
            progressBarEXP.Value = 250;

        }
        private void newCharacterToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            loadCharacter loadCharacter = new loadCharacter();
            loadCharacter.Show();
            this.Hide();
        }
        private void SaveCharacter(string playerName, string playerClass, int pLevel, int pStrength, int pDexterity, int pIntellect, int pStamina, int pHealth, int pHealthMax, int pMagic, int pMagicMax, int pExP, int pExPMAX)
        {
            // Check if the database file exists
            if (!File.Exists("Characters.db"))
            {
                // Create the database file if it doesn't exist
                SQLiteConnection.CreateFile("Characters.db");
            }
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Check if the character already exists
                if (loadCharacter.CharacterExists(playerName, connection))
                {
                    // Ask user for confirmation to overwrite
                    DialogResult result = MessageBox.Show("A character with the same name already exists. Do you want to overwrite it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return; // User chose not to overwrite
                    }
                    DatabaseManagement dataManager = new DatabaseManagement();
                    dataManager.deleteCharacter(playerName);
                }

                // Insert or update the character
                string insertQuery = "INSERT INTO Characters (Name, ClassName, Level, Health, HealthMax, Magic, MagicMax, Strength, Dexterity, Intellect, Stamina, CurrentEXP, EXPMAX) VALUES (@Name, @ClassName, @Level, @Health, @HealthMax @Magic, @MagicMax, @Strength, @Dexterity, @Intellect, @Stamina, @CurrentEXP, @EXPMAX)";
                SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@Name", playerName);
                insertCommand.Parameters.AddWithValue("@ClassName", playerClass);
                insertCommand.Parameters.AddWithValue("@Level", pLevel);
                insertCommand.Parameters.AddWithValue("@Health", pHealth);
                insertCommand.Parameters.AddWithValue("@HealthMax", pHealthMax);
                insertCommand.Parameters.AddWithValue("@Magic", pMagic);
                insertCommand.Parameters.AddWithValue("@MagicMax", pMagicMax);
                insertCommand.Parameters.AddWithValue("@Strength", pStrength);
                insertCommand.Parameters.AddWithValue("@Dexterity", pDexterity);
                insertCommand.Parameters.AddWithValue("@Intellect", pIntellect);
                insertCommand.Parameters.AddWithValue("@Stamina", pStamina);
                insertCommand.Parameters.AddWithValue("@CurrentEXP", pExP);
                insertCommand.Parameters.AddWithValue("@EXPMAX", pExPMAX);
                insertCommand.ExecuteNonQuery();
            }
        }
        private void newCharacterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string playerName = characterName.Text;
            string playerClass = characterClass.Text;
            int pLevel = int.Parse(CharacterLevel.Text);
            int pStrength = int.Parse(characterSTR.Text);
            int pDexterity = int.Parse(characterSTR.Text);
            int pIntellect = int.Parse(characterSTR.Text);
            int pStamina = int.Parse(characterSTR.Text);
            int pHealth = int.Parse(characterSTR.Text);
            int pHealthMax = int.Parse(characterSTR.Text);
            int pMagic = int.Parse(characterSTR.Text);
            int pMagicMax = int.Parse(characterSTR.Text);
            int pExP = int.Parse(characterSTR.Text);
            int pExPMAX = int.Parse(characterSTR.Text);


            SaveCharacter(playerName, playerClass, pLevel, pStrength, pDexterity, pIntellect, pStamina, pHealth, pHealthMax, pMagic, pMagicMax, pExP, pExPMAX);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newCharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createCharacter newCharacter = new createCharacter();
            newCharacter.Show();
            this.Hide();
        }
        private void UpdateHealthBar(characterDataManagement characterData)
        {
            // Update the health bar's width based on player's health
            int maxWidth = 200; // Maximum width of the health bar
            int currentWidth = (int)Math.Round((double)characterData.Health / 100 * maxWidth);
            healthBarPictureBox.Size = new Size(currentWidth, healthBarPictureBox.Height);

            // Update the health value text
            //healthLabel.Text = characterData.Health.ToString();
            //characterData.HealthMax = 100;
            // Change health bar color based on health percentage
            if (characterData.Health < 0.40 * characterData.HealthMax)
            {
                healthBarPictureBox.BackColor = Color.Red;
            }
            else
            {
                healthBarPictureBox.BackColor = Color.Green;
            }
        }
    }
    public class CustomProgressBar : PictureBox
    {
        // Properties
        private int _minimum = 0;
        public int Minimum
        {
            get { return _minimum; }
            set
            {
                _minimum = value;
                // Ensure current value is within the new range
                Value = Math.Max(_minimum, Math.Min(Value, _maximum));
                // Redraw the progress bar
                this.Invalidate();
            }
        }

        private int _maximum = 100;
        public int Maximum
        {
            get { return _maximum; }
            set
            {
                _maximum = value;
                // Ensure current value is within the new range
                Value = Math.Max(_minimum, Math.Min(Value, _maximum));
                // Redraw the progress bar
                this.Invalidate();
            }
        }

        private int _value = 0;
        public int Value
        {
            get { return _value; }
            set
            {
                _value = Math.Max(_minimum, Math.Min(value, _maximum));
                // Redraw the progress bar
                this.Invalidate();
            }
        }

        // Constructor
        public CustomProgressBar()
        {
            this.BackColor = Color.White; // Set background color
        }

        // Override the OnPaint method to draw the progress bar
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Calculate the width of the filled portion based on the current value
            int width = (int)((double)this.Width * ((_value - _minimum) / (double)(_maximum - _minimum)));

            // Draw the filled portion
            Rectangle filledRect = new Rectangle(0, 0, width, this.Height);
            using (SolidBrush brush = new SolidBrush(Color.Blue))
            {
                e.Graphics.FillRectangle(brush, filledRect);
            }
        }

        // Update the value
        public void UpdateValue(int value)
        {
            Value = value;
        }
    }
}
