namespace View.Views.Healthcard
{
    partial class HealthcardView
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
            this.healthcardControl1 = new WindowsForms.Health.HealthcardControl();
            this.SuspendLayout();
            // 
            // healthcardControl1
            // 
            this.healthcardControl1.AutoSize = true;
            this.healthcardControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.healthcardControl1.BackColor = System.Drawing.Color.Transparent;
            this.healthcardControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.healthcardControl1.Location = new System.Drawing.Point(10, 10);
            this.healthcardControl1.Name = "healthcardControl1";
            this.healthcardControl1.ReadOnly = true;
            this.healthcardControl1.Size = new System.Drawing.Size(349, 70);
            this.healthcardControl1.TabIndex = 16;
            // 
            // HealthcardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(369, 349);
            this.Controls.Add(this.healthcardControl1);
            this.Name = "HealthcardView";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "HealthcardView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowsForms.Health.HealthcardControl healthcardControl1;
    }
}