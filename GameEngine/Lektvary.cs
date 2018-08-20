using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Lektvary : Věc
    {
        public int Leceni { get; set; }

        public Lektvary (int id, string jmeno, string jmena, int leceni, int cena): base(id, jmeno, jmena, cena)
        {
            Leceni = leceni;
        }
    }
}
