using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UcakSavarOyunu.Properties;

namespace UcakSavarOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        PictureBox ucakSavar = new PictureBox();
        PictureBox ucak = new PictureBox();
        PictureBox mermi = new PictureBox();

        ArrayList mermiList = new ArrayList();
        ArrayList dusmanUcak = new ArrayList();

        private void Form1_Load(object sender, EventArgs e)
        {

            ucakSavar.Image = Resources.ucakSavar;
            this.Controls.Add(ucakSavar);
            ucakSavar.Location = new Point(300, 300);
            ucakSavar.Size = new Size(300, 300);
            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dusmanUcak.Add(ucakUret());

            foreach (PictureBox item in dusmanUcak)
            {
                ucakHareket(item);
            }
        }

        private void ucakHareket(PictureBox item)
        {
            ucak.Image = Resources.ucak;
            int x = ucak.Location.X;
            int y = ucak.Location.Y;
            y = y + 5;
            ucak.Location = new Point(x, y);
            this.Controls.Add(ucak);
        }

        private object ucakUret()
        {
            PictureBox ucak = new PictureBox();
            ucak.Image = Resources.ucak;
            Random random = new Random();
            int ucakBaslat = random.Next(1000);
            ucak.Location = new Point(ucakBaslat,0);
            return ucak;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            ucakSavarHareket(e);
            if(e.KeyCode == Keys.Space)
            {
                mermiList.Add(MermiUret());
                timer2.Enabled = true;
            }
        }

        private object MermiUret()
        {
            PictureBox mermi = new PictureBox();
            mermi.Image = Resources.mermitek;
            mermi.SizeMode = PictureBoxSizeMode.StretchImage;
            mermi.Location = new Point(ucakSavar.Location.X,ucakSavar.Location.Y);
            this.Controls.Add(mermi);
            return mermi;
        }

        private void ucakSavarHareket(KeyEventArgs e)
        {
           int ucakSavarx = ucakSavar.Location.X;
           int ucakSavary = ucakSavar.Location.Y;
            if (e.KeyCode == Keys.Right)
            {
                ucakSavarx += 5;
            }
            else if (e.KeyCode == Keys.Left)
            {
                ucakSavarx -= 5;
            }
            ucakSavar.Location = new Point(ucakSavarx, ucakSavary);
                this.Controls.Add(ucakSavar);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            foreach (PictureBox item in mermiList)
            {
                mermiHareket(item);
            }
        }

        private void mermiHareket(PictureBox mermi)//item = mermi
        {
            mermi.Image = Resources.mermi;
            int x = mermi.Location.X;
            int y = mermi.Location.Y;
            y = y - 5; //mermi yukarı çıkacak
            mermi.Location = new Point(x, y);
            this.Controls.Add(mermi);
        }

        private int sayi = 0;
        PictureBox kaldirilanUcaklar =  new PictureBox();
        PictureBox kaldirilanMermiler = new PictureBox();

        private void timer3_Tick(object sender, EventArgs e)
        {
            foreach (PictureBox item in mermiList)
            {
                foreach (PictureBox item1 in dusmanUcak)
                {
                    if (item.Bounds.IntersectsWith(item1.Bounds))
                    {
                        this.Controls.Remove(item);
                        this.Controls.Remove(item1);
                        kaldirilanMermiler = item;
                        kaldirilanUcaklar = item1;
                        sayi++;
                        label2.Text = sayi.ToString();
                    }
                }
            }
            mermiList.Remove(kaldirilanMermiler);
            dusmanUcak.Remove(kaldirilanUcaklar);
        }
    }
}
