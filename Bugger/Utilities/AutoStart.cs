using System;
using System.IO;
using System.Reflection;
using Microsoft.Win32;

namespace JiraBugger.Utilities
{
    public class AutoStart
    {
        private const string TheKey = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

        public static bool Set(bool started, string keyName)
        {
            var key = Registry.CurrentUser.OpenSubKey(TheKey, true);

            var appFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var appName = AppDomain.CurrentDomain.FriendlyName;
            var path = string.Format("\"{0}\\{1}\"", appFolder, appName);
            try
            {
                if (started)
                {
                    key.SetValue(keyName, path);
                    key.Close();
                }
                else
                {
                    key.DeleteValue(keyName);
                    key.Close();
                }
            }
            catch
            {
                return false;
            }

            return true;
        } 
    }
}
