using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Students(int id, string fioStudent, DateTime dateOfBirth, string parallell, string numberClass)
        {
            this.id = id;
            this.fioStudent = fioStudent;
            this.dateOfBirth = dateOfBirth;
            this.parallell = parallell;
            this.numberClass = numberClass;
        }

        public int Id { get => id; set => id = value; }
        public string FioStudent { get => fioStudent; set => fioStudent = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Parallell { get => parallell; set => parallell = value; }
        public string NumberClass { get => numberClass; set => numberClass = value; }

        public override bool Equals(object? obj)
        {
            return obj is Students students &&
                   id == students.id &&
                   fioStudent == students.fioStudent &&
                   dateOfBirth == students.dateOfBirth &&
                   parallell == students.parallell &&
                   numberClass == students.numberClass;
        }
    }
}
