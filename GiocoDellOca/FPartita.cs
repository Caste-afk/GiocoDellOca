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
    public partial class FPartita : Form
    {
        public FPartita()
        {
            InitializeComponent();
            ImpostaTabellone();
        }

        private void FPartita_OnClose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ImpostaTabellone()
        {
            dgv_Partita.RowHeadersVisible = false;
            dgv_Partita.ColumnHeadersVisible = false;
            dgv_Partita.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            int caselleTot = 63;
            int colonne = 9;
            int righe = 7;

            
            dgv_Partita.Columns.Clear();
            dgv_Partita.Rows.Clear();

            
            for (int i = 0; i < colonne; i++)
                dgv_Partita.Columns.Add($"col{i}", "");

            for (int i = 1; i < righe; i++)
                dgv_Partita.Rows.Add();

            for (int i = 0; i < caselleTot; i++)
            {
                int riga = i / colonne;
                int colonna = i % colonne;

                dgv_Partita.Rows[riga].Cells[colonna].Value = (i + 1).ToString();
            }

        }

        public void ControllaCellaSpeciale(int c, int r, int num, DataGridView dgv)
        {
            string path = @"\img\";
            if (num == 5 || num%9 == 0)
            {
                dgv.Rows[r].Cells[c] = new DataGridViewImageCell();
                dgv.Rows[r].Cells[c].Value = Image.FromFile($@"{path}CasellaOca.png");
            }
        }
    }
}
