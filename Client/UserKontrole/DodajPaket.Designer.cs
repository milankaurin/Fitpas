namespace Client.UserKontrole
{
    partial class DodajPaket
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
            this.imeTeretaneTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCena = new System.Windows.Forms.TextBox();
            this.CheckedTeretane = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imeTeretaneTxt
            // 
            this.imeTeretaneTxt.Location = new System.Drawing.Point(44, 95);
            this.imeTeretaneTxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.imeTeretaneTxt.Name = "imeTeretaneTxt";
            this.imeTeretaneTxt.Size = new System.Drawing.Size(116, 20);
            this.imeTeretaneTxt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Unesite naziv paketa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 139);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Unesite cenu";
            // 
            // txtCena
            // 
            this.txtCena.Location = new System.Drawing.Point(46, 175);
            this.txtCena.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCena.Name = "txtCena";
            this.txtCena.Size = new System.Drawing.Size(74, 20);
            this.txtCena.TabIndex = 3;
            // 
            // CheckedTeretane
            // 
            this.CheckedTeretane.FormattingEnabled = true;
            this.CheckedTeretane.Location = new System.Drawing.Point(197, 95);
            this.CheckedTeretane.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CheckedTeretane.Name = "CheckedTeretane";
            this.CheckedTeretane.Size = new System.Drawing.Size(230, 229);
            this.CheckedTeretane.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Koje teretane će paket uključivati?";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 253);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 27);
            this.button1.TabIndex = 6;
            this.button1.Text = "Dodaj paket";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DodajPaket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CheckedTeretane);
            this.Controls.Add(this.txtCena);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imeTeretaneTxt);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DodajPaket";
            this.Size = new System.Drawing.Size(460, 398);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox imeTeretaneTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtCena;
        public System.Windows.Forms.CheckedListBox CheckedTeretane;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button button1;
    }
}
