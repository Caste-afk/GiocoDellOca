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

        private List<Image> immaginiDadi;
        private List<Image> immaginiCaselle;

        bool turno; // true = giocatore 1, false = giocatore 2
        CGiocatore g1, g2;
        int pTemp;

        public FPartita(Image img1, Image img2)
        {
            InitializeComponent();
            pTemp = 0;
            g1 = new CGiocatore(img1);
            g2 = new CGiocatore(img2);

            AscoltaEventi(g1);
            AscoltaEventi(g2);

            immaginiDadi = new List<Image>();
            for (int i = 1; i <= 6; i++)
            {
                AggiungiImmagineACella(immaginiDadi, "dado" + i.ToString() + ".png");
            }
            immaginiCaselle = new List<Image>();

            ptb_g1.BackColor = Color.Transparent;
            ptb_g2.BackColor = Color.Transparent;
            ptb_Dado1.BackColor = Color.Transparent;
            ptb_Dado2.BackColor = Color.Transparent;

            ptb_Dado1.Image = immaginiDadi[0];
            ptb_Dado2.Image = immaginiDadi[1];


            turno = true;
            ptb_Dado1.SizeMode = PictureBoxSizeMode.StretchImage;
            ptb_Dado2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Size = new Size(2164, 1158);
            ImpostaImmaginiGiocatori();
            #region imposta immagini

            AggiungiImmagineACella(immaginiCaselle, "CasellaOca.png");
            AggiungiImmagineACella(immaginiCaselle, "ponte.jpg");
            AggiungiImmagineACella(immaginiCaselle, "casa.jpg");
            AggiungiImmagineACella(immaginiCaselle, "prigione.jpg");
            AggiungiImmagineACella(immaginiCaselle, "labirinto.jpg");
            AggiungiImmagineACella(immaginiCaselle, "scheletro.jpg");
            AggiungiImmagineACella(immaginiCaselle, "fine.png");
            #endregion

            ImpostaTabellone();

        }

        private void AscoltaEventi(CGiocatore g)
        {
            List<EventHandler> eventi = new List<EventHandler>()
            {
                (s, e) => CasellaOca(),
                (s, e) => CasellaPonte(),
                (s, e) => CasellaCasa(),
                (s, e) => CasellaPrigione(),
                (s, e) => CasellaLabirinto(),
                (s, e) => CasellaScheletro(),
                (s, e) => CasellaFine()
            };

            g.OnPlayerOca += eventi[0];
            g.OnPlayerPonte += eventi[1];
            g.OnPlayerCasa += eventi[2];
            g.OnPlayerPrigione += eventi[3];
            g.OnPlayerLabirinto += eventi[4];
            g.OnPlayerScheletro += eventi[5];
            g.OnPlayerFine += eventi[6];

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

            if (num == 5 || (num % 9 == 0 && num != 63))
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
            if(num == 42)
            {
                MettiImmagine(c, r, 4, dgv);
                return true;
            }
            if(num == 58)
            {
                MettiImmagine(c, r, 5, dgv);
                return true;
            }
            if(num == 63)//mettere immagine
            {
                MettiImmagine(c, r, 6, dgv);
                return true;
            }

            return false;
        }

        private void CasellaOca()
        {
            MessageBox.Show("casellaOca");
            if (turno)
            {
                Avanzamento(g1);
            }
            else
            {
                Avanzamento(g2);
            }
            SpostaPersonaggi(turno ? ptb_g1 : ptb_g2, turno ? g1.GetPosizione() : g2.GetPosizione());
        }

        private void CasellaPonte()
        {
            MessageBox.Show("Ponte");
            if (turno)
            {
                g1.Avanza(pTemp);
            }
            else
            {
                g2.Avanza(pTemp);
            }
            SpostaPersonaggi(turno ? ptb_g1 : ptb_g2, turno ? g1.GetPosizione() : g2.GetPosizione());
        }

        private void CasellaCasa()
        {
            CGiocatore g = turno ? g1 : g2;

            // Se è già in casa → scala turni
            if (g.getInCasa())
            {
                g.DecrementaCasa();
                MessageBox.Show($"Sei in casa per altri {g.GetTurniCasa()} turni.");
                return;
            }

            // È appena arrivato in casa → inizia i 3 turni
            g.setInCasa(true);
            MessageBox.Show("Sei finito nella Casa! Dovrai restare fermo per 3 turni.");
        }

        private void CasellaPrigione()
        {
            CGiocatore gCorrente = turno ? g1 : g2;
            CGiocatore gAltro = turno ? g2 : g1;

            // Se il giocatore corrente era in prigione → esce
            if (gCorrente.getInPrigione())
            {
                gCorrente.setInPrigione(false);
                MessageBox.Show("Esci dalla prigione! Puoi riprendere a muoverti.");
                return;
            }

            // Se l'altro giocatore è in prigione → liberalo 
            // e il corrente prende il suo posto
            if (gAltro.getInPrigione())
            {
                gAltro.setInPrigione(false);
                gCorrente.setInPrigione(true);

                MessageBox.Show("Hai liberato l'altro giocatore, ma ora sei tu in prigione!");
                return;
            }

            // Nessuno era in prigione → il corrente ci entra ora
            gCorrente.setInPrigione(true);
            MessageBox.Show("Sei finito in prigione! Rimarrai fermo finché l'altro non ti libera.");
        }

        private void CasellaLabirinto()
        {
            MessageBox.Show("Labirinto: Torni alla casella 30");
            CGiocatore g = turno ? g1 : g2;
            g.Indietreggia(g.GetPosizione() - 30);
            SpostaPersonaggi(turno ? ptb_g1 : ptb_g2, g.GetPosizione());
        }

        private void CasellaScheletro()
        {
            MessageBox.Show("Scheletro: Torni alla casella 1");
            CGiocatore g = turno ? g1 : g2;
            g.Indietreggia(g.GetPosizione() - 1);
            SpostaPersonaggi(turno ? ptb_g1 : ptb_g2, g.GetPosizione());
        }

        private void CasellaFine()
        {
            int vincitore = turno ? 1 : 2;
            MessageBox.Show($"Ha vinto il giocatore n°: {vincitore}");
            Application.Exit();
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

            CGiocatore gCorrente = turno ? g1 : g2;

            if (gCorrente.getInCasa())
            {
                gCorrente.DecrementaCasa();
                if (gCorrente.GetTurniCasa() > 0)
                {
                    MessageBox.Show($"Sei in casa! Turno saltato. Rimangono {gCorrente.GetTurniCasa()} turni.");
                }
                else
                {
                    MessageBox.Show("Esci dalla casa! Puoi riprendere a giocare dal prossimo turno.");
                }
                turno = !turno;
                lbl_Turno.Text = turno ? "Turno del Giocatore 1" : "Turno del Giocatore 2";
                return;
            }

            if (gCorrente.getInPrigione())
            {
                MessageBox.Show("Sei in prigione! Non puoi muoverti finché l'altro giocatore non ti libera.");
                turno = !turno;
                lbl_Turno.Text = turno ? "Turno del Giocatore 1" : "Turno del Giocatore 2";
                return;
            }

            Random rnd = new Random();
            int dado1 = rnd.Next(1, 7);
            int dado2 = rnd.Next(1, 7);
            pTemp = dado1 + dado2;

            AnimazioneDadi(dado1 - 1, dado2 - 1);

            Avanzamento(gCorrente);

            turno = !turno;
            lbl_Turno.Text = turno ? "Turno del Giocatore 1" : "Turno del Giocatore 2";
        }

        private void Avanzamento(CGiocatore g)
        {
            g.Avanza(pTemp);
            int posizione = g.GetPosizione();
            (int c, int r)coord = TrovaCoordinata(g.GetPosizione());
            
            g.ControllaPosizione();

            SpostaPersonaggi(turno ? ptb_g1 : ptb_g2, g.GetPosizione());

            CGiocatore gAltro = turno ? g2 : g1;
            ControllaScontro(g, gAltro);
            lbl_Turno.Text = turno ? "Turno del Giocatore 1" : "Turno del Giocatore 2";
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

        private void ControllaScontro(CGiocatore gCorrente, CGiocatore gAltro)
        {
            if (gCorrente.GetPosizione() == gAltro.GetPosizione())
            {
                gAltro.Indietreggia(pTemp); // lo rimetti alla posizione 0
                MessageBox.Show("Hai preso l'altro giocatore! Torna alla partenza.");
                SpostaPersonaggi(turno ? ptb_g2 : ptb_g1, gAltro.GetPosizione());
            }
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
