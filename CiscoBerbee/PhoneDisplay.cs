using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;


namespace CiscoBerbee
{
	public partial class PhoneDisplay : Form
	{
		private string phoneIp;
		private int numPorts;
		private int numStreams;


		private delegate void UpdateStreamTabsCallback(Dictionary<int, StreamingStatistics> info);
		private UpdateStreamTabsCallback UpdateStreamTabsDelegate;
		private delegate Dictionary<int,StreamingStatistics> GetStreamInformation();
		private GetStreamInformation GetStreamDelegate;
		
		private delegate void UpdatePortTabsCallback(Dictionary<int, PortInformation> info);
		private UpdatePortTabsCallback UpdatePortTabsDelegate;
		private delegate Dictionary<int, PortInformation> GetPortInformation();
		private GetPortInformation GetPortDelegate;

		private delegate void UpdateEthernetTextCallback(EthernetInformation info);
		private UpdateEthernetTextCallback UpdateEthernetTextDelegate;
		private delegate EthernetInformation GetEthernetInformation();
		private GetEthernetInformation GetEthernetDelegate;

		private delegate void UpdateNetworkTextCallback(NetworkConfiguration info);
		private UpdateNetworkTextCallback UpdateNetworkTextDelegate;
		private delegate NetworkConfiguration GetNetworkInformation();
		private GetNetworkInformation GetNetworkDelegate;

		private delegate void UpdateDeviceTextCallback(DeviceInformation info);
		private UpdateDeviceTextCallback UpdateDeviceTextDelegate;
		private delegate DeviceInformation GetDeviceInformation();
		private GetDeviceInformation GetDeviceDelegate;

		private delegate void UpdateMacroStatus(string completed);
		private UpdateMacroStatus UpdateMacroDelegate;


		private PhoneDisplay() {;	}

		public PhoneDisplay(string ip)
		{
			this.phoneIp = ip;
			this.numPorts = 0;
			this.numStreams = 0;
			
			InitializeComponent();

			this.Load += new EventHandler(PhoneDisplay_Load);
			this.GetDeviceDelegate = new GetDeviceInformation(this.GetDeviceInformationAsync);
			this.UpdateDeviceTextDelegate = new UpdateDeviceTextCallback(this.UpdateDeviceText);

			this.GetNetworkDelegate = new GetNetworkInformation(this.GetNetworkConfigurationAsync);
			this.UpdateNetworkTextDelegate = new UpdateNetworkTextCallback(this.UpdateNetworkText);

			this.GetEthernetDelegate = new GetEthernetInformation(this.GetEthernetInformationAsync);
			this.UpdateEthernetTextDelegate = new UpdateEthernetTextCallback(this.UpdateEthernetText);

			this.GetPortDelegate = new GetPortInformation(this.GetPortInformationAsync);
			this.UpdatePortTabsDelegate = new UpdatePortTabsCallback(this.UpdatePortTabs);

			this.GetStreamDelegate = new GetStreamInformation(this.GetStreamingStatisticsAsync);
			this.UpdateStreamTabsDelegate = new UpdateStreamTabsCallback(this.UpdateStreamTabs);
			this.macroText.KeyDown += new KeyEventHandler(macroText_KeyDown);
		}

		void macroText_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
			{
				e.Handled=true;
				e.SuppressKeyPress = true;
				this.RunMacro();
			}
		}

		void RunMacro()
		{
			MessageBox.Show("Sending Macro To Phone Now");
			((PhoneController)((TableLayoutPanel)this.phoneTabs.TabPages["phoneDisplayTab"].Controls["tableLayout"]).Controls[1]).SendMacroSring(this.macroText.Text);
		}

		void PhoneDisplay_Load(object sender, EventArgs e)
		{
			GetPhoneInformation();
		}

