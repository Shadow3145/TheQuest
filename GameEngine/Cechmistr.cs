using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Cechmistr
    {
        public Ukoly Detaily { get; set; }
        public bool Dokoncen { get; set; }

        public Cechmistr (Ukoly detaily)
        {
            Detaily = detaily;
            Dokoncen = false;
        }
    }
}
