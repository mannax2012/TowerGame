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
        private characterDataManagement character;
        public static string connectionString { get; } = @"Data Source=Characters.db;Version=3;";
        public mainMenu()
        {
            InitializeComponent();
            DatabaseManagement database = new DatabaseManagement();
            database.InitializeDatabase();
            CustomProgressBar customProgressBar = new CustomProgressBar();
            customProgressBar.Size = new Size(200, 20); // Set size as needed
            customProgressBar.Location = new Point(50, 50); // Set location as needed
            this.Controls.Add(customProgressBar);
            UpdateHealthBar();

        }

        public void updateCharacterData(characterDataManagement character)
        {
            characterName.Text = character.Name;
            CharacterLevel.Text = character.Level.ToString(); 
            characterClass.Text = character.pClassName;

            characterHEALTH.Text = character.Health.ToString();
            characterHEALTHMax.Text = character.HealthMax.ToString();

            characterMAGIC.Text = character.Magic.ToString();
            characterMAGICMax.Text = character.MagicMax.ToString();

            characterSTR.Text = character.Strength.ToString();
            characterDEX.Text = character.Dexterity.ToString();
            characterINTEL.Text = character.Intellect.ToString();
            characterSTAM.Text = character.Stamina.ToString();

            characterEXP.Text = character.playerExP.ToString();
            characterEXPMAX.Text = character.playerExPMAX.ToString();

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
            progressBarEXP.Value = character.playerExP;
            
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

            // Connection string
            string connectionString = @"Data Source=Characters.db;Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Check if the character already exists
                if (CharacterExists(playerName, connection))
                {
                    // Ask user for confirmation to overwrite
                    DialogResult result = MessageBox.Show("A character with the same name already exists. Do you want to overwrite it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return; // User chose not to overwrite
                    }

                    DatabaseManagement Database = new DatabaseManagement();
                    Database.deleteCharacter(playerName);
                }
                // Insert or update the character
                string insertQuery = "INSERT INTO Characters (Name, ClassName, Level, Health, HealthMax, Magic, MagicMax, Strength, Dexterity, Intellect, Stamina, CurrentEXP, EXPMAX) VALUES (@Name, @ClassName, @Level, @Health, @HealthMax, @Magic, @MagicMax, @Strength, @Dexterity, @Intellect, @Stamina, @CurrentEXP, @EXPMAX)";
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


                characterDataManagement character = new characterDataManagement(playerName, playerClass, pLevel, pStrength, pDexterity, pIntellect, pStamina, pHealth, pHealthMax, pMagic, pMagicMax, pExP, pExPMAX);
                updateCharacterData(character);
            }
        }
        public static bool CharacterExists(string playerName, SQLiteConnection connection)
        {
            string selectQuery = "SELECT COUNT(*) FROM Characters WHERE Name = @Name";
            SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@Name", playerName);
            int count = Convert.ToInt32(selectCommand.ExecuteScalar());
            return count > 0;
        }
        private void newCharacterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string playerName = characterName.Text;
            string playerClass = characterClass.Text;
            int pLevel = int.Parse(CharacterLevel.Text);
            int pStrength = int.Parse(characterSTR.Text);
            int pDexterity = int.Parse(characterDEX.Text);
            int pIntellect = int.Parse(characterINTEL.Text);
            int pStamina = int.Parse(characterSTAM.Text);
            int pHealth = int.Parse(characterHEALTH.Text);
            int pHealthMax = int.Parse(characterHEALTHMax.Text);
            int pMagic = int.Parse(characterMAGIC.Text);
            int pMagicMax = int.Parse(characterMAGICMax.Text);
            int pExP = int.Parse(characterEXP.Text);
            int pExPMAX = int.Parse(characterEXPMAX.Text);

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
        private void UpdateHealthBar()
        {
            // Update the health bar's width based on player's health
            int maxWidth = 200; // Maximum width of the health bar
            int currentWidth = (int)Math.Round((double)int.Parse(characterHEALTH.Text) / 100 * maxWidth);
            healthBarPictureBox.Size = new Size(currentWidth, healthBarPictureBox.Height);

            // Update the health value text
            //characterHEALTH.Text = characterData.Health.ToString();
            //characterData.HealthMax = 100;
            int maxHP = int.Parse(characterHEALTHMax.Text);
            int currentHP = int.Parse(characterHEALTH.Text);
            // Change health bar color based on health percentage
            if (currentHP < 0.40 * maxHP)
            {
                healthBarPictureBox.BackColor = Color.Red;
                progressBarHealth.Minimum = 0;
                progressBarHealth.Maximum = int.Parse(characterHEALTHMax.Text);
                progressBarHealth.Value = int.Parse(characterHEALTH.Text);
            }
            else
            {
                progressBarHealth.Minimum = 0;
                progressBarHealth.Maximum = int.Parse(characterHEALTHMax.Text);
                progressBarHealth.Value = int.Parse(characterHEALTH.Text);
            }
        }

        private void expBTN_Click(object sender, EventArgs e)
        {
            string playerName = characterName.Text;
            string playerClass = characterClass.Text;
            int pLevel = int.Parse(CharacterLevel.Text);
            int pStrength = int.Parse(characterSTR.Text);
            int pDexterity = int.Parse(characterDEX.Text);
            int pIntellect = int.Parse(characterINTEL.Text);
            int pStamina = int.Parse(characterSTAM.Text);
            int pHealth = int.Parse(characterHEALTH.Text);
            int pHealthMax = int.Parse(characterHEALTHMax.Text);
            int pMagic = int.Parse(characterMAGIC.Text);
            int pMagicMax = int.Parse(characterMAGICMax.Text);
            int pExP = int.Parse(characterEXP.Text);
            int pExPMAX = int.Parse(characterEXPMAX.Text);
            pExP += 150;
            if (pExP >= pExPMAX)
            {
                pExP = pExP - pExPMAX;
                playerLevelUp player = new playerLevelUp();
                characterDataManagement character = new characterDataManagement(playerName, playerClass, pLevel, pStrength, pDexterity, pIntellect, pStamina, pHealth, pHealthMax, pMagic, pMagicMax, pExP, pExPMAX);
                player.playerLevelUpData(character);
                updateCharacterData(character);
            }
            else
            {
                progressBarEXP.ForeColor = Color.Purple;
                progressBarEXP.Minimum = 0;
                progressBarEXP.Maximum = int.Parse(characterEXPMAX.Text);
                progressBarEXP.Value = pExP;
                characterEXP.Text = pExP.ToString();
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
