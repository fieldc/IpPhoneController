using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Diagnostics;

namespace CiscoBerbee
{
	[XmlRoot("CiscoIPPhoneImage")]
	public class CipImage
	{
		private int[,] image;

		private CipImage() { ;}
		public static CipImage FromFile(string fileName)
		{
			FileInfo fi = new FileInfo(fileName);
			XmlSerializer serializer = new XmlSerializer(typeof(CipImage));
			return (CipImage)serializer.Deserialize(fi.OpenRead());
		}

		public static CipImage FromStream(Stream stream)
		{
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(CipImage));
				return (CipImage)serializer.Deserialize(stream);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
				return (CipImage)null;
			}
		}

		// (script-fu-round-button 0 "0" 16  "TahomaBold"  "6d6d6d" "b5b5b5" "f4f4f4" "d6d6d6" "5b5b5b" "c9ffc3" 4 4 2 1 1 1 1)
		public Bitmap ToBitmap()
		{
			Bitmap bm = new Bitmap(this.Width, this.Height);
			Color[] colors=new Color[4];
			colors[3] = Color.Black;
			colors[2] = Color.FromArgb(Convert.ToInt32(0x7f), Convert.ToInt32(0xaa), Convert.ToInt32(0x75));
			colors[1] = Color.FromArgb(Convert.ToInt32(0x99), Convert.ToInt32(0xcc), Convert.ToInt32(0x99));
			colors[0] = Color.FromArgb(Convert.ToInt32(0xbf), Convert.ToInt32(0xff), Convert.ToInt32(0xbf));

			this.image=new int[this.Width,this.Height];
			this.Data = this.Data.Trim();
			//loop counters for x,y mapping of pixel
			int y = 0, x = 0;
			for (int i = 0; i < this.Data.Length; i += 2)
			{
				string hexDigits = this.Data.Substring(i, 2);
				byte imgByte = Convert.ToByte(hexDigits, 16);
				//acording to doc bytes are mapped reversed 
				byte upackedByte1 = (byte)(imgByte & (byte)3);
				byte upackedByte2 = (byte)((imgByte & (byte)12) >> 2);
				byte upackedByte3 = (byte)((imgByte & (byte)48) >> 4);
				byte upackedByte4 = (byte)((imgByte & (byte)192) >> 6);
				bm.SetPixel(x  , y, colors[upackedByte1]);
				bm.SetPixel(x+1, y, colors[upackedByte2]);
				bm.SetPixel(x+2, y, colors[upackedByte3]);
				bm.SetPixel(x+3, y, colors[upackedByte4]);
				x += 4;
				if (x >= this.Width)
				{
					++y;
					x = 0;
				}
			}

			
			return bm;
		}

		[XmlElement("LocationX")]
		public int LocationX { get; set;}
		[XmlElement("LocationY")]
		public int LocationY {get; set;}
		[XmlElement("Height")]
		public int Height {get; set;}
		[XmlElement("Width")]
		public int Width {get; set;}
		[XmlElement("Depth")]
		public int Depth {get; set;}
		[XmlElement("Data")]
		public string Data {get; set;}


	}
}
