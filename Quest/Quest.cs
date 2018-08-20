using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEngine;



namespace Quest
{
    public partial class Quest : Form
    {
        private Player player;
        private Bestiář bestie;

        public Quest()
        {
            InitializeComponent();
            //Vytvoření nového hráče se staty, přidání zbraně do inventáře a přesunutí do počáteční polohy
            player = new Player(10, 10, 20, 0, 1);
            player.PridatDoInventare(Svet.VecByID(Svet.VEC_ID_PALICE));
            Presun(Svet.MistoByID(Svet.MISTO_ID_CHATRC));

            //Popsání počtu životů, zlata, zkušeností a aktuální úroveň            
            lblzivoty.Text = player.Aktualzdravi.ToString();
            lblzlato.Text = player.Zlato.ToString();
            lblexp.Text = player.Exp.ToString();
            lbllev.Text = player.Uroven.ToString();

        }

        public void ScrollDown()
        {
            rtbZpravy.SelectionStart = rtbZpravy.Text.Length;
            rtbZpravy.ScrollToCaret();
        }

        private void btnSever_Click(object sender, EventArgs e)
        {
            Presun(player.poloha.NaSever);
        }

        private void btnJih_Click(object sender, EventArgs e)
        {
            Presun(player.poloha.NaJih);
        }

        private void btnZapad_Click(object sender, EventArgs e)
        {
            Presun(player.poloha.NaZapad);
        }

        private void btnVychod_Click(object sender, EventArgs e)
        {
            Presun(player.poloha.NaVychod);
        }

