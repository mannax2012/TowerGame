using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TowerGame
{
    public partial class createCharacter : Form
    {
        public string connectionString = @"Data Source=Classes.db;Version=3;";
        public loadClassData selectedClass;
        DataTable dtClasses;
        public createCharacter()
        {
            InitializeComponent();
            InitializeClassDatabase();
            LoadClassesIntoComboBox();
            DatabaseManagement database = new DatabaseManagement();
            database.InitializeDatabase();
            comboBoxClassSelect.SelectedIndex = 0;
            comboBoxClassSelect.SelectedIndexChanged += comboBoxClassSelect_SelectedIndexChanged;
        }
        private void InitializeClassDatabase()
        {
            ClearDatabase();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Check if the table exists
                if (!TableExists("Classes", connection))
                {
                    // If the table does not exist, create it
                    string createTableQuery = "CREATE TABLE Classes (Name TEXT, str INTEGER, dex INTEGER, intel INTEGER, stam INTEGER)";
                    SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection);
                    createTableCommand.ExecuteNonQuery();
                }

                if (!EntryExists("Choose", connection))
                {
                    // If default entry does not exist, insert it
                    string insertQuery = "INSERT INTO Classes (Name, str, dex, intel, stam) VALUES ('Choose a Class', 0, 0, 0, 0)";
                    SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection);
                    insertCommand.ExecuteNonQuery();
                }
                if (!EntryExists("Warrior", connection))
                {
                    // If default entry does not exist, insert it
                    string insertQuery = "INSERT INTO Classes (Name, str, dex, intel, stam) VALUES ('Warrior', 8, 4, 0, 3)";
                    SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection);
                    insertCommand.ExecuteNonQuery();
                }
                if (!EntryExists("Priest", connection))
                {
                    // If default entry does not exist, insert it
                    string insertQuery = "INSERT INTO Classes (Name, str, dex, intel, stam) VALUES ('Mage', 0, 0, 10, 5)";
                    SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection);
                    insertCommand.ExecuteNonQuery();
                }
                if (!EntryExists("Rogue", connection))
                {
                    // If default entry does not exist, insert it
                    string insertQuery = "INSERT INTO Classes (Name, str, dex, intel, stam) VALUES ('Rogue', 3, 5, 2, 5)";
                    SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection);
                    insertCommand.ExecuteNonQuery();
                }
                if (!EntryExists("Mage", connection))
                {
                    // If default entry does not exist, insert it
                    string insertQuery = "INSERT INTO Classes (Name, str, dex, intel, stam) VALUES ('Mage', 0, 3, 10, 2)";
                    SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection);
                    insertCommand.ExecuteNonQuery();
                }
            }
        }
        private void ClearDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Classes"; // Assuming "Classes" is the table name
                SQLiteCommand deleteCommand = new SQLiteCommand(deleteQuery, connection);
                deleteCommand.ExecuteNonQuery();
            }
        }
        private bool TableExists(string tableName, SQLiteConnection connection)
        {
            string query = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}'";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            object result = command.ExecuteScalar();
            return result != null;
        }

        private bool EntryExists(string name, SQLiteConnection connection)
        {
            string query = $"SELECT COUNT(*) FROM Classes WHERE Name = @Name";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@Name", name);
            int count = Convert.ToInt32(command.ExecuteScalar());
            return count > 0;
        }
        private void LoadClassesIntoComboBox()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT Name FROM Classes";
                SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, connection);
                SQLiteDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxClassSelect.Items.Add(reader["Name"].ToString());
                }
            }
        }
        private void comboBoxClassSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Classes";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(selectQuery, connection);
                dtClasses = new DataTable();
                adapter.Fill(dtClasses);
            }

            string selectedClassName = comboBoxClassSelect.SelectedItem.ToString();
            DataRow[] rows = dtClasses.Select($"Name = '{selectedClassName}'");
            if (rows.Length > 0)
            {
                // Assuming "STR" is the column name for bonus strength in your DataTable
                int selectedClassSTR = Convert.ToInt32(rows[0]["STR"]);
                int selectedClassDEX = Convert.ToInt32(rows[0]["DEX"]);
                int selectedClassINTEL = Convert.ToInt32(rows[0]["INTEL"]);
                int selectedClassSTAM = Convert.ToInt32(rows[0]["STAM"]);

                int pStrength = selectedClassSTR + 10;
                int pDexterity = selectedClassDEX + 10;
                int pIntellect = selectedClassINTEL + 10;
                int pStamina = selectedClassSTAM + 10;
                int pHealth = 100 + ((pStamina + pStrength) * 10);
                int pMagic = 100 + ((pStamina + pIntellect) * 10);

                characterHEALTHVal.Text = pHealth.ToString();
                characterMAGICVal.Text = pMagic.ToString();
                characterSTR.Text = pStrength.ToString();
                characterDEX.Text = pDexterity.ToString();
                characterINTEL.Text = pIntellect.ToString();
                characterSTAM.Text = pStamina.ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (comboBoxClassSelect.SelectedIndex == 0 || characterNameEntry.Text == "")
            {
                MessageBox.Show("You MUST select a class and include a name before you can continue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string playerName = characterNameEntry.Text;
                string playerClass = comboBoxClassSelect.SelectedItem.ToString();
                int pLevel = int.Parse(playerLevelLabel.Text);
                int pStrength = int.Parse(characterSTR.Text);
                int pDexterity = int.Parse(characterDEX.Text);
                int pIntellect = int.Parse(characterINTEL.Text);
                int pStamina = int.Parse(characterSTAM.Text);
                int pHealth = int.Parse(characterHEALTHVal.Text);
                int pHealthMax = pHealth;
                int pMagic = int.Parse(characterMAGICVal.Text);
                int pMagicMax = pMagic;
                int pExP = int.Parse(characterEXP.Text);
                int pExPMAX = pLevel * 1000;
                createNewCharacter(playerName, playerClass, pLevel, pStrength, pDexterity, pIntellect, pStamina, pHealth, pHealthMax, pMagic, pMagicMax, pExP, pExPMAX);
                characterDataManagement character = new characterDataManagement(playerName, playerClass, pLevel, pStrength, pDexterity, pIntellect, pStamina, pHealth, pHealthMax, pMagic, pMagicMax, pExP, pExPMAX);
                mainMenu main = new mainMenu();
                main.updateCharacterData(character);
                main.Show();
                this.Close();
              }
        }
        private void createNewCharacter(string playerName, string playerClass, int pLevel, int pStrength, int pDexterity, int pIntellect, int pStamina, int pHealth, int pHealthMax, int pMagic, int pMagicMax, int pExP, int pExPMAX)
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
        public void DeleteCharacter(string playerName)
        {
            string connectionString = @"Data Source=Characters.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                            connection.Open();
                string deleteQuery = "DELETE FROM Characters WHERE Name = @Name";
                SQLiteCommand deleteCommand = new SQLiteCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@Name", playerName);
                deleteCommand.ExecuteNonQuery();
            }
        }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            this.Close();
            mainMenu main = new mainMenu();
            main.Show();
        }
    }

    public class loadClassData
    {
        public string ClassName { get; set; }
        public int bonusSTR { get; set; }
        public int bonusDEX { get; set; }
        public int bonusINTEL { get; set; }
        public int bonusSTAM { get; set; }


        public loadClassData(string name, int str, int dex, int intel, int stam)
        {
            ClassName = name;
            bonusSTR = str;
            bonusDEX = dex;
            bonusINTEL = intel;
            bonusSTAM = stam;
        }
    }
}
