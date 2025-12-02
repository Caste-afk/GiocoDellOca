using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoDellOca
{
    internal class CGiocatore
    {
        private int posizione;
        private Image immagine;

        public CGiocatore(Image immagine)
        {
            this.immagine = immagine;
            posizione = 0;
        }

        public void Avanza(int ris)
        {
            posizione += ris;
        }
        public void Indietreggia(int ris)
        {
            posizione -= ris;
        }

        public int GetPosizione()
        {
            return posizione;
        }

        public Image GetImmagine()
        {
            return immagine;
        }
    }
}
