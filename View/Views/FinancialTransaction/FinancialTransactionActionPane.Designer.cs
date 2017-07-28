namespace View.Views.FinancialTransaction
{
    partial class FinancialTransactionActionPane
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
            this.panelTransactionDetails = new System.Windows.Forms.Panel();
            this.btnUpdateTransaction = new System.Windows.Forms.Button();
            this.lblDateOfVisit = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRemoveTransaction = new System.Windows.Forms.Button();
            this.btnAddTransaction = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.searchDate = new NullableDateTimePicker.NullableDateTimePicker();
            this.lblAccountHolderName = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.panelTransactionDetails.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelTransactionDetails);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 191);
            this.panel1.TabIndex = 1;
            // 
            // panelTransactionDetails
            // 
            this.panelTransactionDetails.AutoSize = true;
            this.panelTransactionDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelTransactionDetails.Controls.Add(this.btnUpdateTransaction);
            this.panelTransactionDetails.Controls.Add(this.lblDateOfVisit);
            this.panelTransactionDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTransactionDetails.Location = new System.Drawing.Point(0, 94);
            this.panelTransactionDetails.Name = "panelTransactionDetails";
            this.panelTransactionDetails.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.panelTransactionDetails.Size = new System.Drawing.Size(262, 65);
            this.panelTransactionDetails.TabIndex = 7;
            // 
            // btnUpdateTransaction
            // 
            this.btnUpdateTransaction.AutoSize = true;
            this.btnUpdateTransaction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdateTransaction.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUpdateTransaction.Location = new System.Drawing.Point(3, 35);
            this.btnUpdateTransaction.Name = "btnUpdateTransaction";
            this.btnUpdateTransaction.Size = new System.Drawing.Size(256, 27);
            this.btnUpdateTransaction.TabIndex = 3;
            this.btnUpdateTransaction.Text = "Update Transaction";
            this.btnUpdateTransaction.UseVisualStyleBackColor = true;
            // 
            // lblDateOfVisit
            // 
            this.lblDateOfVisit.AutoEllipsis = true;
            this.lblDateOfVisit.AutoSize = true;
            this.lblDateOfVisit.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDateOfVisit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateOfVisit.ForeColor = System.Drawing.Color.White;
            this.lblDateOfVisit.Location = new System.Drawing.Point(3, 10);
            this.lblDateOfVisit.Name = "lblDateOfVisit";
            this.lblDateOfVisit.Size = new System.Drawing.Size(53, 25);
            this.lblDateOfVisit.TabIndex = 0;
            this.lblDateOfVisit.Text = "Date";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnRemoveTransaction, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAddTransaction, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.searchDate, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(262, 94);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnRemoveTransaction
            // 
            this.btnRemoveTransaction.AutoSize = true;
            this.btnRemoveTransaction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.btnRemoveTransaction, 2);
            this.btnRemoveTransaction.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRemoveTransaction.Location = new System.Drawing.Point(3, 64);
            this.btnRemoveTransaction.Name = "btnRemoveTransaction";
            this.btnRemoveTransaction.Size = new System.Drawing.Size(256, 27);
            this.btnRemoveTransaction.TabIndex = 5;
            this.btnRemoveTransaction.Text = "Remove Transaction";
            this.btnRemoveTransaction.UseVisualStyleBackColor = true;
            // 
            // btnAddTransaction
            // 
            this.btnAddTransaction.AutoSize = true;
            this.btnAddTransaction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.btnAddTransaction, 2);
            this.btnAddTransaction.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddTransaction.Location = new System.Drawing.Point(3, 31);
            this.btnAddTransaction.Name = "btnAddTransaction";
            this.btnAddTransaction.Size = new System.Drawing.Size(256, 27);
            this.btnAddTransaction.TabIndex = 4;
            this.btnAddTransaction.Text = "Add Transaction";
            this.btnAddTransaction.UseVisualStyleBackColor = true;
            this.btnAddTransaction.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // searchDate
            // 
            this.searchDate.CustomFormat = " ";
            this.searchDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.searchDate.Location = new System.Drawing.Point(66, 3);
            this.searchDate.Name = "searchDate";
            this.searchDate.Size = new System.Drawing.Size(193, 22);
            this.searchDate.TabIndex = 6;
            this.searchDate.Value = null;
            // 
            // lblAccountHolderName
            // 
            this.lblAccountHolderName.AutoEllipsis = true;
            this.lblAccountHolderName.AutoSize = true;
            this.lblAccountHolderName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAccountHolderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountHolderName.ForeColor = System.Drawing.Color.White;
            this.lblAccountHolderName.Location = new System.Drawing.Point(10, 27);
            this.lblAccountHolderName.Name = "lblAccountHolderName";
            this.lblAccountHolderName.Size = new System.Drawing.Size(64, 25);
            this.lblAccountHolderName.TabIndex = 2;
            this.lblAccountHolderName.Text = "Name";
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = true;
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBack.Location = new System.Drawing.Point(10, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(39, 17);
            this.btnBack.TabIndex = 3;
            this.btnBack.TabStop = true;
            this.btnBack.Text = "Back";
            // 
            // FinancialTransactionActionPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblAccountHolderName);
            this.Controls.Add(this.btnBack);
            this.Name = "FinancialTransactionActionPane";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "PatientVisitActionPane";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelTransactionDetails.ResumeLayout(false);
            this.panelTransactionDetails.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnRemoveTransaction;
        private System.Windows.Forms.Button btnAddTransaction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAccountHolderName;
        private NullableDateTimePicker.NullableDateTimePicker searchDate;
        private System.Windows.Forms.Panel panelTransactionDetails;
        private System.Windows.Forms.Button btnUpdateTransaction;
        private System.Windows.Forms.Label lblDateOfVisit;
        private System.Windows.Forms.LinkLabel btnBack;
    }
}