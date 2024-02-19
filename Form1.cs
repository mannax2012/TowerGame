using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace TowerGame
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Data Source=characters.db;Version=3;";
        private loadCharacterData selectedCharacter;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
           // dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            InitializeDatabase();
            LoadCharacters();
            comboBoxCharacters.SelectedIndexChanged += comboBoxCharacters_SelectedIndexChanged;

        }

        private void InitializeDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string createTableQuery = "CREATE TABLE IF NOT EXISTS Characters (Name TEXT, Level INTEGER)";
                SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection);
                createTableCommand.ExecuteNonQuery();
            }
        }

        private void LoadCharacters()
        {
            List<loadCharacterData> characters = GetAllCharacters();
            dataGridView1.DataSource = characters;
            List<string> characterNames = GetAllCharacterNames();
            comboBoxCharacters.DataSource = characterNames;
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
        private void comboBoxCharacters_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedName = comboBoxCharacters.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedName))
            {
                selectedCharacter = GetCharacterByName(selectedName);
            }
            else
            {
                selectedCharacter = null;
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
                string insertQuery = "INSERT INTO Characters (Name, Level) VALUES (@Name, @Level)";
                SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@Name", name);
                insertCommand.Parameters.AddWithValue("@Level", level);
                insertCommand.ExecuteNonQuery();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (selectedCharacter != null)
            {
                // Use the selectedCharacter object in other areas of the app
                MessageBox.Show($"Loaded character: {selectedCharacter.Name}, Level: {selectedCharacter.Level}");
                Form2 form2 = new Form2(selectedCharacter);
                form2.Show();
            }
            else
            {
                MessageBox.Show("Please select a character to load.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
