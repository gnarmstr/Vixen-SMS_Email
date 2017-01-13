using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Vixen_Messaging
{
	internal class GlobalVar
	{
		/// <summary>
		/// Global variable that is constant.
		/// </summary>

		#region General Global Variables
		public static string LogMsg { get; set; }

		public static string Blacklistlocation { get; set; }

		public static string Blacklist { get; set; }

		public static string Whitelistlocation { get; set; }

		public static string Whitelist { get; set; }

		public static string LocalMessages { get; set; }

		public static string SettingsPath { get; set; }

		public static string TwilioSID { get; set; }

		public static string TwilioToken { get; set; }

		public static string TwilioPhoneNumber { get; set; }

		public static decimal SeqIntervalTime { get; set; }

		public static int Msgindex;

		public static bool PlayMessage;

		public static bool PlayCustomMessage;

		public static bool NoNodeID;

		public static int GroupIDNumber;

		public static int Sequential { get; set; }

		public static FileInfo oldest;

		#endregion

		#region Custom Messages

		public static List<string> ListLine1 = new List<string>();

		public static List<string> ListLine2 = new List<string>();

		public static List<string> ListLine3 = new List<string>();

		public static List<string> ListLine4 = new List<string>();

		public static List<int> Line1Colour = new List<int>();

		public static List<int> Line2Colour = new List<int>();

		public static List<int> Line3Colour = new List<int>();

		public static List<int> Line4Colour = new List<int>();

		public static List<string> CountDirection = new List<string>();

		public static List<string> MessageColourOption = new List<string>();

		public static List<string> CustomMessageSeqSel = new List<string>();

		public static List<string> CustomMessageNodeSel = new List<string>();

		public static List<string> GroupNodeID = new List<string>();

		public static List<string> GroupNameID = new List<string>();

		public static List<int> Position = new List<int>();

		public static List<bool> MessageEnabled = new List<bool>();

		public static List<bool> CheckBoxCentreStop = new List<bool>();

		public static List<decimal> CustomMsgLength = new List<decimal>();

		public static int MessageNumber { get; set; }

		public static int CustomMessageCount { get; set; }

		public static List<string> CustomFontSize = new List<string>();

		public static List<string> CustomFont = new List<string>();

		public static List<int> TrackBarCustomSpeed = new List<int>();

		#endregion

		#region Messaging Settings

		public static bool AutoStartMsgRetrieval;

		public static string ReturnBannedMSG;

		public static string ReturnWarningMSG;

		public static string ReturnSuccessMSG;

		public static string GroupName;

		public static string GroupID;

		public static string SequenceTemplate;

		public static string Vixen3Folder;

		public static string VixenServer;

		public static string MessagingFolder;

		public static string OutputSequenceFolder;

		public static string MessageLog;

		public static string BlacklistLog;

		public static string CountDownDate;

		public static string Black_WhiteSelection;

		public static int IntervalMsgs;

		#endregion

		#region Text Settings

		public static int IncomingMessageColourOption;

		public static string StringOrientation;

		public static string TextDirection;

		public static bool CenterText;

		public static bool CenterStop;

		public static int TextPosition;

		public static int TextSpeed;

		public static int Intensity;

		public static string Font;

		public static string FontSize;

		public static decimal MaxWords;

		public static List<Color> TextColor = new List<Color>(10);

		#endregion
	}
}
