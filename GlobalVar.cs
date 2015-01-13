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

            public static decimal SeqIntervalTime { get; set; }

            /// <summary>
            /// Static value protected by access routine.
            /// </summary>
            public static int Msgindex;

            public static bool PlayMessage;

            public static bool Alternating;

    }
}
