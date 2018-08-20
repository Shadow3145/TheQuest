using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Trofej
    {
        public Věc Detaily { get; set; }
        public int Mnozstvi { get; set; }

        public Trofej ( Věc detaily, int mnozstvi)
        {
            Detaily = detaily;
            Mnozstvi = mnozstvi;
        }
    }
}
