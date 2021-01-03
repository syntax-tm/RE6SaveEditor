using Microsoft.Win32;
using System.IO;

namespace RE6SaveEditor.Common
{
    public static class SteamClientHelper
    {

        public const string SteamRegistryPath = @"HKEY_CURRENT_USER\Software\Valve\Steam";
        public const string SteamActiveProcessRegistryPath = @"HKEY_CURRENT_USER\Software\Valve\Steam\ActiveProcess";

        public static string GetSteamPath()
        {
            var steamPath = (string)Registry.GetValue(SteamRegistryPath, @"SteamPath", null);
            steamPath = Path.GetFullPath(steamPath);
            return steamPath;
        }

        public static int GetCurrentUserSteamID()
        {
            var currentUser = (int)Registry.GetValue(SteamActiveProcessRegistryPath, "ActiveUser", 0);
            return currentUser;
        }

        public static bool IsUserActive()
        {
            var currentUser = GetCurrentUserSteamID();
            return currentUser > 0;
        }

    }
}