		private void GetPhoneInformation()
		{
			AsyncCallback deviceCb = new AsyncCallback(GetDeviceInformationAsyncCallBack);
			Object deviceState = new Object();
			this.GetDeviceDelegate.BeginInvoke(deviceCb, deviceState);
			
			AsyncCallback netconfigCb = new AsyncCallback(GetNetworkConfigurationAsyncCallBack);
			Object netconfigState = new Object();
			this.GetNetworkDelegate.BeginInvoke(netconfigCb, netconfigState);

			AsyncCallback ethernetCb = new AsyncCallback(GetEthernetInformationAsyncCallBack);
			Object ethernetState = new Object();
			this.GetEthernetDelegate.BeginInvoke(ethernetCb, ethernetState);
			
			AsyncCallback portsCb = new AsyncCallback(GetPortInformationAsyncCallBack);
			Object portsState = new Object();
			this.GetPortDelegate.BeginInvoke(portsCb, portsState);

			AsyncCallback streamsCb = new AsyncCallback(GetStreamingStatisticsAsyncCallBack);
			Object streamsState = new Object();
			this.GetStreamDelegate.BeginInvoke(streamsCb, streamsState);
			
		}


		private DeviceInformation GetDeviceInformationAsync()
		{
			try{
				XmlSerializer serializer = new XmlSerializer(typeof(DeviceInformation));
				HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://" + this.phoneIp + "/DeviceInformationX");
				request.KeepAlive = true;
				WebResponse response = request.GetResponse();
				return (DeviceInformation)serializer.Deserialize(response.GetResponseStream());
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				System.Console.WriteLine(e.Message);
			}
			return new DeviceInformation() ;

		}
		private void GetDeviceInformationAsyncCallBack(IAsyncResult ar)
		{
			GetDeviceInformation gdi = (GetDeviceInformation)((AsyncResult)ar).AsyncDelegate;
			DeviceInformation di = gdi.EndInvoke(ar);

			if (!string.IsNullOrEmpty(di.MACAddress)) //we can fail to get the info
			{
				this.txtDeviceInformation.Invoke(this.UpdateDeviceTextDelegate, di);
			}
			return;
		}
		private void UpdateDeviceText(DeviceInformation info)
		{
			foreach (FieldInfo fi in info.GetType().GetFields())
			{
				object value = fi.GetValue(info);
				if(value != null)
					this.txtDeviceInformation.Text += fi.Name + ": " + value.ToString() + System.Environment.NewLine;
			}
		}
		
