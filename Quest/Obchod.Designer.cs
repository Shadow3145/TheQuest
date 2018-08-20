namespace Quest
{
    partial class Obchod
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMujInventar = new System.Windows.Forms.Label();
            this.lblObchodnikuvInventar = new System.Windows.Forms.Label();
            this.dgvMojeVeci = new System.Windows.Forms.DataGridView();
            this.dgvObchodnikovyVeci = new System.Windows.Forms.DataGridView();
            this.btnZavrit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMojeVeci)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObchodnikovyVeci)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMujInventar
            // 
            this.lblMujInventar.AutoSize = true;
            this.lblMujInventar.Location = new System.Drawing.Point(99, 13);
            this.lblMujInventar.Name = "lblMujInventar";
            this.lblMujInventar.Size = new System.Drawing.Size(66, 13);
            this.lblMujInventar.TabIndex = 0;
            this.lblMujInventar.Text = "Můj inventář";
            // 
            // lblObchodnikuvInventar
            // 
            this.lblObchodnikuvInventar.AutoSize = true;
            this.lblObchodnikuvInventar.Location = new System.Drawing.Point(349, 13);
            this.lblObchodnikuvInventar.Name = "lblObchodnikuvInventar";
            this.lblObchodnikuvInventar.Size = new System.Drawing.Size(116, 13);
            this.lblObchodnikuvInventar.TabIndex = 1;
            this.lblObchodnikuvInventar.Text = "Obchodníkův Inventář";
            // 
            // dgvMojeVeci
            // 
            this.dgvMojeVeci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMojeVeci.Location = new System.Drawing.Point(13, 43);
            this.dgvMojeVeci.Name = "dgvMojeVeci";
            this.dgvMojeVeci.Size = new System.Drawing.Size(240, 216);
            this.dgvMojeVeci.TabIndex = 2;
            // 
            // dgvObchodnikovyVeci
            // 
            this.dgvObchodnikovyVeci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObchodnikovyVeci.Location = new System.Drawing.Point(276, 43);
            this.dgvObchodnikovyVeci.Name = "dgvObchodnikovyVeci";
            this.dgvObchodnikovyVeci.Size = new System.Drawing.Size(240, 216);
            this.dgvObchodnikovyVeci.TabIndex = 3;
            // 
            // btnZavrit
            // 
            this.btnZavrit.Location = new System.Drawing.Point(441, 274);
            this.btnZavrit.Name = "btnZavrit";
            this.btnZavrit.Size = new System.Drawing.Size(75, 23);
            this.btnZavrit.TabIndex = 4;
            this.btnZavrit.Text = "Zavřít";
            this.btnZavrit.UseVisualStyleBackColor = true;
            this.btnZavrit.Click += new System.EventHandler(this.btnZavrit_Click);
            // 
            // Obchod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 310);
            this.Controls.Add(this.btnZavrit);
            this.Controls.Add(this.dgvObchodnikovyVeci);
            this.Controls.Add(this.dgvMojeVeci);
            this.Controls.Add(this.lblObchodnikuvInventar);
            this.Controls.Add(this.lblMujInventar);
            this.Name = "Obchod";
            this.Text = "Obchod";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMojeVeci)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObchodnikovyVeci)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMujInventar;
        private System.Windows.Forms.Label lblObchodnikuvInventar;
        private System.Windows.Forms.DataGridView dgvMojeVeci;
        private System.Windows.Forms.DataGridView dgvObchodnikovyVeci;
        private System.Windows.Forms.Button btnZavrit;
    }
}