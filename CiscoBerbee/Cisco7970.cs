using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Net;


namespace CiscoBerbee
{
	public partial class Cisco7970 : PhoneController
	{
		public Cisco7970() { ; }

		public Cisco7970(string phoneIp, string userName, string password)
			: base(phoneIp, userName, password)
		{
			InitializeComponent();

			this.screenRefreshTimer.Tick += new EventHandler(screenRefreshTimer_Tick);
			this.screenRefreshTimer.Interval = 2000;
			this.screenRefreshTimer.Enabled = true;
			this.screenRefreshTimer.Start();
			this.RefreshScreenShot();

			this.closeButton.Click += new EventHandler(closeButton_Click);
			this.KeyDown += new KeyEventHandler(PhoneController_KeyDown);

			this.keyPad1Button.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.keyPad2Button.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.keyPad3Button.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.keyPad4Button.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.keyPad5Button.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.keyPad6Button.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.keyPad7Button.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.keyPad8Button.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.keyPad9Button.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.keyPad0Button.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.keyPadPoundButton.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.keyPadStarButton.Click += new System.EventHandler(this.KeyPadButton_Click);


			this.line1Button.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.line2Button.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.line3Button.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.line4Button.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.line5Button.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.line6Button.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.line7button.Click +=new EventHandler(this.KeyPadButton_Click);
			this.line8Button.Click +=new EventHandler(this.KeyPadButton_Click);

			this.soft1Button.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.soft2Button.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.soft3Button.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.soft4Button.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.soft5Button.Click +=new EventHandler(this.KeyPadButton_Click);

			this.navUpButton.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.navDownButton.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.navLeftButton.Click += new EventHandler(this.KeyPadButton_Click);
			this.navRightButton.Click += new EventHandler(this.KeyPadButton_Click);

			this.infoButton.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.servicesButton.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.messagesButton.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.directoryButton.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.settingsButton.Click += new System.EventHandler(this.KeyPadButton_Click);

			this.speakerButton.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.muteButton.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.headsetButton.Click += new System.EventHandler(this.KeyPadButton_Click);
			
			this.voldownButton.Click += new System.EventHandler(this.KeyPadButton_Click);
			this.volupButton.Click += new System.EventHandler(this.KeyPadButton_Click);
		}

		private void KeyPadButton_Click(object sender, EventArgs e)
		{
			this.KeyPadButtonEvent(sender, e);
			this.RefreshScreenShot();
		}

		void closeButton_Click(object sender, EventArgs e)
		{
			this.ParentForm.Close();
		}


		void screenRefreshTimer_Tick(object sender, EventArgs e)
		{
			this.RefreshScreenShot();
		}

        
		public override void RefreshScreenShot()
		{
			AsyncCallback cb = new AsyncCallback(GetScreenShotAsynCallBack);
			Object state = new Object();
			this.getPhoneImageDelegate.BeginInvoke(cb, state);
		}

		private void GetScreenShotAsynCallBack(IAsyncResult ar)
		{
			
			if (ar != null)
			{
				GetPhoneImage gpi = (GetPhoneImage)((AsyncResult)ar).AsyncDelegate;
				Bitmap answer = gpi.EndInvoke(ar);
				if (answer != null) //we can fail to get the image
				{

					this.screenShotBox.Image = answer; //CipImage.FromStream(answer).ToBitmap();
				}
			}
			return;
		}

		private void listenButton_Click(object sender, EventArgs e)
		{
			IPEndPoint ep = new IPEndPoint(IPAddress.Parse("172.31.180.26"), 32002);
			
			listen.StartListening(new IPEndPoint(IPAddress.Parse(this.phoneIp), 32002));
			this.StartStreaming(ep);
			
		}

		private void stopListeningButton_Click(object sender, EventArgs e)
		{
			this.StopStreaming();
			listen.StopListening();
		}
	}
}
