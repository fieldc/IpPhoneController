using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CiscoBerbee
{
	public class CiscoIPPhoneExecute
	{

		public Dictionary<int, Item> items;

		public CiscoIPPhoneExecute()
		{
			this.items = new Dictionary<int, Item>();
		}

		public string Format()
		{
			string formatted = "<CiscoIPPhoneExecute>";
			foreach(Item myItem in this.items.Values){
				formatted += "<ExecuteItem Priority=\""+myItem.Priority.ToString()+"\" URL=\""+myItem.URL+"\"/>";
			}
			formatted+="</CiscoIPPhoneExecute>";
			return formatted;
		}

		public struct Item
		{
			int priority;
			string  url;

			public int Priority { get {return this.priority; } set{this.priority=value;} }
			public string URL { get { return this.url; } set { this.url = value; } }

			public Item(int priority, string url)
			{
				this.priority = priority;
				this.url = url;
			}
		}
	}
}
