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
    public partial class Form1 : Form
    {
        int antalSp = 0;
        BeforeGame bSg = new BeforeGame();
        public Form1()
        {
            BeforeGame bSg = new BeforeGame();
            
           
           

            InitializeComponent();
            BeforeGame b = new BeforeGame();
            antalSp = BeforeGame.antalSp;
        }
        PictureBox[] boardTable;
        Image[] diceImg;
        Bitmap[] diceBmp = new Bitmap[7] { Properties.Resources.dice_0, Properties.Resources.dice_1, Properties.Resources.dice_2, Properties.Resources.dice_3, Properties.Resources.dice_4, Properties.Resources.dice_5, Properties.Resources.dice_6 };
        Board ludoBoard = new Board();
        LudoBoardField[] ludoBoardFeld = new LudoBoardField[52];
        PlayPiece[] pieces = new PlayPiece[16];
        Player[] player = new Player[4];
       
        Dice ludoDice = new Dice(6);
        Control ctrl = new Control();
        GameEngine g;

        private void Form1_Load(object sender, EventArgs e)
        {
            diceImg = new Image[7];
            
            for (int i = 0; i < diceImg.Length; i++)
                diceImg[i] = diceBmp[i];

            g = new GameEngine(ludoDice, ludoBoard, ludoBoardFeld, pieces);
            PictureBox[] pPiece = new PictureBox[] { green1, green2, green3, green4, blue1, blue2, blue3, blue4, yellow1, yellow2, yellow3, yellowZone4, red1, red2, red3, red4 };

            dicebox.Hide();
            btn_RollDice.Hide();
            PictureBox[] ludoBoardPic = new PictureBox[76] { felt0, felt1, felt2, felt3, felt4, felt5, felt6, felt7, felt8, felt9, felt10,
                felt11, felt12, felt13, felt14, felt15, felt16, felt17, felt18, felt19, felt20, felt21, felt22, felt23, felt24, felt25,
                felt26, felt27, felt28, felt29, felt30, felt31, felt32, felt33, felt34, felt35, felt36, felt37, felt38, felt39, felt40,
                felt41, felt42, felt43, felt44, felt45, felt46, felt47, felt48, felt49, felt50, felt51, greenZone1, greenZone2, greenZone3,
                greenZone4, greenZone5, greenZone6, blueZone1, blueZone2, blueZone3, blueZone4, blueZone5, blueZone6, yellowZone1, yellowZone2,
                yellowZone3, yellowZone4, yellowZone5, yellowZone6, redZone1, redZone2, redZone3, redZone4, redZone5, redZone6};
            


        }

        private void Btn_RollDice_Click(object sender, EventArgs e)
        {
            int x = 854, y = 358;
            
            int tal = diceRoll();
            meddelelse.Text = tal.ToString();
            dicebox.Location = new Point(x, y);
           
        }


        public int diceRoll()
        {
            Random rand = new Random();
            int roll = rand.Next(1, 7);

            dicebox.Image = diceImg[roll];
            return roll;
        }

        private void Btn_Restart_Click(object sender, EventArgs e)
        {
            numPlayers.Show();
            lbl_NoP.Show();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            this.Dispose();
           
        }

        private void NumPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            antalSp = int.Parse(numPlayers.SelectedItem.ToString());
            meddelelse.Text = g.startgame(antalSp);
            dicebox.Show();
            btn_RollDice.Show();

            numPlayers.Hide();
            lbl_NoP.Hide();
        }
    }
}
