using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

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
    }
}
