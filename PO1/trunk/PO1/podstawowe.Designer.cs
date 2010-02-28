namespace PO1
{
    partial class podstawowe
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
            this.jasnoscScroll = new System.Windows.Forms.HScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.kontrastScroll = new System.Windows.Forms.HScrollBar();
            this.buttonNegatyw = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonJasnosc = new System.Windows.Forms.Button();
            this.buttonKontrast = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // jasnoscScroll
            // 
            this.jasnoscScroll.LargeChange = 5;
            this.jasnoscScroll.Location = new System.Drawing.Point(5, 50);
            this.jasnoscScroll.Maximum = 127;
            this.jasnoscScroll.Minimum = -128;
            this.jasnoscScroll.Name = "jasnoscScroll";
            this.jasnoscScroll.Size = new System.Drawing.Size(190, 35);
            this.jasnoscScroll.TabIndex = 0;
            this.jasnoscScroll.ValueChanged += new System.EventHandler(this.jasnoscScroll_ValueChanged);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "";
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Jasność";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "";
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(15, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kontrast";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // kontrastScroll
            // 
            this.kontrastScroll.LargeChange = 20;
            this.kontrastScroll.Location = new System.Drawing.Point(5, 169);
            this.kontrastScroll.Maximum = 119;
            this.kontrastScroll.Minimum = -100;
            this.kontrastScroll.Name = "kontrastScroll";
            this.kontrastScroll.Size = new System.Drawing.Size(190, 35);
            this.kontrastScroll.TabIndex = 0;
            this.kontrastScroll.ValueChanged += new System.EventHandler(this.kontrastScroll_ValueChanged);
            // 
            // buttonNegatyw
            // 
            this.buttonNegatyw.Location = new System.Drawing.Point(5, 270);
            this.buttonNegatyw.Name = "buttonNegatyw";
            this.buttonNegatyw.Size = new System.Drawing.Size(189, 67);
            this.buttonNegatyw.TabIndex = 2;
            this.buttonNegatyw.Text = "Negatyw";
            this.buttonNegatyw.UseVisualStyleBackColor = true;
            this.buttonNegatyw.Click += new System.EventHandler(this.buttonNegatyw_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(34, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(86, 139);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox2.Size = new System.Drawing.Size(34, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonJasnosc
            // 
            this.buttonJasnosc.Location = new System.Drawing.Point(129, 13);
            this.buttonJasnosc.Name = "buttonJasnosc";
            this.buttonJasnosc.Size = new System.Drawing.Size(64, 21);
            this.buttonJasnosc.TabIndex = 4;
            this.buttonJasnosc.Text = "Apply";
            this.buttonJasnosc.UseVisualStyleBackColor = false;
            this.buttonJasnosc.Click += new System.EventHandler(this.buttonJasnosc_Click);
            // 
            // buttonKontrast
            // 
            this.buttonKontrast.Location = new System.Drawing.Point(129, 139);
            this.buttonKontrast.Name = "buttonKontrast";
            this.buttonKontrast.Size = new System.Drawing.Size(64, 20);
            this.buttonKontrast.TabIndex = 4;
            this.buttonKontrast.Text = "Apply";
            this.buttonKontrast.UseVisualStyleBackColor = false;
            this.buttonKontrast.Click += new System.EventHandler(this.buttonKontrast_Click);
            // 
            // podstawowe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.buttonKontrast);
            this.Controls.Add(this.buttonJasnosc);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonNegatyw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.kontrastScroll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.jasnoscScroll);
            this.Name = "podstawowe";
            this.Size = new System.Drawing.Size(200, 400);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HScrollBar jasnoscScroll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.HScrollBar kontrastScroll;
        private System.Windows.Forms.Button buttonNegatyw;
        System.Drawing.Bitmap bmp;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonJasnosc;
        private System.Windows.Forms.Button buttonKontrast;
    } 
}
