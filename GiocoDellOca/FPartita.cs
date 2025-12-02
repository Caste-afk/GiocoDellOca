using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiocoDellOca
{
    public partial class FPartita : Form
    {

        public event EventHandler OnCasellaSpeciale;

        private List<Image> immaginiDadi;
        private List<Image> immaginiCaselle;

        bool turno; // true = giocatore 1, false = giocatore 2
        CGiocatore g1, g2;

        public FPartita(Image img1, Image img2)
        {
            InitializeComponent();
            g1 = new CGiocatore(img1);
            g2 = new CGiocatore(img2);
            turno = true;
            ptb_Dado1.SizeMode = PictureBoxSizeMode.StretchImage;
            ptb_Dado2.SizeMode = PictureBoxSizeMode.StretchImage;
            ImpostaImmaginiGiocatori();
            #region imposta immagini

            immaginiDadi = new List<Image>();
            for(int i =1; i<=6; i++)
            {
                AggiungiImmagineACella(immaginiDadi, "dado" + i.ToString() + ".png");
            }
            immaginiCaselle = new List<Image>();
            AggiungiImmagineACella(immaginiCaselle, "CasellaOca.png");
            AggiungiImmagineACella(immaginiCaselle, "ponte.jpg");
            AggiungiImmagineACella(immaginiCaselle, "labirinto.jpg");
            AggiungiImmagineACella(immaginiCaselle, "prigione.jpg");
            AggiungiImmagineACella(immaginiCaselle, "scheletro.jpg");
            AggiungiImmagineACella(immaginiCaselle, "fine.png");
            #endregion

            ImpostaTabellone();

        }

        private void ImpostaImmaginiGiocatori()
        {
            ptb_g1.Image = g1.GetImmagine();
            ptb_g2.Image = g2.GetImmagine();
            ptb_g1.SizeMode = PictureBoxSizeMode.StretchImage;
            ptb_g2.SizeMode = PictureBoxSizeMode.StretchImage;
            ptb_g1.BackColor = Color.Transparent;
            ptb_g2.BackColor = Color.Transparent;
        }


        private void AggiungiImmagineACella(List<Image> lista, string nome)
        {
            lista.Add(Image.FromFile(Path.Combine(Application.StartupPath, "img", nome)));
        }

        private void ImpostaTabellone()
        {
            int dim = 60;
            int colonne = 9;
            int righe = 7;
            dgv_Partita.Rows.Clear();
            dgv_Partita.Columns.Clear();
            dgv_Partita.Width = dim * colonne + 3;
            dgv_Partita.Height = dim * righe + 3;

            dgv_Partita.ColumnHeadersVisible = false;
            dgv_Partita.RowHeadersVisible = false;
            dgv_Partita.ScrollBars = ScrollBars.None;
            dgv_Partita.AllowUserToAddRows = false;
            dgv_Partita.AllowUserToResizeRows = false;
            dgv_Partita.AllowUserToResizeColumns = false;
            dgv_Partita.ReadOnly = true;
            dgv_Partita.ClearSelection();
            dgv_Partita.Enabled = false;

            for (int x = 0; x < colonne; x++)
            {
                dgv_Partita.Columns.Add("", "");
                dgv_Partita.Columns[x].Width = dim;
            }

            for (int y = 0; y < righe; y++)
            {
                dgv_Partita.Rows.Add();
                dgv_Partita.Rows[y].Height = dim;
            }

            int casella = 1;

            for (int y = 0; y < righe; y++)
            {
                for (int x = 0; x < colonne; x++)
                {
                    bool speciale = ControllaCellaSpeciale(x, y, casella, dgv_Partita);
                    var cella = dgv_Partita[x, y];

                    if (!speciale)
                    {
                        if (casella <= 63)
                        {
                            cella.Value = casella.ToString();
                            cella.Style.BackColor = Color.LightBlue;
                        }
                        else
                        {
                            cella.Value = "";
                            cella.Style.BackColor = Color.Gray;
                        }
                    }

                    cella.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    cella.Style.Font = new Font("Arial", 14, FontStyle.Bold);
                    casella++;
                }
            }
        }

        public bool ControllaCellaSpeciale(int c, int r, int num, DataGridView dgv)
        {

            if ((num == 5 || num % 9 == 0 )&& num != 63)
            {
                MettiImmagine(c, r, 0, dgv);
                return true;
            }
            if(num == 6)
            {
                MettiImmagine(c, r, 1, dgv);
                return true;
            }
            if(num == 19)
            {
                MettiImmagine(c, r, 2, dgv);
                return true;
            }
            if (num == 31)
            {
                MettiImmagine(c, r, 3, dgv);
                return true;
            }
            if(num == 58)
            {
                MettiImmagine(c, r, 4, dgv);
                return true;
            }
            if(num == 63)//mettere immagine
            {
                MettiImmagine(c, r, 5, dgv);
                return true;
            }

            return false;
        }

        private void MettiImmagine(int c, int r, int posizione, DataGridView dgv)
        {
            string path = Path.Combine(Application.StartupPath, "img");
            var cell = new DataGridViewImageCell();
            cell.Value = immaginiCaselle[posizione];
            cell.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dgv.Rows[r].Cells[c] = cell;
        }

        private void btn_Dadi_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int dado1 = rnd.Next(1, 6);
            int dado2 = rnd.Next(1, 6);
            AnimazioneDadi(dado1-1, dado2-1);
            MessageBox.Show("Dado 1: " + (dado1).ToString() + "\nDado 2: " + (dado2 ).ToString());
            if (turno)
            {
                Avanzamento(g1, (dado1 + dado2));
            }
            else
            {
                Avanzamento(g2, (dado1 + dado2));
            }
            turno = !turno;
        }

        private void Avanzamento(CGiocatore g, int n)
        {
            (int r, int c) coord = TrovaCoordinata(g.GetPosizione());
            //cambia celle dalle quali si esce
            //if (!(dgv_Partita.Rows[coord.r].Cells[coord.c].Tag is null))//se non e` l'inizio
            //{
            //    dgv_Partita.Rows[coord.r].Cells[coord.c].Tag = false;
            //}


//            int avanzamentoIpotetico = g.GetPosizione() + n;

            g.Avanza(n);
            //cambia lo stato della cella occupata --> true se occupata, false se libera
            //coord = TrovaCoordinata(g.GetPosizione());

            /*if (dgv_Partita.Rows[coord.r].Cells[coord.c].Tag == null || !(bool)dgv_Partita.Rows[coord.r].Cells[coord.c].Tag)//se non c'e` mai stato nessuno oppure chi c'e` stato e` andato via
            {
                dgv_Partita.Rows[coord.r].Cells[coord.c].Tag = true;
                g.Avanza(n);
            }
            else//altrimenti se qualcuno c'e` gia`
            {
                g.Indietreggia(n);
            }*/
            SpostaPersonaggi(turno ? ptb_g1 : ptb_g2, g.GetPosizione());

            MessageBox.Show("Giocatore in posizione: " + g.GetPosizione().ToString());
        }

        private (int r, int c) TrovaCoordinata(int n)
        {
            n--; // porta 1–63 a range 0–62
            int c = n % 9;  // modulo colonne
            int r = n / 9;  // riga
            return (r, c);
        }


        private void AnimazioneDadi(int r1, int r2)
        {
            int durataAnimazione = 1000;
            int frameAnimazione = 15;
            Random rnd = new Random();

            for (int i =0; i<frameAnimazione; i++)
            {
                Thread.Sleep(durataAnimazione / frameAnimazione);
                ptb_Dado1.Refresh();
                ptb_Dado2.Refresh();

                //imposta foto per dado1
                int faccia1 = rnd.Next(0, 5);
                ptb_Dado1.Image = immaginiDadi[faccia1];
                //imposta foto per dado2
                int faccia2 = rnd.Next(0, 5);
                ptb_Dado2.Image = immaginiDadi[faccia2];
            }
            ptb_Dado1.Image = immaginiDadi[r1];
            ptb_Dado2.Image = immaginiDadi[r2];
        }

        private void FPartita_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void SpostaPersonaggi(PictureBox giocatore, int pos)
        {
            (int r, int c) coord = TrovaCoordinata(pos);
            int altezzaCella = dgv_Partita.Rows[0].Height;
            int lunghezzaCella = dgv_Partita.Columns[0].Width;
            Point posizione = dgv_Partita.Location;
            posizione.X += coord.c * lunghezzaCella+10;
            posizione.Y += coord.r * altezzaCella + 10;
            giocatore.Location = posizione;
        }





    }
}
