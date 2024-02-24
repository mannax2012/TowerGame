using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerGame
{
    public partial class loadCharacter : Form
    {
        public string connectionString = @"Data Source=characters.db;Version=3;";
        
        public characterDataManagement character;

        public loadCharacter()
        {
            InitializeComponent();
            DatabaseManagement database = new DatabaseManagement();
            database.InitializeDatabase();
            LoadCharacters();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void LoadCharacters()
        {
            /*
            List<characterDataManagement> characters = GetAllCharacters();
            dataGridView1.DataSource = characters;
            */
            List<characterDataManagement> character = GetAllCharacters();

            // Create a list of DisplayCharacter objects containing only name and level
            List<DisplayCharacter> displayCharacters = character.Select(c => new DisplayCharacter(c.Name, c.Level)).ToList();

            // Set the DataSource of the DataGridView to the list of DisplayCharacter objects
            dataGridView1.DataSource = displayCharacters;
        }
       private List<characterDataManagement> GetAllCharacters()
        {
            List<characterDataManagement> characters = new List<characterDataManagement>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Characters";
                SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, connection);
                SQLiteDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    string playerName = reader["Name"].ToString();
                    string playerClass = reader["ClassName"].ToString();
                    int pLevel = Convert.ToInt32(reader["Level"]);
                    int pHealth = Convert.ToInt32(reader["Health"]);
                    int pHealthMax = Convert.ToInt32(reader["HealthMax"]);
                    int pMagic = Convert.ToInt32(reader["Magic"]);
                    int pMagicMax = Convert.ToInt32(reader["MagicMax"]);
                    int pStrength = Convert.ToInt32(reader["Strength"]);
                    int pDexterity = Convert.ToInt32(reader["Dexterity"]);
                    int pIntellect = Convert.ToInt32(reader["Intellect"]);
                    int pStamina = Convert.ToInt32(reader["Stamina"]);
                    int pExP = Convert.ToInt32(reader["CurrentEXP"]);
                    int pExPMAX = Convert.ToInt32(reader["EXPMAX"]);
                    int characterTotalSP = Convert.ToInt32(reader["SkillPoints"]);
                    int playerCurrency = Convert.ToInt32(reader["playerCurrency"]);
                    int inventorySlotCount = Convert.ToInt32(reader["inventorySlotCOunt"]);

                    characters.Add(new characterDataManagement(playerName, playerClass, pLevel, pStrength, pDexterity, pIntellect, pStamina, pHealth, pHealthMax, pMagic, pMagicMax, pExP, pExPMAX, characterTotalSP, playerCurrency, inventorySlotCount));
                }
            }
            return characters;
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                character = dataGridView1.Rows[selectedIndex].DataBoundItem as characterDataManagement;
            }
            else
            {
                character = null;
            }
        }
        public static bool CharacterExists(string name, SQLiteConnection connection)
        {
            string selectQuery = "SELECT COUNT(*) FROM Characters WHERE Name = @Name";
            SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@Name", name);
            int count = Convert.ToInt32(selectCommand.ExecuteScalar());
            return count > 0;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            if (character != null)
            {
                MessageBox.Show($"Loaded character: {character.Name}, Level: {character.Level}");
                mainMenu main = new mainMenu();
                main.updateCharacterData(character);
                main.Hide();
                this.Close();
                main.Show();
                main.newCharacterToolStripMenuItem1.Enabled = true;

            }
            else
            {
                MessageBox.Show("Please select a character to load.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DatabaseManagement databaseManagement = new DatabaseManagement();
            if (character != null)
            {
                if (MessageBox.Show("Are you sure you want to delete this character? Deleting a Character is PERMINATE!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    databaseManagement.deleteCharacter(character.Name);
                    LoadCharacters();
                }
            }
            else
            {
                MessageBox.Show("Please select a character to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }
    }
    public class DisplayCharacter
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public DisplayCharacter(string name, int level)
        {
            Name = name;
            Level = level;
        }
    }
}

