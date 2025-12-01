using System;
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

        bool turno; // true = giocatore 1, false = giocatore 2
        CGiocatore g1, g2;

        public FPartita()
        {
            InitializeComponent();
            ImpostaTabellone();
            g1 = new CGiocatore();
            g2 = new CGiocatore();
            turno = true;
        }

        private void FPartita_OnClose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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

            if (num == 5 || num % 9 == 0)
            {
                MettiImmagine(c, r, "CasellaOca.png", dgv);
                return true;
            }
            if(num == 6)
            {
                MettiImmagine(c, r, "ponte.jpg", dgv);
                return true;
            }
            if(num == 19)
            {
                MettiImmagine(c, r, "labirinto.jpg", dgv);
                return true;
            }
            if (num == 31)
            {
                MettiImmagine(c, r, "prigione.jpg", dgv);
                return true;
            }
            if(num == 58)
            {
                MettiImmagine(c, r, "scheletro.jpg", dgv);
                return true;
            }

            return false;
        }

        private void MettiImmagine(int c, int r, string nomeFile, DataGridView dgv)
        {
            string path = Path.Combine(Application.StartupPath, "img");
            var cell = new DataGridViewImageCell();
            cell.Value = Image.FromFile(Path.Combine(path, nomeFile));
            cell.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dgv.Rows[r].Cells[c] = cell;
        }

        private void btn_Dadi_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int dado1 = rnd.Next(1, 7);
            int dado2 = rnd.Next(1, 7);
            AnimazioneDadi(dado1, dado2);
            if (turno)
            {
                Avanzamento(g1, dado1 + dado2);
            }
            else
            {
                Avanzamento(g2, dado1 + dado2);
            }
            turno = !turno;
        }

        private void Avanzamento(CGiocatore g, int n)
        {
            (int r, int c) coord = TrovaCoordinata(g.GetPosizione());

            //cambia celle dalle quali si esce
            if (!(dgv_Partita.Rows[coord.r].Cells[coord.c].Tag is null))//se non e` l'inizio
            {
                dgv_Partita.Rows[coord.r].Cells[coord.c].Tag = false;
            }


            int avanzamentoIpotetico = g.GetPosizione() + n;

            //cambia lo stato della cella occupata --> true se occupata, false se libera
            coord = TrovaCoordinata(g.GetPosizione());

            if (!(bool)dgv_Partita.Rows[coord.r].Cells[coord.c].Tag || dgv_Partita.Rows[coord.r].Cells[coord.c].Tag is null)//se non c'e` mai stato nessuno oppure chi c'e` stato e` andato via
            {
                dgv_Partita.Rows[coord.r].Cells[coord.c].Tag = true;
                g.Avanza(n);
            }
            else//altrimenti se qualcuno c'e` gia`
            {
                g.Indietreggia(n);
            }
        }

        private (int, int) TrovaCoordinata(int n)
        {
            int r = 0;
            int c = 0;
            while (n > 0)
            {
                c += 1;
                if (c== 9)
                {
                    c = 0;
                    r += 1;
                }
                n--;
            }
            return (r, c); 
        }

        private void AnimazioneDadi(int r1, int r2)
        {
            int durataAnimazione = 1000;
            int frameAnimazione = 15;

            Random rnd = new Random();

            for (int i =0; i<frameAnimazione; i++)
            {
                //imposta foto per dado1
                int faccia1 = rnd.Next(1, 7);
                ptb_Dado1.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "img", $"dado{faccia1}.png"));
                //imposta foto per dado2
                int faccia2 = rnd.Next(1, 7);
                ptb_Dado2.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "img", $"dado{faccia2}.png"));
                Thread.Sleep(durataAnimazione / frameAnimazione);
            }
            ptb_Dado1.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "img", $"dado{r1}.png"));
            ptb_Dado2.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "img", $"dado{r2}.png"));
        }


    }
}
