using System;
using System.Xml;
using System.Xml.Serialization;

[XmlRoot("DeviceInformation")]
public struct DeviceInformation{
	[XmlElement("MACAddress")]
	public string MACAddress;
	[XmlElement("HostName")]
	public string HostName;
	[XmlElement("phoneDN")]
	public string phoneDN;
	[XmlElement("appLoadID")]
	public string appLoadID;
	[XmlElement("bootLoadID")]
	public string bootLoadID;
	[XmlElement("versionID")]
	public string versionID;
	[XmlElement("addonModule1")]
	public string addonModule1;
	[XmlElement("addonModule2")]
	public string addonModule2;
	[XmlElement("hardwareRevision")]
	public string hardwareRevision;
	[XmlElement("serialNumber")]
	public string serialNumber;
	[XmlElement("modelNumber")]
	public string modelNumber;
	[XmlElement("MessageWaiting")]
	public string MessageWaiting;
	
	//7960 Sepcific
	[XmlElement("Codec")] 
	public string Codec;
	[XmlElement("Amps")]
	public string Amps;
	[XmlElement("C3PORevision")]
	public string C3PORevision;
	[XmlElement("DSPLoadID")]
	public string DSPLoadID;
	
	//7970 Specific Fields
	[XmlElement("udi")]
	public string udi;
	[XmlElement("time")]
	public string time;
	[XmlElement("timezone")]
	public string timezone;
	[XmlElement("date")]
	public string date;
}

[XmlRoot("NetworkConfiguration")]
public struct NetworkConfiguration
{
	[XmlElement("DHCPServer")]
	public string DHCPServer;

	[XmlElement("BOOTPServer")]
	public string BOOTPServer;

	[XmlElement("MACAddress")]
	public string MACAddress;

	[XmlElement("HostName")]
	public string HostName;

	[XmlElement("DomainName")]
	public string DomainName;

	[XmlElement("IPAddress")]
	public string IPAddress;

	[XmlElement("SubNetMask")]
	public string SubNetMask;

	[XmlElement("TFTPServer1")]
	public string TFTPServer1;

	[XmlElement("DefaultRouter1")]
	public string DefaultRouter1;

	[XmlElement("DefaultRouter2")]
	public string DefaultRouter2;

	[XmlElement("DefaultRouter3")]
	public string DefaultRouter3;

	[XmlElement("DefaultRouter4")]
	public string DefaultRouter4;

	[XmlElement("DefaultRouter5")]
	public string DefaultRouter5;

	[XmlElement("DNSServer1")]
	public string DNSServer1;

	[XmlElement("DNSServer2")]
	public string DNSServer2;

	[XmlElement("DNSServer3")]
	public string DNSServer3;

	[XmlElement("DNSServer4")]
	public string DNSServer4;

	[XmlElement("DNSServer5")]
	public string DNSServer5;

	[XmlElement("VLANId")]
	public string VLANId;

	[XmlElement("AdminVLANId")]
	public string AdminVLANId;

	[XmlElement("CallManager1")]
	public string CallManager1;

	[XmlElement("CallManager2")]
	public string CallManager2;

	[XmlElement("CallManager3")]
	public string CallManager3;

	[XmlElement("CallManager4")]
	public string CallManager4;

	[XmlElement("CallManager5")]
	public string CallManager5;

	[XmlElement("InformationURL")]
	public string InformationURL;

	[XmlElement("DirectoriesURL")]
	public string DirectoriesURL;

	[XmlElement("MessagesURL")]
	public string MessagesURL;

	[XmlElement("ServicesURL")]
	public string ServicesURL;

	[XmlElement("DHCPEnabled")]
	public string DHCPEnabled;

	[XmlElement("DHCPAddressReleased")]
	public string DHCPAddressReleased;

	[XmlElement("AltTFTP")]
	public string AltTFTP;

	[XmlElement("IdleURL")]
	public string IdleURL;

	[XmlElement("IdleURLTime")]
	public string IdleURLTime;

	[XmlElement("AuthenticationURL")]
	public string AuthenticationURL;

	[XmlElement("ProxyServerURL")]
	public string ProxyServerURL;

	[XmlElement("PCPortDisable")]
	public string PCPortDisable;

	[XmlElement("SWPortCfg")]
	public string SWPortCfg;

	[XmlElement("PCPortCfg")]
	public string PCPortCfg;

	[XmlElement("TFTPServer2")]
	public string TFTPServer2;

	[XmlElement("UserLocale")]
	public string UserLocale;

