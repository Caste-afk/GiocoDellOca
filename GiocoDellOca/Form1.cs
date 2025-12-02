using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiocoDellOca
{
    public partial class Form1 : Form
    {
        List<Image> immaginiPersonaggi;

        private int c1, c2;

        public Form1()
        {
            InitializeComponent();
            c1 = 0;
            c2 = 0;
            immaginiPersonaggi = new List<Image>();
            for(int i =1; i<=4; i++)
            {
                immaginiPersonaggi.Add(Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "img", "psg" + i.ToString() + ".png")));
            }
        }

        private void btn_Gioca_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FPartita partita = new FPartita(immaginiPersonaggi[c1], immaginiPersonaggi[c2]))
            {
                partita.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ptb_g1.SizeMode = PictureBoxSizeMode.StretchImage;
            ptb_g2.SizeMode = PictureBoxSizeMode.StretchImage;
            ptb_g1.Image = immaginiPersonaggi[c1];
            ptb_g2.Image = immaginiPersonaggi[c2];
        }

        private void btn_destra2_Click(object sender, EventArgs e)
        {
            AggiornaImmagine(ref c2, true, ptb_g2);
        }
        private void btn_sinistra1_Click(object sender, EventArgs e)
        {
            AggiornaImmagine(ref c1, false, ptb_g1);
        }


        private void btn_sinistra2_Click(object sender, EventArgs e)
        {
            AggiornaImmagine(ref c2, false, ptb_g2);
        }

        private void btn_destra1_Click(object sender, EventArgs e)
        {
            AggiornaImmagine(ref c1, true, ptb_g1);
        }

        private void AggiornaImmagine(ref int c, bool incremento, PictureBox ptb)
        {
            if (incremento)
            {
                c = c + 1;
                ControllaCounter();
                ptb.Image = immaginiPersonaggi[c];
            }
            else
            {
                c = c - 1;
                ControllaCounter();
                ptb.Image = immaginiPersonaggi[c];
            }
        }

        private void ControllaCounter()
        {
            if (c1 < 0)
            {
                c1 = immaginiPersonaggi.Count - 1;
            }
            else if(c1 > 3)
            {
                c1 = 0;
            }
            if (c2 < 0)
            {
                c2 = immaginiPersonaggi.Count - 1;
            }
            else if (c2 > 3)
            {
                c2 = 0;
            }
        }
    }
}
