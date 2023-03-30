using SharpLabFour.Database;
using SharpLabFour.Models.Subjects;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SharpLabFour.ViewModels
{
    public class SubjectViewModel : INotifyPropertyChanged
    {
        private event Action<Subject> itsSubjectRemovedEvent;
        private event Action<Subject> itsAddSubjectToDatabaseEvent;
        private event Action<Subject> itsRemoveSubjectFromDatabaseEvent;
        public ObservableCollection<Subject> Subjects { get; set; }

        public SubjectViewModel(ObservableCollection<Subject> subjects)
        {
            Subjects = subjects;
        }
        public SubjectViewModel(StudentViewModel studentViewModel)
        {
            Subjects = new ObservableCollection<Subject>();
            itsSubjectRemovedEvent += studentViewModel.RemoveSubjectFromAllStudents;
        }
        public SubjectViewModel(StudentViewModel studentViewModel, DbUniversityContext dbUniversityContext)
        {
            Subjects = dbUniversityContext.Subjects.Local.ToObservableCollection();
            itsSubjectRemovedEvent += studentViewModel.RemoveSubjectFromAllStudents;
            itsAddSubjectToDatabaseEvent += dbUniversityContext.AddSubject;
            itsRemoveSubjectFromDatabaseEvent += dbUniversityContext.RemoveSubject;
        }
        public void AddSubject(Subject subject)
        {
            Subjects.Add(subject);
            itsAddSubjectToDatabaseEvent(subject);
        }
        public void RemoveSubject(Subject subject)
        {
            Subjects.Remove(subject);
            itsSubjectRemovedEvent(subject);
            itsRemoveSubjectFromDatabaseEvent(subject);
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