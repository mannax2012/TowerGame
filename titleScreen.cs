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
    public partial class titleScreen : Form
    {
        public titleScreen()
        {
            InitializeComponent();
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            createCharacter newCharacter = new createCharacter();
            newCharacter.Show();
            this.Hide();
        }

        private void buttonLoadGame_Click(object sender, EventArgs e)
        {
            loadCharacter loadCharacter = new loadCharacter();
            loadCharacter.Show();
            this.Hide();
        }
    }
}
