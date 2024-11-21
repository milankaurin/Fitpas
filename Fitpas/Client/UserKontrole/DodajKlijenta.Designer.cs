namespace Client.UserKontrole
{
    partial class DodajKlijenta
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
            this.btnDodaj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ime
            // 
            this.ime.Location = new System.Drawing.Point(80, 85);
            this.ime.Name = "ime";
            this.ime.Size = new System.Drawing.Size(163, 22);
            this.ime.TabIndex = 0;
            // 
            // prezime
            // 
            this.prezime.Location = new System.Drawing.Point(80, 145);
            this.prezime.Name = "prezime";
            this.prezime.Size = new System.Drawing.Size(163, 22);
            this.prezime.TabIndex = 1;
            // 
            // datrodjenja
            // 
            this.datrodjenja.Location = new System.Drawing.Point(80, 196);
            this.datrodjenja.Name = "datrodjenja";
            this.datrodjenja.Size = new System.Drawing.Size(255, 22);
            this.datrodjenja.TabIndex = 2;
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(80, 247);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(163, 39);
            this.btnDodaj.TabIndex = 3;
            this.btnDodaj.Text = "Kreirajte klijenta";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Prezime";
            // 
            // DodajKlijenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.datrodjenja);
            this.Controls.Add(this.prezime);
            this.Controls.Add(this.ime);
            this.Name = "DodajKlijenta";
            this.Size = new System.Drawing.Size(389, 344);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox ime;
        public System.Windows.Forms.TextBox prezime;
        public System.Windows.Forms.DateTimePicker datrodjenja;
        public System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
