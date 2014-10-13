namespace JiraBugger
{
    public class LocalJiraAccount
    {
        public string BaseUrl { get; set; }
        public string ProjectKey { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string BugFilter { get; set; }
        public string StoryFilter { get; set; }
    }
}
