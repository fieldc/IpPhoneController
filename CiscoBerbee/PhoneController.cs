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
using System.Media;


namespace CiscoBerbee
{
	public class PhoneController : UserControl
	{
		protected string phoneIp;
		protected string userName;
		protected string password;
		protected NetworkCredential credentials;

		protected object phoneLock;
		protected int currProcessingCount;
		protected HttpWebRequest buttonRequest;

		protected delegate Bitmap GetPhoneImage();
		protected GetPhoneImage getPhoneImageDelegate;
		protected HttpWebRequest screenShotRequest;
		protected StreamListener listen;

		public PhoneController() {;} //for designer
		public PhoneController(string phoneIp, string userName, string password)
		{
			currProcessingCount = 0;
			this.phoneLock = new object();
			this.phoneIp = phoneIp;
			this.userName = userName;
			this.password = password;
			credentials = new NetworkCredential(userName, password);
			listen = new StreamListener();

			this.getPhoneImageDelegate = new GetPhoneImage(GetScreenShotFromPhone);
			//this.ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);	
			
		}

		protected void PhoneController_KeyDown(object sender, KeyEventArgs e)
		{
			string keyCode="";

			switch (e.KeyCode)
			{
				case Keys.D0:
					keyCode = "KeyPad0";
					break;
				case Keys.D1:
					keyCode = "KeyPad1";
					break;
				case Keys.D2:
					keyCode = "KeyPad2";
					break;
				case Keys.D3:
					if (e.Shift)
					{
						keyCode = "KeyPadPound";
					}
					else
					{
						keyCode = "KeyPad3";
					}
					break;
				case Keys.D4:
					keyCode = "KeyPad4";
					break;
				case Keys.D5:
					keyCode = "KeyPad5";
					break;
				case Keys.D6:
					keyCode = "KeyPad6";
					break;
				case Keys.D7:
					keyCode = "KeyPad7";
					break;
				case Keys.D8:
					if (e.Shift)
					{
						keyCode = "KeyPadStar";
					}
					else
					{
						keyCode = "KeyPad8";
					}
					break;
				case Keys.D9:
					keyCode = "KeyPad9";
					break;
				case Keys.NumPad0 :
					keyCode = "KeyPad0";
					break;
				case Keys.NumPad1:
					keyCode = "KeyPad1";
					break;
				case Keys.NumPad2:
					keyCode = "KeyPad2";
					break;
				case Keys.NumPad3:
					keyCode = "KeyPad3";
					break;
				case Keys.NumPad4:
					keyCode = "KeyPad4";
					break;
				case Keys.NumPad5:
					keyCode = "KeyPad5";
					break;
				case Keys.NumPad6:
					keyCode = "KeyPad6";
					break;
				case Keys.NumPad7:
					keyCode = "KeyPad7";
					break;
				case Keys.NumPad8:
					keyCode = "KeyPad8";
					break;
				case Keys.NumPad9:
					keyCode = "KeyPad9";
					break;
				case Keys.Multiply:
					keyCode = "KeyPadStar";
					break;
				case Keys.Divide:
					keyCode = "KeyPadPound";
					break;
				case Keys.Down:
					keyCode = "NavDwn";
					break;
				case Keys.Up:
					keyCode = "NavUp";
					break;
				case Keys.Left:
					keyCode = "NavLeft";
					break;
				case Keys.Right:
					keyCode = "NavRight";
					break;
				
			}
			SendButton(keyCode);
		}

		protected void KeyPadButtonEvent(object sender, EventArgs e)
		{
			string toSend = (string)((PictureBox)sender).Tag;
			SendButton(toSend);
		}
        
		public void SendMacroSring(string macro)
		{
			string[] items = macro.ToUpper().Split(new char[1] { ',' });
			foreach (string key in items)
			{
				switch (key)
				{
					case "SK1":
						this.SendButton("Soft1");
					break;
					case "SK2":
						this.SendButton("Soft2");
					break;
					case "SK3":
						this.SendButton("Soft3");
					break;
					case "SK4":
						this.SendButton("Soft4");
					break;
					case "SK5":
						this.SendButton("Soft5");
					break;
					case "BSER":
						this.SendButton("Services");
					break;
					case "BSET":
						this.SendButton("Settings");
					break;
					case "BMSG":
						this.SendButton("Messages");
					break;
					case "BDIR":
						this.SendButton("Directories");
					break;
					case ".":
						Thread.Sleep(500);
					break;
					case "*":
						this.SendButton("KeyPadStar");
					break;
					case "#":
						this.SendButton("KeyPadPound");
					break;

					default:
						int tst;
						if (Int32.TryParse(key,out tst))
						{
							foreach (char keyCode in key.ToCharArray())
							{
								int keyNum = Int32.Parse(keyCode.ToString());
								if (keyNum >= 0 && keyNum <= 9)
								{
									this.SendButton("KeyPad" + keyNum.ToString());
								}
							}
						}
						else
						{
							MessageBox.Show("Failed: " + key);
						}
					break;

				}
			}
		}

