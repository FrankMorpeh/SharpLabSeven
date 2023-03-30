using SharpLabFour.Memento;
using SharpLabFour.Models.Students;
using SharpLabFour.Models.Subjects;
using SharpLabFour.States.StudentViewModelSortingStates;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace SharpLabFour.ViewModels
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Student> itsStudents;
        private IStudentViewModelSortingState itsStudentViewModelSortingState;

        public ObservableCollection<Student> Students { get { return itsStudents; } set { itsStudents = value; } }
        
        public StudentViewModel()
        {
            itsStudents = new ObservableCollection<Student>();
            itsStudentViewModelSortingState = new StudentViewModelNotSortedByLastNameState();
        }
        public void AddStudent(Student student)
        {
            itsStudents.Add(student);
        }
        public void RemoveStudent(Student student)
        {
            itsStudents.Remove(student);
        }
        public void RemoveSubjectFromAllStudents(Subject subject) // is called when a subject is removed in SubjectViewModel
        {
            foreach (Student student in itsStudents)
            {
                if (student.SubjectsAndGrades.Where(sg => sg.Subject == subject).FirstOrDefault() != null)
                    student.RemoveSubject(subject);
            }
        }
        public List<Tuple<Student, SubjectOfStudent>> GetStudentsBySubjectName(string subjectName)
        {
            List<Student> students = 
                itsStudents.Where(st => st.SubjectsAndGrades.ToList().Exists(sg => sg.Subject.Name == subjectName)).ToList();
            List<Tuple<Student, SubjectOfStudent>> studentsAndChosenSubject = new List<Tuple<Student, SubjectOfStudent>>();
            foreach (Student student in students)
                studentsAndChosenSubject.Add(new Tuple<Student, SubjectOfStudent>(student
                    , student.SubjectsAndGrades.Where(sg => sg.Subject.Name == subjectName).FirstOrDefault()));
            return studentsAndChosenSubject;
        }
        

        // Sorting
        public void SortByLastName(DataGrid studentsDataGrid)
        {
            itsStudentViewModelSortingState.SortByLastName(ref itsStudents, ref itsStudentViewModelSortingState);
            studentsDataGrid.ItemsSource = itsStudents;
        }


        // Memento
        public StudentViewModelMemento SaveState()
        {
            return new StudentViewModelMemento(itsStudents);
        }
        public void LoadState(StudentViewModelMemento studentViewModelMemento, SubjectViewModelMemento subjectViewModelMemento)
        {
            /*
                SubjectViewModelMemento is needed so as to bind student's subjects with the same objects in memory,
                as after serialization subjects of students and actual subjects are different
            */
            foreach (Student student in studentViewModelMemento.Students)
            {
                itsStudents.Add(new Student(student.FirstName, student.LastName));
                foreach (Subject subject in subjectViewModelMemento.Subjects)
                {
                    if (student.SubjectsAndGrades.ToList().Exists(sg => sg.Subject.Name == subject.Name))
                    {
                        itsStudents[itsStudents.Count - 1].SubjectsAndGrades.Add(new SubjectOfStudent(subject
                            , student.SubjectsAndGrades.Where(sg => sg.Subject.Name == subject.Name).FirstOrDefault().Grade));
                    }
                }
            }
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