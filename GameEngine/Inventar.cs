using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Inventar
    {
        public Věc Detaily { get; set; }
        public int Mnozstvi { get; set; }
        
        public int VecID
        {
            get { return Detaily.ID; }
        }

        public string Jmeno
        {
            get { return Detaily.Jmeno; }
        }

        public Inventar (Věc detaily, int mnozstvi)
        {
            Detaily = detaily;
            Mnozstvi = mnozstvi;
        }
    }
}