        private void Presun(Místa noveMisto)
        {
            //Kontrola jestli má hráč přístup na dané místo
            if (!player.MaPozadovanyPredmet(noveMisto))
            {
                rtbZpravy.Text += "Pro vstup do " + noveMisto.Jméno + "musíš mít " + noveMisto.JePotrebaPredmet.Jmeno + Environment.NewLine;
                return;
                ScrollDown();
            }


            player.poloha = noveMisto;
            //Zviditelnění příslušných tlačítek pohybu
            btnSever.Visible = (noveMisto.NaSever != null);
            btnVychod.Visible = (noveMisto.NaVychod != null);
            btnJih.Visible = (noveMisto.NaJih != null);
            btnZapad.Visible = (noveMisto.NaZapad != null);

            rtbMisto.Text = noveMisto.Jméno + Environment.NewLine;
            rtbMisto.Text += noveMisto.Popis + Environment.NewLine;

            btnObchod.Visible = (noveMisto.Obchodnik != null);
                       

            //Kontrola jestli je na aktuální poloze k dispozici nový úkol
            if (noveMisto.UkolJeKDispozici != null)
            {
                bool UkolZadan = player.MaTentoUkol(noveMisto.UkolJeKDispozici);
                bool UkolSplnen = player.UkolDokoncen(noveMisto.UkolJeKDispozici);

                //Kontrola, jestli byl úkol zadán nebo už i splněn
                foreach (Cechmistr ukol in player.Mise)
                {
                    if (ukol.Detaily.ID == noveMisto.UkolJeKDispozici.ID)
                    {
                        UkolZadan = true;

                        if (ukol.Dokoncen)
                        {
                            UkolSplnen = true;
                        }


                    }
                }

                if (UkolZadan)
                {
                    if (!UkolSplnen)
                    {
                        bool hracMaVseKDispozici = player.MaVsechnyTrofeje(noveMisto.UkolJeKDispozici);

                        //V případě, že má hráč všechny předměty potřebné k dokončení úkolu, tak se úkol dokončí a hráč získá odměny. 
                        if (hracMaVseKDispozici)
                        {
                            rtbZpravy.Text += Environment.NewLine;
                            rtbZpravy.Text += "Dokončil jsi úkol: " + noveMisto.UkolJeKDispozici.Jmeno + Environment.NewLine;
                            ScrollDown();

                            player.OdstranitTrofejeZInventare(noveMisto.UkolJeKDispozici);

                            rtbZpravy.Text += "Získáváš: " + Environment.NewLine;
                            rtbZpravy.Text += noveMisto.UkolJeKDispozici.Expy.ToString() + " zkušeností" + Environment.NewLine;
                            rtbZpravy.Text += noveMisto.UkolJeKDispozici.Odmena.ToString() + " zlatých" + Environment.NewLine;
                            rtbZpravy.Text += noveMisto.UkolJeKDispozici.Predmet.Jmeno + Environment.NewLine;
                            rtbZpravy.Text += Environment.NewLine;
                            ScrollDown();

                            player.Exp += noveMisto.UkolJeKDispozici.Expy;
                            player.Zlato += noveMisto.UkolJeKDispozici.Odmena;

                            player.PridatDoInventare(noveMisto.UkolJeKDispozici.Predmet);

                            player.UkolBylDokoncen(noveMisto.UkolJeKDispozici);

                            noveMisto.UkolJeKDispozici.Dokoncen = true;

                        }
                    }
                }
                //Zadání nového úkolu
                else
                {
                    rtbZpravy.Text += "Byl zadán úkol: " + noveMisto.UkolJeKDispozici.Jmeno + Environment.NewLine;
                    rtbZpravy.Text += noveMisto.UkolJeKDispozici.Popis + Environment.NewLine;
                    rtbZpravy.Text += "K dokončení úkolu je třeba přinést:" + Environment.NewLine;

                    ScrollDown();
                    //Vypsání toho, co hráč potřebuje k dokončení úkolu
                    foreach (Trofej trof in noveMisto.UkolJeKDispozici.Trofej)
                    {
                        if (trof.Mnozstvi == 1)
                        {
                            rtbZpravy.Text += trof.Mnozstvi.ToString() + " " + trof.Detaily.Jmeno + Environment.NewLine;
                            ScrollDown();
                        }
                        else
                        {
                            rtbZpravy.Text += trof.Mnozstvi.ToString() + " " + trof.Detaily.Jmena + Environment.NewLine;
                            ScrollDown();
                        }

                    }
                    //Pomocné předměty ke splnění úkolu
                    foreach (Inventar pomoc in noveMisto.UkolJeKDispozici.Pomoc)
                    {
                        rtbZpravy.Text += "Dostal jsi:" + pomoc.Detaily.Jmeno + Environment.NewLine;
                        player.PridatDoInventare(pomoc.Detaily);
                        rtbZpravy.Text += Environment.NewLine;
                    }
                    //Přidání nového úkolu na seznam
                    player.Mise.Add(new Cechmistr(noveMisto.UkolJeKDispozici));

                }
            }
            //Kontrola příšer
            if (noveMisto.NachaziSeZdePrisera != null)
            {
                //Na místě ještě jsou nějaké příšery
                if (noveMisto.NachaziSeZdePrisera.Pocet > 0)
                {
                    rtbZpravy.Text += "Vidíš " + noveMisto.NachaziSeZdePrisera.Jmeno + Environment.NewLine;

                    Bestiář prisera = Svet.PriseraByID(noveMisto.NachaziSeZdePrisera.ID);
                    bestie = new Bestiář(prisera.ID, prisera.Jmeno, prisera.Maxutok, prisera.Expy, prisera.Odmena, prisera.Aktualzdravi, prisera.Maxzdravi);
                    foreach (Korist korist in prisera.Zisk)
                    {
                        bestie.Zisk.Add(korist);
                    }
                    //Přepnutí do bojového módu
                    cboZbrane.Visible = true;
                    cboLektvary.Visible = true;
                    btnPouzitZbran.Visible = true;
                    btnPouzitLektvar.Visible = true;
                    lblUtok.Visible = true;
                }
                //Vypnutí bojového módu
                else
                {
                    cboZbrane.Visible = false;
                    cboLektvary.Visible = false;
                    btnPouzitZbran.Visible = false;
                    btnPouzitLektvar.Visible = false;
                    lblUtok.Visible = false;

                }

            }
            //Nejsou příšery
            else
            {
                bestie = null;

                cboZbrane.Visible = false;
                cboLektvary.Visible = false;
                btnPouzitLektvar.Visible = false;
                btnPouzitZbran.Visible = false;
                lblUtok.Visible = false;

            }

            AktualizaceInventare();

            AktualizaceUkolu();

            AktualizaceZbrani();

            AktualizaceLektvaru();
        }

