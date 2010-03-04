namespace PO1
{
    partial class filtr_kontr_harmoniczny
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
            this.zastosujFiltr = new System.Windows.Forms.Button();
            this.rzadFiltru = new System.Windows.Forms.NumericUpDown();
            this.rzad_filtru = new System.Windows.Forms.Label();
            this.wysokosc_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.wysokosc = new System.Windows.Forms.NumericUpDown();
            this.szerokosc = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.rzadFiltru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wysokosc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.szerokosc)).BeginInit();
            this.SuspendLayout();
            // 
            // zastosujFiltr
            // 
            this.zastosujFiltr.Location = new System.Drawing.Point(16, 106);
            this.zastosujFiltr.Name = "zastosujFiltr";
            this.zastosujFiltr.Size = new System.Drawing.Size(174, 49);
            this.zastosujFiltr.TabIndex = 10;
            this.zastosujFiltr.Text = "Filtruj";
            this.zastosujFiltr.UseVisualStyleBackColor = true;
            this.zastosujFiltr.Click += new System.EventHandler(this.zastosujFiltr_Click);
            // 
            // rzadFiltru
            // 
            this.rzadFiltru.DecimalPlaces = 1;
            this.rzadFiltru.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.rzadFiltru.Location = new System.Drawing.Point(143, 66);
            this.rzadFiltru.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.rzadFiltru.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.rzadFiltru.Name = "rzadFiltru";
            this.rzadFiltru.Size = new System.Drawing.Size(47, 20);
            this.rzadFiltru.TabIndex = 9;
            this.rzadFiltru.ValueChanged += new System.EventHandler(this.Rzad_ValueChanged);
            // 
            // rzad_filtru
            // 
            this.rzad_filtru.AutoSize = true;
            this.rzad_filtru.Location = new System.Drawing.Point(12, 68);
            this.rzad_filtru.Name = "rzad_filtru";
            this.rzad_filtru.Size = new System.Drawing.Size(57, 13);
            this.rzad_filtru.TabIndex = 8;
            this.rzad_filtru.Text = "Rząd Filtru";
            // 
            // wysokosc_label
            // 
            this.wysokosc_label.AutoSize = true;
            this.wysokosc_label.Location = new System.Drawing.Point(12, 41);
            this.wysokosc_label.Name = "wysokosc_label";
            this.wysokosc_label.Size = new System.Drawing.Size(112, 13);
            this.wysokosc_label.TabIndex = 7;
            this.wysokosc_label.Text = "Wysokość sąsiedstwa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Szerokość sąsiedstwa";
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
            this.wysokosc.Size = new System.Drawing.Size(47, 20);
            this.wysokosc.TabIndex = 4;
            this.wysokosc.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.wysokosc.ValueChanged += new System.EventHandler(this.Rzad_ValueChanged);
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
            this.szerokosc.Size = new System.Drawing.Size(47, 20);
            this.szerokosc.TabIndex = 5;
            this.szerokosc.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.szerokosc.ValueChanged += new System.EventHandler(this.Rzad_ValueChanged);
            // 
            // filtr_kontr_harmoniczny
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.zastosujFiltr);
            this.Controls.Add(this.rzadFiltru);
            this.Controls.Add(this.rzad_filtru);
            this.Controls.Add(this.wysokosc_label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.wysokosc);
            this.Controls.Add(this.szerokosc);
            this.Name = "filtr_kontr_harmoniczny";
            this.Size = new System.Drawing.Size(200, 400);
            ((System.ComponentModel.ISupportInitialize)(this.rzadFiltru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wysokosc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.szerokosc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button zastosujFiltr;
        private System.Windows.Forms.NumericUpDown rzadFiltru;
        private System.Windows.Forms.Label rzad_filtru;
        private System.Windows.Forms.Label wysokosc_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown wysokosc;
        private System.Windows.Forms.NumericUpDown szerokosc;
        private System.Drawing.Bitmap source;
        private System.Drawing.Bitmap temporary;


    }
}
