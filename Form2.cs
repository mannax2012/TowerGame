using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerGame
{
    public partial class Form2 : Form
    {
        public Form2(loadCharacterData character)
        {
            InitializeComponent();
            label1.Text = character.Name;
            label2.Text = character.Level.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
