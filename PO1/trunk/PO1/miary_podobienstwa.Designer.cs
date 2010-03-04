namespace PO1
{
    partial class miary_podobienstwa
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
            this.oryginalny_button = new System.Windows.Forms.Button();
            this.MaxRoznica = new System.Windows.Forms.TextBox();
            this.maxRoznica_label = new System.Windows.Forms.Label();
            this.szyt_syg_do_szum = new System.Windows.Forms.TextBox();
            this.Szczyt_syg_do_szum_label = new System.Windows.Forms.Label();
            this.syg_do_szum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.szczyt_sr_kwadrat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bl_sredniokwadrat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Zaszumiony = new System.Windows.Forms.RadioButton();
            this.Odszumiony = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // oryginalny_button
            // 
            this.oryginalny_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.oryginalny_button.Location = new System.Drawing.Point(474, 46);
            this.oryginalny_button.Name = "oryginalny_button";
            this.oryginalny_button.Size = new System.Drawing.Size(107, 37);
            this.oryginalny_button.TabIndex = 1;
            this.oryginalny_button.Text = "Wybierz obrazek";
            this.oryginalny_button.UseVisualStyleBackColor = true;
            this.oryginalny_button.Click += new System.EventHandler(this.oryginalny_button_Click);
            // 
            // MaxRoznica
            // 
            this.MaxRoznica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MaxRoznica.Location = new System.Drawing.Point(386, 23);
            this.MaxRoznica.Name = "MaxRoznica";
            this.MaxRoznica.ReadOnly = true;
            this.MaxRoznica.Size = new System.Drawing.Size(195, 20);
            this.MaxRoznica.TabIndex = 2;
            this.MaxRoznica.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maxRoznica_label
            // 
            this.maxRoznica_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.maxRoznica_label.AutoSize = true;
            this.maxRoznica_label.Location = new System.Drawing.Point(406, 7);
            this.maxRoznica_label.Name = "maxRoznica_label";
            this.maxRoznica_label.Size = new System.Drawing.Size(103, 13);
            this.maxRoznica_label.TabIndex = 3;
            this.maxRoznica_label.Text = "Maksymalna różnica";
            this.maxRoznica_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // szyt_syg_do_szum
            // 
            this.szyt_syg_do_szum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.szyt_syg_do_szum.Location = new System.Drawing.Point(185, 62);
            this.szyt_syg_do_szum.Name = "szyt_syg_do_szum";
            this.szyt_syg_do_szum.ReadOnly = true;
            this.szyt_syg_do_szum.Size = new System.Drawing.Size(195, 20);
            this.szyt_syg_do_szum.TabIndex = 2;
            this.szyt_syg_do_szum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Szczyt_syg_do_szum_label
            // 
            this.Szczyt_syg_do_szum_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Szczyt_syg_do_szum_label.AutoSize = true;
            this.Szczyt_syg_do_szum_label.Location = new System.Drawing.Point(188, 46);
            this.Szczyt_syg_do_szum_label.Name = "Szczyt_syg_do_szum_label";
            this.Szczyt_syg_do_szum_label.Size = new System.Drawing.Size(192, 13);
            this.Szczyt_syg_do_szum_label.TabIndex = 3;
            this.Szczyt_syg_do_szum_label.Text = "Szczytowy stosunek sygnału do szumu";
            this.Szczyt_syg_do_szum_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // syg_do_szum
            // 
            this.syg_do_szum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.syg_do_szum.Location = new System.Drawing.Point(185, 23);
            this.syg_do_szum.Name = "syg_do_szum";
            this.syg_do_szum.ReadOnly = true;
            this.syg_do_szum.Size = new System.Drawing.Size(195, 20);
            this.syg_do_szum.TabIndex = 2;
            this.syg_do_szum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Stosunek sygnału do szumu";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // szczyt_sr_kwadrat
            // 
            this.szczyt_sr_kwadrat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.szczyt_sr_kwadrat.Location = new System.Drawing.Point(3, 62);
            this.szczyt_sr_kwadrat.Name = "szczyt_sr_kwadrat";
            this.szczyt_sr_kwadrat.ReadOnly = true;
            this.szczyt_sr_kwadrat.Size = new System.Drawing.Size(176, 20);
            this.szczyt_sr_kwadrat.TabIndex = 2;
            this.szczyt_sr_kwadrat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Szczytowy błąd średniokwadratowy";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bl_sredniokwadrat
            // 
            this.bl_sredniokwadrat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bl_sredniokwadrat.Location = new System.Drawing.Point(3, 23);
            this.bl_sredniokwadrat.Name = "bl_sredniokwadrat";
            this.bl_sredniokwadrat.ReadOnly = true;
            this.bl_sredniokwadrat.Size = new System.Drawing.Size(176, 20);
            this.bl_sredniokwadrat.TabIndex = 2;
            this.bl_sredniokwadrat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Błąd średniokwadratowy";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Zaszumiony
            // 
            this.Zaszumiony.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Zaszumiony.AutoSize = true;
            this.Zaszumiony.Enabled = false;
            this.Zaszumiony.Location = new System.Drawing.Point(386, 44);
            this.Zaszumiony.Name = "Zaszumiony";
            this.Zaszumiony.Size = new System.Drawing.Size(81, 17);
            this.Zaszumiony.TabIndex = 4;
            this.Zaszumiony.TabStop = true;
            this.Zaszumiony.Text = "Zaszumiony";
            this.Zaszumiony.UseVisualStyleBackColor = true;
            this.Zaszumiony.CheckedChanged += new System.EventHandler(this.Zaszumiony_CheckedChanged);
            // 
            // Odszumiony
            // 
            this.Odszumiony.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Odszumiony.AutoSize = true;
            this.Odszumiony.Enabled = false;
            this.Odszumiony.Location = new System.Drawing.Point(386, 62);
            this.Odszumiony.Name = "Odszumiony";
            this.Odszumiony.Size = new System.Drawing.Size(82, 17);
            this.Odszumiony.TabIndex = 5;
            this.Odszumiony.TabStop = true;
            this.Odszumiony.Text = "Odszumiony";
            this.Odszumiony.UseVisualStyleBackColor = true;
            this.Odszumiony.CheckedChanged += new System.EventHandler(this.Odszumiony_CheckedChanged);
            // 
            // miary_podobienstwa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Odszumiony);
            this.Controls.Add(this.Zaszumiony);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bl_sredniokwadrat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.szczyt_sr_kwadrat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.syg_do_szum);
            this.Controls.Add(this.Szczyt_syg_do_szum_label);
            this.Controls.Add(this.szyt_syg_do_szum);
            this.Controls.Add(this.maxRoznica_label);
            this.Controls.Add(this.MaxRoznica);
            this.Controls.Add(this.oryginalny_button);
            this.Name = "miary_podobienstwa";
            this.Size = new System.Drawing.Size(721, 89);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button oryginalny_button;
        private System.Windows.Forms.TextBox MaxRoznica;
        private System.Windows.Forms.Label maxRoznica_label;
        private System.Windows.Forms.TextBox szyt_syg_do_szum;
        private System.Windows.Forms.Label Szczyt_syg_do_szum_label;
        private System.Windows.Forms.TextBox syg_do_szum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox szczyt_sr_kwadrat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox bl_sredniokwadrat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Drawing.Bitmap original;
        private System.Drawing.Bitmap szum; 
        private System.Windows.Forms.RadioButton Zaszumiony;
        private System.Windows.Forms.RadioButton Odszumiony;
        
    }
}
