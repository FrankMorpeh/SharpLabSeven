namespace SharpLabFour.Memento
{
    public class UniversityMemento
    {
        public SubjectViewModelMemento SubjectViewModelMemento { get; set; }
        public StudentViewModelMemento StudentViewModelMemento { get; set; }

        public UniversityMemento(SubjectViewModelMemento subjectViewModelMemento, StudentViewModelMemento studentViewModelMemento)
        {
            SubjectViewModelMemento = subjectViewModelMemento;
            StudentViewModelMemento = studentViewModelMemento;
        }
    }
}