        public void AktualizaceInventare()
        {
            dgvInventar.RowHeadersVisible = false;
            dgvInventar.ColumnCount = 4;
            dgvInventar.Rows.Clear();
            dgvInventar.Columns[0].Visible = false;
            dgvInventar.Columns[0].DataPropertyName = "VecID";
            dgvInventar.Columns[1].Name = "Jméno";
            dgvInventar.Columns[1].Width = 197;
            dgvInventar.Columns[2].Name = "Množství";
            dgvInventar.Columns[2].Width = 70;
            dgvInventar.Columns[3].Name = "Cena";
            dgvInventar.Columns[3].Width = 70;
            dgvInventar.Columns.Add(new DataGridViewButtonColumn
            {
                Text = "Prodat 1",
                UseColumnTextForButtonValue = true,
                Width = 50,
                DataPropertyName = "VecID",
                Visible = false
            });
            

            foreach (Inventar inventar in player.Inventar)
            {
                if (inventar.Mnozstvi > 0)
                {
                    dgvInventar.Rows.Add(new[] {inventar.VecID.ToString(), inventar.Detaily.Jmeno, inventar.Mnozstvi.ToString(), inventar.Detaily.Cena.ToString() });
                }

            }
            dgvInventar.CellClick += dgvInventar_CellClick;
            lblzlato.Text = player.Zlato.ToString();
        }

        private void AktualizaceUkolu()
        {
            dgvUkoly.RowHeadersVisible = false;
            dgvUkoly.ColumnCount = 2;
            dgvUkoly.Columns[0].Name = "Jméno";
            dgvUkoly.Columns[0].Width = 197;
            dgvUkoly.Columns[1].Name = "Dokončen?";
            dgvUkoly.Rows.Clear();

            foreach (Cechmistr ukoly in player.Mise)
            {
                dgvUkoly.Rows.Add(new[] { ukoly.Detaily.Jmeno, ukoly.Dokoncen.ToString() });
            }
        }

        private void AktualizaceZbrani()
        {
           List<Zbraně> zbraně = new List<Zbraně>();

            foreach (Inventar inventar in player.Inventar)
            {
                if (inventar.Detaily is Zbraně)
                {
                    if (inventar.Mnozstvi > 0)
                    {
                        zbraně.Add((Zbraně)inventar.Detaily);
                    }
                }
            }

            if (zbraně.Count == 0)
            {
                cboZbrane.Visible = false;
                btnPouzitZbran.Visible = false;
                lblUtok.Visible = false;
            }
            else
            {
                cboZbrane.DataSource = zbraně;
                cboZbrane.DisplayMember = "Jmeno";
                cboZbrane.ValueMember = "ID";
                cboZbrane.SelectedIndex = 0;
                foreach (Zbraně z in zbraně)
                {
                    if (z.Aktiv == true)
                    {
                        cboZbrane.SelectedItem = z;
                    }
                }
                
            }
        }

        private void AktualizaceLektvaru()
        {
            List<Lektvary> lektvary = new List<Lektvary>();

            foreach (Inventar inventar in player.Inventar)
            {
                if (inventar.Detaily is Lektvary)
                {
                    if (inventar.Mnozstvi > 0)
                    {
                        lektvary.Add((Lektvary)inventar.Detaily);
                    }
                }
            }

            if (lektvary.Count == 0)
            {
                cboLektvary.Visible = false;
                btnPouzitLektvar.Visible = false;
            }
            else
            {
                cboLektvary.DataSource = lektvary;
                cboLektvary.DisplayMember = "Jmeno";
                cboLektvary.ValueMember = "ID";
                cboLektvary.SelectedIndex = 0;
            }
        }


