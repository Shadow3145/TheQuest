using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
   public class Bestiář : Bytost
    {
        public int ID { get; set; }
        public string Jmeno { get; set; }
        public int Maxutok { get; set; }
        public int Expy { get; set; }
        public int Odmena { get; set; }
        public int Pocet { get; set; }
        public int Vychozi { get; set; }
        

        public List<Korist> Zisk { get; set; }

        public Bestiář (int id, string jmeno, int maxutok, int expy, int odmena, int aktualzdravi, int maxzdravi, int pocet = 0, int vychozi=0) : base (aktualzdravi, maxzdravi)
        {
            ID = id;
            Jmeno = jmeno;
            Maxutok = maxutok;
            Expy = expy;
            Odmena = odmena;
            Pocet = pocet;
            Vychozi = vychozi; 
            

            Zisk = new List<Korist>();
        }
        
    }
}