		void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				this.screenShotRequest.Abort();
				this.buttonRequest.Abort();
			}
			catch
			{
				;//we dont' care abt interupted requests
			}
		}
		
		protected Bitmap GetScreenShotFromPhone()
		{
			MemoryStream ms = new MemoryStream();
			if (currProcessingCount == 0)
			{
				lock (this.phoneLock)
				{
					try
					{
						++currProcessingCount;
						screenShotRequest = (HttpWebRequest)HttpWebRequest.Create("http://" + this.phoneIp + "/CGI/Screenshot");
						screenShotRequest.KeepAlive = true;
						screenShotRequest.PreAuthenticate = true;
						screenShotRequest.Credentials = credentials;
						WebResponse response = screenShotRequest.GetResponse();
						if (!response.ContentType.ToLower().Contains("image/bmp"))
						{
							byte[] buffer = new byte[4096];
							int readBytes = 0;
							Stream readFrom = response.GetResponseStream();
							while ((readBytes = readFrom.Read(buffer, 0, buffer.Length)) != 0)
							{
								ms.Write(buffer, 0, readBytes);
							}
							response.Close();
							ms.Position = 0;
							return CipImage.FromStream(ms).ToBitmap();
						}
						else
						{
							return (Bitmap)Bitmap.FromStream(response.GetResponseStream());
						}
					}
					catch (WebException e)
					{
						MessageBox.Show(e.Message);
					}
					catch { ;}
					finally
					{
						--currProcessingCount;
					}
				}
				return (Bitmap)null;
			}
			else
			{
				return (Bitmap)null;
			}
			
		}

		public void SendButton(string buttonToSend)
		{
			CiscoIPPhoneExecute toExecute = new CiscoIPPhoneExecute();
			toExecute.items.Add(0, new CiscoIPPhoneExecute.Item(0, "Key:" + buttonToSend));
			if (buttonToSend == "Info")
			{
				toExecute.items.Add(1, new CiscoIPPhoneExecute.Item(0, "Key:" + buttonToSend));
			}
			SendRequest(toExecute);
		}

		protected void StartStreaming(IPEndPoint ep)
		{
			CiscoIPPhoneExecute toExecute = new CiscoIPPhoneExecute();
			toExecute.items.Add(0, new CiscoIPPhoneExecute.Item(0, "RTPTx:"+ep.Address.ToString()+":"+ep.Port.ToString()));
			SendRequest(toExecute);
		}

		protected void StopStreaming()
		{
			CiscoIPPhoneExecute toExecute = new CiscoIPPhoneExecute();
			toExecute.items.Add(0, new CiscoIPPhoneExecute.Item(0, "RTPTx:Stop"));
			SendRequest(toExecute);
		}

		protected void SendRequest(CiscoIPPhoneExecute toExecute)
		{
			string xml = "XML=" + toExecute.Format();
			byte[] body = Encoding.ASCII.GetBytes(xml);

			try
			{
				buttonRequest = (HttpWebRequest)HttpWebRequest.Create("http://" + this.phoneIp + "/CGI/Execute");
				buttonRequest.ContentType = "application/x-www-form-urlencoded";
				buttonRequest.ContentLength = body.Length;
				buttonRequest.PreAuthenticate = true;
				buttonRequest.KeepAlive = true;
				buttonRequest.Credentials = credentials;
				buttonRequest.Method = "POST";

				Stream requestStream = buttonRequest.GetRequestStream();
				requestStream.Write(body, 0, body.Length);
				requestStream.Close();

				WebResponse response = buttonRequest.GetResponse();
				response.Close();
			}
			catch (WebException e)
			{
				MessageBox.Show(e.Message);
			}
			catch { ;}

		}

        public virtual void RefreshScreenShot()
        {
            ;
        }

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// PhoneController
			// 
			this.Name = "PhoneController";
			this.Size = new System.Drawing.Size(755, 594);
			this.ResumeLayout(false);

		}
	}
}
