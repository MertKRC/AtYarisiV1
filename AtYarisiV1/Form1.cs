using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtYarisiV1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            //It's just for using same button both for start and stop purposes
            if(timer1.Enabled == false)
            {
                timer1.Enabled = true;
                startButton.Text = "Durdur";
                startButton.BackColor = Color.FromArgb(255, 53, 71);
            }
            else
            {
                timer1.Enabled = false;
                startButton.Text = "Başlat";
                startButton.BackColor = Color.FromArgb(0, 200, 81);
            }
        }

        Random rastgele = new Random();

        private void Timer1_Tick(object sender, EventArgs e)
        {
            int sure = Convert.ToInt32(timeLabel.Text);
            sure++;
            int sureSaniye = sure / 5;
            timeLabel.Text = sure.ToString();
            time2label.Text = sureSaniye.ToString() + " Saniye";

            //Defining a variable to hold horse visuals width. It's for checkpoint and finish check.
            int birGenislik = pictureBox1.Width;
            int ikiGenislik = pictureBox2.Width;
            int ucGenislik = pictureBox3.Width;

            //Defining a variable to hold checkpoint and finish points position. 
            int bitisUzaklik = finishLabel.Left;
            int ortaUzaklik = checkpointLabel.Left;

            //Random integer variable for next step
            int birinciAt = rastgele.Next(1, 10);
            int ikinciAt = rastgele.Next(1, 10);
            int ucuncuAt = rastgele.Next(1, 10);

            //All horse visuals labels accerelates randomly with their label descriptions
            pictureBox1.Left += birinciAt;
            at1label.Left += birinciAt;

            pictureBox2.Left += ikinciAt;
            at2label.Left += ikinciAt;

            pictureBox3.Left += ucuncuAt;
            at3label.Left += ucuncuAt;

            //Who is leading check
            if (pictureBox1.Left > pictureBox2.Left && pictureBox1.Left > pictureBox3.Left)
            {
                yarisBilgisiLabel.Text = "1 Numaralı Gülbatur önde";
            }
            if (pictureBox2.Left > pictureBox1.Left && pictureBox2.Left > pictureBox3.Left)
            {
                yarisBilgisiLabel.Text = "2 Numaralı Şahbatur önde";
            }
            if (pictureBox3.Left > pictureBox1.Left && pictureBox3.Left > pictureBox2.Left)
            {
                yarisBilgisiLabel.Text = "3 Numaralı Hidalgo önde";
            }

            //Checkpoint Check
            if (birGenislik + pictureBox1.Left >= ortaUzaklik)
            {
                yarisBilgisi2Label.Text = "500m'ye Gülbatur önde girdi";
            }

            if (ikiGenislik + pictureBox2.Left >= ortaUzaklik)
            {
                yarisBilgisi2Label.Text = "500m'ye Şahbatur önde girdi";
            }

            if (ucGenislik + pictureBox3.Left >= ortaUzaklik)
            {
                yarisBilgisi2Label.Text = "500m'ye Hidalgo önde girdi";
            }

            //Finish Check
            if (birGenislik + pictureBox1.Left >= bitisUzaklik)
            {
                timer1.Enabled = false;
                yarisBilgisiLabel.Text = "50. yıl gazi koşusunu Gülbatur kazandı";
            }

            if (ikiGenislik + pictureBox2.Left >= bitisUzaklik)
            {
                timer1.Enabled = false;
                yarisBilgisiLabel.Text = "50. yıl gazi koşusunu Şahbatur kazandı";
            }

            if (ucGenislik + pictureBox3.Left >= bitisUzaklik)
            {
                timer1.Enabled = false;
                yarisBilgisiLabel.Text = "50. yıl gazi koşusunu Hidalgo kazandı";
            }


        }
        //Buradan devam et
        private void ResetButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