        private void btnPouzitZbran_Click(object sender, EventArgs e)
        {
            Zbraně aktivniZbran = (Zbraně)cboZbrane.SelectedItem;
            
            //Útok hráče
            int ZZ = Kostky.CisloMezi(aktivniZbran.Minutok, aktivniZbran.Maxutok);

            bestie.Aktualzdravi -= ZZ;

            rtbZpravy.Text += "Zasáhl jsi " + bestie.Jmeno + " za " + ZZ.ToString() + " bodů." + Environment.NewLine;
            ScrollDown();

            //Smrt příšery a získání odměn
            if (bestie.Aktualzdravi <= 0)
            {
                rtbZpravy.Text += Environment.NewLine;
                rtbZpravy.Text += "Porazil jsi " + bestie.Jmeno + Environment.NewLine;
                ScrollDown();

                player.Exp += bestie.Expy;
                rtbZpravy.Text += "Získal jsi " + bestie.Expy.ToString() + " bodů zkušenosti." + Environment.NewLine;
                ScrollDown();

                player.Zlato += bestie.Odmena;
                rtbZpravy.Text += "Získal jsi " + bestie.Odmena.ToString() + " zlata." + Environment.NewLine;
                ScrollDown();


                List<Inventar> korist = new List<Inventar>();
                foreach (Korist kor in bestie.Zisk)
                {
                    if (Kostky.CisloMezi(1, 100) <= kor.Sance)
                    {
                        korist.Add(new Inventar(kor.Detaily, 1));
                    }
                }

               
                //Přidání odměn do inventáře
                foreach (Inventar invent in korist)
                {
                    player.PridatDoInventare(invent.Detaily);

                    if (invent.Mnozstvi == 1)
                    {
                        rtbZpravy.Text += "Získal jsi " + invent.Mnozstvi.ToString() + " " + invent.Detaily.Jmeno + Environment.NewLine;
                        ScrollDown();
                    }
                    else
                    {
                        rtbZpravy.Text += "Získal jsi " + invent.Mnozstvi.ToString() + " " + invent.Detaily.Jmena + Environment.NewLine;
                        ScrollDown();
                    }
                }

                lblexp.Text = player.Exp.ToString();

                AktualizaceInventare();
                AktualizaceZbrani();
                AktualizaceLektvaru();

                rtbZpravy.Text += Environment.NewLine;
                ScrollDown();
                //Přidání příšery pokud už na místě žádné nejsou, ale hráč ještě nemá požadovaný počet předmětů ke splnění úkolů
                player.poloha.NachaziSeZdePrisera.Pocet--;
                if (player.poloha.NachaziSeZdePrisera.Pocet == 0 && player.poloha.UkolJeKDispozici != null && player.poloha.UkolJeKDispozici.Dokoncen == false)
                {
                    player.poloha.NachaziSeZdePrisera.Pocet++;
                }

                Presun(player.poloha);
            }
            //Útok příšery
            else
            {
                int ZB = Kostky.CisloMezi(0, bestie.Maxutok);
                rtbZpravy.Text += bestie.Jmeno + " ti způsobil/a zranění za " + ZB.ToString() + " bodů." + Environment.NewLine;
                ScrollDown();
                player.Aktualzdravi -= ZB;
                lblzivoty.Text = player.Aktualzdravi.ToString();
                //Smrt postavy
                if (player.Aktualzdravi <= 0)
                {
                    rtbZpravy.Text += bestie.Jmeno + " tě zabil/a." + Environment.NewLine;
                    ScrollDown();
                    //Vyčištění invetáře a přidání počáteční zbraně
                    dgvInventar.Rows.Clear();
                    player.Inventar.Clear();
                    player.PridatDoInventare(Svet.VecByID(Svet.VEC_ID_PALICE), 1);
                    //Vyčištění misí
                    player.Mise.Clear();
                    dgvUkoly.Rows.Clear();
                    //Počáteční poloha
                    Presun(Svet.MistoByID(Svet.MISTO_ID_CHATRC));
                    //Počáteční staty
                    player.Maxzdravi = 10;
                    player.Aktualzdravi = 10;
                    player.Zlato = 20;
                    player.Exp = 0;
                    player.Uroven = 1;
                    lblzivoty.Text = player.Aktualzdravi.ToString();
                    lblzlato.Text = player.Zlato.ToString();
                    lblexp.Text = player.Exp.ToString();
                    lbllev.Text = player.Uroven.ToString();
                    //Aktualizace počtu příšer
                    Svet.MistoByID(Svet.MISTO_ID_HOSTINEC).NachaziSeZdePrisera.Pocet = Svet.MistoByID(Svet.MISTO_ID_HOSTINEC).NachaziSeZdePrisera.Vychozi;
                    Svet.MistoByID(Svet.MISTO_ID_SKLEPENI).NachaziSeZdePrisera.Pocet = Svet.MistoByID(Svet.MISTO_ID_SKLEPENI).NachaziSeZdePrisera.Vychozi;
                }
            }
        }

        
        private void btnPouzitLektvar_Click(object sender, EventArgs e)
        {
            //Vypití lektvaru
            Lektvary lektvar = (Lektvary)cboLektvary.SelectedItem;
            player.Aktualzdravi = (player.Aktualzdravi + lektvar.Leceni);
            if (player.Aktualzdravi > player.Maxzdravi)
            {
                player.Aktualzdravi = player.Maxzdravi;
            }

            foreach (Inventar i in player.Inventar)
            {
                if (i.Detaily.ID == lektvar.ID)
                {
                    i.Mnozstvi--;
                    break;
                }
            }

            rtbZpravy.Text += "Vypil jsi " + lektvar.Jmeno + Environment.NewLine;
            ScrollDown();
            //Útok příšery
            int ZB = Kostky.CisloMezi(0, bestie.Maxutok);

            rtbZpravy.Text += bestie.Jmeno + " ti způsobila zranění za " + ZB.ToString() + " bodů." + Environment.NewLine;
            ScrollDown();
            player.Aktualzdravi -= ZB;
            //Smrt postavy
            if (player.Aktualzdravi <= 0)
            {
                rtbZpravy.Text += bestie.Jmeno + " tě zabil/a." + Environment.NewLine;
                ScrollDown();
                dgvInventar.Rows.Clear();
                player.Inventar.Clear();
                player.PridatDoInventare(Svet.VecByID(Svet.VEC_ID_PALICE), 1);
                dgvUkoly.Rows.Clear();
                Presun(Svet.MistoByID(Svet.MISTO_ID_CHATRC));
                player.Maxzdravi = 10;
                player.Aktualzdravi = 10;
                player.Zlato = 20;
                player.Exp = 0;
                player.Uroven = 1;
                lblzivoty.Text = player.Aktualzdravi.ToString();
                lblzlato.Text = player.Zlato.ToString();
                lblexp.Text = player.Exp.ToString();
                lbllev.Text = player.Uroven.ToString();
                //Aktualizace počtu příšer
                Svet.MistoByID(Svet.MISTO_ID_HOSTINEC).NachaziSeZdePrisera.Pocet = Svet.MistoByID(Svet.MISTO_ID_HOSTINEC).NachaziSeZdePrisera.Vychozi;
                Svet.MistoByID(Svet.MISTO_ID_SKLEPENI).NachaziSeZdePrisera.Pocet = Svet.MistoByID(Svet.MISTO_ID_SKLEPENI).NachaziSeZdePrisera.Vychozi;

            }

            lblzivoty.Text = player.Aktualzdravi.ToString();
            AktualizaceInventare();
            AktualizaceLektvaru();

        }