	[XmlElement("NetworkLocale")]
	public string NetworkLocale;

	[XmlElement("UserLocaleVersion")]
	public string UserLocaleVersion;

	[XmlElement("NetworkLocaleVersion")]
	public string NetworkLocaleVersion;

	[XmlElement("VideoCapability")]
	public string VideoCapability;

	[XmlElement("PCVLAN")]
	public string PCVLAN;

	[XmlElement("RevertingFocusPriority")]
	public string RevertingFocusPriority;

	//7960 Specific
	[XmlElement("EraseConfig")] 
	public string EraseConfig;

	[XmlElement("HandsetOnlyMode")] 
	public string HandsetOnlyMode;

	[XmlElement("ConnectionMonitorDuration")]
	public string ConnectionMonitorDuration;

	[XmlElement("GARPEnabled")]
	public string GARPEnabled;

	[XmlElement("VoiceVlanAccessEnabled")]
	public string VoiceVlanAccessEnabled;

	[XmlElement("AutoSelectLineEnabled")]
	public string AutoSelectLineEnabled;

	[XmlElement("DscpForCm2Dvce")]
	public string DscpForCm2Dvce;

	[XmlElement("DscpForPhnCfg")]
	public string DscpForPhnCfg;

	[XmlElement("DscpForPhnSrv")]
	public string DscpForPhnSrv;

	[XmlElement("GlobalSecurityMode")]
	public string GlobalSecurityMode;

	[XmlElement("webAccess")]
	public string webAccess;


	//7970 Field
	[XmlElement("ForwardingDelay")]
	public string ForwardingDelay;

	[XmlElement("HeadsetEnable")]
	public string HeadsetEnable;

	[XmlElement("SpeakerEnable")]
	public string SpeakerEnable;

	[XmlElement("SpanPcPort")]
	public string SpanPcPort;

	[XmlElement("CDPPCPort")]
	public string CDPPCPort;

	[XmlElement("CDPSWPort")]
	public string CDPSWPort;

	[XmlElement("LLDPSWPort")]
	public string LLDPSWPort;
	
	[XmlElement("LLDPPCPort")]
	public string LLDPPCPort;
	
	[XmlElement("lldpPowerPriority")]
	public string lldpPowerPriority;

	[XmlElement("lldpAssetId")]
	public string lldpAssetId;

	[XmlElement("GARP")]
	public string GARP;

	[XmlElement("VoiceVlanAccess")]
	public string VoiceVlanAccess;

	[XmlElement("AutoSelectLine")]
	public string AutoSelectLine;

	[XmlElement("DscpForCallControl")]
	public string DscpForCallControl;

	[XmlElement("DscpForConfiguration")]
	public string DscpForConfiguration;

	[XmlElement("DscpForServices")]
	public string DscpForServices;

	[XmlElement("SecurityMode")]
	public string SecurityMode;

	[XmlElement("WebAccess")]
	public string WebAccess;

}

[XmlRoot("EthernetInformation")]
public struct EthernetInformation
{
	[XmlElement("TxFrames")]
	public string TxFrames;

	[XmlElement("TxBroadcasts")]
	public string TxBroadcasts;

	[XmlElement("TxMulticasts")]
	public string TxMulticasts;

	[XmlElement("RxFrames")]
	public string RxFrames;

	[XmlElement("RxMulticasts")]
	public string RxMulticasts;

	[XmlElement("RxBroadcasts")]
	public string RxBroadcasts;

	//7970 Specific
	[XmlElement("RxUnicasts")]
	public string RxUnicasts;

	[XmlElement("TxUnicasts")]
	public string TxUnicasts;

	[XmlElement("RxPacketNoDes")]
	public string RxPacketNoDes;

	
	//7960 Specific
	[XmlElement("TxExcessiveCollisions")]
	public string TxExcessiveCollisions;

	[XmlElement("TxCollisions")]
	public string TxCollisions;
	
	[XmlElement("TxDeferredAbort")]
	public string TxDeferredAbort;

	[XmlElement("RxOverruns")]
	public string RxOverruns;

	[XmlElement("RxLongCRC")]
	public string RxLongCRC;
	
	[XmlElement("RxCRCErrors")]
	public string RxCRCErrors;

	[XmlElement("RxBadPreamble")]
	public string RxBadPreamble;

	[XmlElement("RxRunt")]
	public string RxRunt;

	[XmlElement("RxShorts")]
	public string RxShorts;

	[XmlElement("RxLongs")]
	public string RxLongs;

}

