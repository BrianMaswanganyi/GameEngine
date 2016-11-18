using System;
using System.Diagnostics;

namespace GameEngine
{
    internal class Debug
    {

        public static bool IsDebugMode { get; internal set; }

        internal static void Log(string name)
        {
            Debugger.Log(1, "Warning", name);
        }
    }
}
