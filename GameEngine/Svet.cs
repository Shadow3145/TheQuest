using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public static class Svet
    {
        public static readonly List<Věc> Predmety = new List<Věc>();
        public static readonly List<Bestiář> Bestiar = new List<Bestiář>();
        public static readonly List<Ukoly> Mise = new List<Ukoly>();
        public static readonly List<Místa> Mista = new List<Místa>();

        public const int VEC_ID_OBYC_MEC = 1;
        public const int VEC_ID_KRYSI_OCAS = 2;
        public const int VEC_ID_KOZESINA = 3;
        public const int VEC_ID_ZUB = 4;
        public const int VEC_ID_HADI_KUZE = 5;
        public const int VEC_ID_PALICE = 6;
        public const int VEC_ID_LEKTVAR_LECENI = 7;
        public const int VEC_ID_KUSADLA = 8;
        public const int VEC_ID_PAVUCINA = 9;
        public const int VEC_ID_PROPUSTKA = 10;

        public const int BESTIAR_ID_KRYSA = 1;
        public const int BESTIAR_ID_HAD = 2;
        public const int BESTIAR_ID_PAVOUK = 3;

        public const int UKOL_ID_HAVET = 1;
        public const int UKOL_ID_PAVOUCIKRALOVNA = 2;

        public const int MISTO_ID_CHATRC = 1;
        public const int MISTO_ID_NAMESTI = 2;
        public const int MISTO_ID_HOSTINEC = 3;
        public const int MISTO_ID_STRAZNICE = 4;
        public const int MISTO_ID_FARMA = 5;
        public const int MISTO_ID_SKLEPENI = 6;
        public const int MISTO_ID_MOST = 7;
        public const int MISTO_ID_ALCHYMISTA = 8;
        public const int MISTO_ID_BRANA = 9;

        static Svet()
        {
            VytvoritVeci();
            VytvoritMonstra();
            VytvoritUkoly();
            VytvoritMista();
        }
        public const int NEPRODEJNE_VECI = -1;
        private static void VytvoritVeci()
        {
            Predmety.Add(new Zbraně(VEC_ID_OBYC_MEC, "Obyčejný meč", "Obyčejné meče", 0, 5, 10, false));
            Predmety.Add(new Věc(VEC_ID_KRYSI_OCAS, "Krysí ocas", "Krysí ocasy",1));
            Predmety.Add(new Věc(VEC_ID_KOZESINA, "Kožešina", "Kožešiny", 1));
            Predmety.Add(new Věc(VEC_ID_ZUB, "Zub", "Zuby",1));
            Predmety.Add(new Věc(VEC_ID_HADI_KUZE, "Hadí kůže", "Hadí kůže", 2));
            Predmety.Add(new Zbraně(VEC_ID_PALICE, "Palice", "Palice", 0, 4, 5, false));
            Predmety.Add(new Lektvary(VEC_ID_LEKTVAR_LECENI, "Lektvar léčení", "Lektvary léčení", 5, 15));
            Predmety.Add(new Věc(VEC_ID_KUSADLA, "Kusadla", "Kusadla", 1));
            Predmety.Add(new Věc(VEC_ID_PAVUCINA, "Pavučina", "Pavučiny", 1));
            Predmety.Add(new Věc(VEC_ID_PROPUSTKA, "Propustka", "Propustky", NEPRODEJNE_VECI));
        }

        private static void VytvoritMonstra()
        {
            Bestiář krysa = new Bestiář(BESTIAR_ID_KRYSA, "Krysa", 3, 3, 1, 3, 3);
            krysa.Zisk.Add(new Korist(VecByID(VEC_ID_KRYSI_OCAS), 75));
            krysa.Zisk.Add(new Korist(VecByID(VEC_ID_KOZESINA), 75));

            Bestiář had = new Bestiář(BESTIAR_ID_HAD, "Had", 5, 3, 10, 3, 3);
            had.Zisk.Add(new Korist(VecByID(VEC_ID_ZUB), 75));
            had.Zisk.Add(new Korist(VecByID(VEC_ID_HADI_KUZE), 75));

            Bestiář pavouk = new Bestiář(BESTIAR_ID_PAVOUK, "Akromantule", 2, 5, 5, 5, 5);
            pavouk.Zisk.Add(new Korist(VecByID(VEC_ID_KUSADLA), 75));
            pavouk.Zisk.Add(new Korist(VecByID(VEC_ID_PAVUCINA), 75));

            Bestiar.Add(krysa);
            Bestiar.Add(had);
            Bestiar.Add(pavouk);
        }

        private static void VytvoritUkoly()
        {
            Ukoly Havet = new Ukoly(UKOL_ID_HAVET, "Havěť", "Zabij krysi v hostinci U Pikového krále. Jako důkaz přines hostinskému 5 krysích ocasů." +
                " Za odměnu získáš lektvar léčení a 10 zlaťáků.", 20, 10, false);
            Havet.Trofej.Add(new Trofej(VecByID(VEC_ID_KRYSI_OCAS), 5));
            Havet.Predmet = VecByID(VEC_ID_LEKTVAR_LECENI);

            Ukoly PavouciKralovna = new Ukoly(UKOL_ID_PAVOUCIKRALOVNA, "Pavoučí královna", "Zabij pavouky ve sklepení a alchymistovi přines 5 kusadel a 3 pavučiny." +
                "Za odměnu dostaneš meč a 15 zlaťáků.", 20, 15, false);
            PavouciKralovna.Trofej.Add(new Trofej(VecByID(VEC_ID_KUSADLA), 5));
            
            PavouciKralovna.Predmet = VecByID(VEC_ID_OBYC_MEC);
            PavouciKralovna.Pomoc.Add(new Inventar(VecByID(VEC_ID_LEKTVAR_LECENI),2));
            
            Mise.Add(Havet);
            Mise.Add(PavouciKralovna);

        }

        private static void VytvoritMista()
        {
            Místa chatrc = new Místa(MISTO_ID_CHATRC, "Chatrč", "Malá chatrč na kraji města, která zoufale potřebuje opravit.");
            Místa namesti = new Místa(MISTO_ID_NAMESTI, "Náměstí", "Na malém čtvercovém náměstí vidíš několik stánků.");
            Místa hostinec = new Místa(MISTO_ID_HOSTINEC, "Hostinec U Pikového krále", "Zatuchlá pajza pod hradbami s dost pochybnou společností.");
            hostinec.UkolJeKDispozici = UkolByID(UKOL_ID_HAVET);
            hostinec.NachaziSeZdePrisera = PriseraByID(BESTIAR_ID_KRYSA);
            hostinec.NachaziSeZdePrisera.Pocet = 6;
            hostinec.NachaziSeZdePrisera.Vychozi = hostinec.NachaziSeZdePrisera.Pocet;
            Obchodnik Hostinsky = new Obchodnik("Hostinský");
            Hostinsky.PridatDoInventare(VecByID(VEC_ID_LEKTVAR_LECENI), 2);
            hostinec.Obchodnik = Hostinsky;
            Místa straznice = new Místa(MISTO_ID_STRAZNICE, "Strážnice", "Před mohutnými okovanými dveřmi stojí znuděný strážný opírající se o svou halapartnu.");
            Místa farma = new Místa(MISTO_ID_FARMA, "Farma", "Za mostem se rozkládá farmářská usedlost zásobující město základními potravinami.");
            Místa sklepeni = new Místa(MISTO_ID_SKLEPENI, "Sklepení", "Sklepení pod strážnicí je na první pohled velmi nehostinné místo.");
            sklepeni.NachaziSeZdePrisera = PriseraByID(BESTIAR_ID_PAVOUK);
            sklepeni.NachaziSeZdePrisera.Pocet = 6;
            sklepeni.NachaziSeZdePrisera.Vychozi = sklepeni.NachaziSeZdePrisera.Pocet;
            sklepeni.UkolJeKDispozici = UkolByID(UKOL_ID_PAVOUCIKRALOVNA);
            Místa most = new Místa(MISTO_ID_MOST, "Most", "Most přes řeku spojující jižní bránu a farmářskou usedlost.");
            Místa alchymista = new Místa(MISTO_ID_ALCHYMISTA, "Alchymista", "Malý domek na samotě, ze kterého se často kouří, občas lze slyšet výbuch a vevnitř to zvláštně páchne.");
            alchymista.UkolJeKDispozici = UkolByID(UKOL_ID_PAVOUCIKRALOVNA);
            Obchodnik Alchymista = new Obchodnik("Alchymista");
            Alchymista.PridatDoInventare(VecByID(VEC_ID_HADI_KUZE), 5);
            Alchymista.PridatDoInventare(VecByID(VEC_ID_KOZESINA), 5);
            Alchymista.PridatDoInventare(VecByID(VEC_ID_KUSADLA), 5);
            Alchymista.PridatDoInventare(VecByID(VEC_ID_PAVUCINA), 5);
            Alchymista.PridatDoInventare(VecByID(VEC_ID_LEKTVAR_LECENI), 8);
            alchymista.Obchodnik = Alchymista;
            Místa brana = new Místa(MISTO_ID_BRANA, "Brána", "Severní brána, jediná cesta ven z města. Bedlivě hlídána několika strážnými.", VecByID(VEC_ID_PROPUSTKA));

            chatrc.NaSever = namesti;
            chatrc.NaJih = most;

            namesti.NaJih = chatrc;
            namesti.NaSever = brana;
            namesti.NaVychod = hostinec;
            namesti.NaZapad = alchymista;

            most.NaJih = farma;
            most.NaSever = chatrc;

            farma.NaSever = most;

            alchymista.NaVychod = namesti;
            alchymista.NaSever = straznice;

            straznice.NaJih = alchymista;
            straznice.NaVychod = sklepeni;

            sklepeni.NaZapad = straznice;
            sklepeni.NaJih = alchymista;

            hostinec.NaZapad = namesti;

            Mista.Add(chatrc);
            Mista.Add(namesti);
            Mista.Add(hostinec);
            Mista.Add(straznice);
            Mista.Add(farma);
            Mista.Add(sklepeni);
            Mista.Add(most);
            Mista.Add(alchymista);
            Mista.Add(brana);
            
        }

        public static Věc VecByID(int id)
        {
            foreach(Věc predmet in Predmety)
            {
                if(predmet.ID == id)
                {
                    return predmet;
                }
            }
            return null;
        }

        public static Bestiář PriseraByID(int id)
        {
            foreach(Bestiář prisera in Bestiar)
            {
                if(prisera.ID == id)
                {
                    return prisera;
                }
            }
            return null;
        }

        public static Ukoly UkolByID(int id)
        {
            foreach(Ukoly ukol in Mise)
            {
                if(ukol.ID == id)
                {
                    return ukol;
                }
            }
            return null;
        }

        public static Místa MistoByID(int id)
        {
            foreach(Místa misto in Mista)
            {
                if(misto.ID == id)
                {
                    return misto;
                }
            }
            return null;
        }
       

    }
}
