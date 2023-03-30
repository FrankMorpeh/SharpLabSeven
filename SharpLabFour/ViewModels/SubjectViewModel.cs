using SharpLabFour.Memento;
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
        public ObservableCollection<Subject> Subjects { get; set; }

        public SubjectViewModel(ObservableCollection<Subject> subjects)
        {
            Subjects = subjects;
        }
        public SubjectViewModel(StudentViewModel studentViewModel)
        {
            itsSubjectRemovedEvent += studentViewModel.RemoveSubjectFromAllStudents;
        }
        public void AddSubject(Subject subject)
        {
            Subjects.Add(subject);
        }
        public void RemoveSubject(Subject subject)
        {
            Subjects.Remove(subject);
            itsSubjectRemovedEvent(subject);
        }


        // Memento
        public SubjectViewModelMemento SaveState()
        {
            return new SubjectViewModelMemento(Subjects);
        }
        public void LoadState(SubjectViewModelMemento subjectViewModelMemento)
        {
            Subjects = subjectViewModelMemento.Subjects;
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