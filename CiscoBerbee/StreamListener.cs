using System;
using System.Collections.Generic;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace CiscoBerbee
{
	public class StreamListener
	{
		static short[] muLawToPcmMap = new short[256];
		static Boolean mapInitialized = false;
		IPEndPoint ep;
		UdpClient client;
		SoundPlayer player;
		MemoryStream soundStreamPacket;


		public const int BIAS = 0x84; //132, or 1000 0100
		//public const int MAX = 32635; //32767 (max 15-bit integer) minus BIAS

		public StreamListener()
		{
			if (mapInitialized == false)
			{
				for (byte i = 0; i < byte.MaxValue; i++)
				{
					muLawToPcmMap[i] = Decode(i);
				}
			}
			
			player = new SoundPlayer();
			soundStreamPacket = new MemoryStream();
			
			soundStreamPacket.Write(new byte[4] { 0x52, 0x49,0x46,0x46 }, 0, 4); //RIFF

			//size
			soundStreamPacket.Write(new byte[4] { 0x66, 0x01, 0x00, 0x00 }, 0, 4); //Max int val
					
			//wave header
			soundStreamPacket.Write(new byte[4] { 0x57,0x41, 0x56,0x45 }, 0, 4); //'WAVE'

			//Format header
			soundStreamPacket.Write(new byte[4] { 0x66, 0x6D, 0x74,0x20 }, 0, 4); //'fmt '

			//	Chunk Data Size
			soundStreamPacket.Write(new byte[4] { 0x12, 0x00 , 0x00,0x00 }, 0, 4); //12

			//Compression code/format 1=PCM, 7=Ulaw
			soundStreamPacket.Write(new byte[2] { 0x01, 0x00 }, 0, 2); //7

			//Number of channels
			soundStreamPacket.Write(new byte[2] { 0x01, 0x00 }, 0, 2); //1

			//Sample rate
			soundStreamPacket.Write(new byte[4] { 0x40, 0x1F, 0x00, 0x00 }, 0, 4);//8000

			//Average bytes per sec
			soundStreamPacket.Write(new byte[4] { 0x40, 0x1F , 0x00,0x00 }, 0, 4); //8000

			//Block Align
			soundStreamPacket.Write(new byte[2] { 0x01, 0x00 }, 0, 2);
			
			//Significante bits/sample (8?)
			soundStreamPacket.Write(new byte[2] { 0x08, 0x00 }, 0, 2); //8
			
			//Extra format bytes
			soundStreamPacket.Write(new byte[2] { 0x00, 0x00 }, 0, 2);

			//fact header
			//soundStreamPacket.Write(new byte[4] {0x66,0x61,0x63,0x74} , 0, 4); //fact

			//	Chunk Data Size
			//soundStreamPacket.Write(new byte[4] { 0x04, 0x00, 0x00, 0x00 }, 0, 4); //4

			//Format info
			//soundStreamPacket.Write(new byte[4] {0xC0,0x57,0x01,0x00}, 0, 4); 

			//data header
			soundStreamPacket.Write(new byte[4] { 0x64, 0x61, 0x74, 0x61 }, 0, 4);  //data
			
			//data size 
			soundStreamPacket.Write(new byte[4] { 0x40, 0x01, 0x00, 0x00 }, 0, 4);
			
			
		}


		public uint StartListening(IPEndPoint otherSide)
		{
			client = new UdpClient(32002, AddressFamily.InterNetwork);
			ep = otherSide;
			//client.ExclusiveAddressUse = true;
			//client.Connect(otherSide);//to make sure we don't allow misc data in
			this.Listen();
			return 32002;
		}
		public void StopListening()
		{
			if(this.client!=null)
				this.client.Close();
			
		}

		private void Listen()
		{
			object state = new object();
			this.client.BeginReceive(new AsyncCallback(this.ListenCallback), state);
		}

		private void ListenCallback(IAsyncResult ar)
		{
			try
			{
				lock (this.GetType())
				{
					//http://www.sonicspot.com/guide/wavefiles.html	
					if (ar != null && client != null)
					{
						byte[] recPacket = client.EndReceive(ar, ref ep);
						int size = recPacket.Length-12; //12 is packet header
						
						//decode to PCM
						byte[] decoded = new byte[size * 2];
						for (int i = 0; i < size ; i++)
						{
							//First byte is the less significant byte
							decoded[2*i] = (byte)(muLawToPcmMap[recPacket[i + 12]] & 0xff);
							//Second byte is the more significant byte
							decoded[(2*i) + 1] = (byte)(muLawToPcmMap[recPacket[i + 12]] >> 8);
						}


						MemoryStream packet = new MemoryStream();
						packet.Write(this.soundStreamPacket.ToArray(), 0, (int)this.soundStreamPacket.Length);
						packet.Write(decoded, 0, decoded.Length);
						
						player.Stream = packet;
						player.Stream.Position = 0;
						player.Play();
						
						Listen();
					}
				}
			}
			catch (Exception e)
			{
				System.Console.WriteLine(e.Message);
			}
		}

		private static short Decode(byte mulaw)
		{
			//code borrowed from http://www.codeproject.com/KB/security/g711audio.aspx
			
			//Flip all the bits
			mulaw = (byte)~mulaw;

			//Pull out the value of the sign bit
			int sign = mulaw & 0x80;
			
			//Pull out and shift over the value of the exponent
			int exponent = (mulaw & 0x70) >> 4;
			
			//Pull out the four bits of data
			int data = mulaw & 0x0f;

			//Add on the implicit fifth bit (we know the four data bits followed a one bit)
			data |= 0x10;

			/* Add a 1 to the end of the data by shifting over and adding one. Why?
			* Mu-law is not a one-to-one function. There is a range of values that all
			* map to the same mu-law byte. Adding a one to the end essentially adds a
			* "half byte", which means that the decoding will return the value in the
			* middle of that range. Otherwise, the mu-law decoding would always be
			* less than the original data. */
			data <<= 1;
			data += 1;

			/* Shift the five bits to where they need to be: left (exponent + 2) places
			* Why (exponent + 2) ?
			* 1 2 3 4 5 6 7 8 9 A B C D E F G
			* . 7 6 5 4 3 2 1 0 . . . . . . . <-- starting bit (based on exponent)
			* . . . . . . . . . . 1 x x x x 1 <-- our data
			* We need to move the one under the value of the exponent,
			* which means it must move (exponent + 2) times
			*/
			data <<= exponent + 2;

			//Remember, we added to the original, so we need to subtract from the final
			data -= StreamListener.BIAS;
			
			//If the sign bit is 0, the number is positive. Otherwise, negative.
			return (short)(sign == 0 ? data : -data);
		}

		class UdpState 
		{
			public UdpClient u;
			public IPEndPoint e;
		}

	}
}
