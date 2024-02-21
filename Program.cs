using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TowerGame
{
    internal static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainMenu());
        }

    }
    public class DatabaseManagement
    {
        public static string connectionString { get; } = @"Data Source=characters.db;Version=3;";
        public void InitializeDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string createTableQuery = "CREATE TABLE IF NOT EXISTS Characters (Name TEXT, ClassName TEXT, Level INTEGER, Health INTEGER, HealthMax INTEGER, Magic INTEGER, MagicMax INTEGER, Strength INTEGER, Dexterity INTEGER, Intellect INTEGER, Stamina INTEGER, CurrentEXP INTEGER, EXPMAX INTEGER)";
                SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection);
                createTableCommand.ExecuteNonQuery();
            }
        }
        public void deleteCharacter(string playerName)
        {

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Characters WHERE Name = @Name";
                SQLiteCommand deleteCommand = new SQLiteCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@Name", playerName);
                deleteCommand.ExecuteNonQuery();
            }
        }
    }
    public class characterDataManagement
    {
        public string Name { get; set; }
        public string pClassName { get; set; }
        public int Level { get; set; }
        public int Magic { get; set; }
        public int Health { get; set; }
        public int HealthMax { get; set; }
        public int MagicMax { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intellect { get; set; }
        public int Stamina { get; set; }
        public int playerExP { get; set; }
        public int playerExPMAX { get; set; }

        public characterDataManagement(string playerName, string playerClass, int pLevel, int pStrength, int pDexterity, int pIntellect, int pStamina, int pHealth, int pHealthMax, int pMagic, int pMagicMax, int pExP, int pExPMAX)
        {
            Name = playerName;
            Level = pLevel;
            pClassName = playerClass;
            Health = pHealth;
            Magic = pMagic;
            HealthMax = pHealthMax;
            MagicMax = pMagicMax;
            Strength = pStrength;
            Dexterity = pDexterity;
            Intellect = pIntellect;
            Stamina = pStamina;
            playerExP = pExP;
            playerExPMAX = pExPMAX;
        }
    }
    public class playerLevelUp
    {
        public static string connectionString { get; } = @"Data Source=characters.db;Version=3;";
        public void playerLevelUpData(characterDataManagement character)
        {
            double experienceMultiplier = 10.75;
            double quadraticCoefficient = 1.5;
            int playerEXP = character.playerExP;
            int pLevel = character.Level;
            string playerName = character.Name;
            string playerClass = character.pClassName;
            int pStrength = character.Strength;
            int pDexterity = character.Dexterity;
            int pIntellect = character.Intellect;
            int pHealth = character.Health;
            int pHealthMax = character.HealthMax;
            int pMagic = character.Magic;
            int pMagicMax = character.MagicMax;
            int pExPMAX = character.playerExPMAX;

            int maxEXPnew = character.playerExP + (int)(10 * (experienceMultiplier * Math.Pow(character.Level, 2)) + (quadraticCoefficient * character.Level));
            character.Level = pLevel + 1;
            character.playerExPMAX += maxEXPnew;
            //Console.Write("Passed Level Up");
        }
    }
}
