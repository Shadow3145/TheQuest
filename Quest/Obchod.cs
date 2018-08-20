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
using Quest;

namespace Quest
{
    public partial class Obchod : Form
    {
        private Player _player;
        Quest quest = new Quest();
        public Obchod(Player player)
        {
            _player = player;
            InitializeComponent();

            DataGridViewCellStyle ZarovnaneVpravo = new DataGridViewCellStyle();
            ZarovnaneVpravo.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMojeVeci.RowHeadersVisible = false;
            dgvMojeVeci.AutoGenerateColumns = false;

            dgvMojeVeci.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "VecID",
                Visible = false
            });

            dgvMojeVeci.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Jméno",
                Width = 100,
                DataPropertyName = "Jmeno",

                
            });

            dgvMojeVeci.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Množství",
                Width = 30,
                DefaultCellStyle = ZarovnaneVpravo,
                DataPropertyName = "Mnozstvi"
            });

            dgvMojeVeci.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cena",
                Width = 35,
                DefaultCellStyle = ZarovnaneVpravo,
                DataPropertyName = "Cena"
            });

            dgvMojeVeci.Columns.Add(new DataGridViewButtonColumn
            {
                Text = "Prodat 1",
                UseColumnTextForButtonValue = true,
                Width = 50,
                DataPropertyName = "VecID"
            });

            dgvMojeVeci.DataSource = _player.Inventar;
            dgvMojeVeci.CellClick += dgvMojeVeci_CellClick;



            dgvObchodnikovyVeci.RowHeadersVisible = false;
            dgvObchodnikovyVeci.AutoGenerateColumns = false;

            dgvObchodnikovyVeci.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "VecID",
                Visible = false
            });

            dgvObchodnikovyVeci.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Jméno",
                Width = 100,
                DataPropertyName = "Jmeno"
            });

            dgvObchodnikovyVeci.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cena",
                Width = 35,
                DefaultCellStyle = ZarovnaneVpravo,
                DataPropertyName = "Cena"
            });

            dgvObchodnikovyVeci.Columns.Add(new DataGridViewButtonColumn
            {
                Text = "Koupit 1",
                UseColumnTextForButtonValue = true,
                Width = 50,
                DataPropertyName = "VecID"
            });

            dgvObchodnikovyVeci.DataSource = _player.poloha.Obchodnik.Inventar;
            dgvObchodnikovyVeci.CellClick += dgvObchodnikovyVeci_CellClick;
                  
        }

        private void btnZavrit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvMojeVeci_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 4)
            {
                var vecID = dgvMojeVeci.Rows[e.RowIndex].Cells[0].Value;
                Věc prodatVec = Svet.VecByID(Convert.ToInt32(vecID));

                if(prodatVec.Cena == Svet.NEPRODEJNE_VECI)
                {
                    MessageBox.Show("Nemůžeš prodat " + prodatVec.Jmeno);
                }
                else
                {
                   _player.OdebratZInventare(prodatVec);
                   _player.Zlato += prodatVec.Cena;
                    quest.AktualizaceInventare();
                                     
                }
            }

        }
        

        private void dgvObchodnikovyVeci_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 3)
            {
                var vecID = dgvObchodnikovyVeci.Rows[e.RowIndex].Cells[0].Value;

                Věc zbozi = Svet.VecByID(Convert.ToInt32(vecID));

                if(_player.Zlato >= zbozi.Cena)
                {
                    _player.PridatDoInventare(zbozi);

                    _player.Zlato -= zbozi.Cena;
                    quest.AktualizaceInventare();


                }
                else
                {
                    MessageBox.Show("Nemáš dostatek zlata ke koupi " + zbozi.Jmeno);
                }
            }
        }
    }
}
