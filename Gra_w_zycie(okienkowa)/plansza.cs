using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Gra_w_zycie_okienkowa_
{
    internal class plansza
    {
        public plansza(int wielkosc)
        {
            bitmapa = new Bitmap(wielkosc, wielkosc);
            rysopwnik = Graphics.FromImage(bitmapa);
            olowek = new Pen(Color.Red);
            wielkosckomorki = wielkosc / ilosckomorek;
            kolorkomorki = new SolidBrush(Color.DarkGreen);
            kolorkomorkiPozniej = new SolidBrush(Color.White);
            komorkiteraz = new komorki(100);
            komorkipozniej = new komorki(100);
            pokolenie = 0;
        }

        public Bitmap bitmapa;
        private Graphics rysopwnik;
        private Pen olowek;
        private int ilosckomorek = 15;
        private float wielkosckomorki;
        private komorki komorkiteraz, komorkipozniej;
        private SolidBrush kolorkomorki, kolorkomorkiPozniej;
        public int pokolenie;

        public void funkcja()
        {
        }

        public void ZmienRozmiarSiatki(int r, int p)
        {
            ilosckomorek = r;
            ilosckomorek = p;
            wielkosckomorki = bitmapa.Size.Height / ilosckomorek;
            komorkiteraz = new komorki(ilosckomorek);
            komorkipozniej = new komorki(ilosckomorek);
            Rysujsiatke();
        }

        private void Rysujsiatke()
        {
            for (int i = 1; i < ilosckomorek; i++)
            {
                rysopwnik.DrawLine(olowek, i * wielkosckomorki, 0, i * wielkosckomorki, bitmapa.Size.Height);
                rysopwnik.DrawLine(olowek, 0, i * wielkosckomorki, bitmapa.Size.Height, i * wielkosckomorki);
            }
        }

        public void RysujKomorki()
        {
            for (int i = 1; i <= ilosckomorek; i++)
            {
                for (int j = 1; j <= ilosckomorek; j++)
                {
                    if (komorkiteraz.stan[i, j])
                    {
                        rysopwnik.FillRectangle(kolorkomorki, (i - 1) * wielkosckomorki, (j - 1) * wielkosckomorki, wielkosckomorki, wielkosckomorki);
                    }
                    else
                    {
                        rysopwnik.FillRectangle(kolorkomorkiPozniej, (i - 1) * wielkosckomorki, (j - 1) * wielkosckomorki, wielkosckomorki, wielkosckomorki);
                    }
                }
            }
            Rysujsiatke();
        }

        public void PrzeliczPololenie()
        {
            int zywiSasiedzi;
            for (int i = 1; i <= ilosckomorek; i++)
            {
                for (int j = 1; j <= ilosckomorek; j++)
                {
                    zywiSasiedzi = 0;
                    for (int m = -1; m <= 1; m++)
                    {
                        for (int n = -1; n <= 1; n++)
                        {
                            if (!(m == 0 && n == 0))
                            {
                                if (komorkiteraz.stan[i + m, j + n])
                                {
                                    zywiSasiedzi++;
                                }
                            }
                        }
                    }

                    if (komorkiteraz.stan[i, j])
                    {
                        if (zywiSasiedzi == 2 || zywiSasiedzi == 3)
                        {
                            komorkipozniej.stan[i, j] = true;
                        }
                        else
                        {
                            komorkipozniej.stan[i, j] = false;
                        }
                    }
                    else
                    {
                        if (zywiSasiedzi == 3)
                        {
                            komorkipozniej.stan[i, j] = true;
                        }
                        else
                        {
                            komorkipozniej.stan[i, j] = false;
                        }
                    }
                }
            }
            //  nrPokolenia++;
            for (int i = 1; i <= ilosckomorek; i++)
            {
                for (int j = 1; j <= ilosckomorek; j++)
                {
                    komorkiteraz.stan[i, j] = komorkipozniej.stan[i, j];
                }
            }
            pokolenie++;

            RysujKomorki();
        }

        public void ZmienStanKomorki(int x, int y)
        {
            x = (int)(x / wielkosckomorki);
            y = (int)(y / wielkosckomorki);
            komorkiteraz.ZmienStan(x, y);
            RysujKomorki();
        }

        public void LosujKomorki(int procenty)
        {
            Random losuj = new Random();
            for (int i = 1; i <= ilosckomorek; i++)
            {
                for (int j = 1; j <= ilosckomorek; j++)
                {
                    if (losuj.Next(1, 100) <= procenty)
                    {
                        komorkiteraz.stan[i, j] = true;
                    }
                    else
                    {
                        komorkiteraz.stan[i, j] = false;
                    }
                }
            }
            RysujKomorki();
        }

        public void wyczysckomorki(bool czyCzyscic)
        {
            komorkiteraz = new komorki(100);
            komorkipozniej = new komorki(100);
            pokolenie = 0;

            Rysujsiatke();
        }
    }
}