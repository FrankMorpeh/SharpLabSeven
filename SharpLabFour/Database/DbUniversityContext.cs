using Microsoft.EntityFrameworkCore;
using SharpLabFour.Models.Students;
using SharpLabFour.Models.Subjects;

namespace SharpLabFour.Database
{
    public class DbUniversityContext : DbContext
    {
        public DbUniversityContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public DbSet<SubjectOfStudent> SubjectsOfStudent { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlite("Data Source=Database\\University.db");
        }


        // Data
        public void AddStudent(Student student)
        {
            Students.Add(student);
            SaveChanges();
        }
        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
            SaveChanges();
        }
        public void UpdateStudent(Student student)
        {
            Student studentToUpdate = Students.Find(student.Id);
            if (studentToUpdate != null)
            {
                studentToUpdate = student;
                SaveChanges();
            }
        }
        public void AddSubject(Subject subject)
        {
            Subjects.Add(subject);
            SaveChanges();
        }
        public void RemoveSubject(Subject subject)
        {
            Subjects.Remove(subject);
            SaveChanges();
        }
        public void UpdateSubject(Subject subject)
        {
            Subject subjectToUpdate = Subjects.Find(subject.Id);
            if (subjectToUpdate != null)
            {
                subjectToUpdate = subject;
                SaveChanges();
            }
        }
        public void RemoveSubjectOfStudent(SubjectOfStudent subjectOfStudent)
        {
            SubjectsOfStudent.Remove(subjectOfStudent);
            SaveChanges();
        }
    }
}