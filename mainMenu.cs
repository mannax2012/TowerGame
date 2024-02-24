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
        public int damagetaken;
        public int magicUsed;
        private characterDataManagement character;
        public static string connectionString { get; } = @"Data Source=Characters.db;Version=3;";
        public mainMenu()
        {
            InitializeComponent();
            DatabaseManagement database = new DatabaseManagement();
            database.InitializeDatabase();
            UpdateHealthBar();

        }

        public void updateCharacterData(characterDataManagement character)
        {
            grabSheetData();
           
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

            characterTotalSP.Text = character.SkillPoints.ToString();

            int newHealth = character.HealthMax - character.Health;
            progressBarHealth.Minimum = 0;
            progressBarHealth.Maximum = character.HealthMax;
            progressBarHealth.Value = character.Health + newHealth - damagetaken;
            character.Health = newHealth + character.Health - damagetaken;
            characterHEALTH.Text = character.Health.ToString();

            int newMagic = character.MagicMax - character.Magic;
            progressBarMagic.ForeColor = Color.Blue;
            progressBarMagic.Minimum = 0;
            progressBarMagic.Maximum = character.MagicMax;
            progressBarMagic.Value = character.Magic + newMagic - magicUsed;
            character.Magic = newMagic + character.Magic - magicUsed;
            characterMAGIC.Text = character.Magic.ToString();

            progressBarEXP.ForeColor = Color.Purple;
            progressBarEXP.Minimum = 0;
            progressBarEXP.Maximum = character.playerExPMAX;
            progressBarEXP.Value = character.playerExP;
            if (character.SkillPoints != 0)
            {
                characterTotalSP.Visible = true;
                buttonResetSkills.Visible = !buttonResetSkills.Visible;
                buttonAddSTR.Visible = true;
                buttonAddDEX.Visible = true;
                buttonAddINTEL.Visible = true;
                buttonAddSTAM.Visible = true;
                labelSP.Visible = true;
                if (buttonResetSkills.Visible)
                {
                    Console.WriteLine("enableSKillAdd Running...");
                }
            }
        }
        private void newCharacterToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            loadCharacter loadCharacter = new loadCharacter();
            loadCharacter.Show();
            this.Hide();
        }
        private void SaveCharacter(characterDataManagement character)
        {
            grabSheetData();
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
                if (CharacterExists(character.Name, connection))
                {
                    // Ask user for confirmation to overwrite
                    DialogResult result = MessageBox.Show("A character with the same name already exists. Do you want to overwrite it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return; // User chose not to overwrite
                    }

                    DatabaseManagement Database = new DatabaseManagement();
                    Database.deleteCharacter(character.Name);
                }
                // Insert or update the character
                
                string insertQuery = "INSERT INTO Characters (Name, ClassName, Level, Health, HealthMax, Magic, MagicMax, Strength, Dexterity, Intellect, Stamina, CurrentEXP, EXPMAX, SkillPoints, playerCurrency, inventorySlotCount) VALUES (@Name, @ClassName, @Level, @Health, @HealthMax, @Magic, @MagicMax, @Strength, @Dexterity, @Intellect, @Stamina, @CurrentEXP, @EXPMAX, @SkillPoints, @playerCurrency, @inventorySlotCount)";
                SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@Name", character.Name);
                insertCommand.Parameters.AddWithValue("@ClassName", character.pClassName);
                insertCommand.Parameters.AddWithValue("@Level", character.Level);
                insertCommand.Parameters.AddWithValue("@Health", character.Health);
                insertCommand.Parameters.AddWithValue("@HealthMax", character.HealthMax);
                insertCommand.Parameters.AddWithValue("@Magic", character.Magic);
                insertCommand.Parameters.AddWithValue("@MagicMax", character.MagicMax);
                insertCommand.Parameters.AddWithValue("@Strength", character.Strength);
                insertCommand.Parameters.AddWithValue("@Dexterity", character.Dexterity);
                insertCommand.Parameters.AddWithValue("@Intellect", character.Intellect);
                insertCommand.Parameters.AddWithValue("@Stamina", character.Stamina);
                insertCommand.Parameters.AddWithValue("@CurrentEXP", character.playerExP);
                insertCommand.Parameters.AddWithValue("@EXPMAX", character.playerExPMAX);
                insertCommand.Parameters.AddWithValue("@SkillPoints", character.SkillPoints);
                insertCommand.Parameters.AddWithValue("@playerCurrency", character.playerCurrency);
                insertCommand.Parameters.AddWithValue("@inventorySlotCount", character.inventorySlotCount);

                insertCommand.ExecuteNonQuery();


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
            grabSheetData();
            SaveCharacter(character);
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
            grabSheetData();
            int newHealth = character.HealthMax - character.Health;
   
            if (character.Health < 0.40 * character.HealthMax)
            {
               
                progressBarHealth.Minimum = 0;
                progressBarHealth.Maximum = character.HealthMax;
                progressBarHealth.Value = character.Health + newHealth;
            }
            else
            {
                progressBarHealth.Minimum = 0;
                progressBarHealth.Maximum = character.HealthMax;
                progressBarHealth.Value = character.Health + newHealth;
            }
        }

        private void expBTN_Click(object sender, EventArgs e)
        {
            grabSheetData();

            character.playerExP += 150;
            if (character.playerExP >= character.playerExPMAX)
            {
                character.playerExP = character.playerExP - character.playerExPMAX;
                playerLevelUp player = new playerLevelUp();
                player.playerLevelUpData(character);
                updateCharacterData(character);
            }
            else
            {
                progressBarEXP.ForeColor = Color.Purple;
                progressBarEXP.Minimum = 0;
                progressBarEXP.Maximum = int.Parse(characterEXPMAX.Text);
                progressBarEXP.Value = character.playerExP;
                characterEXP.Text = character.playerExP.ToString();
            }
        }
        public void grabSheetData()
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

            int skillpointTotal = int.Parse(characterTotalSP.Text);
            int playerCurrency = 0;
            int inventorySlotCount = 10;

            character = new characterDataManagement(playerName, playerClass, pLevel, pStrength, pDexterity, pIntellect, pStamina, pHealth, pHealthMax, pMagic, pMagicMax, pExP, pExPMAX, skillpointTotal, playerCurrency, inventorySlotCount);
        }
        private void buttonDamageTest_Click(object sender, EventArgs e)
        {
            damagetaken += 10;
            grabSheetData();
            updateCharacterData(character);
        }

        private void buttonFullHeal_Click(object sender, EventArgs e)
        {
            damagetaken = 0;
            grabSheetData();
            character.HealthMax = character.HealthMax;

            updateCharacterData(character);
        }

    }
}
