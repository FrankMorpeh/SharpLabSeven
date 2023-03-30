using SharpLabFour.Models.Students;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SharpLabFour.Models.Subjects
{
    public class Subject : INotifyPropertyChanged
    {
        private int itsId;
        private string itsName;

        public int Id { get { return itsId; } set { itsId = value; } }
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