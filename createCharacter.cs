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
        int totalSP = 5;
        public int totalAdjustedSTR;
        public int totalAdjustedDEX;
        public int totalAdjustedINTEL;
        public int totalAdjustedSTAM;
        public int currentSP = 0;
        public int currentAdjustedHP = 0;
        public int currentAdjustedMP = 0;
        public int totalAdjustedHP = 0;
        public int totalAdjustedMP = 0;

        public int totalSTR;
        public int totalDEX;
        public int totalINTEL;
        public int totalSTAM;
        public createCharacter()
        {
            InitializeComponent();
            InitializeClassDatabase();
            LoadClassesIntoComboBox();
            getLoadStats();
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
                    string insertQuery = "INSERT INTO Classes (Name, str, dex, intel, stam) VALUES ('Priest', 0, 0, 10, 5)";
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
                int selectedClassSTR = Convert.ToInt32(rows[0]["STR"]);
                int selectedClassDEX = Convert.ToInt32(rows[0]["DEX"]);
                int selectedClassINTEL = Convert.ToInt32(rows[0]["INTEL"]);
                int selectedClassSTAM = Convert.ToInt32(rows[0]["STAM"]);
                       
        
        
                int pStrength = (selectedClassSTR + 10) + totalAdjustedSTR;
                int pDexterity = (selectedClassDEX + 10) + totalAdjustedDEX;
                int pIntellect = (selectedClassINTEL + 10) + totalAdjustedINTEL;
                int pStamina = (selectedClassSTAM + 10) + totalAdjustedSTAM;
                int pHealth = 100 + (pStamina * 10) + currentAdjustedHP;
                int pMagic = 100 + (pIntellect * 10)+ currentAdjustedMP;

                characterHEALTHVal.Text = pHealth.ToString();
                characterMAGICVal.Text = pMagic.ToString();
                characterSTR.Text = pStrength.ToString();
                characterDEX.Text = pDexterity.ToString();
                characterINTEL.Text = pIntellect.ToString();
                characterSTAM.Text = pStamina.ToString();
            }
        }
        public void getLoadStats()
        {
            int startingSTR = 10;
            int startingDEX = 10;
            int startingINTEL = 10;
            int startingSTAM = 10;

            int pStrength = startingSTR + totalAdjustedSTR;
            int pDexterity = startingDEX + totalAdjustedDEX;
            int pIntellect = startingINTEL + totalAdjustedINTEL;
            int pStamina = startingSTAM + totalAdjustedSTAM;

            int pHealth = 100 + (pStamina * 10) + currentAdjustedHP;
            int pMagic = 100 + (pIntellect * 10) + currentAdjustedMP;

            characterHEALTHVal.Text = pHealth.ToString();
            characterMAGICVal.Text = pMagic.ToString();
            characterSTR.Text = pStrength.ToString();
            characterDEX.Text = pDexterity.ToString();
            characterINTEL.Text = pIntellect.ToString();
            characterSTAM.Text = pStamina.ToString();
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
                main.newCharacterToolStripMenuItem1.Enabled = true;
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
            titleScreen main = new titleScreen();
            main.Show();
        }
        public void getSheetUpdate()
        {
            int pCurrentHealth = int.Parse(characterHEALTHVal.Text);
            int pCurrentMagic = int.Parse(characterMAGICVal.Text);
           int pHealthStep = pCurrentHealth - currentAdjustedHP;
            int pMagicStep = pCurrentMagic - currentAdjustedMP;

            int pHealth = pHealthStep + totalAdjustedHP;
            characterHEALTHVal.Text = pHealth.ToString();
            //totalAdjustedHPshow.Text = totalAdjustedHP.ToString();

            int pMagic = pMagicStep + totalAdjustedMP;
            characterMAGICVal.Text = pMagic.ToString();
            //totalAdjustedHPshow.Text = totalAdjustedMP.ToString();
        }
        private void buttonAddSTR_Click(object sender, EventArgs e)
        {
            if (totalSP > 0)
            {
                totalSP = totalSP - 1;
                totalAdjustedSTR = totalAdjustedSTR + 1;
                
                int currentSTR = int.Parse(characterSTR.Text);
                
                //int pMagic = 100 + ((pStamina + pIntellect) * 10);
                int addedSTR = currentSTR + 1;
                characterSTR.Text = addedSTR.ToString();
                characterTotalSP.Text = totalSP.ToString();
                getSheetUpdate();
            }
            else
            {
                MessageBox.Show($"Not enough skill points: {totalSP}");
            }
        }

        private void buttonAddDEX_Click(object sender, EventArgs e)
        {
            if (totalSP > 0)
            {
                totalSP = totalSP - 1;
                totalAdjustedDEX = totalAdjustedDEX + 1;
                int currentDEX = int.Parse(characterDEX.Text);

                int addedDEX = currentDEX + 1;
                characterDEX.Text = addedDEX.ToString();
                characterTotalSP.Text = totalSP.ToString();
            }
            else
            {
                MessageBox.Show($"Not enough skill points: {totalSP}");
            }
        }

        private void buttonAddINTEL_Click(object sender, EventArgs e)
        {
            if (comboBoxClassSelect.SelectedIndex != 0)
            {
                if (totalSP > 0)
                {
                    totalSP = totalSP - 1;
                    totalAdjustedINTEL = totalAdjustedINTEL + 1;
                    int currentINTEL = int.Parse(characterINTEL.Text);

                    int addedINTEL = currentINTEL + 1;
                    characterINTEL.Text = addedINTEL.ToString();
                    characterTotalSP.Text = totalSP.ToString();

                    currentAdjustedMP = totalAdjustedMP;

                    totalAdjustedMP = (totalAdjustedINTEL * 10);
                    //totalAdjustedHPshow.Text = totalAdjustedMP.ToString();

                    getSheetUpdate();
                }
                else
                {
                    MessageBox.Show($"Not enough skill points: {totalSP}");
                }
            }
            else
            {
                MessageBox.Show($"Select a Class first!");
            }
        }

        private void buttonAddSTAM_Click(object sender, EventArgs e)
        {
            if (comboBoxClassSelect.SelectedIndex != 0)
            {
                if (totalSP > 0)
                {
                    totalSP = totalSP - 1;
                    totalAdjustedSTAM = totalAdjustedSTAM + 1;
                    int currentSTAM = int.Parse(characterSTAM.Text);

                    int addedSTAM = currentSTAM + 1;
                    characterSTAM.Text = addedSTAM.ToString();
                    characterTotalSP.Text = totalSP.ToString();

                    currentAdjustedHP = totalAdjustedHP;

                    totalAdjustedHP = (totalAdjustedSTAM * 10);
                    //totalAdjustedHPshow.Text = totalAdjustedHP.ToString();

                    getSheetUpdate();
                }
                else
                {
                    MessageBox.Show($"Not enough skill points: {totalSP}");
                }
            }
            else
            {
                MessageBox.Show($"Select a Class first!");
            }
        }

        private void buttonResetSkills_Click(object sender, EventArgs e)
        {
            resetSKillPoints();
            getSheetUpdate();
        }
        public void resetSKillPoints()
        {
            if (totalAdjustedSTR > 0 || totalAdjustedINTEL > 0 || totalAdjustedSTAM > 0 || totalAdjustedDEX > 0)
            {
                totalSP += totalAdjustedSTR + totalAdjustedINTEL + totalAdjustedSTAM + totalAdjustedDEX;
                characterTotalSP.Text = totalSP.ToString();

                int totalSTR = int.Parse(characterSTR.Text) - totalAdjustedSTR;
                characterSTR.Text = totalSTR.ToString();
                totalAdjustedSTR = 0;

                int totalDEX = int.Parse(characterDEX.Text) - totalAdjustedDEX;
                characterDEX.Text = totalDEX.ToString();
                totalAdjustedDEX = 0;

                int totalINTEL = int.Parse(characterINTEL.Text) - totalAdjustedINTEL;
                characterINTEL.Text = totalINTEL.ToString();
                totalAdjustedINTEL = 0;

                int totalSTAM = int.Parse(characterSTAM.Text) - totalAdjustedSTAM;
                characterSTAM.Text = totalSTAM.ToString();
                totalAdjustedSTAM = 0;

                int baseHP = 100;
                int adjustedHP = (int.Parse(characterSTAM.Text) * 10) + baseHP;
                characterHEALTHVal.Text = adjustedHP.ToString();
                totalAdjustedHP = 0;
                currentAdjustedHP = 0;

                int baseMP = 100;
                int adjustedMP = (int.Parse(characterINTEL.Text) * 10) + baseMP;
                characterMAGICVal.Text = adjustedMP.ToString();
                totalAdjustedMP = 0;
                currentAdjustedMP = 0;
            }
            else
            {
                MessageBox.Show($"Your Skill Points have already been reset: {totalSP}");
            }
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
