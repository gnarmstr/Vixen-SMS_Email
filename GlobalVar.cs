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

            public static decimal SeqIntervalTime { get; set; }

            /// <summary>
            /// Static value protected by access routine.
            /// </summary>
  //          static int _globalValue;

            /// <summary>
            /// Access routine for global variable.
            /// </summary>
  //          public static int GlobalValue
  //          {
  //              get
  //              {
  //                  return _globalValue;
  //              }
  //              set
  //              {
  //                  _globalValue = value;
  //              }
  //          }

            /// <summary>
            /// Global static field.
            /// </summary>
  //          public static bool GlobalBoolean;
    }
}
