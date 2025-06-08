using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProgramClassJournal.Classes
{
    public class Students
    {
        private int id;
        private string fioStudent;
        private DateTime dateOfBirth;
        private string parallell;
        private string numberClass;

        public Students(int id, string fioStudent, string parallell, string numberClass)
        {
            this.id = id;
            this.fioStudent = fioStudent;
            this.dateOfBirth = DateTime.Now;
            this.parallell = parallell;
            this.numberClass = numberClass;
        }

        public int Id { get => id; set => id = value; }
        public string FioStudent { get => fioStudent; set => fioStudent = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Parallell { get => parallell; set => parallell = value; }
        public string NumberClass { get => numberClass; set => numberClass = value; }

        public static void Save()
        {
            string fileName = "student.json";
            string json = JsonSerializer.Serialize(App.allStudents, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
            File.WriteAllText(fileName, json, Encoding.UTF8);
        }
        public static void Load()
        {
            string fileName = "student.json";
            string data = File.ReadAllText(fileName);
            App.allStudents = JsonSerializer.Deserialize<ObservableCollection<Students>>(data);

        }
    }
}
