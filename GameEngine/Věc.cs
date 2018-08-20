using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Věc
    {
        public int ID { get; set; }
        public string Jmeno { get; set; }
        public string Jmena { get; set; }
        public int Cena { get; set; }

        public Věc (int id, string jmeno, string jmena, int cena)
        {
            ID = id;
            Jmeno = jmeno;
            Jmena = jmena;
            Cena = cena;
        }
    }
}
