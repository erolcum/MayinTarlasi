using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayinTarlasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int score = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            MayinDoldur(10, 10);
        }

        private void MayinDoldur(int mayin, int boyut) 
        { 
            flowLayoutPanel1.Width = 30 * boyut;
            flowLayoutPanel1.Height = 30 * boyut;
            flowLayoutPanel1.Controls.Clear();
            int[] mayinlar = new int[mayin];
            Random rnd = new Random();
            for (int i = 0; i < mayin; i++)
            {
                int mayinAdayi = rnd.Next(0, boyut * boyut);
                if (mayinlar.Contains(mayinAdayi))
                {
                    i--;
                    continue;
                }
                mayinlar[i] = mayinAdayi;

            }
            for (int i = 0; i < boyut*boyut; i++) 
            { 
                Button btn = new Button();
                btn.Width = 30;
                btn.Height = 30;
                btn.Text = "";
                btn.Margin = new Padding(0);
                btn.Tag = mayinlar.Contains(i);
                btn.Click += Btn_Click;
                flowLayoutPanel1.Controls.Add(btn);
            }
        
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if ((bool)b.Tag)
            {
                b.BackColor = Color.Red;
                OyunBitir();
            }
            else 
            { 
                b.BackColor = Color.Green;
                score++;
                txtScore.Text = score.ToString();
            }
        }

        private void OyunBitir()
        {         
            foreach (Button item in flowLayoutPanel1.Controls)
            {
                bool b = (bool)item.Tag;
                if (b)
                {
                    item.BackColor = Color.Red;
                }
                else
                {
                    item.BackColor = Color.Green;
                }
            }
            
            DialogResult result = MessageBox.Show("Yeniden oynamak ister misin?", "İster misin?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) 
            {
                MayinDoldur(10, 10);
                score = 0;
                txtScore.Text = score.ToString();
            }
            else
                Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
