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
    public class Otchet
    {
        private int id;
        private string studentFIO;
        private string predmetName;
        private int ocenka;

        public Otchet(int id, string studentFIO, string predmetName, int ocenka)
        {
            this.id = id;
            this.studentFIO = studentFIO;
            this.predmetName = predmetName;
            this.ocenka = ocenka;
        }

        public int Id { get => id; set => id = value; }
        public string StudentFIO { get => studentFIO; set => studentFIO = value; }
        public string PredmetName { get => predmetName; set => predmetName = value; }
        public int Ocenka { get => ocenka; set => ocenka = value; }
   
    }
}
