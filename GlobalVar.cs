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

            public static List<string> CountDirection = new List<string>();

            public static List<int> Position = new List<int>();

            public static List<bool> MessageEnabled = new List<bool>();

            public static int MessageNumber { get; set; }

            public static int CustomMessageCount { get; set; }

            /// <summary>
            /// Static value protected by access routine.
            /// </summary>
            public static int Msgindex;

            public static bool PlayMessage;

            public static int Sequential { get; set; }

    }
}
