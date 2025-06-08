using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json;

namespace ProgramClassJournal.Classes
{
    public class Ocenky
    {
        private int id;
        private string studentName;
        private string predmetName;
        private DateTime dateOcenk;
        private int ocenka;
        private string teacherName;

        public Ocenky(int id, string studentName, string predmetName, int ocenka, string teacherName)
        {
            this.id = id;
            this.studentName = studentName;
            this.predmetName = predmetName;
            this.dateOcenk = DateTime.Now;
            this.ocenka = ocenka;
            this.teacherName = teacherName;
        }

        public int Id { get => id; set => id = value; }
        public string StudentName { get => studentName; set => studentName = value; }
        public string PredmetName { get => predmetName; set => predmetName = value; }
        public DateTime DateOcenk { get => dateOcenk; set => dateOcenk = value; }
        public int Ocenka { get => ocenka; set => ocenka = value; }
        public string TeacherName { get =>  teacherName; set => teacherName = value; }
        public static void Save()
        {
            string fileName = "ocenkypg.json";
            string json = JsonSerializer.Serialize(App.allOcenky, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
            File.WriteAllText(fileName, json, Encoding.UTF8);
        }
        public static void Load()
        {
            string fileName = "ocenkypg.json";
            string data = File.ReadAllText(fileName);
            App.allOcenky = JsonSerializer.Deserialize<ObservableCollection<Ocenky>>(data);

        }
    }
 
}
