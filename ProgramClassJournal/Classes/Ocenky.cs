using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramClassJournal.Classes
{
    public class Ocenky
    {
        private int id;
        private string studentName;
        private string predmetName;
        private DateTime dateOcenk;

        public Ocenky(int id, string studentName, string predmetName, DateTime dateOcenk)
        {
            this.id = id;
            this.studentName = studentName;
            this.predmetName = predmetName;
            this.dateOcenk = dateOcenk;
        }

        public int Id { get => id; set => id = value; }
        public string StudentName { get => studentName; set => studentName = value; }
        public string PredmetName { get => predmetName; set => predmetName = value; }
        public DateTime DateOcenk { get => dateOcenk; set => dateOcenk = value; }

        public override bool Equals(object? obj)
        {
            return obj is Ocenky ocenky &&
                   id == ocenky.id &&
                   studentName == ocenky.studentName &&
                   predmetName == ocenky.predmetName &&
                   dateOcenk == ocenky.dateOcenk;
        }
    }
}
