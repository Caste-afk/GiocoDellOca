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
        public event EventHandler OnPlayerOca;
        public event EventHandler OnPlayerPonte;
        public event EventHandler OnPlayerCasa;
        public event EventHandler OnPlayerPrigione;
        public event EventHandler OnPlayerLabirinto;
        public event EventHandler OnPlayerScheletro;
        public event EventHandler OnPlayerFine;

        private int posizione;
        private Image immagine;
        private int casa;
        private bool inPrigione;
        private bool inCasa;
        public CGiocatore(Image immagine)
        {
            this.immagine = immagine;
            posizione = 0;
            inCasa = false;
            inPrigione = false;
            casa = 0;
        }

        public void Avanza(int ris)
        {
            posizione += ris;
        }
        public void Indietreggia(int ris)
        {
            posizione -= ris;
        }

        public bool getInPrigione()
        {
            return inPrigione;
        }

        public void setInPrigione(bool stato)
        {
            inPrigione = stato;
        }

        public bool getInCasa()
        {
            return inCasa;
        }
        public void setInCasa(bool stato)
        {
            inCasa = stato;
            if (stato)
            {
                casa = 3;
            }
        }

        public void DecrementaCasa()
        {
            if (casa > 0)
            {
                casa--;
            }
            if (casa == 0)
            {
                inCasa = false;
            }
        }

        public int GetTurniCasa()
        {
            return casa;
        }


        public void ControllaPosizione()
        {

            if (posizione == 63)
            {
                OnPlayerFine?.Invoke(this, EventArgs.Empty);
            }
            else if (posizione > 63)
            {
                posizione = 63 - (posizione - 63);
            }
            if ((posizione % 9 == 0 && posizione != 63)|| posizione == 5)
            {
                OnPlayerOca?.Invoke(this, EventArgs.Empty);
            }
            else if (posizione == 6)
            {
                OnPlayerPonte?.Invoke(this, EventArgs.Empty);
            }
            else if (posizione == 19)
            {
                OnPlayerCasa?.Invoke(this, EventArgs.Empty);
            }
            else if (posizione == 31)
            {
                OnPlayerPrigione?.Invoke(this, EventArgs.Empty);
            }
            else if (posizione == 42)
            {
                OnPlayerLabirinto?.Invoke(this, EventArgs.Empty);
            } else if (posizione == 58)
            {
                OnPlayerScheletro?.Invoke(this, EventArgs.Empty);
            }
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
