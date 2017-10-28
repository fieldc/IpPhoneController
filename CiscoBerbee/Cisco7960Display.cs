using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace CiscoBerbee
{

	public partial class Cisco7960Display : PhoneController
	{
		
		
		private CipImage currentScreen;
		

		

		public Cisco7960Display(string phoneIp, string userName,string password) : base(phoneIp, userName,password)
		{
			
			InitializeComponent();
			credentials = new NetworkCredential(this.userName, this.password);
	
			this.screenRefreshTimer.Tick += new EventHandler(screenRefreshTimer_Tick);
			this.screenRefreshTimer.Interval = 3000;
			this.screenRefreshTimer.Enabled = true;
			this.screenRefreshTimer.Start();
			this.RefreshScreenShot();
			
		}

	

		void screenRefreshTimer_Tick(object sender, EventArgs e)
		{
			this.RefreshScreenShot();
		}

		private void keypadButton_Click(object sender, EventArgs e)
		{
			string toSend = (string)((PictureBox)sender).Tag;
			SendButton(toSend);
			
		}

		

		

	}
}
