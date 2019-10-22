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
            //Reset all start points on create
            pictureBox1.Left = 32;
            at1label.Left = 45;
            at1500Label.Left = 45;

            pictureBox2.Left = 32;
            at2label.Left = 45;
            at1500Label.Left = 45;

            pictureBox3.Left = 32;
            at3label.Left = 45;
            at1500Label.Left = 45;


            axWindowsMediaPlayer1.URL = "C:\\Users\\selef\\Desktop\\ders\\dersbla.mp3";
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            //It's just for using same button both for start and stop purposes
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                startButton.Text = "Durdur";
                startButton.BackColor = Color.FromArgb(255, 53, 71);
                MusicPlay(1);
            }
            else
            {
                timer1.Enabled = false;
                startButton.Text = "Başlat";
                startButton.BackColor = Color.FromArgb(0, 200, 81);
                MusicPlay(2);
            }
        }

        //Define all variables in global scope to avoid unnecessary RAM usage
        Random random = new Random();
        int sure = 0, sureSaniye;
        int ortaUzaklik,bitisUzaklik;
        int birinciAt,ikinciAt,ucuncuAt;

        private void Play_Click(object sender, EventArgs e)
        {
            if(play.Text == "Play")
            {
                play.Text = "Pause";
                play.BackColor = Color.FromArgb(255, 53, 71);
                MusicPlay(1);
            }
            else
            {
                play.Text = "Play";
                play.BackColor = Color.FromArgb(0, 200, 81);
                MusicPlay(2);
            }
        }

        int Rastgele()
        {
            int a = random.Next(1, 10);
            return a;
        }
        
        void MusicPlay(int deger)
        {
            if(deger == 1)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            else if(deger == 2)
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
            }
            else if(deger == 3)
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = sure.ToString();
            sure++;
            sureSaniye = sure / 5;
            time2label.Text = sureSaniye.ToString() + " Saniye";

            //Defining a variable to hold checkpoint and finish points position. 
            bitisUzaklik = finishLabel.Left;
            ortaUzaklik = checkpointLabel.Left;

            //Random integer variable for next step
            birinciAt = Rastgele();
            ikinciAt = Rastgele();
            ucuncuAt = Rastgele();

            //All horse visuals labels accerelates randomly with their own label descriptions
            pictureBox1.Left += birinciAt;
            at1label.Left += birinciAt;
            at1500Label.Left += birinciAt;

            pictureBox2.Left += ikinciAt;
            at2label.Left += ikinciAt;
            at2500Label.Left += ikinciAt;

            pictureBox3.Left += ucuncuAt;
            at3label.Left += ucuncuAt;
            label13.Left += ucuncuAt;

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
            ////Burası 500m de problem yapıyor. İlk gireni yazıyor en son gireni kontrole devam ettiği için yazmaya devam ediyor. Burayı hallet.
            if (pictureBox1.Width + at1500Label.Left >= ortaUzaklik)
            {
                yarisBilgisi2Label.Text = "500m'ye Gülbatur önde girdi";
            }

            else if (pictureBox2.Width + at2500Label.Left >= ortaUzaklik)
            {
                yarisBilgisi2Label.Text = "500m'ye Şahbatur önde girdi";
            }

            else if (pictureBox3.Width + label13.Left >= ortaUzaklik)
            {
                yarisBilgisi2Label.Text = "500m'ye Hidalgo önde girdi";
            }
            //çözüm ek label ekle her bir item için. Hepsini visible false yap. 500m e geldiğinde konusu kapansın...

            //Finish Check
            if (pictureBox1.Width + pictureBox1.Left >= bitisUzaklik)
            {
                timer1.Enabled = false;
                yarisBilgisiLabel.Text = "50. yıl gazi koşusunu Gülbatur kazandı";
            }

            if (pictureBox2.Width + pictureBox2.Left >= bitisUzaklik)
            {
                timer1.Enabled = false;
                yarisBilgisiLabel.Text = "50. yıl gazi koşusunu Şahbatur kazandı";
            }

            if (pictureBox3.Width + pictureBox3.Left >= bitisUzaklik)
            {
                timer1.Enabled = false;
                yarisBilgisiLabel.Text = "50. yıl gazi koşusunu Hidalgo kazandı";
            }


        }
        private void ResetButton_Click(object sender, EventArgs e)
        {
            timeLabel.Text = "0";
            time2label.Text = "0";
            timer1.Enabled = false;
            startButton.Text = "Başlat";
            startButton.BackColor = Color.FromArgb(0, 200, 81);

            pictureBox1.Left = 32;
            at1label.Left = 45;
            at1500Label.Left = 45;

            pictureBox2.Left = 32;
            at2label.Left = 45;
            at1500Label.Left = 45;

            pictureBox3.Left = 32;
            at3label.Left = 45;
            at1500Label.Left = 45;
        }

    }
}
