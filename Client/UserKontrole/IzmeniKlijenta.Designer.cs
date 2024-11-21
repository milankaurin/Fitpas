namespace Client.UserKontrole
{
    partial class IzmeniKlijenta
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ime = new System.Windows.Forms.TextBox();
            this.prezime = new System.Windows.Forms.TextBox();
            this.datrodjenja = new System.Windows.Forms.DateTimePicker();
            this.izmeniKlijentabtn = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.TextBox();
            this.btnObrisiKlijenta = new System.Windows.Forms.Button();
            this.dgvClanarine = new System.Windows.Forms.DataGridView();
            this.btnBrisiClanarine = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClanarine)).BeginInit();
            this.SuspendLayout();
            // 
            // ime
            // 
            this.ime.Location = new System.Drawing.Point(70, 76);
            this.ime.Name = "ime";
            this.ime.Size = new System.Drawing.Size(247, 22);
            this.ime.TabIndex = 1;
            // 
            // prezime
            // 
            this.prezime.Location = new System.Drawing.Point(70, 114);
            this.prezime.Name = "prezime";
            this.prezime.Size = new System.Drawing.Size(247, 22);
            this.prezime.TabIndex = 2;
            // 
            // datrodjenja
            // 
            this.datrodjenja.Location = new System.Drawing.Point(70, 155);
            this.datrodjenja.Name = "datrodjenja";
            this.datrodjenja.Size = new System.Drawing.Size(247, 22);
            this.datrodjenja.TabIndex = 3;
            // 
            // izmeniKlijentabtn
            // 
            this.izmeniKlijentabtn.Location = new System.Drawing.Point(70, 203);
            this.izmeniKlijentabtn.Name = "izmeniKlijentabtn";
            this.izmeniKlijentabtn.Size = new System.Drawing.Size(247, 32);
            this.izmeniKlijentabtn.TabIndex = 4;
            this.izmeniKlijentabtn.Text = "Izmeni klijenta";
            this.izmeniKlijentabtn.UseVisualStyleBackColor = true;
            // 
            // id
            // 
            this.id.Enabled = false;
            this.id.Location = new System.Drawing.Point(70, 43);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(247, 22);
            this.id.TabIndex = 5;
            // 
            // btnObrisiKlijenta
            // 
            this.btnObrisiKlijenta.Location = new System.Drawing.Point(70, 241);
            this.btnObrisiKlijenta.Name = "btnObrisiKlijenta";
            this.btnObrisiKlijenta.Size = new System.Drawing.Size(247, 30);
            this.btnObrisiKlijenta.TabIndex = 6;
            this.btnObrisiKlijenta.Text = "Obrisi klijenta";
            this.btnObrisiKlijenta.UseVisualStyleBackColor = true;
            // 
            // dgvClanarine
            // 
            this.dgvClanarine.AllowUserToAddRows = false;
            this.dgvClanarine.ColumnHeadersHeight = 29;
            this.dgvClanarine.Location = new System.Drawing.Point(336, 43);
            this.dgvClanarine.Name = "dgvClanarine";
            this.dgvClanarine.ReadOnly = true;
            this.dgvClanarine.RowHeadersVisible = false;
            this.dgvClanarine.RowHeadersWidth = 55;
            this.dgvClanarine.RowTemplate.Height = 24;
            this.dgvClanarine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClanarine.Size = new System.Drawing.Size(627, 150);
            this.dgvClanarine.TabIndex = 7;
            // 
            // btnBrisiClanarine
            // 
            this.btnBrisiClanarine.Location = new System.Drawing.Point(380, 206);
            this.btnBrisiClanarine.Name = "btnBrisiClanarine";
            this.btnBrisiClanarine.Size = new System.Drawing.Size(271, 29);
            this.btnBrisiClanarine.TabIndex = 8;
            this.btnBrisiClanarine.Text = "Obrisi odabrane clanrine za klijenta";
            this.btnBrisiClanarine.UseVisualStyleBackColor = true;
            // 
            // IzmeniKlijenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBrisiClanarine);
            this.Controls.Add(this.dgvClanarine);
            this.Controls.Add(this.btnObrisiKlijenta);
            this.Controls.Add(this.id);
            this.Controls.Add(this.izmeniKlijentabtn);
            this.Controls.Add(this.datrodjenja);
            this.Controls.Add(this.prezime);
            this.Controls.Add(this.ime);
            this.Name = "IzmeniKlijenta";
            this.Size = new System.Drawing.Size(988, 375);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClanarine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox ime;
        public System.Windows.Forms.TextBox prezime;
        public System.Windows.Forms.DateTimePicker datrodjenja;
        public System.Windows.Forms.Button izmeniKlijentabtn;
        public System.Windows.Forms.TextBox id;
        public System.Windows.Forms.Button btnObrisiKlijenta;
        public System.Windows.Forms.DataGridView dgvClanarine;
        public System.Windows.Forms.Button btnBrisiClanarine;
    }
}
