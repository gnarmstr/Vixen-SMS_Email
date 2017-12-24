using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Vixen_Messaging
{
	public class GlobalVar
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

		public static bool NoNodeID;

		public static int GroupIDNumber;

		public static int Sequential { get; set; }

		public static FileInfo oldest;

		public static bool closeMessagingApp;
		
		public static string FileText;

		public static bool SaveFlag;

		public static string CurrentSequence  { get; set; }

		#endregion

		#region Messaging Settings

		public static bool AutoStartMsgRetrieval;

		public static bool ClearBannedLog;

		public static bool RepeatDisplayMessage;

		public static string CountDownDate;

		public static string Black_WhiteSelection;

		public static int IntervalMsgs;

		#endregion

		#region Messages

		public static string CountDownMSG;

		public static string AdvertisingMSG;

		public static string[] Messages;

		public static int RandomCountDownSensitivity;

		public static int RandomAdvertisingSensitivity;

		public static int RandomMessagesSensitivity;

		#endregion

		#region Vixen Settings

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

		public static string PhoneNumberLog;

		public static string DisplayLog;
		
		#endregion

		#region Text Settings

		public static int IncomingMessageColourOption;

		public static string StringOrientation;

		public static string TextDirection;

		public static bool CenterText;

		public static bool CenterStop;

		public static bool SingleLine;

		public static int TextPosition;

		public static int TextIterations;

		public static int TextSpeed;

		public static int Intensity;

		public static string Font;

		public static string FontSize;

		public static decimal MaxWords;

		public static List<Color> TextColor = new List<Color>(10);

		public static string GradientMode;

		#endregion

		#region Vixen Sequences

		public static List<string> VixenSequencesList;

		public static bool VixenSequences;

		public static int RandomSequenceSensitivity;

		#endregion

		#region Instant Message

		public static string InstantMSG;

		public static bool CloseInstantMSGForm;

		#endregion

		#region Scheduler

		public static List<SchedulerClass> _schedules;

		public static string[] ScheduledDay = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

		public class SchedulerClass
		{
			public string Schedule_Day;
			public DateTime Schedule_TimeOn;
			public DateTime Schedule_TimeOff;
		}
		
		#endregion
	}
}
