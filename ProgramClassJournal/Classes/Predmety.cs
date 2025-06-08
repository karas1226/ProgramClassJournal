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
    public class Predmety
    {
        private int id;
        private string namePredmet;
        private string fioTeacher;
        private DateTime datePredmet;

        public Predmety(int id, string namePredmet, string fioTeacher)
        {
            this.id = id;
            this.namePredmet = namePredmet;
            this.fioTeacher = fioTeacher;
            this.datePredmet = DateTime.Now;
        }

        public int Id { get => id; set => id = value; }
        public string NamePredmet { get => namePredmet; set => namePredmet = value; }
        public string FioTeacher { get => fioTeacher; set => fioTeacher = value; }
        public DateTime DatePredmet { get => datePredmet; set => datePredmet = value; }
        public static void Save()
        {
            string fileName = "predmets.json";
            string json = JsonSerializer.Serialize(App.allPredmety, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
            File.WriteAllText(fileName, json, Encoding.UTF8);
        }
        public static void Load()
        {
            string fileName = "predmets.json";
            string data = File.ReadAllText(fileName);
            App.allPredmety = JsonSerializer.Deserialize<ObservableCollection<Predmety>>(data);

        }

    }
}
