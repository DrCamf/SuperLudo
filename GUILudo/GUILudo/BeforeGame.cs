using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUILudo
{
    public partial class BeforeGame : Form
    {
        public static int antalSp = 0;
        public BeforeGame()
        {
            InitializeComponent();
             
        }
        

        private void NumPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            antalSp = int.Parse(numPlayers.SelectedItem.ToString());

            
            //Form1 game = new Form1();
            //game.Show();


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
