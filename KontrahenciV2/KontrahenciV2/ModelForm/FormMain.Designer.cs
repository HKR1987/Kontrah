namespace KontrahenciV2.ModelForm
{
    partial class FormMain
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonNowyKontrahent = new System.Windows.Forms.Button();
            this.GridGlowny = new System.Windows.Forms.DataGridView();
            this.buttonUsunKontrahenta = new System.Windows.Forms.Button();
            this.buttonEdytuj = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridGlowny)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonNowyKontrahent
            // 
            this.buttonNowyKontrahent.Location = new System.Drawing.Point(12, 12);
            this.buttonNowyKontrahent.Name = "buttonNowyKontrahent";
            this.buttonNowyKontrahent.Size = new System.Drawing.Size(99, 23);
            this.buttonNowyKontrahent.TabIndex = 0;
            this.buttonNowyKontrahent.Text = "Nowy Kontrahent";
            this.buttonNowyKontrahent.UseVisualStyleBackColor = true;
            this.buttonNowyKontrahent.Click += new System.EventHandler(this.ButtonNowyKontrahent_Click);
            // 
            // GridGlowny
            // 
            this.GridGlowny.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridGlowny.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GridGlowny.Location = new System.Drawing.Point(12, 41);
            this.GridGlowny.MultiSelect = false;
            this.GridGlowny.Name = "GridGlowny";
            this.GridGlowny.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridGlowny.Size = new System.Drawing.Size(776, 397);
            this.GridGlowny.TabIndex = 1;
            this.GridGlowny.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridGlowny_CellDoubleClick);
            // 
            // buttonUsunKontrahenta
            // 
            this.buttonUsunKontrahenta.Location = new System.Drawing.Point(181, 12);
            this.buttonUsunKontrahenta.Name = "buttonUsunKontrahenta";
            this.buttonUsunKontrahenta.Size = new System.Drawing.Size(58, 23);
            this.buttonUsunKontrahenta.TabIndex = 2;
            this.buttonUsunKontrahenta.Text = "Usuń";
            this.buttonUsunKontrahenta.UseVisualStyleBackColor = true;
            this.buttonUsunKontrahenta.Click += new System.EventHandler(this.ButtonUsunKontrahenta_Click);
            // 
            // buttonEdytuj
            // 
            this.buttonEdytuj.Location = new System.Drawing.Point(117, 12);
            this.buttonEdytuj.Name = "buttonEdytuj";
            this.buttonEdytuj.Size = new System.Drawing.Size(58, 23);
            this.buttonEdytuj.TabIndex = 3;
            this.buttonEdytuj.Text = "Edytuj";
            this.buttonEdytuj.UseVisualStyleBackColor = true;
            this.buttonEdytuj.Click += new System.EventHandler(this.ButtonEdytuj_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonEdytuj);
            this.Controls.Add(this.buttonUsunKontrahenta);
            this.Controls.Add(this.GridGlowny);
            this.Controls.Add(this.buttonNowyKontrahent);
            this.Name = "FormMain";
            this.Text = "KontrahenciV2";
            ((System.ComponentModel.ISupportInitialize)(this.GridGlowny)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNowyKontrahent;
        private System.Windows.Forms.DataGridView GridGlowny;
        private System.Windows.Forms.Button buttonUsunKontrahenta;
        private System.Windows.Forms.Button buttonEdytuj;
    }
}