        //Příchod do obchodu
        private void btnObchod_Click(object sender, EventArgs e)
        {
            AktualizaceInventare();
            //Zviditelní tlačítka prodat a vytvoření obchodníkova inventáře.
            dgvInventar.Columns[4].Visible = true;
            dgvObchod.RowHeadersVisible = false;
            dgvObchod.Rows.Clear();
            dgvObchod.ColumnCount = 4;
            dgvObchod.Columns[0].Visible = false;
            dgvObchod.Columns[0].DataPropertyName = "VecID";
            dgvObchod.Columns[1].Name = "Jméno";
            dgvObchod.Columns[1].Width = 197;
            dgvObchod.Columns[2].Name = "Množství";
            dgvObchod.Columns[2].Width = 70;
            dgvObchod.Columns[3].Name = "Cena";
            dgvObchod.Columns[3].Width = 70;
            dgvObchod.Columns.Add(new DataGridViewButtonColumn
            {
                Text = "Koupit 1",
                UseColumnTextForButtonValue = true,
                Width = 50,
                DataPropertyName = "VecID"
            });
            
            foreach (Inventar inventar in player.poloha.Obchodnik.Inventar)
            {
                if (inventar.Mnozstvi > 0)
                {
                    dgvObchod.Rows.Add(new[] { inventar.VecID.ToString(), inventar.Detaily.Jmeno, inventar.Mnozstvi.ToString(), inventar.Detaily.Cena.ToString() });
                }
            }

            dgvObchod.CellClick += dgvObchod_CellClick;
            dgvObchod.Visible = true;
            //Zneviditelnění ostatních tlačítek - pohybu, boje...
            btnObchod.Visible = false;
            btnZObchodu.Visible = true;
            btnJih.Visible = false;
            btnSever.Visible = false;
            btnVychod.Visible = false;
            btnZapad.Visible = false;
            cboLektvary.Visible = false;
            cboZbrane.Visible = false;
            btnPouzitZbran.Visible = false;
            btnPouzitLektvar.Visible = false;
            lblUtok.Visible = false;
        }

        
        //Kliknutí na tlačítko prodat
        private void dgvInventar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                var vecID = dgvInventar.Rows[e.RowIndex].Cells[0].Value;
                Věc prodatVec = Svet.VecByID(Convert.ToInt32(vecID));
                if (prodatVec.Cena == Svet.NEPRODEJNE_VECI)
                {
                    MessageBox.Show("Nemůžeš prodat věc jménem: " + prodatVec.Jmeno);
                }
                else
                {
                    player.poloha.Obchodnik.PridatDoInventare(prodatVec);
                    player.OdebratZInventare(prodatVec);
                    player.Zlato += prodatVec.Cena;
                    AktualizaceInventare();
                    dgvInventar.Columns[4].Visible = true;
                    dgvObchod.Rows.Clear();
                    foreach (Inventar inventar in player.poloha.Obchodnik.Inventar)
                    {
                        if (inventar.Mnozstvi > 0)
                        {
                            dgvObchod.Rows.Add(new[] { inventar.VecID.ToString(), inventar.Detaily.Jmeno, inventar.Mnozstvi.ToString(), inventar.Detaily.Cena.ToString() });
                        }

                    }
                }
            }
        }

        //Kliknutí na tlačítko koupit
        private void dgvObchod_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                var vecID = dgvObchod.Rows[e.RowIndex].Cells[0].Value;
                Věc zbozi = Svet.VecByID(Convert.ToInt32(vecID));
                if (player.Zlato >= zbozi.Cena)
                {
                    player.PridatDoInventare(zbozi);
                    player.Zlato -= zbozi.Cena;
                    AktualizaceInventare();
                    dgvInventar.Columns[4].Visible = true;
                    player.poloha.Obchodnik.OdebratZInventare(zbozi);
                    dgvObchod.Rows.Clear();
                    foreach (Inventar inventar in player.poloha.Obchodnik.Inventar)
                    {
                        if (inventar.Mnozstvi > 0)
                        {
                            dgvObchod.Rows.Add(new[] { inventar.VecID.ToString(), inventar.Detaily.Jmeno, inventar.Mnozstvi.ToString(), inventar.Detaily.Cena.ToString() });
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Nemáš dostatek zlata ke koupi " + zbozi.Jmeno);
                }
            }
        }

        //Odchod z obchodu, zviditelnění tlačítek pohybu a případně boje
        private void btnZObchodu_Click(object sender, EventArgs e)
        {
            dgvInventar.Columns[4].Visible = false;
            dgvObchod.Visible = false;
            btnObchod.Visible = true;
            btnZObchodu.Visible = false;
            btnSever.Visible = (player.poloha.NaSever != null);
            btnVychod.Visible = (player.poloha.NaVychod != null);
            btnJih.Visible = (player.poloha.NaJih != null);
            btnZapad.Visible = (player.poloha.NaZapad != null);
            if (player.poloha.NachaziSeZdePrisera != null && player.poloha.NachaziSeZdePrisera.Pocet > 0)
            {
                cboLektvary.Visible = true;
                cboZbrane.Visible = true;
                btnPouzitZbran.Visible = true;
                btnPouzitLektvar.Visible = true;
                lblUtok.Visible = true;
                AktualizaceLektvaru();
            }
        }

        //Změna zbraně
        private void cboZbrane_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Zbraně> zbraně = new List<Zbraně>();
            Zbraně aktivniZbran = (Zbraně)cboZbrane.SelectedItem;
            lblUtok.Text = "Útok: " + aktivniZbran.Maxutok.ToString();
            foreach (Zbraně z in zbraně)
            {
                z.Aktiv = false;
            }
            aktivniZbran.Aktiv = true;
        }
    }

}
