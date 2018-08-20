using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public static class Kostky
    {
        private static Random kostky = new Random();

        public static int CisloMezi(int minimum, int maximum)
        {
            return kostky.Next(minimum, maximum + 1);
        }
    }
}
