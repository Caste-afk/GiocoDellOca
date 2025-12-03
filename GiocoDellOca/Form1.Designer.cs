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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbl_Titolo = new System.Windows.Forms.Label();
            this.btn_Gioca = new System.Windows.Forms.Button();
            this.ptb_g1 = new System.Windows.Forms.PictureBox();
            this.btn_sinistra1 = new System.Windows.Forms.Button();
            this.btn_destra1 = new System.Windows.Forms.Button();
            this.btn_destra2 = new System.Windows.Forms.Button();
            this.btn_sinistra2 = new System.Windows.Forms.Button();
            this.ptb_g2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_g1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_g2)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Titolo
            // 
            this.lbl_Titolo.AutoSize = true;
            this.lbl_Titolo.Font = new System.Drawing.Font("MV Boli", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Titolo.Location = new System.Drawing.Point(383, 9);
            this.lbl_Titolo.Name = "lbl_Titolo";
            this.lbl_Titolo.Size = new System.Drawing.Size(382, 70);
            this.lbl_Titolo.TabIndex = 0;
            this.lbl_Titolo.Text = "Gioco dell\'oca!";
            // 
            // btn_Gioca
            // 
            this.btn_Gioca.Font = new System.Drawing.Font("MV Boli", 13.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Gioca.Location = new System.Drawing.Point(432, 604);
            this.btn_Gioca.Name = "btn_Gioca";
            this.btn_Gioca.Size = new System.Drawing.Size(270, 103);
            this.btn_Gioca.TabIndex = 1;
            this.btn_Gioca.Text = "Gioca!";
            this.btn_Gioca.UseVisualStyleBackColor = true;
            this.btn_Gioca.Click += new System.EventHandler(this.btn_Gioca_Click);
            // 
            // ptb_g1
            // 
            this.ptb_g1.Location = new System.Drawing.Point(156, 196);
            this.ptb_g1.Name = "ptb_g1";
            this.ptb_g1.Size = new System.Drawing.Size(242, 258);
            this.ptb_g1.TabIndex = 2;
            this.ptb_g1.TabStop = false;
            // 
            // btn_sinistra1
            // 
            this.btn_sinistra1.BackColor = System.Drawing.Color.Transparent;
            this.btn_sinistra1.BackgroundImage = global::GiocoDellOca.Properties.Resources.frecciaSinistra;
            this.btn_sinistra1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_sinistra1.FlatAppearance.BorderSize = 0;
            this.btn_sinistra1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sinistra1.ForeColor = System.Drawing.Color.Transparent;
            this.btn_sinistra1.Location = new System.Drawing.Point(75, 255);
            this.btn_sinistra1.Name = "btn_sinistra1";
            this.btn_sinistra1.Size = new System.Drawing.Size(75, 111);
            this.btn_sinistra1.TabIndex = 3;
            this.btn_sinistra1.UseVisualStyleBackColor = false;
            this.btn_sinistra1.Click += new System.EventHandler(this.btn_sinistra1_Click);
            // 
            // btn_destra1
            // 
            this.btn_destra1.BackColor = System.Drawing.Color.Transparent;
            this.btn_destra1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_destra1.BackgroundImage")));
            this.btn_destra1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_destra1.FlatAppearance.BorderSize = 0;
            this.btn_destra1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_destra1.ForeColor = System.Drawing.Color.Transparent;
            this.btn_destra1.Location = new System.Drawing.Point(404, 255);
            this.btn_destra1.Name = "btn_destra1";
            this.btn_destra1.Size = new System.Drawing.Size(75, 111);
            this.btn_destra1.TabIndex = 4;
            this.btn_destra1.UseVisualStyleBackColor = false;
            this.btn_destra1.Click += new System.EventHandler(this.btn_destra1_Click);
            // 
            // btn_destra2
            // 
            this.btn_destra2.BackColor = System.Drawing.Color.Transparent;
            this.btn_destra2.BackgroundImage = global::GiocoDellOca.Properties.Resources.frecciaDestra;
            this.btn_destra2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_destra2.FlatAppearance.BorderSize = 0;
            this.btn_destra2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_destra2.ForeColor = System.Drawing.Color.Transparent;
            this.btn_destra2.Location = new System.Drawing.Point(987, 255);
            this.btn_destra2.Name = "btn_destra2";
            this.btn_destra2.Size = new System.Drawing.Size(75, 111);
            this.btn_destra2.TabIndex = 7;
            this.btn_destra2.UseVisualStyleBackColor = false;
            this.btn_destra2.Click += new System.EventHandler(this.btn_destra2_Click);
            // 
            // btn_sinistra2
            // 
            this.btn_sinistra2.BackColor = System.Drawing.Color.Transparent;
            this.btn_sinistra2.BackgroundImage = global::GiocoDellOca.Properties.Resources.frecciaSinistra;
            this.btn_sinistra2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_sinistra2.FlatAppearance.BorderSize = 0;
            this.btn_sinistra2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sinistra2.ForeColor = System.Drawing.Color.Transparent;
            this.btn_sinistra2.Location = new System.Drawing.Point(658, 255);
            this.btn_sinistra2.Name = "btn_sinistra2";
            this.btn_sinistra2.Size = new System.Drawing.Size(75, 111);
            this.btn_sinistra2.TabIndex = 6;
            this.btn_sinistra2.UseVisualStyleBackColor = false;
            this.btn_sinistra2.Click += new System.EventHandler(this.btn_sinistra2_Click);
            // 
            // ptb_g2
            // 
            this.ptb_g2.Location = new System.Drawing.Point(739, 196);
            this.ptb_g2.Name = "ptb_g2";
            this.ptb_g2.Size = new System.Drawing.Size(242, 258);
            this.ptb_g2.TabIndex = 5;
            this.ptb_g2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 759);
            this.Controls.Add(this.btn_destra2);
            this.Controls.Add(this.btn_sinistra2);
            this.Controls.Add(this.ptb_g2);
            this.Controls.Add(this.btn_destra1);
            this.Controls.Add(this.btn_sinistra1);
            this.Controls.Add(this.ptb_g1);
            this.Controls.Add(this.btn_Gioca);
            this.Controls.Add(this.lbl_Titolo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptb_g1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_g2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Titolo;
        private System.Windows.Forms.Button btn_Gioca;
        private System.Windows.Forms.PictureBox ptb_g1;
        private System.Windows.Forms.Button btn_sinistra1;
        private System.Windows.Forms.Button btn_destra1;
        private System.Windows.Forms.Button btn_destra2;
        private System.Windows.Forms.Button btn_sinistra2;
        private System.Windows.Forms.PictureBox ptb_g2;
    }
}

