using Microsoft.VisualStudio.TestTools.UnitTesting;
using RE6SaveEditor.Common;
using System;
using System.IO;

namespace RE6SaveEditorUnitTests
{
    [TestClass]
    public class SteamClientTests
    {
        [TestMethod]
        public void GetSteamClientPath()
        {
            var clientPath = SteamClientHelper.GetSteamPath();

            Console.WriteLine($"Steam Client Path: '{clientPath}'");

            Assert.IsTrue(!string.IsNullOrEmpty(clientPath));
            Assert.IsTrue(Directory.Exists(clientPath));
        }

        [TestMethod]
        public void GetActiveUserID()
        {
            var userID = SteamClientHelper.GetCurrentUserSteamID();

            Console.WriteLine($"User ID: {userID}");

            Assert.IsTrue(userID > 0);
        }

        //[TestMethod]
        //public void GetRE6SaveFile()
        //{
        //    var appID = 221040;
        //    var userID = SteamClientHelper.GetCurrentUserSteamID();
        //    var saveFileName = @"savedata.bin";

        //    var saveFile = SteamUserDataHelper.GetSave(userID, appID, saveFileName);
        //}
    }
}
