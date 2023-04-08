using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TH_week_6_kenneith
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Label wordle,intro;
        Button play;
        TextBox isi;
        public static int input;
        private void Form1_Load(object sender, EventArgs e)
        {
            wordle = new Label();
            wordle.Text = "WORDLE";
            wordle.Location = new Point(85, 80);
            wordle.Size = new Size(200, 40);
            wordle.Font = new Font("Arial", wordle.Font.Size * 3, FontStyle.Bold);
            this.Controls.Add(wordle);

            intro = new Label();
            intro.Text = "Set How Much You Can Guess!";
            intro.Location = new Point(85, 120);
            intro.Size = new Size(300, 20);
            intro.Font = new Font("Arial", intro.Font.Size);
            this.Controls.Add(intro);

            isi = new TextBox();
            isi.Location = new Point(115, 140);
            isi.Size = new Size(100, 90);
            this.Controls.Add(isi);

            play = new Button();
            play.Text = "PLAY!";
            play.Location = new Point(127, 165);
            play.Size = new Size(70, 20);
            play.Click += btn_play_click;
            this.Controls.Add(play);
        }
        private void btn_play_click(object sender,EventArgs e)
        {
            if(!int.TryParse(isi.Text, out input))
            {
                MessageBox.Show("Pls fill a number", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(Convert.ToInt32(isi.Text)<=3)
            {
                MessageBox.Show("Number must be greater than 3","",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                input = Convert.ToInt32(isi.Text);
                Form2 formgame = new Form2();
                formgame.Show();
            }
        }
    }
}
