namespace Client
{
    partial class FrmPaketiTeretane
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
            this.dodajTeretanuBtn = new System.Windows.Forms.Button();
            this.upravljajPaketimabtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDodajPaket = new System.Windows.Forms.Button();
            this.btnUpravljajTeretanama = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dodajTeretanuBtn
            // 
            this.dodajTeretanuBtn.Location = new System.Drawing.Point(12, 41);
            this.dodajTeretanuBtn.Name = "dodajTeretanuBtn";
            this.dodajTeretanuBtn.Size = new System.Drawing.Size(201, 37);
            this.dodajTeretanuBtn.TabIndex = 0;
            this.dodajTeretanuBtn.Text = "Dodaj teretanu";
            this.dodajTeretanuBtn.UseVisualStyleBackColor = true;
            // 
            // upravljajPaketimabtn
            // 
            this.upravljajPaketimabtn.Location = new System.Drawing.Point(12, 201);
            this.upravljajPaketimabtn.Name = "upravljajPaketimabtn";
            this.upravljajPaketimabtn.Size = new System.Drawing.Size(201, 37);
            this.upravljajPaketimabtn.TabIndex = 1;
            this.upravljajPaketimabtn.Text = "Upravljaj paketima";
            this.upravljajPaketimabtn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(219, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 473);
            this.panel1.TabIndex = 2;
            // 
            // btnDodajPaket
            // 
            this.btnDodajPaket.Location = new System.Drawing.Point(13, 155);
            this.btnDodajPaket.Name = "btnDodajPaket";
            this.btnDodajPaket.Size = new System.Drawing.Size(200, 40);
            this.btnDodajPaket.TabIndex = 3;
            this.btnDodajPaket.Text = "Dodaj paket";
            this.btnDodajPaket.UseVisualStyleBackColor = true;
            // 
            // btnUpravljajTeretanama
            // 
            this.btnUpravljajTeretanama.Location = new System.Drawing.Point(13, 84);
            this.btnUpravljajTeretanama.Name = "btnUpravljajTeretanama";
            this.btnUpravljajTeretanama.Size = new System.Drawing.Size(200, 37);
            this.btnUpravljajTeretanama.TabIndex = 4;
            this.btnUpravljajTeretanama.Text = "Upravljaj teretanama";
            this.btnUpravljajTeretanama.UseVisualStyleBackColor = true;
            // 
            // FrmPaketiTeretane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 565);
            this.Controls.Add(this.btnUpravljajTeretanama);
            this.Controls.Add(this.btnDodajPaket);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.upravljajPaketimabtn);
            this.Controls.Add(this.dodajTeretanuBtn);
            this.Name = "FrmPaketiTeretane";
            this.Text = "FrmPaketiTeretane";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button dodajTeretanuBtn;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button upravljajPaketimabtn;
        public System.Windows.Forms.Button btnDodajPaket;
        public System.Windows.Forms.Button btnUpravljajTeretanama;
    }
}