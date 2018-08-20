using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameEngine
{
    public class Player : Bytost
    {
        public int Zlato { get; set; }
        public int Exp { get; set; }
        public int Uroven { get; set; }

        public List<Inventar> Inventar { get; set; }
        public List<Cechmistr> Mise { get; set; }

        public int sila { get; set; }
        public int obr { get; set; }
        public int zrc { get; set; }
        public int inte { get; set; }
        public int vule { get; set; }
        public int chr { get; set; }
        public int odl { get; set; }
        public int vdr { get; set; }
        public int sms { get; set; }
        public int rych { get; set; }
        public int points { get; set; }
        public string jmeno { get; set; }
        public string rasa { get; set; }
        public string povolani { get; set; }
        public Místa poloha { get; set; }

        public Player (int aktualzdravi, int maxzdravi, int Zlato, int exp, int uroven) : base (aktualzdravi, maxzdravi)
        {
            this.Zlato = Zlato;
            Exp = exp;
            Uroven = uroven;

            Inventar = new List<Inventar>();
            Mise = new List<Cechmistr>();
        }

        public bool MaPozadovanyPredmet (Místa misto)
        {
            if(misto.JePotrebaPredmet == null)
            {
                return true;
            }
            
            foreach(Inventar i in Inventar)
            {
                if(i.Detaily.ID == misto.JePotrebaPredmet.ID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool MaTentoUkol (Ukoly ukol)
        {
            foreach(Cechmistr ukoly in Mise)
            {
                if(ukoly.Detaily.ID == ukol.ID)
                {
                    return true;
                }
            }

            return false;
        }

        public bool UkolDokoncen(Ukoly ukol)
        {
            foreach(Cechmistr ukoly in Mise)
            {
                if(ukoly.Detaily.ID == ukol.ID)
                {
                    return ukoly.Dokoncen;
                }
            }

            return false;
        }

        public bool MaVsechnyTrofeje(Ukoly ukol)
        {
            foreach (Trofej trof in ukol.Trofej)
            {
                bool nalezenoVInventari = false;

                foreach (Inventar i in Inventar)
                {
                    if (i.Detaily.ID == trof.Detaily.ID)
                    {
                        nalezenoVInventari = true;
                        if (i.Mnozstvi < trof.Mnozstvi)
                        {
                            return false;
                        }
                    }
                }

                if (!nalezenoVInventari)
                {
                    return false;
                }
            }
            return true;
        }

        public void OdstranitTrofejeZInventare(Ukoly ukol)
        {
            foreach(Trofej trof in ukol.Trofej)
            {
                foreach(Inventar i in Inventar)
                {
                    if(i.Detaily.ID == trof.Detaily.ID)
                    {
                        i.Mnozstvi -= trof.Mnozstvi;
                        break;
                    }
                }
            }
                
        }

        public void PridatDoInventare(Věc pridatVec, int mnozstvi = 1)
        {
            Inventar polozka = Inventar.SingleOrDefault(ii => ii.Detaily.ID == pridatVec.ID);

            if (polozka == null)
            {
                Inventar.Add(new Inventar(pridatVec, mnozstvi));
            }
            else
            {
                polozka.Mnozstvi += mnozstvi;
            }

        }
        public void UkolBylDokoncen(Ukoly ukol)
        {
            foreach(Cechmistr mise in Mise)
            {
                if(mise.Detaily.ID == ukol.ID)
                {
                    mise.Dokoncen = true;
                    return;
                }
            }
        }

        public void OdebratZInventare(Věc odstranitVec, int mnozstvi = 1)
        {
            Inventar polozka = Inventar.SingleOrDefault(ii => ii.Detaily.ID == odstranitVec.ID);

            if (polozka == null)
            {

            }
            else
            {
                polozka.Mnozstvi -= mnozstvi;

                if (polozka.Mnozstvi < 0)
                {
                    polozka.Mnozstvi = 0;
                }

                if (polozka.Mnozstvi == 0)
                {
                    Inventar.Remove(polozka);
                }

            }
        }

              

    }
}
