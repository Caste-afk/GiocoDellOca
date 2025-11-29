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
        }

        private void ImpostaTabellone()
        {
            int caselleTot = 63;
            int colonne = 9;
            int righe = (int)Math.Ceiling((double)caselleTot / colonne);

            for (int i = 0; i < colonne; i++)
            {
                dgv_Partita.Columns.Add("", "");
            }

            for (int i =0; i < righe; i++)
            {
                dgv_Partita.Rows.Add();
            }

            for(int i = 0; i < caselleTot; i++)
            {
                int riga = i / colonne;
                int colonna = i % colonne;
                dgv_Partita.Rows[riga].Cells[colonna].Value = (i + 1).ToString();
            }
        }

        public void ControllaCellaSpeciale(int c, int r, int num, DataGridView dgv)
        {
            if (num == 5 || num%9 == 0)
            {
                dgv.Rows[r].Cells[c].Im = Color.Red;
            }
        }
    }
}
