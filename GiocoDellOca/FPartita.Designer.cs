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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Partita)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Partita
            // 
            this.dgv_Partita.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Partita.Location = new System.Drawing.Point(12, 12);
            this.dgv_Partita.Name = "dgv_Partita";
            this.dgv_Partita.RowHeadersWidth = 82;
            this.dgv_Partita.RowTemplate.Height = 33;
            this.dgv_Partita.Size = new System.Drawing.Size(919, 919);
            this.dgv_Partita.TabIndex = 0;
            // 
            // FPartita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1401, 943);
            this.Controls.Add(this.dgv_Partita);
            this.Name = "FPartita";
            this.Text = "FPartita";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Partita)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Partita;
    }
}