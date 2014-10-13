using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;

namespace JiraBugger
{
    public static class IssueStorage
    {
        private const string IsolatedFileName = "LocalInfo";
        public static void SaveSettings(List<string> list, BuggerIssueType issueType)
        {
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForDomain())
            {
                using (IsolatedStorageFileStream rawStream = isf.CreateFile(IsolatedFileName + issueType))
                {
                    var writer = new StreamWriter(rawStream);
                    foreach(var item in list)
                    {
                        writer.WriteLine(item);
                    }
                    writer.Close();
                }
            }
        }

        public static List<string> LoadSettings(BuggerIssueType issueType)
        {
            var list = new List<string>();
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForDomain())
            {
                if (isf.FileExists(IsolatedFileName + issueType))
                {
                    using (IsolatedStorageFileStream rawStream = isf.OpenFile(IsolatedFileName + issueType, FileMode.Open))
                    {
                        var reader = new StreamReader(rawStream);
                        string item = null;
                        while((item = reader.ReadLine())!=null)
                        {
                            list.Add(item);
                        }
                        reader.Close();
                    }
                }
            }
            return list;
        }

        public static void DeleteSettings(BuggerIssueType issueType)
        {
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForDomain())
            {
                if (isf.FileExists(IsolatedFileName + issueType))
                {
                    isf.DeleteFile(IsolatedFileName + issueType);
                }
            }
        }
    }
}