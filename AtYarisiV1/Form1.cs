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
        //Problem list;
        //When reset button clicked timer stops and second text going 0 but if start button clicked after that, second turn back to last state
        //Will add horse sfx on start button click
        //Wİll add another music to play button
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

            //Automatically refers to programs Bin\Debug folder
            string dizin = Application.StartupPath.ToString();
            try
            {
                //Find better way to do this or make it work with standalone .exe file
                axWindowsMediaPlayer1.URL = dizin + "\\blabla.mp3";
            }
            catch
            {
                //add exception message here
            }
            
        }

        //Start-Stop button
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

        //Play-Pause button for music control
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

        private void ResetButton_Click(object sender, EventArgs e)
        {
            //All changes below is reset all values to default as application start

            //Time labels not working properly. When start button clicked after reset button, this values turn back to saved ones.
            timeLabel.Text = "0";
            time2label.Text = "0";

            yarisBilgisiLabel.Text = "...";
            yarisBilgisi2Label.Text = "...";

            CheckpointFlag = 0;


            timer1.Enabled = false;
            startButton.Text = "Başlat";
            startButton.BackColor = Color.FromArgb(0, 200, 81);

            //Horse and label positions

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

        //Function for create random int value
        int Rastgele()
        {
            int a = random.Next(1, 10);
            return a;
        }
        
        //Function for call media events 
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

        //Define all variables in global scope to avoid unnecessary RAM usage
        Random random = new Random();
        int sure = 0, sureSaniye;
        int ortaUzaklik, bitisUzaklik;
        int birinciAt, ikinciAt, ucuncuAt;
        int CheckpointFlag = 0;
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
            if (pictureBox1.Width + at1500Label.Left >= ortaUzaklik && CheckpointFlag == 0)
            {
                yarisBilgisi2Label.Text = "500m'ye Gülbatur önde girdi";
                CheckpointFlag++;
            }

            else if (pictureBox2.Width + at2500Label.Left >= ortaUzaklik && CheckpointFlag == 0)
            {
                yarisBilgisi2Label.Text = "500m'ye Şahbatur önde girdi";
                CheckpointFlag++;
            }

            else if (pictureBox3.Width + label13.Left >= ortaUzaklik && CheckpointFlag == 0)
            {
                yarisBilgisi2Label.Text = "500m'ye Hidalgo önde girdi";
                CheckpointFlag++;
            }

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
        

    }
}
