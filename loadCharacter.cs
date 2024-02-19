using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
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
        public loadCharacterData selectedCharacter;

        public loadCharacter()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            InitializeDatabase();
            LoadCharacters();
            //comboBoxCharacters.SelectedIndexChanged += comboBoxCharacters_SelectedIndexChanged;

        }

        public void InitializeDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string createTableQuery = "CREATE TABLE IF NOT EXISTS Characters (Name TEXT, ClassName TEXT, Level INTEGER, Health INTEGER, Magic INTEGER, Strength INTEGER, Dexterity INTEGER, Intellect INTEGER, Stamina INTEGER, CurrentEXP INTEGER, EXPMAX INTEGER)";
                SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection);
                createTableCommand.ExecuteNonQuery();
            }
        }

        private void LoadCharacters()
        {
            List<loadCharacterData> characters = GetAllCharacters();
            dataGridView1.DataSource = characters;
        }
        private List<string> GetAllCharacterNames()
        {
            List<string> characterNames = new List<string>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT Name FROM Characters";
                SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, connection);
                SQLiteDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    characterNames.Add(reader["Name"].ToString());
                }
            }
            return characterNames;
        }
        private loadCharacterData GetCharacterByName(string name)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Characters WHERE Name = @Name";
                SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@Name", name);
                SQLiteDataReader reader = selectCommand.ExecuteReader();
                if (reader.Read())
                {
                    string characterName = reader["Name"].ToString();
                    string pclass = reader["ClassName"].ToString();
                    int level = Convert.ToInt32(reader["Level"]);
                    return new loadCharacterData(characterName, pclass, level);
                }
                else
                {
                    return null; // Character not found
                }
            }
        }
        private List<loadCharacterData> GetAllCharacters()
        {
            List<loadCharacterData> characters = new List<loadCharacterData>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Characters";
                SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, connection);
                SQLiteDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader["Name"].ToString();
                    string pclass = reader["ClassName"].ToString();
                    int level = Convert.ToInt32(reader["Level"]);
                    characters.Add(new loadCharacterData(name, pclass, level));
                }
            }
            return characters;
        }

        private void btnAddCharacter_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int level;
            if (!int.TryParse(txtLevel.Text, out level))
            {
                MessageBox.Show("Please enter a valid level.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AddCharacter(name, level);
            LoadCharacters();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                selectedCharacter = dataGridView1.Rows[selectedIndex].DataBoundItem as loadCharacterData;
            }
            else
            {
                selectedCharacter = null;
            }
        }
        private void AddCharacter(string name, int level)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Check if the character already exists
                if (CharacterExists(name, connection))
                {
                    // Ask user for confirmation to overwrite
                    DialogResult result = MessageBox.Show("A character with the same name already exists. Do you want to overwrite it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return; // User chose not to overwrite
                    }

                    // If user confirms, delete the existing entry
                    DeleteCharacter(name);
                }

                // Insert or update the character
                string insertQuery = "INSERT INTO Characters (Name, Level) VALUES (@Name, @Level)";
                SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@Name", name);
                insertCommand.Parameters.AddWithValue("@Level", level);
                insertCommand.ExecuteNonQuery();
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
            if (selectedCharacter != null)
            {
                // Use the selectedCharacter object in other areas of the app
                MessageBox.Show($"Loaded character: {selectedCharacter.Name}, Level: {selectedCharacter.Level}");
                mainMenu main = new mainMenu();
                main.updateCharacterData(selectedCharacter);
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
            if (selectedCharacter != null)
            {
                if (MessageBox.Show("Are you sure you want to delete this character? Deleting a Character is PERMINATE!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteCharacter(selectedCharacter.Name);
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

    public class loadCharacterData
    {
        public string Name { get; set; }
        public string pClassName { get; set; }
        public int Level { get; set; }

        public loadCharacterData(string name, string ClassName, int level)
        {
            Name = name;
            Level = level;
            pClassName = ClassName;
        }
    }
}

