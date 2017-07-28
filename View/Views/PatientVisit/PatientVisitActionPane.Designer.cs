namespace View.Views.PatientVisit
{
    partial class PatientVisitActionPane
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
            this.panelPatientVisitDetails = new System.Windows.Forms.Panel();
            this.btnUpdatePatientVisit = new System.Windows.Forms.Button();
            this.lblDateOfVisit = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRemovePatientVisit = new System.Windows.Forms.Button();
            this.btnAddPatientVisit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.searchDate = new NullableDateTimePicker.NullableDateTimePicker();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.btnBackToPatients = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.panelPatientVisitDetails.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelPatientVisitDetails);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 191);
            this.panel1.TabIndex = 1;
            // 
            // panelPatientVisitDetails
            // 
            this.panelPatientVisitDetails.AutoSize = true;
            this.panelPatientVisitDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelPatientVisitDetails.Controls.Add(this.btnUpdatePatientVisit);
            this.panelPatientVisitDetails.Controls.Add(this.lblDateOfVisit);
            this.panelPatientVisitDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPatientVisitDetails.Location = new System.Drawing.Point(0, 94);
            this.panelPatientVisitDetails.Name = "panelPatientVisitDetails";
            this.panelPatientVisitDetails.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.panelPatientVisitDetails.Size = new System.Drawing.Size(262, 65);
            this.panelPatientVisitDetails.TabIndex = 7;
            // 
            // btnUpdatePatientVisit
            // 
            this.btnUpdatePatientVisit.AutoSize = true;
            this.btnUpdatePatientVisit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdatePatientVisit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUpdatePatientVisit.Location = new System.Drawing.Point(3, 35);
            this.btnUpdatePatientVisit.Name = "btnUpdatePatientVisit";
            this.btnUpdatePatientVisit.Size = new System.Drawing.Size(256, 27);
            this.btnUpdatePatientVisit.TabIndex = 3;
            this.btnUpdatePatientVisit.Text = "Update Info";
            this.btnUpdatePatientVisit.UseVisualStyleBackColor = true;
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
            this.tableLayoutPanel1.Controls.Add(this.btnRemovePatientVisit, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAddPatientVisit, 0, 2);
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
            // btnRemovePatientVisit
            // 
            this.btnRemovePatientVisit.AutoSize = true;
            this.btnRemovePatientVisit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.btnRemovePatientVisit, 2);
            this.btnRemovePatientVisit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRemovePatientVisit.Location = new System.Drawing.Point(3, 64);
            this.btnRemovePatientVisit.Name = "btnRemovePatientVisit";
            this.btnRemovePatientVisit.Size = new System.Drawing.Size(256, 27);
            this.btnRemovePatientVisit.TabIndex = 5;
            this.btnRemovePatientVisit.Text = "Remove PatientVisit";
            this.btnRemovePatientVisit.UseVisualStyleBackColor = true;
            // 
            // btnAddPatientVisit
            // 
            this.btnAddPatientVisit.AutoSize = true;
            this.btnAddPatientVisit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.btnAddPatientVisit, 2);
            this.btnAddPatientVisit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddPatientVisit.Location = new System.Drawing.Point(3, 31);
            this.btnAddPatientVisit.Name = "btnAddPatientVisit";
            this.btnAddPatientVisit.Size = new System.Drawing.Size(256, 27);
            this.btnAddPatientVisit.TabIndex = 4;
            this.btnAddPatientVisit.Text = "Add PatientVisit";
            this.btnAddPatientVisit.UseVisualStyleBackColor = true;
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
            // lblPatientName
            // 
            this.lblPatientName.AutoEllipsis = true;
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPatientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientName.ForeColor = System.Drawing.Color.White;
            this.lblPatientName.Location = new System.Drawing.Point(10, 27);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(64, 25);
            this.lblPatientName.TabIndex = 2;
            this.lblPatientName.Text = "Name";
            // 
            // btnBackToPatients
            // 
            this.btnBackToPatients.AutoSize = true;
            this.btnBackToPatients.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBackToPatients.Location = new System.Drawing.Point(10, 10);
            this.btnBackToPatients.Name = "btnBackToPatients";
            this.btnBackToPatients.Size = new System.Drawing.Size(39, 17);
            this.btnBackToPatients.TabIndex = 3;
            this.btnBackToPatients.TabStop = true;
            this.btnBackToPatients.Text = "Back";
            // 
            // PatientVisitActionPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.btnBackToPatients);
            this.Name = "PatientVisitActionPane";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "PatientVisitActionPane";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelPatientVisitDetails.ResumeLayout(false);
            this.panelPatientVisitDetails.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnRemovePatientVisit;
        private System.Windows.Forms.Button btnAddPatientVisit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPatientName;
        private NullableDateTimePicker.NullableDateTimePicker searchDate;
        private System.Windows.Forms.Panel panelPatientVisitDetails;
        private System.Windows.Forms.Button btnUpdatePatientVisit;
        private System.Windows.Forms.Label lblDateOfVisit;
        private System.Windows.Forms.LinkLabel btnBackToPatients;
    }
}