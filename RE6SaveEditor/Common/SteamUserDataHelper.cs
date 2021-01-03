using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RE6SaveEditor.Common
{
    public static class SteamUserDataHelper
    {

        public static string GetUserDataDirectory()
        {
            var steamPath = SteamClientHelper.GetSteamPath();
            if (string.IsNullOrEmpty(steamPath))
            {
                throw new ArgumentNullException(nameof(steamPath));
            }

            var userDataDirectory = Path.Combine(steamPath, "userdata");
            if (!Directory.Exists(userDataDirectory))
            {
                throw new DirectoryNotFoundException($"Steam 'userdata' directory not found in '{steamPath}'.");
            }

            return userDataDirectory;
        }

        public static string GetCurrentUserSaveDirectory(int appID)
        {
            var userDataDirectory = GetUserDataDirectory();
            var currentUserID = SteamClientHelper.GetCurrentUserSteamID();

            var currentUserSaveDirectory = Path.Combine(userDataDirectory, currentUserID.ToString(), appID.ToString(), "remote");
            if (!Directory.Exists(userDataDirectory))
            {
                throw new DirectoryNotFoundException($"Steam userdata directory not found for app ID '{appID}'.");
            }

            return currentUserSaveDirectory;
        }

        public static string GetSaveDirectory(int userID, int appID)
        {
            var userDataDirectory = GetUserDataDirectory();
            var saveDirectory = Path.Combine(userDataDirectory, userID.ToString(), appID.ToString(), "remote");

            return saveDirectory;
        }

        public static List<string> GetSaves(int userID, int appID)
        {
            var saveDirectory = GetSaveDirectory(userID, appID);
            var saveFiles = Directory.GetFiles(saveDirectory, "*", SearchOption.AllDirectories);

            return saveFiles.ToList();
        }

        public static List<string> GetSaves(int userID, int appID, string saveFile)
        {
            var saveDirectory = GetSaveDirectory(userID, appID);
            var saveFiles = Directory.GetFiles(saveDirectory, saveFile, SearchOption.AllDirectories);

            return saveFiles.ToList();
        }

    }
}
