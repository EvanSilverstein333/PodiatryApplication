namespace View.Views.FinancialAccount
{
    partial class FinancialAccountActionPane
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelPatientDetails = new System.Windows.Forms.Panel();
            this.btnViewFinancialTransactions = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMakePayment = new System.Windows.Forms.Button();
            this.btnChargeAccount = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.panelPatientDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelPatientDetails);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 233);
            this.panel1.TabIndex = 1;
            // 
            // panelPatientDetails
            // 
            this.panelPatientDetails.AutoSize = true;
            this.panelPatientDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelPatientDetails.Controls.Add(this.btnViewFinancialTransactions);
            this.panelPatientDetails.Controls.Add(this.btnChargeAccount);
            this.panelPatientDetails.Controls.Add(this.btnMakePayment);
            this.panelPatientDetails.Controls.Add(this.btnBack);
            this.panelPatientDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPatientDetails.Location = new System.Drawing.Point(0, 0);
            this.panelPatientDetails.Name = "panelPatientDetails";
            this.panelPatientDetails.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.panelPatientDetails.Size = new System.Drawing.Size(262, 111);
            this.panelPatientDetails.TabIndex = 6;
            // 
            // btnViewFinancialTransactions
            // 
            this.btnViewFinancialTransactions.AutoSize = true;
            this.btnViewFinancialTransactions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnViewFinancialTransactions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnViewFinancialTransactions.Location = new System.Drawing.Point(3, 81);
            this.btnViewFinancialTransactions.Name = "btnViewFinancialTransactions";
            this.btnViewFinancialTransactions.Size = new System.Drawing.Size(256, 27);
            this.btnViewFinancialTransactions.TabIndex = 3;
            this.btnViewFinancialTransactions.Text = "View Transactions";
            this.btnViewFinancialTransactions.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(262, 0);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnMakePayment
            // 
            this.btnMakePayment.AutoSize = true;
            this.btnMakePayment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMakePayment.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMakePayment.Location = new System.Drawing.Point(3, 27);
            this.btnMakePayment.Name = "btnMakePayment";
            this.btnMakePayment.Size = new System.Drawing.Size(256, 27);
            this.btnMakePayment.TabIndex = 4;
            this.btnMakePayment.Text = "Make Payment";
            this.btnMakePayment.UseVisualStyleBackColor = true;
            // 
            // btnChargeAccount
            // 
            this.btnChargeAccount.AutoSize = true;
            this.btnChargeAccount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChargeAccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChargeAccount.Location = new System.Drawing.Point(3, 54);
            this.btnChargeAccount.Name = "btnChargeAccount";
            this.btnChargeAccount.Size = new System.Drawing.Size(256, 27);
            this.btnChargeAccount.TabIndex = 5;
            this.btnChargeAccount.Text = "Charge Account";
            this.btnChargeAccount.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = true;
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBack.Location = new System.Drawing.Point(3, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(39, 17);
            this.btnBack.TabIndex = 6;
            this.btnBack.TabStop = true;
            this.btnBack.Text = "Back";
            // 
            // FinancialAccountActionPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.panel1);
            this.Name = "FinancialAccountActionPane";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "FinancialAccountActionPane";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelPatientDetails.ResumeLayout(false);
            this.panelPatientDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelPatientDetails;
        private System.Windows.Forms.Button btnViewFinancialTransactions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnMakePayment;
        private System.Windows.Forms.Button btnChargeAccount;
        private System.Windows.Forms.LinkLabel btnBack;
    }
}