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
        public static ObservableCollection<Ocenky> allOcenky = new ObservableCollection<Ocenky>();
        public static ObservableCollection<Predmety> allPredmety = new ObservableCollection<Predmety>();
        public static ObservableCollection<Students> allStudents = new ObservableCollection<Students>();
        public static ObservableCollection<Teacher> allTeachers = new ObservableCollection<Teacher>();
        
    }

}
