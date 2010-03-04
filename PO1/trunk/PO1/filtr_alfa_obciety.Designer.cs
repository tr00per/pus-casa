namespace PO1
{
    partial class filtr_alfa_obciety
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
            this.szerokosc = new System.Windows.Forms.NumericUpDown();
            this.Szerokosc_label = new System.Windows.Forms.Label();
            this.wysokosc = new System.Windows.Forms.NumericUpDown();
            this.wysokosc_label = new System.Windows.Forms.Label();
            this.wartosc_d = new System.Windows.Forms.NumericUpDown();
            this.d_label = new System.Windows.Forms.Label();
            this.zastosujFiltr = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.szerokosc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wysokosc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wartosc_d)).BeginInit();
            this.SuspendLayout();
            // 
            // szerokosc
            // 
            this.szerokosc.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.szerokosc.Location = new System.Drawing.Point(143, 13);
            this.szerokosc.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.szerokosc.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.szerokosc.Name = "szerokosc";
            this.szerokosc.Size = new System.Drawing.Size(44, 20);
            this.szerokosc.TabIndex = 0;
            this.szerokosc.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.szerokosc.ValueChanged += new System.EventHandler(this.wartosc_d_ValueChanged);
            // 
            // Szerokosc_label
            // 
            this.Szerokosc_label.AutoSize = true;
            this.Szerokosc_label.Location = new System.Drawing.Point(12, 15);
            this.Szerokosc_label.Name = "Szerokosc_label";
            this.Szerokosc_label.Size = new System.Drawing.Size(112, 13);
            this.Szerokosc_label.TabIndex = 1;
            this.Szerokosc_label.Text = "Szerokość sąsiedstwa";
            // 
            // wysokosc
            // 
            this.wysokosc.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.wysokosc.Location = new System.Drawing.Point(143, 39);
            this.wysokosc.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.wysokosc.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.wysokosc.Name = "wysokosc";
            this.wysokosc.Size = new System.Drawing.Size(44, 20);
            this.wysokosc.TabIndex = 0;
            this.wysokosc.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.wysokosc.ValueChanged += new System.EventHandler(this.wartosc_d_ValueChanged);
            // 
            // wysokosc_label
            // 
            this.wysokosc_label.AutoSize = true;
            this.wysokosc_label.Location = new System.Drawing.Point(12, 41);
            this.wysokosc_label.Name = "wysokosc_label";
            this.wysokosc_label.Size = new System.Drawing.Size(112, 13);
            this.wysokosc_label.TabIndex = 1;
            this.wysokosc_label.Text = "Wysokość sąsiedstwa";
            // 
            // wartosc_d
            // 
            this.wartosc_d.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.wartosc_d.Location = new System.Drawing.Point(143, 66);
            this.wartosc_d.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.wartosc_d.Name = "wartosc_d";
            this.wartosc_d.Size = new System.Drawing.Size(44, 20);
            this.wartosc_d.TabIndex = 2;
            this.wartosc_d.ValueChanged += new System.EventHandler(this.wartosc_d_ValueChanged);
            // 
            // d_label
            // 
            this.d_label.AutoSize = true;
            this.d_label.Location = new System.Drawing.Point(12, 68);
            this.d_label.Name = "d_label";
            this.d_label.Size = new System.Drawing.Size(53, 13);
            this.d_label.TabIndex = 1;
            this.d_label.Text = "wartość d";
            // 
            // zastosujFiltr
            // 
            this.zastosujFiltr.Location = new System.Drawing.Point(16, 106);
            this.zastosujFiltr.Name = "zastosujFiltr";
            this.zastosujFiltr.Size = new System.Drawing.Size(171, 49);
            this.zastosujFiltr.TabIndex = 3;
            this.zastosujFiltr.Text = "Filtruj";
            this.zastosujFiltr.UseVisualStyleBackColor = true;
            this.zastosujFiltr.Click += new System.EventHandler(this.zastosujFiltr_Click);
            // 
            // filtr_alfa_obciety
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.zastosujFiltr);
            this.Controls.Add(this.wartosc_d);
            this.Controls.Add(this.d_label);
            this.Controls.Add(this.wysokosc_label);
            this.Controls.Add(this.Szerokosc_label);
            this.Controls.Add(this.wysokosc);
            this.Controls.Add(this.szerokosc);
            this.Name = "filtr_alfa_obciety";
            this.Size = new System.Drawing.Size(200, 400);
            ((System.ComponentModel.ISupportInitialize)(this.szerokosc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wysokosc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wartosc_d)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown szerokosc;
        private System.Windows.Forms.Label Szerokosc_label;
        private System.Windows.Forms.NumericUpDown wysokosc;
        private System.Windows.Forms.Label wysokosc_label;
        private System.Windows.Forms.NumericUpDown wartosc_d;
        private System.Windows.Forms.Label d_label;
        private System.Drawing.Bitmap source;
        private System.Drawing.Bitmap temporary;
        private System.Windows.Forms.Button zastosujFiltr;
    }
}
