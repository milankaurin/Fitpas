namespace Client
{
    partial class FrmKlijent
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
            this.btnDodajKlijenta = new System.Windows.Forms.Button();
            this.panelKlijenti = new System.Windows.Forms.Panel();
            this.dgvKlijenti = new System.Windows.Forms.DataGridView();
            this.btnPregledKlijenta = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.sviKlijentiBtn = new System.Windows.Forms.Button();
            this.panelKlijenti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlijenti)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDodajKlijenta
            // 
            this.btnDodajKlijenta.Location = new System.Drawing.Point(9, 112);
            this.btnDodajKlijenta.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDodajKlijenta.Name = "btnDodajKlijenta";
            this.btnDodajKlijenta.Size = new System.Drawing.Size(157, 31);
            this.btnDodajKlijenta.TabIndex = 0;
            this.btnDodajKlijenta.Text = "Dodaj novog klijenta";
            this.btnDodajKlijenta.UseVisualStyleBackColor = true;
            this.btnDodajKlijenta.Click += new System.EventHandler(this.btnDodajKlijenta_Click);
            // 
            // panelKlijenti
            // 
            this.panelKlijenti.Controls.Add(this.dgvKlijenti);
            this.panelKlijenti.Location = new System.Drawing.Point(187, 72);
            this.panelKlijenti.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelKlijenti.Name = "panelKlijenti";
            this.panelKlijenti.Size = new System.Drawing.Size(754, 254);
            this.panelKlijenti.TabIndex = 1;
            // 
            // dgvKlijenti
            // 
            this.dgvKlijenti.AllowUserToAddRows = false;
            this.dgvKlijenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKlijenti.Location = new System.Drawing.Point(2, 2);
            this.dgvKlijenti.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvKlijenti.MultiSelect = false;
            this.dgvKlijenti.Name = "dgvKlijenti";
            this.dgvKlijenti.ReadOnly = true;
            this.dgvKlijenti.RowHeadersWidth = 51;
            this.dgvKlijenti.RowTemplate.Height = 24;
            this.dgvKlijenti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKlijenti.Size = new System.Drawing.Size(475, 254);
            this.dgvKlijenti.TabIndex = 0;
            // 
            // btnPregledKlijenta
            // 
            this.btnPregledKlijenta.Location = new System.Drawing.Point(9, 148);
            this.btnPregledKlijenta.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPregledKlijenta.Name = "btnPregledKlijenta";
            this.btnPregledKlijenta.Size = new System.Drawing.Size(157, 31);
            this.btnPregledKlijenta.TabIndex = 2;
            this.btnPregledKlijenta.Text = "Pregled odabranog klijenta";
            this.btnPregledKlijenta.UseVisualStyleBackColor = true;
            this.btnPregledKlijenta.Click += new System.EventHandler(this.btnIzmeniKlijenta_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(160, 31);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(254, 20);
            this.textBox1.TabIndex = 4;
            // 
            // sviKlijentiBtn
            // 
            this.sviKlijentiBtn.Location = new System.Drawing.Point(13, 31);
            this.sviKlijentiBtn.Name = "sviKlijentiBtn";
            this.sviKlijentiBtn.Size = new System.Drawing.Size(87, 23);
            this.sviKlijentiBtn.TabIndex = 5;
            this.sviKlijentiBtn.Text = "Svi klijenti";
            this.sviKlijentiBtn.UseVisualStyleBackColor = true;
            // 
            // FrmKlijent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 366);
            this.Controls.Add(this.sviKlijentiBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnPregledKlijenta);
            this.Controls.Add(this.panelKlijenti);
            this.Controls.Add(this.btnDodajKlijenta);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmKlijent";
            this.Text = "Klijent";
            this.panelKlijenti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlijenti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnDodajKlijenta;
        public System.Windows.Forms.Panel panelKlijenti;
        public System.Windows.Forms.DataGridView dgvKlijenti;
        public System.Windows.Forms.Button btnPregledKlijenta;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Button sviKlijentiBtn;
    }
}