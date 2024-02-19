using System;
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

namespace TowerGame
{
    public partial class mainMenu : Form
    {
        public static string connectionString { get; } = @"Data Source=characters.db;Version=3;";
        public mainMenu()
        {
            InitializeComponent();
            loadCharacter loadCharacter = new loadCharacter();
            loadCharacter.InitializeDatabase();
        }
        public void updateCharacterDataNEW(string playerName, string playerClass, int pLevel, int pStrength, int pDexterity, int pIntellect, int pStamina, int pHealth, int pMagic, int pExP, int pExPMAX)
        {
            characterName.Text = playerName;
            CharacterLevel.Text = pLevel.ToString(); 
            characterClass.Text = playerClass;

        }
        public void updateCharacterData(loadCharacterData character)
        {
            characterName.Text = character.Name;
            CharacterLevel.Text = character.Level.ToString();
            characterClass.Text = character.pClassName;

        }
        private void newCharacterToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            loadCharacter loadCharacter = new loadCharacter();
            loadCharacter.Show();
            this.Hide();
        }
        private void SaveCharacter(string name, int level)
        {

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Check if the character already exists
                if (loadCharacter.CharacterExists(name, connection))
                {
                    // Ask user for confirmation to overwrite
                    DialogResult result = MessageBox.Show("A character with the same name already exists. Do you want to overwrite it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return; // User chose not to overwrite
                    }
                    characterDataManagement dataManager = new characterDataManagement();
                    dataManager.deleteCharacter(name);
                }

                // Insert or update the character
                string insertQuery = "INSERT INTO Characters (Name, Level) VALUES (@Name, @Level)";
                SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@Name", name);
                insertCommand.Parameters.AddWithValue("@Level", level);
                insertCommand.ExecuteNonQuery();
            }
        }
        private void newCharacterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string name = characterName.Text;
            int level = CharacterLevel.Text.Length;

            SaveCharacter(name, level);
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
    }
}
