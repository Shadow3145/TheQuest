using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GameEngine
{
    public class Obchodnik 
    {
        public string Jmeno { get; set; }
        public List<Inventar> Inventar { get; set; }

        public Obchodnik (string jmeno)
        {
            Jmeno = jmeno;
            Inventar = new List<GameEngine.Inventar>();
        }

        public void PridatDoInventare(Věc pridatVec, int mnozstvi = 1)
        {
            Inventar polozka = Inventar.SingleOrDefault(ii => ii.Detaily.ID == pridatVec.ID);

            if(polozka == null)
            {
                Inventar.Add(new Inventar(pridatVec, mnozstvi));
            }
            else
            {
                polozka.Mnozstvi += mnozstvi;
            }

        }

        public void OdebratZInventare(Věc odstranitVec, int mnozstvi = 1)
        {
            Inventar polozka = Inventar.SingleOrDefault(ii => ii.Detaily.ID == odstranitVec.ID);

            if(polozka == null)
            {

            }
            else
            {
                polozka.Mnozstvi -= mnozstvi;

                if(polozka.Mnozstvi<0)
                {
                    polozka.Mnozstvi = 0;
                }

                if(polozka.Mnozstvi == 0)
                {
                    Inventar.Remove(polozka);
                }

                
            }
        }

     
    }
}
