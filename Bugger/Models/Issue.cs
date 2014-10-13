using System.ComponentModel;

namespace JiraBugger
{
    public class Issue : INotifyPropertyChanged
    {
        private string key;
        public string Key
        {
            get
            {
                return this.key;
            }
            set
            {
                this.key = value;
                this.OnPropertyChanged("Key");
            }
        }

        private string summary;
        public string Summary {
            get { 
                return this.summary; 
            }
            set { 
                this.summary = value;
                this.OnPropertyChanged("Summary");
            }
        }
        
        private string status;
        public string Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
                this.OnPropertyChanged("Status");
            }
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