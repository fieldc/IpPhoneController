using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace CiscoBerbee
{
	public partial class Login : Form
	{
		private delegate CipImage GetPhoneImage();
		//private PhoneController phone;

		public Login()
		{
			InitializeComponent();
            this.phoneAddress.KeyDown += new KeyEventHandler(input_KeyDown);
            this.userName.KeyDown += new KeyEventHandler(input_KeyDown);
            this.password.KeyDown += new KeyEventHandler(input_KeyDown);
		}

        void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                if (!string.IsNullOrEmpty(this.phoneAddress.Text) && !string.IsNullOrEmpty(this.userName.Text)
                    && !string.IsNullOrEmpty(this.password.Text))
                {
                    this.StartLogin();
                }
            }
        }

        private void StartLogin()
        {
            if (Regex.IsMatch(this.phoneAddress.Text, @"^\p{Nd}{1,3}\.\p{Nd}{1,3}\.\p{Nd}{1,3}\.\p{Nd}{1,3}$"))
            {
                if (this.CheckCredentials(this.phoneAddress.Text, this.userName.Text, this.password.Text))
                {
                    ShowPhone(this.phoneAddress.Text, this.userName.Text, this.password.Text);
                }
            }
            else if (Regex.IsMatch(this.phoneAddress.Text, @"^\p{Nd}{1,}$"))
            {
                MessageBox.Show("Search Phone Number");
            }
            else if (Regex.IsMatch(this.phoneAddress.Text, @"^[\p{Ll}\p{Lu} -']{1,}$"))
            {
                MessageBox.Show("Search Name");
            }
            else if (Regex.IsMatch(this.phoneAddress.Text, @"^[\p{Nd}a-fA-F]{2}:[\p{Nd}a-fA-F]{2}:[\p{Nd}a-fA-F]{2}:[\p{Nd}a-fA-F]{2}:[\p{Nd}a-fA-F]{2}:[\p{Nd}a-fA-F]{2}$"))
            {
                MessageBox.Show("Search Mac");
            }
        }

		private bool CheckCredentials(string ip, string userName,string password)
		{

			try
			{
				//check credentials by sending ding
				CiscoIPPhoneExecute toExecute = new CiscoIPPhoneExecute();
				toExecute.items.Add(0, new CiscoIPPhoneExecute.Item(0, "Play:Jamaica.raw"));

				string xml = "XML=" + toExecute.Format();
				byte[] body = Encoding.ASCII.GetBytes(xml);

                IWebProxy myProxy = GlobalProxySelection.GetEmptyWebProxy();
                GlobalProxySelection.Select = myProxy;


                HttpWebRequest.DefaultWebProxy = myProxy;
				HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://" + ip + "/CGI/Execute");

                
				request.ContentType = "application/x-www-form-urlencoded";
				request.ContentLength = body.Length;
				request.PreAuthenticate = true;
				request.KeepAlive = true;
                request.Proxy = myProxy;
				request.Credentials = new NetworkCredential(userName, password);
				request.Method = "POST";

				Stream requestStream = request.GetRequestStream();
				requestStream.Write(body, 0, body.Length);
				requestStream.Close();

				WebResponse response = request.GetResponse();
				string responseStr = new StreamReader(response.GetResponseStream()).ReadToEnd();
				response.Close();
				
				if (responseStr.Contains("CiscoIPPhoneError"))
				{
					Match errorCode = Regex.Match(responseStr, "Number=\"(?<err>[1-4]+)\"");
					string errorMessage = "";
					if (errorCode.Success)
					{
						int errorNumber = Int32.Parse(errorCode.Groups["err"].Value);
						switch (errorNumber)
						{
							case 1:
								errorMessage = "Error Parsing Message";
								break;
							case 2:
								errorMessage = "Error Framing Message";
								break;
							case 3:
								errorMessage = "Internal File Error";
								break;
							case 4:
								errorMessage = "Authentication Error";
								break;
                            default:
                                errorMessage = "Unknown Error: "+errorNumber;
                                break;
						}
					}
					else
					{
						errorMessage = "Authentication Error";
					}
					throw new WebException(errorMessage);
				}
				
				return true;
			}
			catch (WebException e)
			{
				MessageBox.Show(e.Message);
			}
			catch
			{
				MessageBox.Show("Cannot Contact Phone Webserver");
			}
			return false;
		}

		private void ShowPhone(string ip, string userName, string password)
		{
			PhoneDisplay pd = new PhoneDisplay(ip);
			//modelNumber: CP-7970G
			XmlSerializer serializer = new XmlSerializer(typeof(DeviceInformation));
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://" + this.phoneAddress.Text + "/DeviceInformationX");
			request.KeepAlive = true;
			WebResponse response = request.GetResponse();
			if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
			{
				DeviceInformation info =(DeviceInformation)serializer.Deserialize(response.GetResponseStream());
                if (info.modelNumber.Contains("7960") || info.modelNumber.Contains("7962") || info.modelNumber.Contains("7961"))
				{
                    ((TableLayoutPanel)pd.phoneTabs.TabPages["phoneDisplayTab"].Controls["tableLayout"]).Controls.Add(new Cisco7962(this.phoneAddress.Text, this.userName.Text, this.password.Text), 0, 0);
					//((TableLayoutPanel)pd.phoneTabs.TabPages["phoneDisplayTab"].Controls["tableLayout"]).Controls.Add(new Cisco7960(this.phoneAddress.Text, this.userName.Text, this.password.Text), 0, 0);
				}
                else if (info.modelNumber.Contains("7975"))
                {
                    ((TableLayoutPanel)pd.phoneTabs.TabPages["phoneDisplayTab"].Controls["tableLayout"]).Controls.Add(new Cisco7975(this.phoneAddress.Text, this.userName.Text, this.password.Text), 0, 0);
                    pd.Height = 646 + 150;
                }
                else if (info.modelNumber.Contains("7965") || info.modelNumber.Contains("7945"))
                {
                    ((TableLayoutPanel)pd.phoneTabs.TabPages["phoneDisplayTab"].Controls["tableLayout"]).Controls.Add(new Cisco7965(this.phoneAddress.Text, this.userName.Text, this.password.Text), 0, 0);
                    
                }
                else if (info.modelNumber.Contains("7970"))
                {
                    ((TableLayoutPanel)pd.phoneTabs.TabPages["phoneDisplayTab"].Controls["tableLayout"]).Controls.Add(new Cisco7970(this.phoneAddress.Text, this.userName.Text, this.password.Text), 0, 0);
                    //pd.Width = 557 + 20;
                    pd.Height = 656 + 150;
                }
                else
                {
                    MessageBox.Show("Invalid Phone Model: " + info.modelNumber);
                }
                //pd.Height = ((TableLayoutPanel)pd.phoneTabs.TabPages["phoneDisplayTab"].Controls["tableLayout"]).Controls[0].Height + 150;
				pd.Show();
				pd.phoneTabs.TabPages["phoneDisplayTab"].Controls["tableLayout"].Controls[0].Focus();
				
			}
			else
			{
				MessageBox.Show("Error getting device information");
			}
		}

		private void connectButton_Click(object sender, EventArgs e)
		{
            if (!string.IsNullOrEmpty(this.phoneAddress.Text) && !string.IsNullOrEmpty(this.userName.Text)
               && !string.IsNullOrEmpty(this.password.Text))
            {
                this.StartLogin();
            }
		}
	}
}