[XmlRoot("PortInformation")]
public struct PortInformation
{
	[XmlIgnore]
	public int portId;

	[XmlElement("RxtotalPkt")]
	public string RxtotalPkt;

	[XmlElement("RxcrcErr")]
	public string RxcrcErr;

	[XmlElement("RxalignErr")]
	public string RxalignErr;

	[XmlElement("Rxmulticast")]
	public string Rxmulticast;

	[XmlElement("Rxbroadcast")]
	public string Rxbroadcast;

	[XmlElement("Rxunicast")]
	public string Rxunicast;

	[XmlElement("RxshortErr")]
	public string RxshortErr;

	[XmlElement("RxshortGood")]
	public string RxshortGood;

	[XmlElement("RxlongGood")]
	public string RxlongGood;

	[XmlElement("RxlongErr")]
	public string RxlongErr;

	[XmlElement("Rxsize64")]
	public string Rxsize64;

	[XmlElement("Rxsize65to127")]
	public string Rxsize65to127;

	[XmlElement("Rxsize128to255")]
	public string Rxsize128to255;

	[XmlElement("Rxsize256to511")]
	public string Rxsize256to511;

	[XmlElement("Rxsize512to1023")]
	public string Rxsize512to1023;

	[XmlElement("Rxsize1024to1518")]
	public string Rxsize1024to1518;


	[XmlElement("RxtokenDrop")]
	public string RxtokenDrop;

	[XmlElement("TxexcessDefer")]
	public string TxexcessDefer;

	[XmlElement("TxlateCollision")]
	public string TxlateCollision;

	[XmlElement("TxtotalGoodPkt")]
	public string TxtotalGoodPkt;

	[XmlElement("Txcollisions")]
	public string Txcollisions;

	[XmlElement("TxexcessLength")]
	public string TxexcessLength;

	[XmlElement("Txbroadcast")]
	public string Txbroadcast;

	[XmlElement("Txmulticast")]
	public string Txmulticast;

	[XmlElement("PortSpeed")]
	public string PortSpeed;
	
	//7960 Specific 
	[XmlElement("carrierEvnt")]
	public string carrierEvnt;

	[XmlElement("Rxsize1519to1548")]
	public string Rxsize1519to1548;

	[XmlElement("TxfifoUnderrun")]
	public string TxfifoUnderrun;

	[XmlElement("Txsize64")]
	public string Txsize64;

	[XmlElement("Txsize65to127")]
	public string Txsize65to127;

	[XmlElement("Txsize128to255")]
	public string Txsize128to255;

	[XmlElement("Txsize256to511")]
	public string Txsize256to511;

	[XmlElement("Txsize512to1023")]
	public string Txsize512to1023;

	[XmlElement("Txsize1024to1518")]
	public string Txsize1024to1518;

	[XmlElement("cos0Drop")]
	public string cos0Drop;

	[XmlElement("cos1Drop")]
	public string cos1Drop;

	[XmlElement("cos2Drop")]
	public string cos2Drop;

	[XmlElement("cos3Drop")]
	public string cos3Drop;

	[XmlElement("cos4Drop")]
	public string cos4Drop;

	[XmlElement("cos5Drop")]
	public string cos5Drop;

	[XmlElement("cos6Drop")]
	public string cos6Drop;

	[XmlElement("cos7Drop")]
	public string cos7Drop;

	[XmlElement("bpduDrop")]
	public string bpduDrop;

	[XmlElement("overflowDrop")]
	public string overflowDrop;

	[XmlElement("deviceId")]
	public string deviceId;

	[XmlElement("ipAddress")]
	public string ipAddress;

	[XmlElement("port")]
	public string port;

	//7970 specific
	[XmlElement("lldpFramesOutTotal")]
	public string lldpFramesOutTotal;

	[XmlElement("lldpAgeoutsTotal")]
	public string lldpAgeoutsTotal;

	[XmlElement("lldpFramesDiscardedTotal")]
	public string lldpFramesDiscardedTotal;

	[XmlElement("lldpFramesInErrorsTotal")]
	public string lldpFramesInErrorsTotal;

	[XmlElement("lldpFramesInTotal")]
	public string lldpFramesInTotal;

	[XmlElement("lldpTLVDiscardedTotal")]
	public string lldpTLVDiscardedTotal;

	[XmlElement("lldpTLVUnrecognizedTotal")]
	public string lldpTLVUnrecognizedTotal;

	[XmlElement("CDPNeighborDeviceId")]
	public string CDPNeighborDeviceId;

