using SharpLabFour.Models.Subjects;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SharpLabFour.Models.Students
{
    public class SubjectOfStudent : INotifyPropertyChanged
    {
        private int itsId;
        private Subject itsSubject;
        private double itsGrade;

        public int Id { get { return itsId; } set { itsId = value; } }
        public Subject Subject { get { return itsSubject; } set { itsSubject = value; } } // subject can't be edited, it can only be added or removed
        public double Grade { get { return itsGrade; } set { itsGrade = value; OnPropertyChanged("Grade"); } }

        public SubjectOfStudent()
        {
            itsSubject = new Subject();
            itsGrade = 0.0;
        }
        public SubjectOfStudent(Subject subject, double grade = 0.0)
        {
            itsSubject = subject;
            itsGrade = grade;
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