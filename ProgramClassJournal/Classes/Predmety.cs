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

        public Predmety(int id, string namePredmet, string fioTeacher, DateTime datePredmet)
        {
            this.id = id;
            this.namePredmet = namePredmet;
            this.fioTeacher = fioTeacher;
            this.datePredmet = datePredmet;
        }

        public int Id { get => id; set => id = value; }
        public string NamePredmet { get => namePredmet; set => namePredmet = value; }
        public string FioTeacher { get => fioTeacher; set => fioTeacher = value; }
        public DateTime DatePredmet { get => datePredmet; set => datePredmet = value; }

        public override bool Equals(object? obj)
        {
            return obj is Predmety predmety &&
                   id == predmety.id &&
                   namePredmet == predmety.namePredmet &&
                   fioTeacher == predmety.fioTeacher &&
                   datePredmet == predmety.datePredmet;
        }
    }
}
