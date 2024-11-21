namespace Client
{
    partial class FrmMain
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
            this.klijentiBtn = new System.Windows.Forms.Button();
            this.btnPaketiTeretane = new System.Windows.Forms.Button();
            this.comboPaket = new System.Windows.Forms.ComboBox();
            this.dgvKlijenti = new System.Windows.Forms.DataGridView();
            this.labelDanas = new System.Windows.Forms.Label();
            this.label30Dana = new System.Windows.Forms.Label();
            this.btnKreiraj = new System.Windows.Forms.Button();
            this.dateCurrent = new System.Windows.Forms.TextBox();
            this.date30 = new System.Windows.Forms.TextBox();
            this.btnKategorije = new System.Windows.Forms.Button();
            this.txtPretragaKlijenta = new System.Windows.Forms.TextBox();
            this.comboKategorije = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlijenti)).BeginInit();
            this.SuspendLayout();
            // 
            // klijentiBtn
            // 
            this.klijentiBtn.Location = new System.Drawing.Point(49, 99);
            this.klijentiBtn.Name = "klijentiBtn";
            this.klijentiBtn.Size = new System.Drawing.Size(257, 43);
            this.klijentiBtn.TabIndex = 3;
            this.klijentiBtn.Text = "Upravljaj Klijentima";
            this.klijentiBtn.UseVisualStyleBackColor = true;
            // 
            // btnPaketiTeretane
            // 
            this.btnPaketiTeretane.Location = new System.Drawing.Point(49, 148);
            this.btnPaketiTeretane.Name = "btnPaketiTeretane";
            this.btnPaketiTeretane.Size = new System.Drawing.Size(257, 41);
            this.btnPaketiTeretane.TabIndex = 4;
            this.btnPaketiTeretane.Text = "Upravljaj paketima i teretanama";
            this.btnPaketiTeretane.UseVisualStyleBackColor = true;
            // 
            // comboPaket
            // 
            this.comboPaket.FormattingEnabled = true;
            this.comboPaket.Location = new System.Drawing.Point(659, 225);
            this.comboPaket.Name = "comboPaket";
            this.comboPaket.Size = new System.Drawing.Size(233, 24);
            this.comboPaket.TabIndex = 5;
            // 
            // dgvKlijenti
            // 
            this.dgvKlijenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKlijenti.Location = new System.Drawing.Point(49, 239);
            this.dgvKlijenti.MultiSelect = false;
            this.dgvKlijenti.Name = "dgvKlijenti";
            this.dgvKlijenti.ReadOnly = true;
            this.dgvKlijenti.RowHeadersWidth = 51;
            this.dgvKlijenti.RowTemplate.Height = 24;
            this.dgvKlijenti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKlijenti.Size = new System.Drawing.Size(483, 150);
            this.dgvKlijenti.TabIndex = 7;
            // 
            // labelDanas
            // 
            this.labelDanas.AutoSize = true;
            this.labelDanas.Location = new System.Drawing.Point(46, 412);
            this.labelDanas.Name = "labelDanas";
            this.labelDanas.Size = new System.Drawing.Size(165, 16);
            this.labelDanas.TabIndex = 8;
            this.labelDanas.Text = "Pocetak vazenja clanarine";
            // 
            // label30Dana
            // 
            this.label30Dana.AutoSize = true;
            this.label30Dana.Location = new System.Drawing.Point(46, 493);
            this.label30Dana.Name = "label30Dana";
            this.label30Dana.Size = new System.Drawing.Size(110, 16);
            this.label30Dana.TabIndex = 9;
            this.label30Dana.Text = "Clanarina vazi do";
            // 
            // btnKreiraj
            // 
            this.btnKreiraj.Location = new System.Drawing.Point(307, 447);
            this.btnKreiraj.Name = "btnKreiraj";
            this.btnKreiraj.Size = new System.Drawing.Size(290, 38);
            this.btnKreiraj.TabIndex = 10;
            this.btnKreiraj.Text = "Kreiraj članarinu";
            this.btnKreiraj.UseVisualStyleBackColor = true;
            // 
            // dateCurrent
            // 
            this.dateCurrent.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dateCurrent.Font = new System.Drawing.Font("Asap", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateCurrent.Location = new System.Drawing.Point(49, 447);
            this.dateCurrent.Name = "dateCurrent";
            this.dateCurrent.ReadOnly = true;
            this.dateCurrent.Size = new System.Drawing.Size(209, 38);
            this.dateCurrent.TabIndex = 11;
            // 
            // date30
            // 
            this.date30.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.date30.Font = new System.Drawing.Font("Asap", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.date30.Location = new System.Drawing.Point(49, 526);
            this.date30.Name = "date30";
            this.date30.ReadOnly = true;
            this.date30.Size = new System.Drawing.Size(209, 38);
            this.date30.TabIndex = 12;
            // 
            // btnKategorije
            // 
            this.btnKategorije.Location = new System.Drawing.Point(635, 118);
            this.btnKategorije.Name = "btnKategorije";
            this.btnKategorije.Size = new System.Drawing.Size(257, 41);
            this.btnKategorije.TabIndex = 13;
            this.btnKategorije.Text = "Kategorije";
            this.btnKategorije.UseVisualStyleBackColor = true;
            // 
            // txtPretragaKlijenta
            // 
            this.txtPretragaKlijenta.Location = new System.Drawing.Point(49, 195);
            this.txtPretragaKlijenta.Name = "txtPretragaKlijenta";
            this.txtPretragaKlijenta.Size = new System.Drawing.Size(297, 22);
            this.txtPretragaKlijenta.TabIndex = 14;
            // 
            // comboKategorije
            // 
            this.comboKategorije.FormattingEnabled = true;
            this.comboKategorije.Location = new System.Drawing.Point(659, 315);
            this.comboKategorije.Name = "comboKategorije";
            this.comboKategorije.Size = new System.Drawing.Size(233, 24);
            this.comboKategorije.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(656, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Odabir paketa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(656, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Odabir kategorije";
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(697, 32);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(195, 37);
            this.btnLogOut.TabIndex = 19;
            this.btnLogOut.Text = "Odjava";
            this.btnLogOut.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 602);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboKategorije);
            this.Controls.Add(this.txtPretragaKlijenta);
            this.Controls.Add(this.btnKategorije);
            this.Controls.Add(this.date30);
            this.Controls.Add(this.dateCurrent);
            this.Controls.Add(this.btnKreiraj);
            this.Controls.Add(this.label30Dana);
            this.Controls.Add(this.labelDanas);
            this.Controls.Add(this.dgvKlijenti);
            this.Controls.Add(this.comboPaket);
            this.Controls.Add(this.btnPaketiTeretane);
            this.Controls.Add(this.klijentiBtn);
            this.Name = "FrmMain";
            this.Text = "Fitpas - početna";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlijenti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip klijentMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem dodajKlijentaToolStripMenuItem;
        public System.Windows.Forms.Button klijentiBtn;
        public System.Windows.Forms.Button btnPaketiTeretane;
        public System.Windows.Forms.DataGridView dgvKlijenti;
        public System.Windows.Forms.ComboBox comboPaket;
        public System.Windows.Forms.Label labelDanas;
        public System.Windows.Forms.Label label30Dana;
        public System.Windows.Forms.Button btnKreiraj;
        public System.Windows.Forms.TextBox dateCurrent;
        public System.Windows.Forms.TextBox date30;
        public System.Windows.Forms.TextBox txtPretragaKlijenta;
        public System.Windows.Forms.ComboBox comboKategorije;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnLogOut;
        public System.Windows.Forms.Button btnKategorije;
    }
}