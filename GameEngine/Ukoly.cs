using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Ukoly
    {
        public int ID { get; set; }
        public string Jmeno { get; set; }
        public string Popis { get; set; }
        public int Expy { get; set; }
        public int Odmena { get; set; }
        public Věc Predmet { get; set; }
        public bool Dokoncen { get; set; }
                
        public List<Inventar> Pomoc { get; set; }
        public List<Trofej> Trofej { get; set; }
        
        
        
        public Ukoly (int id, string jmeno, string popis, int expy, int odmena, bool dokoncen)
        {
            ID = id;
            Jmeno = jmeno;
            Popis = popis;
            Expy = expy;
            Odmena = odmena;
            Dokoncen = dokoncen;

            Trofej = new List<Trofej>();
            Pomoc = new List<Inventar>();
            
        }
    }
}
