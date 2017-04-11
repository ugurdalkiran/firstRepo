using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // PictureBox create edebilmek için..
using System.Drawing; // PictureBox drawing edebilmek için..
using System.Media; // SoundPlayer için..

/*
    Author: Uğur Dalkıran
    Author Page: http://ugurdalkiran.com
    Version: v1
*/

namespace yereDusenCisimlerClass
{
    abstract class KutuAna
    {
        protected int yukseklik;
        protected int genisliki;
        protected int locationX;
        protected int locationY;
        protected int renkR;
        protected int renkG;
        protected int renkB;
    }
    class Sepet:KutuAna
    {
        PictureBox sepet;
        public Sepet()
        {
            yukseklik = 7;
            genisliki = 130;
            renkR = 241;
            renkG = 196;
            renkB = 15;
        }
        public void SepetiCiz(Form formumuz)
        {
            sepet = new PictureBox();
            sepet.Size = new Size(genisliki, yukseklik);
            sepet.BackColor = Color.FromArgb(renkR, renkG, renkB);

            int hesap = yukseklik + 38;

            locationX = (formumuz.Size.Width / 2) - (sepet.Size.Width / 2);
            locationY = formumuz.Size.Height - hesap;

            sepet.Location = new Point(locationX, locationY);
            formumuz.Controls.Add(sepet);
        }
        public void SepetiHareketEttir(int comX)
        {
            sepet.Left = comX - (sepet.Size.Width / 2);
        }
        public int SepetKordinatGoster(string istenen)
        {
            if ( istenen == "Top")
            {
                return sepet.Top;
            }
            else if( istenen == "Right")
            {
                return sepet.Right;
            }
            else if ( istenen == "Left")
            {
                return sepet.Left;
            }else
            {
                return 0;
            }
        }
        public void SepetiSil(Form formumuz)
        {
            formumuz.Controls.Remove(sepet);
        }
        public void SepetGenislikAyarla(int newGenislik)
        {
            sepet.Size = new Size(newGenislik, yukseklik);
        }
    }
    class DusenNesne : KutuAna
    {
        PictureBox nesne;
        SoundPlayer sesler;
        public DusenNesne()
        {
            yukseklik = 18;
            genisliki = 18;
            locationY = 0 - yukseklik;
            sesler = new SoundPlayer();
        }
        public void DusenNesneCiz(Form formumuz)
        {
            Random ras = new Random();

            locationX = ras.Next(0, formumuz.Size.Width - 34);

            renkR = ras.Next(0, 255);
            renkG = ras.Next(0, 255);
            renkB = ras.Next(0, 255);

            nesne = new PictureBox();
            nesne.Size = new Size(genisliki, yukseklik);
            nesne.BackColor = Color.FromArgb(renkR, renkG, renkB);
            nesne.Location = new Point(locationX, locationY);

            /* Oval Yap - Start */
            int ovalDegeri = 2;
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, nesne.Width - ovalDegeri, nesne.Height - ovalDegeri);
            Region oval = new Region(gp);
            /* Oval Yap - End */

            nesne.Region = oval;
            formumuz.Controls.Add(nesne);
        }
        public void NesneHareketEttir()
        {
            nesne.Top = nesne.Top + 5;
        }
        public void NesneSepeteCarptiMi(Form formumuz, Sepet sepetGelen, OyunStatistics bilgiler)
        {
            if ( nesne.Bottom == sepetGelen.SepetKordinatGoster("Top") && nesne.Left >= sepetGelen.SepetKordinatGoster("Left") && nesne.Right <= sepetGelen.SepetKordinatGoster("Right") )
            {
                sesler.SoundLocation = "basarili.wav";
                sesler.Play();
                formumuz.Controls.Remove(nesne);
                bilgiler.oyunSkorBilgi = bilgiler.oyunSkorBilgi + bilgiler.skorArtiBilgi;
                bilgiler.kutuAdetBilgi = bilgiler.kutuAdetBilgi + 1;
                DusenNesneCiz(formumuz);
            }
        }
        public void NesneYereDustuMu(Form formumuz, Sepet sepetGelen, OyunStatistics bilgiler)
        {
            if ( nesne.Bottom == formumuz.Height)
            {
                sesler.SoundLocation = "basarisiz.wav";
                sesler.Play();
                formumuz.Controls.Remove(nesne);
                bilgiler.oyunSkorBilgi = bilgiler.oyunSkorBilgi - bilgiler.skorArtiBilgi;
                bilgiler.oyunCaniBilgi = bilgiler.oyunCaniBilgi - 1;
                bilgiler.kutuAdetBilgi = bilgiler.kutuAdetBilgi + 1;
                DusenNesneCiz(formumuz);
            }
        }
    }
    class OyunStatistics
    {
        private int oyunSkor;
        private int oyunCani;
        private int skorArti;
        private int kutuAdet;
        
        public OyunStatistics()
        {
            oyunSkor = 0;
            oyunCani = 3;
            skorArti = 10;
            kutuAdet = 0;
        }
        public int oyunSkorBilgi
        {
            get { return oyunSkor; }
            set { oyunSkor = value; }
        }
        public int oyunCaniBilgi
        {
            get { return oyunCani; }
            set { oyunCani = value; }
        }
        public int skorArtiBilgi
        {
            get { return skorArti; }
            set { skorArti = value; }
        }
        public int kutuAdetBilgi
        {
            get { return kutuAdet; }
            set { kutuAdet = value; }
        }
    }
}
