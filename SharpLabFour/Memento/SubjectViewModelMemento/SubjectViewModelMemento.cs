using SharpLabFour.Models.Subjects;
using System.Collections.ObjectModel;

namespace SharpLabFour.Memento
{
    public class SubjectViewModelMemento
    {
        public ObservableCollection<Subject> Subjects { get; set; }

        public SubjectViewModelMemento(ObservableCollection<Subject> subjects) { Subjects = subjects; }
    }
}