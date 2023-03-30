using SharpLabFour.Models.Students;
using System.Collections.ObjectModel;

namespace SharpLabFour.Memento
{
    public class StudentViewModelMemento
    {
        public ObservableCollection<Student> Students { get; set; }

        public StudentViewModelMemento(ObservableCollection<Student> students) { Students = students; }
    }
}