using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoDellOca
{
    internal class CGiocatore
    {
        private int posizione;

        public CGiocatore()
        {
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
    }
}