		private NetworkConfiguration GetNetworkConfigurationAsync()
		{
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(NetworkConfiguration));
				HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://" + this.phoneIp + "/NetworkConfigurationX");
				request.KeepAlive = true;
				WebResponse response = request.GetResponse();
				return (NetworkConfiguration)serializer.Deserialize(response.GetResponseStream());
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
			return new NetworkConfiguration();
		}
		private void GetNetworkConfigurationAsyncCallBack(IAsyncResult ar)
		{
			GetNetworkInformation gni = (GetNetworkInformation)((AsyncResult)ar).AsyncDelegate;
			NetworkConfiguration ni = gni.EndInvoke(ar);

			if (!string.IsNullOrEmpty(ni.MACAddress)) //we can fail to get the info
			{
				this.txtNetworkInformation.Invoke(this.UpdateNetworkTextDelegate, ni);
			}
			return;
		}
		private void UpdateNetworkText(NetworkConfiguration info)
		{
			foreach (FieldInfo fi in info.GetType().GetFields())
			{
				object value = fi.GetValue(info);
				if (value != null)
					this.txtNetworkInformation.Text += fi.Name + ": " + value.ToString() + System.Environment.NewLine;
			}
		}

		private EthernetInformation GetEthernetInformationAsync()
		{
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(EthernetInformation));
				HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://" + this.phoneIp + "/EthernetInformationX");
				request.KeepAlive = true;
				WebResponse response = request.GetResponse();
				return (EthernetInformation)serializer.Deserialize(response.GetResponseStream());
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
			return new EthernetInformation();
		}
		private void GetEthernetInformationAsyncCallBack(IAsyncResult ar)
		{
			GetEthernetInformation gei = (GetEthernetInformation)((AsyncResult)ar).AsyncDelegate;
			EthernetInformation ei = gei.EndInvoke(ar);

			if (!string.IsNullOrEmpty(ei.RxFrames)) //we can fail to get the info
			{
				this.txtEthernetInformation.Invoke(this.UpdateEthernetTextDelegate, ei);
			}
			return;
		}
		private void UpdateEthernetText(EthernetInformation info)
		{
			foreach (FieldInfo fi in info.GetType().GetFields())
			{
				object value = fi.GetValue(info);
				if (value != null)
					this.txtEthernetInformation.Text += fi.Name + ": " + value.ToString() + System.Environment.NewLine;
			}
		}

		private Dictionary<int, PortInformation> GetPortInformationAsync()
		{
			Dictionary<int, PortInformation> info = new Dictionary<int, PortInformation>();
			int portNum = 1;
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(PortInformation));
				for (portNum = 1; portNum < 10; portNum++)
				{

					HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://" + this.phoneIp + "/PortInformationX?" + portNum.ToString());
					request.KeepAlive = true;
					WebResponse response = request.GetResponse();
					if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
					{
						PortInformation pi = (PortInformation)serializer.Deserialize(response.GetResponseStream());
						if (string.Compare(pi.port, "Invalid Argument", StringComparison.OrdinalIgnoreCase) == 0)
						{
							this.numPorts = portNum;
							break;
						}
						pi.portId = portNum;
						info.Add(portNum, pi);
					}
					else
					{
						this.numPorts = portNum;
						break;
					}
				}
				return info;
			}
			catch (WebException wex)
			{
				this.numPorts = portNum;
				if (((HttpWebResponse)wex.Response).StatusCode != HttpStatusCode.Unauthorized)
				{
					MessageBox.Show("Ports(" + portNum + "): " + wex.Message);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Ports("+portNum+"): " + e.Message);
			}
			return info;
		}
		private void GetPortInformationAsyncCallBack(IAsyncResult ar)
		{
			GetPortInformation gpi = (GetPortInformation)((AsyncResult)ar).AsyncDelegate;
			Dictionary<int, PortInformation> info = gpi.EndInvoke(ar);

			if (info.Count>0) //we can fail to get the info
			{
				this.ports.Invoke(this.UpdatePortTabsDelegate, info);
			}
			return;
		}
		private void UpdatePortTabs(Dictionary<int, PortInformation> info)
		{
			foreach (KeyValuePair<int, PortInformation> kvp in info)
			{
				string displayName = !string.IsNullOrEmpty(kvp.Value.port) ? kvp.Value.port : "Port: " + kvp.Value.portId.ToString();
				string tabName = !string.IsNullOrEmpty(kvp.Value.port) ? kvp.Value.port : "Port" + kvp.Value.portId.ToString();
					
				if (this.ports.TabCount == 0 || !this.ports.TabPages.ContainsKey("Port" + kvp.Key.ToString()))
				{
					TabPage tb = new TabPage(displayName);
					tb.Name = tabName;

					TextBox txtBox = new TextBox();
					txtBox.Multiline = true;
					txtBox.Name = "portInfo";
					txtBox.ReadOnly = true;
					txtBox.ScrollBars = ScrollBars.Vertical;
					txtBox.Dock = DockStyle.Fill;
					txtBox.ContextMenuStrip = this.refreshMenu;
					foreach (FieldInfo fi in kvp.Value.GetType().GetFields())
					{
						object value = fi.GetValue(kvp.Value);
						if (value != null)
							txtBox.Text += fi.Name + ": " + value.ToString() + System.Environment.NewLine;
					}
					tb.Controls.Add(txtBox);
					this.ports.TabPages.Add(tb);
				}
				else
				{
					this.ports.TabPages[tabName].Controls["portInfo"].Text = "";
					foreach (FieldInfo fi in kvp.Value.GetType().GetFields())
					{
						object value = fi.GetValue(kvp.Value);
						if (value != null)
							this.ports.TabPages[tabName].Controls["portInfo"].Text += fi.Name + ": " + value.ToString() + System.Environment.NewLine;
					}
				}
			}
		}

		private Dictionary<int, StreamingStatistics> GetStreamingStatisticsAsync()
		{
			Dictionary<int, StreamingStatistics> info = new Dictionary<int, StreamingStatistics>();
			int streamNumber = 0;
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(StreamingStatistics));
				for (streamNumber = 1; streamNumber < 10; streamNumber++)
				{
					HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://" + this.phoneIp + "/StreamingStatisticsX?" + streamNumber.ToString());
					request.KeepAlive = true;
					WebResponse response = request.GetResponse();
					if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
					{
						StreamingStatistics si = (StreamingStatistics)serializer.Deserialize(response.GetResponseStream());
						if (string.Compare(si.Name, "Invalid Argument", StringComparison.OrdinalIgnoreCase) == 0)
						{
							this.numStreams = streamNumber;
							break;
						}
						info.Add(streamNumber, si);
					}
					else
					{
						this.numStreams = streamNumber;
						break;
					}
				}
				return info;
			}
			catch (WebException wex)
			{
				if (((HttpWebResponse)wex.Response).StatusCode != HttpStatusCode.Unauthorized)
				{
					MessageBox.Show("Stream("+streamNumber.ToString()+"): "+ wex.Message);
				}
				this.numStreams = streamNumber;
			}
			catch (Exception e)
			{
				MessageBox.Show("Stream("+streamNumber.ToString()+"): "+e.Message);
			}
			return info;
		}
		private void GetStreamingStatisticsAsyncCallBack(IAsyncResult ar)
		{
			GetStreamInformation gsi = (GetStreamInformation)((AsyncResult)ar).AsyncDelegate;
			Dictionary<int, StreamingStatistics> info = gsi.EndInvoke(ar);
			
			if (info.Count>0) //we can fail to get the info
			{
				lock (this.streams)
				{
					try
					{
						this.streams.Invoke(this.UpdateStreamTabsDelegate, info);
					}
					catch { ;} 
				}
			}
			return;
		}
		private void UpdateStreamTabs(Dictionary<int, StreamingStatistics> info)
		{
			try
			{
				foreach (KeyValuePair<int, StreamingStatistics> kvp in info)
				{

					if (this.streams.TabCount == 0 || !this.streams.TabPages.ContainsKey("Stream" + kvp.Key.ToString()))
					{
						TabPage tb = new TabPage("Stream: " + kvp.Key.ToString());
						tb.Name = "Stream" + kvp.Key.ToString();

						TextBox txtBox = new TextBox();
						txtBox.Multiline = true;
						txtBox.Name = "streamInfo";
						txtBox.ReadOnly = true;
						txtBox.ScrollBars = ScrollBars.Vertical;
						txtBox.Dock = DockStyle.Fill;
						txtBox.ContextMenuStrip = this.refreshMenu;
						foreach (FieldInfo fi in kvp.Value.GetType().GetFields())
						{
							object value = fi.GetValue(kvp.Value);
							if (value != null)
								txtBox.Text += fi.Name + ": " + value.ToString() + System.Environment.NewLine;
						}
						tb.Controls.Add(txtBox);
						this.streams.TabPages.Add(tb);
					}
					else
					{
						this.streams.TabPages["Stream" + kvp.Key.ToString()].Controls["streamInfo"].Text = "";
						foreach (FieldInfo fi in kvp.Value.GetType().GetFields())
						{
							object value = fi.GetValue(kvp.Value);
							if (value != null)
								this.streams.TabPages["Stream" + kvp.Key.ToString()].Controls["streamInfo"].Text += fi.Name + ": " + value.ToString() + System.Environment.NewLine;
						}
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AsyncCallback ethernetCb = new AsyncCallback(GetEthernetInformationAsyncCallBack);
			Object ethernetState = new Object();
			this.GetEthernetDelegate.BeginInvoke(ethernetCb, ethernetState);

			AsyncCallback portsCb = new AsyncCallback(GetPortInformationAsyncCallBack);
			Object portsState = new Object();
			this.GetPortDelegate.BeginInvoke(portsCb, portsState);

			AsyncCallback streamsCb = new AsyncCallback(GetStreamingStatisticsAsyncCallBack);
			Object streamsState = new Object();
			this.GetStreamDelegate.BeginInvoke(streamsCb, streamsState);
		}

		private void executeMacro_Click(object sender, EventArgs e)
		{
			this.RunMacro();
		}
		
	}
}
