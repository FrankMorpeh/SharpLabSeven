using SharpLabFour.Models.Subjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SharpLabFour.Models.Students
{
    public class Student : INotifyPropertyChanged
    {
        private int itsId;
        private string itsFirstName;
        private string itsLastName;
        private ObservableCollection<SubjectOfStudent> itsSubjectsAndGrades;

        public int Id { get { return itsId; } set { itsId = value; } }
        public string FirstName
        {
            get { return itsFirstName; }
            set { itsFirstName = value; OnPropertyChanged("FirstName"); }
        }
        public string LastName
        {
            get { return itsLastName; }
            set { itsLastName = value; OnPropertyChanged("LastName"); }
        }
        public ObservableCollection<SubjectOfStudent> SubjectsAndGrades { get { return itsSubjectsAndGrades; } 
            set { itsSubjectsAndGrades = value; } }

        public Student() : this(string.Empty, string.Empty, new ObservableCollection<SubjectOfStudent>()) {}
        public Student(string firstName, string lastName)
        {
            itsFirstName = firstName;
            itsLastName = lastName;
            itsSubjectsAndGrades = new ObservableCollection<SubjectOfStudent>();
        }
        public Student(string firstName, string lastName, ObservableCollection<SubjectOfStudent> subjectsAndGrades)
        {
            itsFirstName = firstName;
            itsLastName = lastName;
            itsSubjectsAndGrades = subjectsAndGrades;
        }
        public void AddSubject(Subject subject)
        {
            itsSubjectsAndGrades.Add(new SubjectOfStudent(subject));
        }
        public void AddSubjectRange(List<Subject> subjects)
        {
            foreach (Subject subject in subjects)
                itsSubjectsAndGrades.Add(new SubjectOfStudent(subject));
        }
        public void RemoveSubject(SubjectOfStudent subjectOfStudent)
        {
            itsSubjectsAndGrades.Remove(subjectOfStudent);
        }
        public void RemoveSubject(Subject subject) // called from StudentViewModel when an initial subject is deleted
        {
            itsSubjectsAndGrades.Remove(itsSubjectsAndGrades.Where(sg => sg.Subject == subject).FirstOrDefault());
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