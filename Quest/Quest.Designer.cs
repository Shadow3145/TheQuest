namespace Quest
{
    partial class Quest
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quest));
            this.btnObchod = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblzivoty = new System.Windows.Forms.Label();
            this.lblzlato = new System.Windows.Forms.Label();
            this.lblexp = new System.Windows.Forms.Label();
            this.lbllev = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboZbrane = new System.Windows.Forms.ComboBox();
            this.cboLektvary = new System.Windows.Forms.ComboBox();
            this.btnPouzitZbran = new System.Windows.Forms.Button();
            this.btnPouzitLektvar = new System.Windows.Forms.Button();
            this.btnSever = new System.Windows.Forms.Button();
            this.btnVychod = new System.Windows.Forms.Button();
            this.btnJih = new System.Windows.Forms.Button();
            this.btnZapad = new System.Windows.Forms.Button();
            this.rtbMisto = new System.Windows.Forms.RichTextBox();
            this.rtbZpravy = new System.Windows.Forms.RichTextBox();
            this.dgvUkoly = new System.Windows.Forms.DataGridView();
            this.dgvObchod = new System.Windows.Forms.DataGridView();
            this.btnZObchodu = new System.Windows.Forms.Button();
            this.lblUtok = new System.Windows.Forms.Label();
            this.lblLeceni = new System.Windows.Forms.Label();
            this.dgvInventar = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUkoly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObchod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnObchod
            // 
            this.btnObchod.Location = new System.Drawing.Point(619, 621);
            this.btnObchod.Name = "btnObchod";
            this.btnObchod.Size = new System.Drawing.Size(75, 23);
            this.btnObchod.TabIndex = 21;
            this.btnObchod.Text = "Do obchodu";
            this.btnObchod.UseVisualStyleBackColor = true;
            this.btnObchod.Visible = false;
            this.btnObchod.Click += new System.EventHandler(this.btnObchod_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Životy:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Zlato:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Zkušenosti:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Úroveň:";
            // 
            // lblzivoty
            // 
            this.lblzivoty.AutoSize = true;
            this.lblzivoty.Location = new System.Drawing.Point(110, 19);
            this.lblzivoty.Name = "lblzivoty";
            this.lblzivoty.Size = new System.Drawing.Size(0, 13);
            this.lblzivoty.TabIndex = 4;
            // 
            // lblzlato
            // 
            this.lblzlato.AutoSize = true;
            this.lblzlato.Location = new System.Drawing.Point(110, 45);
            this.lblzlato.Name = "lblzlato";
            this.lblzlato.Size = new System.Drawing.Size(0, 13);
            this.lblzlato.TabIndex = 5;
            // 
            // lblexp
            // 
            this.lblexp.AutoSize = true;
            this.lblexp.Location = new System.Drawing.Point(110, 73);
            this.lblexp.Name = "lblexp";
            this.lblexp.Size = new System.Drawing.Size(0, 13);
            this.lblexp.TabIndex = 6;
            // 
            // lbllev
            // 
            this.lbllev.AutoSize = true;
            this.lbllev.Location = new System.Drawing.Point(110, 99);
            this.lbllev.Name = "lbllev";
            this.lbllev.Size = new System.Drawing.Size(0, 13);
            this.lbllev.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(743, 532);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Vyber akci";
            // 
            // cboZbrane
            // 
            this.cboZbrane.FormattingEnabled = true;
            this.cboZbrane.Location = new System.Drawing.Point(495, 560);
            this.cboZbrane.Name = "cboZbrane";
            this.cboZbrane.Size = new System.Drawing.Size(96, 21);
            this.cboZbrane.TabIndex = 9;
            this.cboZbrane.SelectedIndexChanged += new System.EventHandler(this.cboZbrane_SelectedIndexChanged);
            // 
            // cboLektvary
            // 
            this.cboLektvary.FormattingEnabled = true;
            this.cboLektvary.Location = new System.Drawing.Point(495, 594);
            this.cboLektvary.Name = "cboLektvary";
            this.cboLektvary.Size = new System.Drawing.Size(96, 21);
            this.cboLektvary.TabIndex = 10;
            // 
            // btnPouzitZbran
            // 
            this.btnPouzitZbran.Location = new System.Drawing.Point(746, 560);
            this.btnPouzitZbran.Name = "btnPouzitZbran";
            this.btnPouzitZbran.Size = new System.Drawing.Size(72, 21);
            this.btnPouzitZbran.TabIndex = 11;
            this.btnPouzitZbran.Text = "Použít";
            this.btnPouzitZbran.UseVisualStyleBackColor = true;
            this.btnPouzitZbran.Click += new System.EventHandler(this.btnPouzitZbran_Click);
            // 
            // btnPouzitLektvar
            // 
            this.btnPouzitLektvar.Location = new System.Drawing.Point(746, 594);
            this.btnPouzitLektvar.Name = "btnPouzitLektvar";
            this.btnPouzitLektvar.Size = new System.Drawing.Size(72, 21);
            this.btnPouzitLektvar.TabIndex = 12;
            this.btnPouzitLektvar.Text = "Vypít";
            this.btnPouzitLektvar.UseVisualStyleBackColor = true;
            this.btnPouzitLektvar.Click += new System.EventHandler(this.btnPouzitLektvar_Click);
            // 
            // btnSever
            // 
            this.btnSever.Location = new System.Drawing.Point(619, 434);
            this.btnSever.Name = "btnSever";
            this.btnSever.Size = new System.Drawing.Size(72, 43);
            this.btnSever.TabIndex = 13;
            this.btnSever.Text = "Sever";
            this.btnSever.UseVisualStyleBackColor = true;
            this.btnSever.Click += new System.EventHandler(this.btnSever_Click);
            // 
            // btnVychod
            // 
            this.btnVychod.Location = new System.Drawing.Point(699, 458);
            this.btnVychod.Name = "btnVychod";
            this.btnVychod.Size = new System.Drawing.Size(72, 43);
            this.btnVychod.TabIndex = 14;
            this.btnVychod.Text = "Východ";
            this.btnVychod.UseVisualStyleBackColor = true;
            this.btnVychod.Click += new System.EventHandler(this.btnVychod_Click);
            // 
            // btnJih
            // 
            this.btnJih.Location = new System.Drawing.Point(619, 488);
            this.btnJih.Name = "btnJih";
            this.btnJih.Size = new System.Drawing.Size(72, 43);
            this.btnJih.TabIndex = 15;
            this.btnJih.Text = "Jih";
            this.btnJih.UseVisualStyleBackColor = true;
            this.btnJih.Click += new System.EventHandler(this.btnJih_Click);
            // 
            // btnZapad
            // 
            this.btnZapad.Location = new System.Drawing.Point(538, 458);
            this.btnZapad.Name = "btnZapad";
            this.btnZapad.Size = new System.Drawing.Size(72, 43);
            this.btnZapad.TabIndex = 16;
            this.btnZapad.Text = "Západ";
            this.btnZapad.UseVisualStyleBackColor = true;
            this.btnZapad.Click += new System.EventHandler(this.btnZapad_Click);
            // 
            // rtbMisto
            // 
            this.rtbMisto.Location = new System.Drawing.Point(473, 20);
            this.rtbMisto.Name = "rtbMisto";
            this.rtbMisto.ReadOnly = true;
            this.rtbMisto.Size = new System.Drawing.Size(360, 105);
            this.rtbMisto.TabIndex = 17;
            this.rtbMisto.Text = "";
            // 
            // rtbZpravy
            // 
            this.rtbZpravy.Location = new System.Drawing.Point(473, 131);
            this.rtbZpravy.Name = "rtbZpravy";
            this.rtbZpravy.ReadOnly = true;
            this.rtbZpravy.Size = new System.Drawing.Size(360, 286);
            this.rtbZpravy.TabIndex = 18;
            this.rtbZpravy.Text = "";
            // 
            // dgvUkoly
            // 
            this.dgvUkoly.AllowUserToAddRows = false;
            this.dgvUkoly.AllowUserToDeleteRows = false;
            this.dgvUkoly.AllowUserToResizeRows = false;
            this.dgvUkoly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUkoly.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvUkoly.Enabled = false;
            this.dgvUkoly.Location = new System.Drawing.Point(16, 446);
            this.dgvUkoly.MultiSelect = false;
            this.dgvUkoly.Name = "dgvUkoly";
            this.dgvUkoly.ReadOnly = true;
            this.dgvUkoly.RowHeadersVisible = false;
            this.dgvUkoly.Size = new System.Drawing.Size(312, 189);
            this.dgvUkoly.TabIndex = 20;
            // 
            // dgvObchod
            // 
            this.dgvObchod.AllowUserToAddRows = false;
            this.dgvObchod.AllowUserToDeleteRows = false;
            this.dgvObchod.AllowUserToResizeRows = false;
            this.dgvObchod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObchod.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvObchod.Location = new System.Drawing.Point(473, 131);
            this.dgvObchod.MultiSelect = false;
            this.dgvObchod.Name = "dgvObchod";
            this.dgvObchod.ReadOnly = true;
            this.dgvObchod.RowHeadersVisible = false;
            this.dgvObchod.Size = new System.Drawing.Size(401, 309);
            this.dgvObchod.TabIndex = 22;
            this.dgvObchod.Visible = false;
            // 
            // btnZObchodu
            // 
            this.btnZObchodu.Location = new System.Drawing.Point(660, 621);
            this.btnZObchodu.Name = "btnZObchodu";
            this.btnZObchodu.Size = new System.Drawing.Size(75, 23);
            this.btnZObchodu.TabIndex = 23;
            this.btnZObchodu.Text = "Z obchodu";
            this.btnZObchodu.UseVisualStyleBackColor = true;
            this.btnZObchodu.Visible = false;
            this.btnZObchodu.Click += new System.EventHandler(this.btnZObchodu_Click);
            // 
            // lblUtok
            // 
            this.lblUtok.AutoSize = true;
            this.lblUtok.Location = new System.Drawing.Point(607, 564);
            this.lblUtok.Name = "lblUtok";
            this.lblUtok.Size = new System.Drawing.Size(0, 13);
            this.lblUtok.TabIndex = 24;
            // 
            // lblLeceni
            // 
            this.lblLeceni.AutoSize = true;
            this.lblLeceni.Location = new System.Drawing.Point(607, 597);
            this.lblLeceni.Name = "lblLeceni";
            this.lblLeceni.Size = new System.Drawing.Size(0, 13);
            this.lblLeceni.TabIndex = 25;
            // 
            // dgvInventar
            // 
            this.dgvInventar.AllowUserToAddRows = false;
            this.dgvInventar.AllowUserToDeleteRows = false;
            this.dgvInventar.AllowUserToResizeRows = false;
            this.dgvInventar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInventar.Location = new System.Drawing.Point(16, 131);
            this.dgvInventar.MultiSelect = false;
            this.dgvInventar.Name = "dgvInventar";
            this.dgvInventar.ReadOnly = true;
            this.dgvInventar.RowHeadersVisible = false;
            this.dgvInventar.Size = new System.Drawing.Size(401, 309);
            this.dgvInventar.TabIndex = 26;
            // 
            // Quest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 651);
            this.Controls.Add(this.dgvInventar);
            this.Controls.Add(this.lblLeceni);
            this.Controls.Add(this.lblUtok);
            this.Controls.Add(this.btnZObchodu);
            this.Controls.Add(this.dgvObchod);
            this.Controls.Add(this.dgvUkoly);
            this.Controls.Add(this.rtbZpravy);
            this.Controls.Add(this.rtbMisto);
            this.Controls.Add(this.btnZapad);
            this.Controls.Add(this.btnJih);
            this.Controls.Add(this.btnVychod);
            this.Controls.Add(this.btnSever);
            this.Controls.Add(this.btnPouzitLektvar);
            this.Controls.Add(this.btnPouzitZbran);
            this.Controls.Add(this.btnObchod);
            this.Controls.Add(this.cboLektvary);
            this.Controls.Add(this.cboZbrane);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbllev);
            this.Controls.Add(this.lblexp);
            this.Controls.Add(this.lblzlato);
            this.Controls.Add(this.lblzivoty);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Quest";
            this.Text = "Quest";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUkoly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObchod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblzivoty;
        private System.Windows.Forms.Label lblzlato;
        private System.Windows.Forms.Label lblexp;
        private System.Windows.Forms.Label lbllev;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboZbrane;
        private System.Windows.Forms.ComboBox cboLektvary;
        private System.Windows.Forms.Button btnPouzitZbran;
        private System.Windows.Forms.Button btnPouzitLektvar;
        private System.Windows.Forms.Button btnSever;
        private System.Windows.Forms.Button btnVychod;
        private System.Windows.Forms.Button btnJih;
        private System.Windows.Forms.Button btnZapad;
        private System.Windows.Forms.Button btnObchod;
        private System.Windows.Forms.RichTextBox rtbMisto;
        private System.Windows.Forms.RichTextBox rtbZpravy;
        private System.Windows.Forms.DataGridView dgvUkoly;
        private System.Windows.Forms.DataGridView dgvObchod;
        private System.Windows.Forms.Button btnZObchodu;
        private System.Windows.Forms.Label lblUtok;
        private System.Windows.Forms.Label lblLeceni;
        private System.Windows.Forms.DataGridView dgvInventar;
    }
}

