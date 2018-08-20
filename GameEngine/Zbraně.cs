using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Zbraně : Věc
    {
        public int Minutok { get; set; }
        public int Maxutok { get; set; }
        public bool Aktiv { get; set; }

        public Zbraně (int id, string jmeno, string jmena, int minutok, int maxutok, int cena, bool aktiv) : base (id, jmeno, jmena, cena)
        {
            Minutok = minutok;
            Maxutok = maxutok;
            Aktiv = aktiv;
        }
    }
}
