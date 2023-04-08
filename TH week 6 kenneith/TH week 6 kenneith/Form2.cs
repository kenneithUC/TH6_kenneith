using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TH_week_6_kenneith
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Button[,] tempatnebak;
        Button tempatkey,enter,delete;
        int x, y,panjangkata,guessbrpkali,keyboardx,keyboardy,posisiguessx,posisiguessy,lebarkeyboard;
        string[] keyboard;
        string kata = "";
        List<string>wordleword=new List<string>();
        string answer;
        private void Form2_Load(object sender, EventArgs e)
        {
            x = 10;
            y = 10;
            int totalangka= 26;
            panjangkata = 5;
            guessbrpkali = Form1.input;
            tempatnebak = new Button[panjangkata, guessbrpkali];
            keyboard= new string[26] {"Q","W","E","R","T","Y","U","I","O","P","A","S","D","F","G","H","J","K","L","Z","X","C","V","B","N","M"};
            posisiguessx = 0;
            posisiguessy = 0;
            for(int i = 0; i < panjangkata; i++)
            {
                for (int j = 0; j <guessbrpkali; j++)
                {
                    tempatnebak[i, j] = new Button();
                    tempatnebak[i, j].Tag = i.ToString() + "," + j.ToString();
                    tempatnebak[i, j].Size = new Size(50, 50);
                    tempatnebak[i, j].Location = new Point(x, y);
                    this.Controls.Add(tempatnebak[i,j]);
                    y+= 50;
                }
                y= 10;
                x+= 50;
            }
            keyboardx = 300;
            keyboardy = 10;
            for(int u=0; u <totalangka; u++)
            {
                if(u==10)
                {
                    keyboardx = 330;
                    keyboardy = 70;
                }
                if(u==19)
                {
                    keyboardx = 390;
                    keyboardy = 130;
                }
                tempatkey = new Button();
                tempatkey.Text = keyboard[u];
                tempatkey.Size = new Size(50, 50);
                tempatkey.Location = new Point(keyboardx, keyboardy);
                this.Controls.Add(tempatkey);
                tempatkey.Click += key_click;
                keyboardx += 60;
            }
            delete = new Button();
            delete.Text = "Delete";
            delete.Size = new Size(80,50);
            delete.Location = new Point(810, 130);
            this.Controls.Add(delete);
            delete.Click += delete_click;

            enter=new Button();
            enter.Text = "Enter";
            enter.Size = new Size(80, 50);
            enter.Location = new Point(300, 130);
            this.Controls.Add(enter);
            enter.Click += enter_click;

            string[] wordlines = File.ReadAllLines("Wordle Word List.txt");
            foreach (string word in wordlines)
            {
                wordleword.AddRange(word.Split(','));
            }
            answer = wordleword[new Random().Next(0, wordleword.Count - 1)].ToUpper();
            MessageBox.Show(answer);
        }

        private void key_click(object sender,EventArgs e)
        {
            var key = sender as Button;
            if (posisiguessx < 5)
            {
                tempatnebak[posisiguessx, posisiguessy].Text = key.Text;
                posisiguessx++;
            }
        }
        private void delete_click(object sender,EventArgs e)
        {
            if(posisiguessx>0)
            {
                posisiguessx--;
                tempatnebak[posisiguessx, posisiguessy].Text ="";
            }
        }
        private void enter_click(object sender,EventArgs e)
        {
            int green=0;
            int yellow = 0;
            if(posisiguessx!=5)
            {
                MessageBox.Show("harus isi satu baris baru bisa enter", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                for (int l = 0; l < panjangkata; l++)
                {
                    kata += tempatnebak[l, posisiguessy].Text;
                }
                if (wordleword.Contains(kata.ToLower()))
                {
                    foreach (char kata in answer)
                    {
                        for (int l = 0; l < panjangkata; l++)
                        {
                            if (tempatnebak[l, posisiguessy].Text == kata.ToString())
                            {
                                green++;
                                tempatnebak[l, posisiguessy].BackColor = Color.Green;
                            }
                            if (tempatnebak[l, posisiguessy].Text.Contains(kata.ToString()) && tempatnebak[l, posisiguessy].Text != answer[l].ToString())
                            {
                                tempatnebak[l, posisiguessy].BackColor = Color.Yellow;
                            }
                        }
                    }
                    posisiguessx = 0;
                    posisiguessy++;
                    kata = "";
                    if(green==5)
                    {
                        MessageBox.Show("Yay kata ditemukan!!!", "", MessageBoxButtons.OK);
                    }

                }
                else
                {
                    MessageBox.Show("Kata tidak ada dalam wordle word list", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    kata = "";
                }
            }
        }
    }
}
