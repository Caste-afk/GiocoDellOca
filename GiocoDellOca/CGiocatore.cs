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
        public EventHandler OnPlayerOca;

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

        public void ControllaPosizione()
        {
            OnPlayerOca?.Invoke(this, EventArgs.Empty);
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
