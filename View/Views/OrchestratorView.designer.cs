namespace View.Views
{
    partial class OrchestratorView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrchestratorView));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.actionPaneContainer = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.viewContainer = new System.Windows.Forms.SplitContainer();
            this.panelMaster = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblMasterCaption = new System.Windows.Forms.Label();
            this.toolStripMaster = new System.Windows.Forms.ToolStrip();
            this.btnFullScreenMaster = new System.Windows.Forms.ToolStripButton();
            this.detailsTabCollection = new System.Windows.Forms.TabControl();
            this.toolStripDetails = new System.Windows.Forms.ToolStrip();
            this.btnFullScreenDetails = new System.Windows.Forms.ToolStripButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelActionPane = new System.Windows.Forms.Panel();
            this.navigationContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnPatients = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.actionPaneContainer)).BeginInit();
            this.actionPaneContainer.Panel1.SuspendLayout();
            this.actionPaneContainer.Panel2.SuspendLayout();
            this.actionPaneContainer.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewContainer)).BeginInit();
            this.viewContainer.Panel1.SuspendLayout();
            this.viewContainer.Panel2.SuspendLayout();
            this.viewContainer.SuspendLayout();
            this.toolStripMaster.SuspendLayout();
            this.toolStripDetails.SuspendLayout();
            this.panel4.SuspendLayout();
            this.navigationContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "125_FullView_48x48_72.png");
            this.imageList1.Images.SetKeyName(1, "SelectCurrentRegion.png");
            this.imageList1.Images.SetKeyName(2, "imageSplitScreen");
            this.imageList1.Images.SetKeyName(3, "imageFullScreen");
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 494);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1101, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // actionPaneContainer
            // 
            this.actionPaneContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionPaneContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.actionPaneContainer.Location = new System.Drawing.Point(0, 31);
            this.actionPaneContainer.Name = "actionPaneContainer";
            // 
            // actionPaneContainer.Panel1
            // 
            this.actionPaneContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.actionPaneContainer.Panel1.Controls.Add(this.panel2);
            this.actionPaneContainer.Panel1.Padding = new System.Windows.Forms.Padding(50);
            // 
            // actionPaneContainer.Panel2
            // 
            this.actionPaneContainer.Panel2.Controls.Add(this.panel4);
            this.actionPaneContainer.Size = new System.Drawing.Size(1101, 463);
            this.actionPaneContainer.SplitterDistance = 897;
            this.actionPaneContainer.SplitterWidth = 2;
            this.actionPaneContainer.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.viewContainer);
            this.panel2.Controls.Add(this.lblMasterCaption);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(50, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(797, 363);
            this.panel2.TabIndex = 2;
            // 
            // viewContainer
            // 
            this.viewContainer.BackColor = System.Drawing.SystemColors.Control;
            this.viewContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewContainer.Location = new System.Drawing.Point(0, 35);
            this.viewContainer.Name = "viewContainer";
            // 
            // viewContainer.Panel1
            // 
            this.viewContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.viewContainer.Panel1.Controls.Add(this.panelMaster);
            this.viewContainer.Panel1.Controls.Add(this.panel3);
            this.viewContainer.Panel1.Controls.Add(this.toolStripMaster);
            // 
            // viewContainer.Panel2
            // 
            this.viewContainer.Panel2.BackColor = System.Drawing.Color.White;
            this.viewContainer.Panel2.Controls.Add(this.detailsTabCollection);
            this.viewContainer.Panel2.Controls.Add(this.toolStripDetails);
            this.viewContainer.Size = new System.Drawing.Size(797, 328);
            this.viewContainer.SplitterDistance = 430;
            this.viewContainer.SplitterWidth = 5;
            this.viewContainer.TabIndex = 4;
            // 
            // panelMaster
            // 
            this.panelMaster.BackColor = System.Drawing.Color.White;
            this.panelMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMaster.Location = new System.Drawing.Point(0, 0);
            this.panelMaster.Name = "panelMaster";
            this.panelMaster.Padding = new System.Windows.Forms.Padding(3);
            this.panelMaster.Size = new System.Drawing.Size(430, 301);
            this.panelMaster.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(430, 0);
            this.panel3.TabIndex = 0;
            // 
            // lblMasterCaption
            // 
            this.lblMasterCaption.AutoEllipsis = true;
            this.lblMasterCaption.AutoSize = true;
            this.lblMasterCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMasterCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMasterCaption.Location = new System.Drawing.Point(0, 0);
            this.lblMasterCaption.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lblMasterCaption.Name = "lblMasterCaption";
            this.lblMasterCaption.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.lblMasterCaption.Size = new System.Drawing.Size(145, 35);
            this.lblMasterCaption.TabIndex = 1;
            this.lblMasterCaption.Text = "Master Caption";
            // 
            // toolStripMaster
            // 
            this.toolStripMaster.BackColor = System.Drawing.Color.White;
            this.toolStripMaster.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripMaster.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMaster.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMaster.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFullScreenMaster});
            this.toolStripMaster.Location = new System.Drawing.Point(0, 301);
            this.toolStripMaster.Name = "toolStripMaster";
            this.toolStripMaster.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripMaster.Size = new System.Drawing.Size(430, 27);
            this.toolStripMaster.TabIndex = 1;
            this.toolStripMaster.Text = "toolStrip2";
            // 
            // btnFullScreenMaster
            // 
            this.btnFullScreenMaster.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnFullScreenMaster.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFullScreenMaster.Image = ((System.Drawing.Image)(resources.GetObject("btnFullScreenMaster.Image")));
            this.btnFullScreenMaster.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFullScreenMaster.Name = "btnFullScreenMaster";
            this.btnFullScreenMaster.Size = new System.Drawing.Size(24, 24);
            this.btnFullScreenMaster.Text = "toolStripButton1";
            this.btnFullScreenMaster.ToolTipText = "Full screen";
            // 
            // detailsTabCollection
            // 
            this.detailsTabCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsTabCollection.Location = new System.Drawing.Point(0, 0);
            this.detailsTabCollection.Margin = new System.Windows.Forms.Padding(0);
            this.detailsTabCollection.Name = "detailsTabCollection";
            this.detailsTabCollection.SelectedIndex = 0;
            this.detailsTabCollection.Size = new System.Drawing.Size(362, 301);
            this.detailsTabCollection.TabIndex = 0;
            // 
            // toolStripDetails
            // 
            this.toolStripDetails.BackColor = System.Drawing.Color.White;
            this.toolStripDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripDetails.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripDetails.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFullScreenDetails});
            this.toolStripDetails.Location = new System.Drawing.Point(0, 301);
            this.toolStripDetails.Name = "toolStripDetails";
            this.toolStripDetails.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripDetails.Size = new System.Drawing.Size(362, 27);
            this.toolStripDetails.TabIndex = 0;
            this.toolStripDetails.Text = "toolStrip1";
            // 
            // btnFullScreenDetails
            // 
            this.btnFullScreenDetails.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnFullScreenDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFullScreenDetails.Image = ((System.Drawing.Image)(resources.GetObject("btnFullScreenDetails.Image")));
            this.btnFullScreenDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFullScreenDetails.Name = "btnFullScreenDetails";
            this.btnFullScreenDetails.Size = new System.Drawing.Size(24, 24);
            this.btnFullScreenDetails.Text = "toolStripButton1";
            this.btnFullScreenDetails.ToolTipText = "Full screen";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.panelActionPane);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(10);
            this.panel4.Size = new System.Drawing.Size(202, 463);
            this.panel4.TabIndex = 0;
            // 
            // panelActionPane
            // 
            this.panelActionPane.BackColor = System.Drawing.Color.LightSlateGray;
            this.panelActionPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelActionPane.Location = new System.Drawing.Point(10, 10);
            this.panelActionPane.Name = "panelActionPane";
            this.panelActionPane.Size = new System.Drawing.Size(180, 441);
            this.panelActionPane.TabIndex = 3;
            // 
            // navigationContainer
            // 
            this.navigationContainer.AutoSize = true;
            this.navigationContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.navigationContainer.Controls.Add(this.btnHome);
            this.navigationContainer.Controls.Add(this.btnPatients);
            this.navigationContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.navigationContainer.Location = new System.Drawing.Point(0, 0);
            this.navigationContainer.Name = "navigationContainer";
            this.navigationContainer.Size = new System.Drawing.Size(1101, 31);
            this.navigationContainer.TabIndex = 3;
            this.navigationContainer.WrapContents = false;
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(3, 3);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(75, 23);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // btnPatients
            // 
            this.btnPatients.Location = new System.Drawing.Point(84, 3);
            this.btnPatients.Name = "btnPatients";
            this.btnPatients.Size = new System.Drawing.Size(75, 23);
            this.btnPatients.TabIndex = 1;
            this.btnPatients.Text = "Patients";
            this.btnPatients.UseVisualStyleBackColor = true;
            // 
            // OrchestratorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 516);
            this.Controls.Add(this.actionPaneContainer);
            this.Controls.Add(this.navigationContainer);
            this.Controls.Add(this.statusStrip1);
            this.Name = "OrchestratorView";
            this.Text = "Form1";
            this.actionPaneContainer.Panel1.ResumeLayout(false);
            this.actionPaneContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.actionPaneContainer)).EndInit();
            this.actionPaneContainer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.viewContainer.Panel1.ResumeLayout(false);
            this.viewContainer.Panel1.PerformLayout();
            this.viewContainer.Panel2.ResumeLayout(false);
            this.viewContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewContainer)).EndInit();
            this.viewContainer.ResumeLayout(false);
            this.toolStripMaster.ResumeLayout(false);
            this.toolStripMaster.PerformLayout();
            this.toolStripDetails.ResumeLayout(false);
            this.toolStripDetails.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.navigationContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer actionPaneContainer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer viewContainer;
        private System.Windows.Forms.Panel panelMaster;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblMasterCaption;
        private System.Windows.Forms.ToolStrip toolStripMaster;
        private System.Windows.Forms.ToolStripButton btnFullScreenMaster;
        private System.Windows.Forms.TabControl detailsTabCollection;
        private System.Windows.Forms.ToolStrip toolStripDetails;
        private System.Windows.Forms.ToolStripButton btnFullScreenDetails;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panelActionPane;
        private System.Windows.Forms.FlowLayoutPanel navigationContainer;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnPatients;
    }
}