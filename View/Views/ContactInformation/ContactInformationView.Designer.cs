namespace View.Views.ContactInformation
{
    partial class ContactInformationView
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
            this.contactInfoControl1 = new WindowsForms.General.ContactInfoControl();
            this.SuspendLayout();
            // 
            // contactInfoControl1
            // 
            this.contactInfoControl1.AutoSize = true;
            this.contactInfoControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contactInfoControl1.BackColor = System.Drawing.SystemColors.Control;
            this.contactInfoControl1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
            this.contactInfoControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.contactInfoControl1.Location = new System.Drawing.Point(10, 10);
            this.contactInfoControl1.Name = "contactInfoControl1";
            this.contactInfoControl1.ReadOnly = true;
            this.contactInfoControl1.Size = new System.Drawing.Size(318, 200);
            this.contactInfoControl1.TabIndex = 15;
            // 
            // ContactInformationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(338, 315);
            this.Controls.Add(this.contactInfoControl1);
            this.Name = "ContactInformationView";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "ContactInformationView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowsForms.General.ContactInfoControl contactInfoControl1;
    }
}