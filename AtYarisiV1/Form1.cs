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

        //Todo list;
        //Create a class for horses and call all horses from there


        //Define all variables in global scope to avoid unnecessary RAM usage
        Random random = new Random();
        int sure = 0, sureSaniye;
        int ortaUzaklik, bitisUzaklik;
        int birinciAt, ikinciAt, ucuncuAt;
        string dizin;

        int CheckpointFlag = 0;
        int TimeFlag;

        public Form1()
        {
            InitializeComponent();
            //Reset all start points on create
            AtSifirla();

            //Automatically refers to programs Bin\Debug folder
            dizin = Application.StartupPath.ToString();
            try
            {
                //Find better way to do this or make it work with standalone .exe file
                axWindowsMediaPlayer1.URL = dizin + "\\Sounds\\blabla.mp3";
                axWindowsMediaPlayer2.URL = dizin + "\\Sounds\\HorseSfx.mp3";
                axWindowsMediaPlayer2.Ctlcontrols.stop();
            }
            catch
            {
                //add exception message here
            }
            
        }
        //Sea Mode
        private void ClearLabel(int mode)
        {
            Label[] labels = new Label[]
            {
                label3,label8,label9,label5,label6,label7,label10,label11,label12,label14,label15,checkpointLabel
            };
            for (int i = 0; i < labels.Length; i++)
            {
                if(mode == 1)
                {
                    labels[i].Visible = false;
                }
                else
                {
                    labels[i].Visible = true;
                }
            }

        }
        private void ClearWave(int mode)
        {
            PictureBox[] waves = new PictureBox[]
            {
                wave1,wave2,wave3
            };
            for(int i = 0; i < waves.Length; i++)
            {
                if(mode == 1)
                {
                    waves[i].Visible = true;
                }
                else
                {
                    waves[i].Visible = false;
                }
            }
        }
        private void SeaColors()
        {
            ClearLabel(1);
            ClearWave(1);
            this.BackColor = Color.FromArgb(0, 123, 255);
            this.Text = "Mert KARACA - Deniz Atı Yarışı";
            pictureBox1.Image = Image.FromFile(dizin + "\\Images\\kirmizi.gif");
            pictureBox2.Image = Image.FromFile(dizin + "\\Images\\gri.gif");
            pictureBox3.Image = Image.FromFile(dizin + "\\Images\\mavi.gif");
            label16.BackColor = Color.FromArgb(0, 123, 255);
            label17.BackColor = Color.FromArgb(0, 123, 255);
            at1label.BackColor = Color.FromArgb(0, 123, 255);
            at2label.BackColor = Color.FromArgb(0, 123, 255);
            at3label.BackColor = Color.FromArgb(0, 123, 255);
            at1label.Text = "Gülsubatur";
            at2label.Text = "Şahsubatur";
            at3label.Text = "Hidalsu";
        }
        private void LandColors()
        {
            ClearLabel(2);
            ClearWave(2);
            this.BackColor = Color.Green;
            this.Text = "Mert KARACA - At Yarışı";
            pictureBox1.Image = Image.FromFile(dizin + "\\Images\\1.gif");
            pictureBox2.Image = Image.FromFile(dizin + "\\Images\\2.gif");
            pictureBox3.Image = Image.FromFile(dizin + "\\Images\\3.gif");
            label16.BackColor = Color.Green;
            label17.BackColor = Color.Green;
            at1label.BackColor = Color.Green;
            at2label.BackColor = Color.Green;
            at3label.BackColor = Color.Green;
            at1label.Text = "Gülbatur";
            at2label.Text = "Şahbatur";
            at3label.Text = "Hidalgo";
        }
        private void RaceMode_Click(object sender, EventArgs e)
        {
            if (raceMode.Text == "Deniz")
            {
                SeaColors();
                raceMode.Text = "Kara";
                raceMode.BackColor = Color.Green;
            }
            else
            {
                LandColors();
                raceMode.Text = "Deniz";
                raceMode.BackColor = Color.FromArgb(0, 123, 255);

            }
        }
        //Sea Mode end

        //Start-Stop button

        private void StartButton_Click(object sender, EventArgs e)
        {
            //It's just for using same button both for start and stop purposes
            if (timer1.Enabled == false)
            {
                timer1.Start();
                startButton.Text = "Durdur";
                startButton.BackColor = Color.FromArgb(255, 53, 71);
                HorseSfx(1);
            }
            else
            {
                timer1.Stop();
                startButton.Text = "Başlat";
                startButton.BackColor = Color.FromArgb(0, 200, 81);
                HorseSfx(2);
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
            //All changes below resets all values to default as application start
            timeLabel.Text = "0";
            time2label.Text = "0";

            yarisBilgisiLabel.Text = "...";
            yarisBilgisi2Label.Text = "...";

            TimeFlag++;
            CheckpointFlag++;

            timer1.Stop();
            startButton.Text = "Başlat";
            startButton.BackColor = Color.FromArgb(0, 200, 81);

            AtSifirla();
            HorseSfx(2);
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

        void HorseSfx(int deger)
        {
            if (deger == 1)
            {
                axWindowsMediaPlayer2.Ctlcontrols.play();
            }
            else if (deger == 2)
            {
                axWindowsMediaPlayer2.Ctlcontrols.pause();
            }
            else if (deger == 3)
            {
                axWindowsMediaPlayer2.Ctlcontrols.stop();
            }
        }
        void AtSifirla()
        {
            pictureBox1.Left = 45;
            pictureBox2.Left = 45;
            pictureBox3.Left = 45;

            at1label.Left = 45;
            at2label.Left = 45;
            at3label.Left = 45;

            at1500Label.Left = 45;
            at2500Label.Left = 45;
            at3500Label.Left = 45;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

            //If control to avoid time and checkpoint 
            if (TimeFlag != 0)
            {
                sure = 0;
                TimeFlag = 0;
                CheckpointFlag = 0;
            }


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
            at3500Label.Left += ucuncuAt;

            //Who is leading check
            if (pictureBox1.Left > pictureBox2.Left && pictureBox1.Left > pictureBox3.Left)
            {
                yarisBilgisiLabel.Text = "1 Numaralı " + at1label.Text + " önde";
            }
            if (pictureBox2.Left > pictureBox1.Left && pictureBox2.Left > pictureBox3.Left)
            {
                yarisBilgisiLabel.Text = "1 Numaralı " + at2label.Text + " önde";
            }
            if (pictureBox3.Left > pictureBox1.Left && pictureBox3.Left > pictureBox2.Left)
            {
                yarisBilgisiLabel.Text = "1 Numaralı " + at3label.Text + " önde";
            }

            //Checkpoint Check
            if (pictureBox1.Width + at1500Label.Left >= ortaUzaklik && CheckpointFlag == 0)
            {
                yarisBilgisi2Label.Text = "500m'ye " + at1label.Text + " önde girdi";
                CheckpointFlag++;

            }

            else if (pictureBox2.Width + at2500Label.Left >= ortaUzaklik && CheckpointFlag == 0)
            {
                yarisBilgisi2Label.Text = "500m'ye " + at2label.Text + " önde girdi";
                CheckpointFlag++;
            }

            else if (pictureBox3.Width + at3500Label.Left >= ortaUzaklik && CheckpointFlag == 0)
            {
                yarisBilgisi2Label.Text = "500m'ye " + at3label.Text + " önde girdi";
                CheckpointFlag++;
            }

            //Finish Check
            if (pictureBox1.Width + pictureBox1.Left >= bitisUzaklik)
            {
                timer1.Stop();
                yarisBilgisiLabel.Text = "50. yıl gazi koşusunu " + at1label.Text + " kazandı";
            }

            if (pictureBox2.Width + pictureBox2.Left >= bitisUzaklik)
            {
                timer1.Stop();
                yarisBilgisiLabel.Text = "50. yıl gazi koşusunu " + at2label.Text + " kazandı";
            }

            if (pictureBox3.Width + pictureBox3.Left >= bitisUzaklik)
            {
                timer1.Stop();
                yarisBilgisiLabel.Text = "50. yıl gazi koşusunu " + at3label.Text + " kazandı";
            }
        }
    }
}
