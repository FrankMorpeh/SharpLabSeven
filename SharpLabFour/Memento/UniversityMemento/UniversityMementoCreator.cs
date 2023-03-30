namespace SharpLabFour.Memento
{
    public static class UniversityMementoCreator
    {
        public static void CreateSave(MainWindow content)
        {
            UniversityMementoFileCreator.CreateSaveFile(new UniversityMemento(content.subjectViewModel.SaveState()
                , content.studentViewModel.SaveState()));
        }
        public static void LoadSave(MainWindow content)
        {
            UniversityMemento universityMemento = UniversityMementoFileCreator.LoadSaveFile();
            if (universityMemento != null)
            {
                content.subjectViewModel.LoadState(universityMemento.SubjectViewModelMemento);
                content.studentViewModel.LoadState(universityMemento.StudentViewModelMemento, universityMemento.SubjectViewModelMemento);
            }
        }
    }
}