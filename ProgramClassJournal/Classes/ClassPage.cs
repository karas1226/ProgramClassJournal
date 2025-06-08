using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ProgramClassJournal.Classes
{
    public class ClassPage
    {
        private int id;
        private string className;
        private string parallel;
        private string classTeacher;

        public ClassPage(int id, string className, string parallel, string classTeacher)
        {
            this.id = id;
            this.className = className;
            this.parallel = parallel;
            this.classTeacher = classTeacher;
        }

        public int Id { get => id; set => id = value; }
        public string ClassName { get => className; set => className = value; }
        public string Parallel { get => parallel; set => parallel = value; }
        public string ClassTeacher { get => classTeacher; set => classTeacher = value; }
        public static void Save()
        {
            string fileName = "ClassesPages.json";
            string json = JsonSerializer.Serialize(App.allClasses, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
            File.WriteAllText(fileName, json, Encoding.UTF8);
        }
        public static void Load() 
        {
            string fileName = "ClassesPages.json";
            string data = File.ReadAllText(fileName);
            App.allClasses = JsonSerializer.Deserialize<ObservableCollection<ClassPage>>(data);
            
        }
    
    }
}
