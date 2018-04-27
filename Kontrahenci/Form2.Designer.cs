namespace Kontrahenci
{
    partial class Form2
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
            this.b_spr = new System.Windows.Forms.Button();
            this.b_tworz = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.b_dodaj = new System.Windows.Forms.Button();
            this.b_wybierz = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // b_spr
            // 
            this.b_spr.Location = new System.Drawing.Point(12, 339);
            this.b_spr.Name = "b_spr";
            this.b_spr.Size = new System.Drawing.Size(151, 23);
            this.b_spr.TabIndex = 0;
            this.b_spr.Text = "Sprawdź połączenie z bazą";
            this.b_spr.UseVisualStyleBackColor = true;
            this.b_spr.Click += new System.EventHandler(this.b_spr_Click);
            // 
            // b_tworz
            // 
            this.b_tworz.Location = new System.Drawing.Point(12, 368);
            this.b_tworz.Name = "b_tworz";
            this.b_tworz.Size = new System.Drawing.Size(151, 23);
            this.b_tworz.TabIndex = 1;
            this.b_tworz.Text = "Utwórz tabelę Kontrah";
            this.b_tworz.UseVisualStyleBackColor = true;
            this.b_tworz.Click += new System.EventHandler(this.b_tworz_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(890, 321);
            this.dataGridView1.TabIndex = 2;
            // 
            // b_dodaj
            // 
            this.b_dodaj.Location = new System.Drawing.Point(169, 339);
            this.b_dodaj.Name = "b_dodaj";
            this.b_dodaj.Size = new System.Drawing.Size(151, 23);
            this.b_dodaj.TabIndex = 3;
            this.b_dodaj.Text = "Dodaj Kontrahenta";
            this.b_dodaj.UseVisualStyleBackColor = true;
            this.b_dodaj.Click += new System.EventHandler(this.b_dodaj_Click);
            // 
            // b_wybierz
            // 
            this.b_wybierz.Location = new System.Drawing.Point(169, 368);
            this.b_wybierz.Name = "b_wybierz";
            this.b_wybierz.Size = new System.Drawing.Size(151, 23);
            this.b_wybierz.TabIndex = 4;
            this.b_wybierz.Text = "Wybierz Kontrahenta";
            this.b_wybierz.UseVisualStyleBackColor = true;
            this.b_wybierz.Click += new System.EventHandler(this.b_wybierz_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 403);
            this.Controls.Add(this.b_wybierz);
            this.Controls.Add(this.b_dodaj);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.b_tworz);
            this.Controls.Add(this.b_spr);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_spr;
        private System.Windows.Forms.Button b_tworz;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button b_dodaj;
        private System.Windows.Forms.Button b_wybierz;
    }
}