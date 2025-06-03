using ProgramClassJournal.Classes;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ProgramClassJournal
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ObservableCollection<ClassPage> allClasses = new ObservableCollection<ClassPage>();
        public static List<Classes.Ocenky> AllOcenky = new List<Classes.Ocenky>();
        public static List<Classes.Predmety> AllPredmety = new List<Classes.Predmety>();
        public static List<Classes.Students> AllStusents = new List<Classes.Students>();
        public static List<Classes.Teacher> AllTeachers = new List<Classes.Teacher>();
    }

}
