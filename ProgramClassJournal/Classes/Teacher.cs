using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramClassJournal.Classes
{
    public class Teacher
    {
        private int id;
        private string fioTeacher;
        private string namePredmety;
        private string nameClass;
        private bool classTeacher;

        public Teacher(int id, string fioTeacher, string namePredmety, string nameClass, bool classTeacher)
        {
            this.id = id;
            this.fioTeacher = fioTeacher;
            this.namePredmety = namePredmety;
            this.nameClass = nameClass;
            this.classTeacher = classTeacher;
        }

        public int Id { get => id; set => id = value; }
        public string FioTeacher { get => fioTeacher; set => fioTeacher = value; }
        public string NamePredmety { get => namePredmety; set => namePredmety = value; }
        public string NameClass { get => nameClass; set => nameClass = value; }
        public bool ClassTeacher { get => classTeacher; set => classTeacher = value; }

        public override bool Equals(object? obj)
        {
            return obj is Teacher teacher &&
                   id == teacher.id &&
                   fioTeacher == teacher.fioTeacher &&
                   namePredmety == teacher.namePredmety &&
                   nameClass == teacher.nameClass &&
                   classTeacher == teacher.classTeacher;
        }
    }

}
