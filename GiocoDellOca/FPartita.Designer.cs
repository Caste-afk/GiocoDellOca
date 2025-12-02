namespace GiocoDellOca
{
    partial class FPartita
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
            this.dgv_Partita = new System.Windows.Forms.DataGridView();
            this.btn_Dadi = new System.Windows.Forms.Button();
            this.lbl_Turno = new System.Windows.Forms.Label();
            this.ptb_Dado1 = new System.Windows.Forms.PictureBox();
            this.ptb_Dado2 = new System.Windows.Forms.PictureBox();
            this.ptb_g1 = new System.Windows.Forms.PictureBox();
            this.ptb_g2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Partita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Dado1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Dado2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_g1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_g2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Partita
            // 
            this.dgv_Partita.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Partita.Location = new System.Drawing.Point(238, 108);
            this.dgv_Partita.Name = "dgv_Partita";
            this.dgv_Partita.RowHeadersWidth = 82;
            this.dgv_Partita.RowTemplate.Height = 33;
            this.dgv_Partita.Size = new System.Drawing.Size(839, 708);
            this.dgv_Partita.TabIndex = 0;
            // 
            // btn_Dadi
            // 
            this.btn_Dadi.Location = new System.Drawing.Point(1520, 530);
            this.btn_Dadi.Name = "btn_Dadi";
            this.btn_Dadi.Size = new System.Drawing.Size(464, 118);
            this.btn_Dadi.TabIndex = 1;
            this.btn_Dadi.Text = "Lancia i dadi!";
            this.btn_Dadi.UseVisualStyleBackColor = true;
            this.btn_Dadi.Click += new System.EventHandler(this.btn_Dadi_Click);
            // 
            // lbl_Turno
            // 
            this.lbl_Turno.AutoSize = true;
            this.lbl_Turno.Location = new System.Drawing.Point(1706, 124);
            this.lbl_Turno.Name = "lbl_Turno";
            this.lbl_Turno.Size = new System.Drawing.Size(61, 25);
            this.lbl_Turno.TabIndex = 2;
            this.lbl_Turno.Text = "turno";
            // 
            // ptb_Dado1
            // 
            this.ptb_Dado1.Location = new System.Drawing.Point(1472, 274);
            this.ptb_Dado1.Name = "ptb_Dado1";
            this.ptb_Dado1.Size = new System.Drawing.Size(242, 204);
            this.ptb_Dado1.TabIndex = 3;
            this.ptb_Dado1.TabStop = false;
            // 
            // ptb_Dado2
            // 
            this.ptb_Dado2.Location = new System.Drawing.Point(1806, 274);
            this.ptb_Dado2.Name = "ptb_Dado2";
            this.ptb_Dado2.Size = new System.Drawing.Size(242, 204);
            this.ptb_Dado2.TabIndex = 4;
            this.ptb_Dado2.TabStop = false;
            // 
            // ptb_g1
            // 
            this.ptb_g1.Location = new System.Drawing.Point(124, 108);
            this.ptb_g1.Name = "ptb_g1";
            this.ptb_g1.Size = new System.Drawing.Size(80, 80);
            this.ptb_g1.TabIndex = 5;
            this.ptb_g1.TabStop = false;
            // 
            // ptb_g2
            // 
            this.ptb_g2.Location = new System.Drawing.Point(12, 108);
            this.ptb_g2.Name = "ptb_g2";
            this.ptb_g2.Size = new System.Drawing.Size(80, 80);
            this.ptb_g2.TabIndex = 6;
            this.ptb_g2.TabStop = false;
            // 
            // FPartita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2138, 1087);
            this.Controls.Add(this.ptb_g2);
            this.Controls.Add(this.ptb_g1);
            this.Controls.Add(this.ptb_Dado2);
            this.Controls.Add(this.ptb_Dado1);
            this.Controls.Add(this.lbl_Turno);
            this.Controls.Add(this.btn_Dadi);
            this.Controls.Add(this.dgv_Partita);
            this.Name = "FPartita";
            this.Text = "FPartita";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FPartita_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Partita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Dado1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Dado2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_g1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_g2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Partita;
        private System.Windows.Forms.Button btn_Dadi;
        private System.Windows.Forms.Label lbl_Turno;
        private System.Windows.Forms.PictureBox ptb_Dado1;
        private System.Windows.Forms.PictureBox ptb_Dado2;
        private System.Windows.Forms.PictureBox ptb_g1;
        private System.Windows.Forms.PictureBox ptb_g2;
    }
}