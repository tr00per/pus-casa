namespace PO1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otwórzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.zakończToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oknoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edycjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacjePodstawoweToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacjeGeometryczneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuwanieSzumuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ącyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtrKontrharmonicznyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analizaPodobieństwaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.miary_podobienstwa1 = new PO1.miary_podobienstwa();
            this.filtr_kontr_harmoniczny1 = new PO1.filtr_kontr_harmoniczny();
            this.filtr_alfa_obciety1 = new PO1.filtr_alfa_obciety();
            this.geometryczne1 = new PO1.geometryczne();
            this.podstawowe1 = new PO1.podstawowe();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.oknoToolStripMenuItem,
            this.edycjaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.oknoToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(806, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otwórzToolStripMenuItem,
            this.zapiszToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.zamknijToolStripMenuItem,
            this.toolStripSeparator1,
            this.zakończToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // otwórzToolStripMenuItem
            // 
            this.otwórzToolStripMenuItem.Name = "otwórzToolStripMenuItem";
            this.otwórzToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.otwórzToolStripMenuItem.Text = "Otwórz";
            this.otwórzToolStripMenuItem.Click += new System.EventHandler(this.otwórzToolStripMenuItem_Click);
            // 
            // zapiszToolStripMenuItem
            // 
            this.zapiszToolStripMenuItem.Name = "zapiszToolStripMenuItem";
            this.zapiszToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.zapiszToolStripMenuItem.Text = "Zapisz";
            this.zapiszToolStripMenuItem.Click += new System.EventHandler(this.zapiszToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // zamknijToolStripMenuItem
            // 
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            this.zamknijToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.zamknijToolStripMenuItem.Text = "Zamknij";
            this.zamknijToolStripMenuItem.Click += new System.EventHandler(this.zamknijToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(115, 6);
            // 
            // zakończToolStripMenuItem
            // 
            this.zakończToolStripMenuItem.Name = "zakończToolStripMenuItem";
            this.zakończToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.zakończToolStripMenuItem.Text = "Zakończ";
            this.zakończToolStripMenuItem.Click += new System.EventHandler(this.zakończToolStripMenuItem_Click_1);
            // 
            // oknoToolStripMenuItem
            // 
            this.oknoToolStripMenuItem.Name = "oknoToolStripMenuItem";
            this.oknoToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.oknoToolStripMenuItem.Text = "Okno";
            // 
            // edycjaToolStripMenuItem
            // 
            this.edycjaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operacjePodstawoweToolStripMenuItem,
            this.operacjeGeometryczneToolStripMenuItem,
            this.usuwanieSzumuToolStripMenuItem,
            this.analizaPodobieństwaToolStripMenuItem});
            this.edycjaToolStripMenuItem.Name = "edycjaToolStripMenuItem";
            this.edycjaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.edycjaToolStripMenuItem.Text = "Edycja";
            // 
            // operacjePodstawoweToolStripMenuItem
            // 
            this.operacjePodstawoweToolStripMenuItem.Name = "operacjePodstawoweToolStripMenuItem";
            this.operacjePodstawoweToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.operacjePodstawoweToolStripMenuItem.Text = "Operacje podstawowe";
            this.operacjePodstawoweToolStripMenuItem.Click += new System.EventHandler(this.operacjePodstawoweToolStripMenuItem_Click);
            // 
            // operacjeGeometryczneToolStripMenuItem
            // 
            this.operacjeGeometryczneToolStripMenuItem.Name = "operacjeGeometryczneToolStripMenuItem";
            this.operacjeGeometryczneToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.operacjeGeometryczneToolStripMenuItem.Text = "Operacje geometryczne";
            this.operacjeGeometryczneToolStripMenuItem.Click += new System.EventHandler(this.operacjeGeometryczneToolStripMenuItem_Click);
            // 
            // usuwanieSzumuToolStripMenuItem
            // 
            this.usuwanieSzumuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ącyToolStripMenuItem,
            this.filtrKontrharmonicznyToolStripMenuItem});
            this.usuwanieSzumuToolStripMenuItem.Name = "usuwanieSzumuToolStripMenuItem";
            this.usuwanieSzumuToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.usuwanieSzumuToolStripMenuItem.Text = "Usuwanie szumu";
            // 
            // ącyToolStripMenuItem
            // 
            this.ącyToolStripMenuItem.Name = "ącyToolStripMenuItem";
            this.ącyToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.ącyToolStripMenuItem.Text = "filtr alfa-odcinajacy";
            this.ącyToolStripMenuItem.Click += new System.EventHandler(this.ącyToolStripMenuItem_Click);
            // 
            // filtrKontrharmonicznyToolStripMenuItem
            // 
            this.filtrKontrharmonicznyToolStripMenuItem.Name = "filtrKontrharmonicznyToolStripMenuItem";
            this.filtrKontrharmonicznyToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.filtrKontrharmonicznyToolStripMenuItem.Text = "filtr kontr-harmoniczny";
            this.filtrKontrharmonicznyToolStripMenuItem.Click += new System.EventHandler(this.filtrKontrharmonicznyToolStripMenuItem_Click);
            // 
            // analizaPodobieństwaToolStripMenuItem
            // 
            this.analizaPodobieństwaToolStripMenuItem.Name = "analizaPodobieństwaToolStripMenuItem";
            this.analizaPodobieństwaToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.analizaPodobieństwaToolStripMenuItem.Text = "Analiza podobieństwa";
            this.analizaPodobieństwaToolStripMenuItem.Click += new System.EventHandler(this.analizaPodobieństwaToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
            // 
            // miary_podobienstwa1
            // 
            this.miary_podobienstwa1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.miary_podobienstwa1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.miary_podobienstwa1.Enabled = false;
            this.miary_podobienstwa1.Location = new System.Drawing.Point(0, 379);
            this.miary_podobienstwa1.Name = "miary_podobienstwa1";
            this.miary_podobienstwa1.Size = new System.Drawing.Size(6, 89);
            this.miary_podobienstwa1.TabIndex = 12;
            this.miary_podobienstwa1.Visible = false;
            // 
            // filtr_kontr_harmoniczny1
            // 
            this.filtr_kontr_harmoniczny1.Dock = System.Windows.Forms.DockStyle.Right;
            this.filtr_kontr_harmoniczny1.Enabled = false;
            this.filtr_kontr_harmoniczny1.Location = new System.Drawing.Point(6, 24);
            this.filtr_kontr_harmoniczny1.Name = "filtr_kontr_harmoniczny1";
            this.filtr_kontr_harmoniczny1.Size = new System.Drawing.Size(200, 444);
            this.filtr_kontr_harmoniczny1.TabIndex = 8;
            this.filtr_kontr_harmoniczny1.Visible = false;
            // 
            // filtr_alfa_obciety1
            // 
            this.filtr_alfa_obciety1.Dock = System.Windows.Forms.DockStyle.Right;
            this.filtr_alfa_obciety1.Enabled = false;
            this.filtr_alfa_obciety1.Location = new System.Drawing.Point(206, 24);
            this.filtr_alfa_obciety1.Name = "filtr_alfa_obciety1";
            this.filtr_alfa_obciety1.Size = new System.Drawing.Size(200, 444);
            this.filtr_alfa_obciety1.TabIndex = 6;
            this.filtr_alfa_obciety1.Visible = false;
            // 
            // geometryczne1
            // 
            this.geometryczne1.Dock = System.Windows.Forms.DockStyle.Right;
            this.geometryczne1.Enabled = false;
            this.geometryczne1.Location = new System.Drawing.Point(406, 24);
            this.geometryczne1.Name = "geometryczne1";
            this.geometryczne1.Size = new System.Drawing.Size(200, 444);
            this.geometryczne1.TabIndex = 4;
            this.geometryczne1.Visible = false;
            // 
            // podstawowe1
            // 
            this.podstawowe1.Dock = System.Windows.Forms.DockStyle.Right;
            this.podstawowe1.Enabled = false;
            this.podstawowe1.Location = new System.Drawing.Point(606, 24);
            this.podstawowe1.Name = "podstawowe1";
            this.podstawowe1.Size = new System.Drawing.Size(200, 444);
            this.podstawowe1.TabIndex = 0;
            this.podstawowe1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(806, 468);
            this.Controls.Add(this.miary_podobienstwa1);
            this.Controls.Add(this.filtr_kontr_harmoniczny1);
            this.Controls.Add(this.filtr_alfa_obciety1);
            this.Controls.Add(this.geometryczne1);
            this.Controls.Add(this.podstawowe1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Przetwarzanie Obrazów 1 - CASA";
            this.MdiChildActivate += new System.EventHandler(this.Form1_MdiChildActivate);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otwórzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem zakończToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oknoToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private podstawowe podstawowe1;
        private System.Windows.Forms.ToolStripMenuItem edycjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operacjePodstawoweToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operacjeGeometryczneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuwanieSzumuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analizaPodobieństwaToolStripMenuItem;
        private geometryczne geometryczne1;
        private filtr_alfa_obciety filtr_alfa_obciety1;
        private System.Windows.Forms.ToolStripMenuItem ącyToolStripMenuItem;
        private filtr_kontr_harmoniczny filtr_kontr_harmoniczny1;
        private System.Windows.Forms.ToolStripMenuItem filtrKontrharmonicznyToolStripMenuItem;
        private miary_podobienstwa miary_podobienstwa1;

    }
}

