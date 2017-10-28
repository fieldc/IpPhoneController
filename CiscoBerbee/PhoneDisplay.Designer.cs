namespace CiscoBerbee
{
	partial class PhoneDisplay
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
            this.phoneTabs = new System.Windows.Forms.TabControl();
            this.phoneDisplayTab = new System.Windows.Forms.TabPage();
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.macroGroupBox = new System.Windows.Forms.GroupBox();
            this.executeMacro = new System.Windows.Forms.Button();
            this.macroText = new System.Windows.Forms.TextBox();
            this.phoneInfoTab = new System.Windows.Forms.TabPage();
            this.ethernetInformationBox = new System.Windows.Forms.GroupBox();
            this.txtEthernetInformation = new System.Windows.Forms.TextBox();
            this.refreshMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.streamStatisticsBox = new System.Windows.Forms.GroupBox();
            this.streams = new System.Windows.Forms.TabControl();
            this.portInformationBox = new System.Windows.Forms.GroupBox();
            this.ports = new System.Windows.Forms.TabControl();
            this.networkConfigurationBox = new System.Windows.Forms.GroupBox();
            this.txtNetworkInformation = new System.Windows.Forms.TextBox();
            this.deviceGroupBox = new System.Windows.Forms.GroupBox();
            this.txtDeviceInformation = new System.Windows.Forms.TextBox();
            this.phoneTabs.SuspendLayout();
            this.phoneDisplayTab.SuspendLayout();
            this.tableLayout.SuspendLayout();
            this.macroGroupBox.SuspendLayout();
            this.phoneInfoTab.SuspendLayout();
            this.ethernetInformationBox.SuspendLayout();
            this.refreshMenu.SuspendLayout();
            this.streamStatisticsBox.SuspendLayout();
            this.portInformationBox.SuspendLayout();
            this.networkConfigurationBox.SuspendLayout();
            this.deviceGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // phoneTabs
            // 
            this.phoneTabs.Controls.Add(this.phoneDisplayTab);
            this.phoneTabs.Controls.Add(this.phoneInfoTab);
            this.phoneTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.phoneTabs.Location = new System.Drawing.Point(0, 0);
            this.phoneTabs.Name = "phoneTabs";
            this.phoneTabs.SelectedIndex = 0;
            this.phoneTabs.Size = new System.Drawing.Size(792, 696);
            this.phoneTabs.TabIndex = 0;
            // 
            // phoneDisplayTab
            // 
            this.phoneDisplayTab.BackColor = System.Drawing.Color.White;
            this.phoneDisplayTab.Controls.Add(this.tableLayout);
            this.phoneDisplayTab.Location = new System.Drawing.Point(4, 22);
            this.phoneDisplayTab.Name = "phoneDisplayTab";
            this.phoneDisplayTab.Padding = new System.Windows.Forms.Padding(3);
            this.phoneDisplayTab.Size = new System.Drawing.Size(784, 670);
            this.phoneDisplayTab.TabIndex = 0;
            this.phoneDisplayTab.Text = "Phone Display";
            this.phoneDisplayTab.UseVisualStyleBackColor = true;
            // 
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 1;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.Controls.Add(this.macroGroupBox, 0, 1);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(3, 3);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 2;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.32492F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.675078F));
            this.tableLayout.Size = new System.Drawing.Size(778, 664);
            this.tableLayout.TabIndex = 0;
            // 
            // macroGroupBox
            // 
            this.macroGroupBox.Controls.Add(this.executeMacro);
            this.macroGroupBox.Controls.Add(this.macroText);
            this.macroGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.macroGroupBox.Location = new System.Drawing.Point(3, 609);
            this.macroGroupBox.Name = "macroGroupBox";
            this.macroGroupBox.Size = new System.Drawing.Size(772, 52);
            this.macroGroupBox.TabIndex = 0;
            this.macroGroupBox.TabStop = false;
            this.macroGroupBox.Text = "Control Macro";
            // 
            // executeMacro
            // 
            this.executeMacro.Location = new System.Drawing.Point(684, 19);
            this.executeMacro.Name = "executeMacro";
            this.executeMacro.Size = new System.Drawing.Size(82, 23);
            this.executeMacro.TabIndex = 1;
            this.executeMacro.Text = "Send Macro";
            this.executeMacro.UseVisualStyleBackColor = true;
            this.executeMacro.Click += new System.EventHandler(this.executeMacro_Click);
            // 
            // macroText
            // 
            this.macroText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macroText.Location = new System.Drawing.Point(20, 19);
            this.macroText.Name = "macroText";
            this.macroText.Size = new System.Drawing.Size(658, 26);
            this.macroText.TabIndex = 0;
            // 
            // phoneInfoTab
            // 
            this.phoneInfoTab.BackColor = System.Drawing.Color.White;
            this.phoneInfoTab.Controls.Add(this.ethernetInformationBox);
            this.phoneInfoTab.Controls.Add(this.streamStatisticsBox);
            this.phoneInfoTab.Controls.Add(this.portInformationBox);
            this.phoneInfoTab.Controls.Add(this.networkConfigurationBox);
            this.phoneInfoTab.Controls.Add(this.deviceGroupBox);
            this.phoneInfoTab.Location = new System.Drawing.Point(4, 22);
            this.phoneInfoTab.Name = "phoneInfoTab";
            this.phoneInfoTab.Padding = new System.Windows.Forms.Padding(3);
            this.phoneInfoTab.Size = new System.Drawing.Size(784, 670);
            this.phoneInfoTab.TabIndex = 1;
            this.phoneInfoTab.Text = "Phone Information";
            this.phoneInfoTab.UseVisualStyleBackColor = true;
            // 
            // ethernetInformationBox
            // 
            this.ethernetInformationBox.Controls.Add(this.txtEthernetInformation);
            this.ethernetInformationBox.Location = new System.Drawing.Point(9, 281);
            this.ethernetInformationBox.Name = "ethernetInformationBox";
            this.ethernetInformationBox.Size = new System.Drawing.Size(765, 117);
            this.ethernetInformationBox.TabIndex = 5;
            this.ethernetInformationBox.TabStop = false;
            this.ethernetInformationBox.Text = "Ethernet Information";
            // 
            // txtEthernetInformation
            // 
            this.txtEthernetInformation.ContextMenuStrip = this.refreshMenu;
            this.txtEthernetInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEthernetInformation.Location = new System.Drawing.Point(3, 16);
            this.txtEthernetInformation.Multiline = true;
            this.txtEthernetInformation.Name = "txtEthernetInformation";
            this.txtEthernetInformation.ReadOnly = true;
            this.txtEthernetInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEthernetInformation.Size = new System.Drawing.Size(759, 98);
            this.txtEthernetInformation.TabIndex = 0;
            // 
            // refreshMenu
            // 
            this.refreshMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.refreshMenu.Name = "refreshMenu";
            this.refreshMenu.Size = new System.Drawing.Size(124, 26);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.refreshToolStripMenuItem.Text = "&Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // streamStatisticsBox
            // 
            this.streamStatisticsBox.Controls.Add(this.streams);
            this.streamStatisticsBox.Location = new System.Drawing.Point(394, 404);
            this.streamStatisticsBox.Name = "streamStatisticsBox";
            this.streamStatisticsBox.Size = new System.Drawing.Size(380, 228);
            this.streamStatisticsBox.TabIndex = 3;
            this.streamStatisticsBox.TabStop = false;
            this.streamStatisticsBox.Text = "Stream Statistics";
            // 
            // streams
            // 
            this.streams.ContextMenuStrip = this.refreshMenu;
            this.streams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.streams.Location = new System.Drawing.Point(3, 16);
            this.streams.Name = "streams";
            this.streams.SelectedIndex = 0;
            this.streams.Size = new System.Drawing.Size(374, 209);
            this.streams.TabIndex = 0;
            // 
            // portInformationBox
            // 
            this.portInformationBox.Controls.Add(this.ports);
            this.portInformationBox.Location = new System.Drawing.Point(9, 404);
            this.portInformationBox.Name = "portInformationBox";
            this.portInformationBox.Size = new System.Drawing.Size(380, 228);
            this.portInformationBox.TabIndex = 2;
            this.portInformationBox.TabStop = false;
            this.portInformationBox.Text = "Port Information";
            // 
            // ports
            // 
            this.ports.ContextMenuStrip = this.refreshMenu;
            this.ports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ports.Location = new System.Drawing.Point(3, 16);
            this.ports.Name = "ports";
            this.ports.SelectedIndex = 0;
            this.ports.Size = new System.Drawing.Size(374, 209);
            this.ports.TabIndex = 0;
            // 
            // networkConfigurationBox
            // 
            this.networkConfigurationBox.Controls.Add(this.txtNetworkInformation);
            this.networkConfigurationBox.Location = new System.Drawing.Point(9, 94);
            this.networkConfigurationBox.Name = "networkConfigurationBox";
            this.networkConfigurationBox.Size = new System.Drawing.Size(765, 180);
            this.networkConfigurationBox.TabIndex = 1;
            this.networkConfigurationBox.TabStop = false;
            this.networkConfigurationBox.Text = "Network Configuration";
            // 
            // txtNetworkInformation
            // 
            this.txtNetworkInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNetworkInformation.Location = new System.Drawing.Point(3, 16);
            this.txtNetworkInformation.Multiline = true;
            this.txtNetworkInformation.Name = "txtNetworkInformation";
            this.txtNetworkInformation.ReadOnly = true;
            this.txtNetworkInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNetworkInformation.Size = new System.Drawing.Size(759, 161);
            this.txtNetworkInformation.TabIndex = 0;
            // 
            // deviceGroupBox
            // 
            this.deviceGroupBox.Controls.Add(this.txtDeviceInformation);
            this.deviceGroupBox.Location = new System.Drawing.Point(9, 6);
            this.deviceGroupBox.Name = "deviceGroupBox";
            this.deviceGroupBox.Size = new System.Drawing.Size(765, 82);
            this.deviceGroupBox.TabIndex = 0;
            this.deviceGroupBox.TabStop = false;
            this.deviceGroupBox.Text = "Device Information";
            // 
            // txtDeviceInformation
            // 
            this.txtDeviceInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDeviceInformation.Location = new System.Drawing.Point(3, 16);
            this.txtDeviceInformation.Multiline = true;
            this.txtDeviceInformation.Name = "txtDeviceInformation";
            this.txtDeviceInformation.ReadOnly = true;
            this.txtDeviceInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDeviceInformation.Size = new System.Drawing.Size(759, 63);
            this.txtDeviceInformation.TabIndex = 0;
            // 
            // PhoneDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 696);
            this.Controls.Add(this.phoneTabs);
            this.Name = "PhoneDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhoneDisplay";
            this.phoneTabs.ResumeLayout(false);
            this.phoneDisplayTab.ResumeLayout(false);
            this.tableLayout.ResumeLayout(false);
            this.macroGroupBox.ResumeLayout(false);
            this.macroGroupBox.PerformLayout();
            this.phoneInfoTab.ResumeLayout(false);
            this.ethernetInformationBox.ResumeLayout(false);
            this.ethernetInformationBox.PerformLayout();
            this.refreshMenu.ResumeLayout(false);
            this.streamStatisticsBox.ResumeLayout(false);
            this.portInformationBox.ResumeLayout(false);
            this.networkConfigurationBox.ResumeLayout(false);
            this.networkConfigurationBox.PerformLayout();
            this.deviceGroupBox.ResumeLayout(false);
            this.deviceGroupBox.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabPage phoneDisplayTab;
		private System.Windows.Forms.TabPage phoneInfoTab;
		public System.Windows.Forms.TabControl phoneTabs;
		private System.Windows.Forms.GroupBox streamStatisticsBox;
		private System.Windows.Forms.GroupBox portInformationBox;
		private System.Windows.Forms.TabControl ports;
		private System.Windows.Forms.GroupBox networkConfigurationBox;
		private System.Windows.Forms.GroupBox deviceGroupBox;
		private System.Windows.Forms.GroupBox ethernetInformationBox;
		private System.Windows.Forms.TabControl streams;
		private System.Windows.Forms.TextBox txtDeviceInformation;
		private System.Windows.Forms.TextBox txtNetworkInformation;
		private System.Windows.Forms.TextBox txtEthernetInformation;
		private System.Windows.Forms.TableLayoutPanel tableLayout;
		private System.Windows.Forms.GroupBox macroGroupBox;
		private System.Windows.Forms.Button executeMacro;
		private System.Windows.Forms.TextBox macroText;
		private System.Windows.Forms.ContextMenuStrip refreshMenu;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
	}
}