using System.IO;
using System.IO.IsolatedStorage;

namespace JiraBugger
{
    public static class SettingStorage
    {
        private const string IsolatedFileName = "JiraAccount";
        public static void SaveSettings(LocalJiraAccount jiraAccount)
        {
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForDomain())
            {
                using (IsolatedStorageFileStream rawStream = isf.CreateFile(IsolatedFileName))
                {
                    var writer = new StreamWriter(rawStream);
                    writer.WriteLine(jiraAccount.BaseUrl);
                    writer.WriteLine(jiraAccount.ProjectKey);
                    writer.WriteLine(jiraAccount.User);
                    writer.WriteLine(jiraAccount.Password);
                    writer.WriteLine(jiraAccount.BugFilter);
                    writer.WriteLine(jiraAccount.StoryFilter);
                    writer.Close();
                }
            }
        }

        public static LocalJiraAccount LoadSettings()
        {
            var jiraAccount = new LocalJiraAccount();
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForDomain())
            {
                if (isf.FileExists(IsolatedFileName))
                {
                    using (IsolatedStorageFileStream rawStream = isf.OpenFile(IsolatedFileName, FileMode.Open))
                    {
                        var reader = new StreamReader(rawStream);
                        jiraAccount.BaseUrl = reader.ReadLine();
                        jiraAccount.ProjectKey = reader.ReadLine();
                        jiraAccount.User = reader.ReadLine();
                        jiraAccount.Password = reader.ReadLine();
                        jiraAccount.BugFilter = reader.ReadLine();
                        jiraAccount.StoryFilter = reader.ReadLine();
                        reader.Close();
                    }
                }
            }

            return jiraAccount;
        }

        public static void DeleteSettings()
        {
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForDomain())
            {
                if (isf.FileExists(IsolatedFileName))
                {
                    isf.DeleteFile(IsolatedFileName);
                }
            }
        }
    }
}