	[XmlElement("CDPNeighborIP")]
	public string CDPNeighborIP;

	[XmlElement("CDPNeighborPort")]
	public string CDPNeighborPort;

	[XmlElement("LLDPNeighborDeviceId")]
	public string LLDPNeighborDeviceId;

	[XmlElement("LLDPNeighborIP")]
	public string LLDPNeighborIP;

	[XmlElement("LLDPNeighborPort")]
	public string LLDPNeighborPort;
}

[XmlRoot("StreamingStatistics")]
public struct StreamingStatistics
{
	[XmlIgnore]
	int streamId;

	[XmlElement("Domain")]
	public string Domain;

	[XmlElement("RemoteAddr")]
	public string RemoteAddr;

	[XmlElement("LocalAddr")]
	public string LocalAddr;

	[XmlElement("SenderJoins")]
	public string SenderJoins;

	[XmlElement("ReceiverJoins")]
	public string ReceiverJoins;

	[XmlElement("Byes")]
	public string Byes;

	[XmlElement("StartTime")]
	public string StartTime;

	[XmlElement("RowStatus")]
	public string RowStatus;

	[XmlElement("Name")]
	public string Name;

	[XmlElement("SenderPackets")]
	public string SenderPackets;

	[XmlElement("SenderOctets")]
	public string SenderOctets;

	[XmlElement("SenderTool")]
	public string SenderTool;

	[XmlElement("SenderReports")]
	public string SenderReports;

	[XmlElement("SenderReportTime")]
	public string SenderReportTime;

	[XmlElement("SenderStartTime")]
	public string SenderStartTime;

	[XmlElement("RcvrLostPackets")]
	public string RcvrLostPackets;

	[XmlElement("RcvrJitter")]
	public string RcvrJitter;

	[XmlElement("ReceiverTool")]
	public string ReceiverTool;

	[XmlElement("RcvrReports")]
	public string RcvrReports;

	[XmlElement("RcvrReportTime")]
	public string RcvrReportTime;

	[XmlElement("RcvrPackets")]
	public string RcvrPackets;

	[XmlElement("RcvrOctets")]
	public string RcvrOctets;

	[XmlElement("RcvrStartTime")]
	public string RcvrStartTime;

	[XmlElement("MOSLQK")]
	public string MOSLQK;

	[XmlElement("AvgMOSLQK")]
	public string AvgMOSLQK;

	[XmlElement("MinMOSLQK")]
	public string MinMOSLQK;

	[XmlElement("MaxMOSLQK")]
	public string MaxMOSLQK;

	[XmlElement("MOSLQKVersion")]
	public string MOSLQKVersion;

	[XmlElement("CmltveConcealRatio")]
	public string CmltveConcealRatio;

	[XmlElement("IntervalConcealRatio")]
	public string IntervalConcealRatio;

	[XmlElement("MaxConcealRatio")]
	public string MaxConcealRatio;

	[XmlElement("ConcealSecs")]
	public string ConcealSecs;

	[XmlElement("SeverelyConcealSecs")]
	public string SeverelyConcealSecs;

	//7970 Specific
	[XmlElement("StreamStatus")]
	public string StreamStatus;

	[XmlElement("SenderCodec")]
	public string SenderCodec;

	[XmlElement("SenderReportsSent")]
	public string SenderReportsSent;

	[XmlElement("SenderReportTimeSent")]
	public string SenderReportTimeSent;

	[XmlElement("AvgJitter")]
	public string AvgJitter;

	[XmlElement("RcvrCodec")]
	public string RcvrCodec;

	[XmlElement("RcvrReportsSent")]
	public string RcvrReportsSent;

	[XmlElement("RcvrReportTimeSent")]
	public string RcvrReportTimeSent;

	[XmlElement("Latency")]
	public string Latency;

	[XmlElement("MaxJitter")]
	public string MaxJitter;

	[XmlElement("SenderSize")]
	public string SenderSize;

	[XmlElement("SenderReportsReceived")]
	public string SenderReportsReceived;

	[XmlElement("SenderReportTimeReceived")]
	public string SenderReportTimeReceived;

	[XmlElement("RcvrSize")]
	public string RcvrSize;

	[XmlElement("RcvrDiscarded")]
	public string RcvrDiscarded;

	[XmlElement("RcvrReportsReceived")]
	public string RcvrReportsReceived;

	[XmlElement("RcvrReportTimeReceive")]
	public string RcvrReportTimeReceive;

}
