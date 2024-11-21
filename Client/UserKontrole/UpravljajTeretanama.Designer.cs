namespace Client.UserKontrole
{
    partial class UpravljajTeretanama
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
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.dgvTeretane = new System.Windows.Forms.DataGridView();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAzuriraj = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.txtNovNaziv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeretane)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(53, 89);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(240, 22);
            this.txtPretraga.TabIndex = 3;
            // 
            // dgvTeretane
            // 
            this.dgvTeretane.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTeretane.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTeretane.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeretane.Location = new System.Drawing.Point(53, 117);
            this.dgvTeretane.MultiSelect = false;
            this.dgvTeretane.Name = "dgvTeretane";
            this.dgvTeretane.RowHeadersWidth = 51;
            this.dgvTeretane.RowTemplate.Height = 24;
            this.dgvTeretane.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTeretane.Size = new System.Drawing.Size(240, 150);
            this.dgvTeretane.TabIndex = 4;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(368, 89);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(267, 225);
            this.checkedListBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Pretraga";
            // 
            // btnAzuriraj
            // 
            this.btnAzuriraj.Location = new System.Drawing.Point(56, 364);
            this.btnAzuriraj.Name = "btnAzuriraj";
            this.btnAzuriraj.Size = new System.Drawing.Size(167, 42);
            this.btnAzuriraj.TabIndex = 7;
            this.btnAzuriraj.Text = "Ažuriraj teretanu";
            this.btnAzuriraj.UseVisualStyleBackColor = true;
            // 
            // btnObrisi
            // 
            this.btnObrisi.Location = new System.Drawing.Point(468, 364);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(167, 42);
            this.btnObrisi.TabIndex = 8;
            this.btnObrisi.Text = "Obriši teretanu";
            this.btnObrisi.UseVisualStyleBackColor = true;
            // 
            // txtNovNaziv
            // 
            this.txtNovNaziv.Location = new System.Drawing.Point(53, 318);
            this.txtNovNaziv.Name = "txtNovNaziv";
            this.txtNovNaziv.Size = new System.Drawing.Size(167, 22);
            this.txtNovNaziv.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Naziv teretane";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(368, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Paketi kojima teretana pripada";
            // 
            // UpravljajTeretanama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNovNaziv);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnAzuriraj);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.dgvTeretane);
            this.Controls.Add(this.txtPretraga);
            this.Name = "UpravljajTeretanama";
            this.Size = new System.Drawing.Size(671, 441);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeretane)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtPretraga;
        public System.Windows.Forms.DataGridView dgvTeretane;
        public System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnAzuriraj;
        public System.Windows.Forms.Button btnObrisi;
        public System.Windows.Forms.TextBox txtNovNaziv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
