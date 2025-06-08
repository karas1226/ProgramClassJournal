using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

       
    }
}
