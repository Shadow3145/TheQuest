using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Korist
    {
        public Věc Detaily { get; set; }
        public int Sance { get; set; }
       

        public Korist (Věc detaily, int sance)
        {
            Detaily = detaily;
            Sance = sance;
        }
    }
}
