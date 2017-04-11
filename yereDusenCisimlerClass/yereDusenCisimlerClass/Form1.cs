using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
    Author: Uğur Dalkıran
    Author Page: http://ugurdalkiran.com
    Version: v1
*/

namespace yereDusenCisimlerClass
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Sepet sepetim;
        DusenNesne nesneler;
        OyunStatistics istatistikler;

        public void yeniOyunOlustur()
        {
            istatistikler = new OyunStatistics();

            sepetim = new Sepet();
            sepetim.SepetiCiz(this);

            nesneler = new DusenNesne();
            nesneler.DusenNesneCiz(this);

            timer1.Start();
        }

        public void labelSettings(Label input, int renk)
        {
            if ( renk == 1 )
                input.BackColor = Color.FromArgb(230, 126, 34);
            if ( renk == 2 )
                input.BackColor = Color.FromArgb(231, 76, 60);
            input.ForeColor = Color.FromArgb(255, 255, 255);
            input.Padding = new Padding(5);
            input.AutoSize = false;
            input.TextAlign = ContentAlignment.TopLeft;
            input.Size = new Size(100, 28);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(44, 62, 80);

            labelSettings(oyunSkor, 1);
            labelSettings(oyunCani, 2);

            yeniOyunOlustur();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            sepetim.SepetiHareketEttir(e.X);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            nesneler.NesneHareketEttir();
            nesneler.NesneSepeteCarptiMi(this, sepetim, istatistikler);
            nesneler.NesneYereDustuMu(this, sepetim, istatistikler);

            oyunSkor.Text = "Skor: " + istatistikler.oyunSkorBilgi;
            oyunCani.Text = "Can: " + istatistikler.oyunCaniBilgi;

            if ( istatistikler.kutuAdetBilgi == 5)
            {
                sepetim.SepetGenislikAyarla(120);
                timer1.Interval = 19;
                istatistikler.skorArtiBilgi = 15;
            }
            else if( istatistikler.kutuAdetBilgi == 15)
            {
                sepetim.SepetGenislikAyarla(110);
                timer1.Interval = 17;
                istatistikler.skorArtiBilgi = 25;
            }
            else if (istatistikler.kutuAdetBilgi == 25)
            {
                sepetim.SepetGenislikAyarla(100);
                timer1.Interval = 15;
                istatistikler.skorArtiBilgi = 35;
            }
            else if (istatistikler.kutuAdetBilgi == 35)
            {
                sepetim.SepetGenislikAyarla(90);
                timer1.Interval = 13;
                istatistikler.skorArtiBilgi = 45;
            }
            else if (istatistikler.kutuAdetBilgi == 45)
            {
                sepetim.SepetGenislikAyarla(80);
                timer1.Interval = 11;
                istatistikler.skorArtiBilgi = 55;
            }
            else if (istatistikler.kutuAdetBilgi == 55)
            {
                sepetim.SepetGenislikAyarla(70);
                timer1.Interval = 9;
                istatistikler.skorArtiBilgi = 65;
            }
            else if (istatistikler.kutuAdetBilgi == 65)
            {
                sepetim.SepetGenislikAyarla(60);
                timer1.Interval = 7;
                istatistikler.skorArtiBilgi = 75;
            }
            else if (istatistikler.kutuAdetBilgi == 75)
            {
                sepetim.SepetGenislikAyarla(50);
                timer1.Interval = 5;
                istatistikler.skorArtiBilgi = 85;
            }
            else if (istatistikler.kutuAdetBilgi == 85)
            {
                sepetim.SepetGenislikAyarla(40);
                timer1.Interval = 3;
                istatistikler.skorArtiBilgi = 95;
            }
            else if (istatistikler.kutuAdetBilgi == 95)
            {
                sepetim.SepetGenislikAyarla(30);
                timer1.Interval = 1;
                istatistikler.skorArtiBilgi = 100;
            }

            if (istatistikler.oyunCaniBilgi == 0)
            {
                timer1.Stop();
                MessageBox.Show("Kaybettin, oysaki buraya kadar iyi gelmiştin.");
                sepetim.SepetiSil(this);
                yeniOyunOlustur();
            }
        }
    }
}
