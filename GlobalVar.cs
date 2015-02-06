using System.Collections.Generic;

namespace Vixen_Messaging
{
    class GlobalVar
    {
            /// <summary>
            /// Global variable that is constant.
            /// </summary>
            public static string LogMsg { get; set; }

            public static string Blacklistlocation { get; set; }

            public static string Whitelistlocation { get; set; }

            public static string LocalMessages { get; set; }

            public static string SettingsPath { get; set; }

            public static string MovieFolder { get; set; }

            public static string TwilioSID { get; set; }

            public static string TwilioToken { get; set; }

            public static string TwilioPhoneNumber { get; set; }

            public static decimal SeqIntervalTime { get; set; }

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

            /// <summary>
            /// Static value protected by access routine.
            /// </summary>
            public static int Msgindex;

            public static bool PlayMessage;

            public static bool PlayCustomMessage;

			public static bool NoNodeID;

			public static int GroupIDNumber;

			public static int Sequential { get; set; }

    }
}
