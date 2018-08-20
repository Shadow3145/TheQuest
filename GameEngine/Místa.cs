using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Místa
    {
        public int ID { get; set; }
        public string Jméno { get; set; }
        public string Popis { get; set; }
        public Věc JePotrebaPredmet { get; set; }
        public Ukoly UkolJeKDispozici { get; set; }
        public Bestiář NachaziSeZdePrisera { get; set; }
        public Místa NaSever { get; set; }
        public Místa NaJih { get; set; }
        public Místa NaZapad { get; set; }
        public Místa NaVychod { get; set; }
        public Obchodnik Obchodnik { get; set; }

        public Místa(int id, string jméno, string popis, Věc jePotrebaPredmet = null, Ukoly ukolJeKDispozici = null, Bestiář nachaziSeZdePrisera = null)
        {
            ID = id;
            Jméno = jméno;
            Popis = popis;
            JePotrebaPredmet = jePotrebaPredmet;
            UkolJeKDispozici = ukolJeKDispozici;
            NachaziSeZdePrisera = nachaziSeZdePrisera;
        }
    }
}
