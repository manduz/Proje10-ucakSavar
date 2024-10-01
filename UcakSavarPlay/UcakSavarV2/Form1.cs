using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UcakSavarV2.Properties;

namespace UcakSavarV2
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
        ArrayList dusmanUcak = new ArrayList();
        ArrayList mermiList = new ArrayList();
        void UcakSavarHareket(KeyEventArgs e)
        {

            int ucakSavarx = ucakSavar.Location.X;
            int ucakSavary = ucakSavar.Location.Y;

            if (e.KeyCode == Keys.Right)
                ucakSavarx += 5;
            else if (e.KeyCode == Keys.Left)
                ucakSavarx -= 5;
            ucakSavar.Location = new Point(ucakSavarx, ucakSavary);
            this.Controls.Add(ucakSavar);
         
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            ucakSavar.Image =Resources.ucaksavar ;
            this.Controls.Add(ucakSavar);
            ucakSavar.Location = new Point(300, 500);
            timer1.Enabled = true;
         
          

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            UcakSavarHareket(e);
            if (e.KeyCode == Keys.Space)
            {

             mermiList.Add( MermiUret());
                timer2.Enabled = true;
            }
           
        }

        PictureBox UcakUret()
        {
            
            PictureBox ucak = new PictureBox();
            ucak.Image = Resources.ucak;
            Random rnd = new Random();
            int ucakBaslax = rnd.Next(1000);
            ucak.Location = new Point(ucakBaslax, 0);
            timer3.Enabled = true;
            return ucak;;

        }
       
        void UcakHareket(PictureBox ucak)
        {

            //ucak.Image = Resources.ucak;
            int x = ucak.Location.X;
            int y = ucak.Location.Y;
            y += 5;
            ucak.Location = new Point(x, y);
            this.Controls.Add(ucak);
        }
        PictureBox MermiUret()
        {

            PictureBox mermi = new PictureBox();
            mermi.Image = Resources.mermi;
            mermi.SizeMode = PictureBoxSizeMode.StretchImage;
            mermi.Location = new Point(ucakSavar.Location.X, ucakSavar.Location.Y);
            this.Controls.Add(mermi);   
            return mermi ;
            
        }
        void MermiHareket(PictureBox mermi)
        {

            mermi.Image = Resources.mermi;
            int x = mermi.Location.X;
            int y = mermi.Location.Y;
            y -= 5;
            mermi .Location = new Point(x, y);
            this.Controls.Add(mermi);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            dusmanUcak.Add(UcakUret());
            foreach (PictureBox item1 in dusmanUcak)
            {
               
                UcakHareket(item1);
            }
           
           
           
        }
        int sayi = 0;

        private void timer2_Tick(object sender, EventArgs e)
        {
            foreach (PictureBox item2 in mermiList)
            {

                MermiHareket(item2);
            }
        }

        PictureBox kaldirilanUcaklar = new PictureBox();
        PictureBox kaldirilanMermiler = new PictureBox();
        private void timer3_Tick(object sender, EventArgs e)
        {
            

                foreach (PictureBox item1 in mermiList )
                {
                    foreach (PictureBox item2 in dusmanUcak)
                    {
                        if (item1.Bounds.IntersectsWith(item2.Bounds))
                        {
                            this.Controls.Remove(item1);
                            this.Controls.Remove(item2);
                             kaldirilanMermiler = item1;
                             kaldirilanUcaklar = item2;
                             sayi++;
                            label2.Text = sayi.ToString();



                    }
                        
                    }
                       
                }
            
            mermiList.Remove(kaldirilanMermiler);
            dusmanUcak.Remove(kaldirilanUcaklar);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
