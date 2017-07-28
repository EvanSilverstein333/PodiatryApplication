namespace View.Views.PatientVisit
{
    partial class PatientVisitIndex
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
            this.dgvPatientVisits = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientVisits)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPatientVisits
            // 
            this.dgvPatientVisits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatientVisits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPatientVisits.Location = new System.Drawing.Point(0, 0);
            this.dgvPatientVisits.Name = "dgvPatientVisits";
            this.dgvPatientVisits.RowTemplate.Height = 24;
            this.dgvPatientVisits.Size = new System.Drawing.Size(571, 345);
            this.dgvPatientVisits.TabIndex = 11;
            // 
            // PatientVisitIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 345);
            this.Controls.Add(this.dgvPatientVisits);
            this.Name = "PatientVisitIndex";
            this.Text = "PatientVisitsView";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientVisits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPatientVisits;
    }
}