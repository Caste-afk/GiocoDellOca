namespace GiocoDellOca
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Titolo = new System.Windows.Forms.Label();
            this.btn_Gioca = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Titolo
            // 
            this.lbl_Titolo.AutoSize = true;
            this.lbl_Titolo.Font = new System.Drawing.Font("MV Boli", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Titolo.Location = new System.Drawing.Point(109, 42);
            this.lbl_Titolo.Name = "lbl_Titolo";
            this.lbl_Titolo.Size = new System.Drawing.Size(382, 70);
            this.lbl_Titolo.TabIndex = 0;
            this.lbl_Titolo.Text = "Gioco dell\'oca!";
            // 
            // btn_Gioca
            // 
            this.btn_Gioca.Font = new System.Drawing.Font("MV Boli", 13.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Gioca.Location = new System.Drawing.Point(166, 210);
            this.btn_Gioca.Name = "btn_Gioca";
            this.btn_Gioca.Size = new System.Drawing.Size(270, 103);
            this.btn_Gioca.TabIndex = 1;
            this.btn_Gioca.Text = "Gioca!";
            this.btn_Gioca.UseVisualStyleBackColor = true;
            this.btn_Gioca.Click += new System.EventHandler(this.btn_Gioca_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 416);
            this.Controls.Add(this.btn_Gioca);
            this.Controls.Add(this.lbl_Titolo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Titolo;
        private System.Windows.Forms.Button btn_Gioca;
    }
}

