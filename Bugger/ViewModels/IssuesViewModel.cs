using System.ComponentModel;

namespace JiraBugger
{
    public class IssuesViewModel : INotifyPropertyChanged
    {
        public ObservableCollectionWrapper<Issue> MyBugsModel { get; set; }
        public ObservableCollectionWrapper<Issue> MyStoriesModel { get; set; }

        private int activeBugs;
        public int ActiveBugs
        {
            get
            {
                return this.activeBugs;
            }
            set
            {
                this.activeBugs = value;
                this.OnPropertyChanged("ActiveBugs");
            }
        }

        private int resolvedBugs;
        public int ResolvedBugs
        {
            get
            {
                return this.resolvedBugs;
            }
            set
            {
                this.resolvedBugs = value;
                this.OnPropertyChanged("ResolvedBugs");
            }
        }

        public IssuesViewModel()
        {
            MyBugsModel = new ObservableCollectionWrapper<Issue>();
            MyStoriesModel = new ObservableCollectionWrapper<Issue>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
