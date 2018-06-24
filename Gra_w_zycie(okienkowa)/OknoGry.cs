using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gra_w_zycie_okienkowa_
{
    public partial class OknoGry : Form
    {
        public OknoGry()
        {
            InitializeComponent();

            plansza = new plansza(pictureBox1.Size.Height);
            comboBox1.SelectedIndex = 1;
            pictureBox1.Image = plansza.bitmapa;
            plansza.funkcja();
            timer1.Interval = 300;
        }

        private void wyswietl()
        {
            pictureBox1.Image = plansza.bitmapa;
        }

        private plansza plansza;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void x10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            plansza.ZmienRozmiarSiatki(10, 10);
            wyswietl();
        }

        private void x15ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            plansza.ZmienRozmiarSiatki(15, 15);
            wyswietl();
        }

        private void x15ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            plansza.ZmienRozmiarSiatki(20, 20);
            wyswietl();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            plansza.ZmienStanKomorki(e.X, e.Y);
            wyswietl();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int wybor = comboBox1.SelectedIndex;
            switch (wybor)
            {
                case 0:
                    plansza.ZmienRozmiarSiatki(10, 10);

                    break;

                case 1:
                    plansza.ZmienRozmiarSiatki(15, 15);

                    break;

                case 2:
                    plansza.ZmienRozmiarSiatki(20, 20);

                    break;
            }
            wyswietl();
        }

        private void start_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            plansza.PrzeliczPololenie();
            wyswietl();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Losowanie żywych komórek: " + trackBar1.Value.ToString() + "%";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            plansza.LosujKomorki(trackBar1.Value);

            wyswietl();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            plansza.wyczysckomorki(true);
            wyswietl();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void wyczyśćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            plansza.wyczysckomorki(true);
            wyswietl();
        }

        private void wylosujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            plansza.LosujKomorki(trackBar1.Value);

            wyswietl();
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}