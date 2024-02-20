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
        
        public characterDataManagement characterData;

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
            List<characterDataManagement> characters = GetAllCharacters();
            dataGridView1.DataSource = characters;
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

                    characters.Add(new characterDataManagement(playerName, playerClass, pLevel, pStrength, pDexterity, pIntellect, pStamina, pHealth, pHealthMax, pMagic, pMagicMax, pExP, pExPMAX));
                }
            }
            return characters;
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                characterData = dataGridView1.Rows[selectedIndex].DataBoundItem as characterDataManagement;
            }
            else
            {
                characterData = null;
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
            if (characterData != null)
            {
                // Use the characterData object in other areas of the app
                MessageBox.Show($"Loaded character: {characterData.Name}, Level: {characterData.Level}");
                mainMenu main = new mainMenu();
                main.updateCharacterData(characterData);
                main.Hide();
                this.Close();
                main.Show();

            }
            else
            {
                MessageBox.Show("Please select a character to load.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (characterData != null)
            {
                if (MessageBox.Show("Are you sure you want to delete this character? Deleting a Character is PERMINATE!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteCharacter(characterData.Name);
                    LoadCharacters(); // Refresh DataGridView after deletion
                }
            }
            else
            {
                MessageBox.Show("Please select a character to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DeleteCharacter(string name)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Characters WHERE Name = @Name";
                SQLiteCommand deleteCommand = new SQLiteCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@Name", name);
                deleteCommand.ExecuteNonQuery();
            }
        }
    }
}

