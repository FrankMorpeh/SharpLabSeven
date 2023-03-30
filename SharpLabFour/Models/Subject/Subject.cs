using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SharpLabFour.Models.Subjects
{
    public class Subject : INotifyPropertyChanged
    {
        private string itsName;

        public string Name { get { return itsName; } set { itsName = value; OnPropertyChanged("Name"); } }

        public Subject()
        {
            itsName = string.Empty;
        }
        public Subject(string name)
        {
            itsName = name;
        }


        // MVVM events
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}