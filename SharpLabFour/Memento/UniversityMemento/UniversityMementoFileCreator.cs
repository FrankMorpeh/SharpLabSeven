using System;
using System.IO;
using System.Text.Json;

namespace SharpLabFour.Memento
{
    public static class UniversityMementoFileCreator
    {
        public static void CreateSaveFile(UniversityMemento universityMemento)
        {
            try
            {
                string serializedUniversityMememento = JsonSerializer.Serialize(universityMemento);
                File.WriteAllText(MainWindow.initialLocation + "\\SaveFiles\\University.json", serializedUniversityMememento);
            }
            catch (Exception) {}
        }
        public static UniversityMemento LoadSaveFile()
        {
            UniversityMemento universityMemento = null;
            try
            {
                FileStream fileStream = new FileStream(MainWindow.initialLocation + "\\SaveFiles\\University.json", FileMode.Open);
                universityMemento = JsonSerializer.Deserialize<UniversityMemento>(fileStream);
            }
            catch (Exception) { }
            return universityMemento;
        }
    }
}