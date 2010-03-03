namespace PO1
{
    partial class geometryczne
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
            this.odbiciePoziome = new System.Windows.Forms.Button();
            this.odbiciePion = new System.Windows.Forms.Button();
            this.OdbicieSkos = new System.Windows.Forms.Button();
            this.resizeButton = new System.Windows.Forms.Button();
            this.resizeBarPoziom = new System.Windows.Forms.HScrollBar();
            this.resizeTextPoziom = new System.Windows.Forms.TextBox();
            this.resizeBarPion = new System.Windows.Forms.VScrollBar();
            this.resizeTextPion = new System.Windows.Forms.TextBox();
            this.ResizeZlaczone = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // odbiciePoziome
            // 
            this.odbiciePoziome.Location = new System.Drawing.Point(3, 12);
            this.odbiciePoziome.Name = "odbiciePoziome";
            this.odbiciePoziome.Size = new System.Drawing.Size(194, 33);
            this.odbiciePoziome.TabIndex = 0;
            this.odbiciePoziome.Text = "Odbicice lustrzane w poziomie";
            this.odbiciePoziome.UseVisualStyleBackColor = true;
            this.odbiciePoziome.Click += new System.EventHandler(this.odbiciePoziome_Click);
            // 
            // odbiciePion
            // 
            this.odbiciePion.Location = new System.Drawing.Point(3, 51);
            this.odbiciePion.Name = "odbiciePion";
            this.odbiciePion.Size = new System.Drawing.Size(194, 33);
            this.odbiciePion.TabIndex = 0;
            this.odbiciePion.Text = "Odbicice lustrzane w pionie";
            this.odbiciePion.UseVisualStyleBackColor = true;
            this.odbiciePion.Click += new System.EventHandler(this.odbiciePion_Click);
            // 
            // OdbicieSkos
            // 
            this.OdbicieSkos.Location = new System.Drawing.Point(3, 90);
            this.OdbicieSkos.Name = "OdbicieSkos";
            this.OdbicieSkos.Size = new System.Drawing.Size(194, 33);
            this.OdbicieSkos.TabIndex = 0;
            this.OdbicieSkos.Text = "Odbicice lustrzane ukośne";
            this.OdbicieSkos.UseVisualStyleBackColor = true;
            this.OdbicieSkos.Click += new System.EventHandler(this.OdbicieSkos_Click);
            // 
            // resizeButton
            // 
            this.resizeButton.Location = new System.Drawing.Point(36, 183);
            this.resizeButton.Name = "resizeButton";
            this.resizeButton.Size = new System.Drawing.Size(164, 158);
            this.resizeButton.TabIndex = 0;
            this.resizeButton.Text = "Zmień rozmiar";
            this.resizeButton.UseVisualStyleBackColor = true;
            this.resizeButton.Click += new System.EventHandler(this.resizeButton_Click);
            // 
            // resizeBarPoziom
            // 
            this.resizeBarPoziom.Location = new System.Drawing.Point(36, 344);
            this.resizeBarPoziom.Maximum = 209;
            this.resizeBarPoziom.Minimum = 10;
            this.resizeBarPoziom.Name = "resizeBarPoziom";
            this.resizeBarPoziom.Size = new System.Drawing.Size(161, 30);
            this.resizeBarPoziom.TabIndex = 1;
            this.resizeBarPoziom.Value = 100;
            this.resizeBarPoziom.ValueChanged += new System.EventHandler(this.resizeBarPoziom_ValueChanged);
            // 
            // resizeTextPoziom
            // 
            this.resizeTextPoziom.Location = new System.Drawing.Point(94, 377);
            this.resizeTextPoziom.Name = "resizeTextPoziom";
            this.resizeTextPoziom.ReadOnly = true;
            this.resizeTextPoziom.Size = new System.Drawing.Size(40, 20);
            this.resizeTextPoziom.TabIndex = 2;
            this.resizeTextPoziom.Text = "100 %";
            this.resizeTextPoziom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // resizeBarPion
            // 
            this.resizeBarPion.Location = new System.Drawing.Point(3, 183);
            this.resizeBarPion.Maximum = -1;
            this.resizeBarPion.Minimum = -200;
            this.resizeBarPion.Name = "resizeBarPion";
            this.resizeBarPion.Size = new System.Drawing.Size(30, 161);
            this.resizeBarPion.TabIndex = 3;
            this.resizeBarPion.Value = -100;
            this.resizeBarPion.ValueChanged += new System.EventHandler(this.resizeBarPion_ValueChanged);
            // 
            // resizeTextPion
            // 
            this.resizeTextPion.Location = new System.Drawing.Point(0, 160);
            this.resizeTextPion.Name = "resizeTextPion";
            this.resizeTextPion.ReadOnly = true;
            this.resizeTextPion.Size = new System.Drawing.Size(40, 20);
            this.resizeTextPion.TabIndex = 2;
            this.resizeTextPion.Text = "100 %";
            this.resizeTextPion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ResizeZlaczone
            // 
            this.ResizeZlaczone.AutoSize = true;
            this.ResizeZlaczone.Location = new System.Drawing.Point(18, 347);
            this.ResizeZlaczone.Name = "ResizeZlaczone";
            this.ResizeZlaczone.Size = new System.Drawing.Size(15, 14);
            this.ResizeZlaczone.TabIndex = 4;
            this.ResizeZlaczone.UseVisualStyleBackColor = true;
            this.ResizeZlaczone.CheckedChanged += new System.EventHandler(this.ResizeZlaczone_CheckedChanged);
            // 
            // geometryczne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ResizeZlaczone);
            this.Controls.Add(this.resizeBarPion);
            this.Controls.Add(this.resizeTextPion);
            this.Controls.Add(this.resizeTextPoziom);
            this.Controls.Add(this.resizeBarPoziom);
            this.Controls.Add(this.resizeButton);
            this.Controls.Add(this.OdbicieSkos);
            this.Controls.Add(this.odbiciePion);
            this.Controls.Add(this.odbiciePoziome);
            this.Name = "geometryczne";
            this.Size = new System.Drawing.Size(200, 400);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button odbiciePoziome;
        private System.Windows.Forms.Button odbiciePion;
        private System.Windows.Forms.Button OdbicieSkos;
        private System.Windows.Forms.Button resizeButton;
        private System.Windows.Forms.HScrollBar resizeBarPoziom;
        private System.Windows.Forms.TextBox resizeTextPoziom;
        private System.Drawing.Bitmap bmp;
        private System.Windows.Forms.TextBox resizeTextPion;
        private System.Windows.Forms.VScrollBar resizeBarPion;
        private System.Windows.Forms.CheckBox ResizeZlaczone;
    }
}
