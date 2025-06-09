using ProgramClassJournal.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgramClassJournal.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageTeachersAddEdit.xaml
    /// </summary>
    public partial class PageTeachersAddEdit : Page
    {
        public PageTeachersAddEdit()
        {
            InitializeComponent();
            
            currentTeacher = new Teacher(0, "", "", "", false);
            DataContext = this;
        }
        bool editOrAdd = false;
        public Classes.Teacher currentTeacher { get; set; }
        
        public PageTeachersAddEdit(Classes.Teacher tc)
        {
            InitializeComponent();
            DataContext = this;
            editOrAdd = true;
            currentTeacher = tc;
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currentTeacher.FioTeacher))
            {
                MessageBox.Show("Введите ФИО учителя");
                return;
            }

            if (string.IsNullOrWhiteSpace(currentTeacher.NamePredmety))
            {
                MessageBox.Show("Введите предмет");
                return;
            }
            if ((currentTeacher.ClassTeacher == true) && (currentTeacher.NameClass == null))
            {
                MessageBox.Show("Отсутствие класса у классного руководителя невозможно");
                return;
            }
            if (!editOrAdd)
            {
                if (App.allTeachers.Any(p => p.FioTeacher == currentTeacher.FioTeacher) && App.allTeachers.Any(p => p.NameClass == currentTeacher.NameClass) && App.allTeachers.Any(p => p.NamePredmety == currentTeacher.NamePredmety))
                {
                    MessageBox.Show("Такой учитель уже существует");
                    return;
                }
                
                if (App.allTeachers.Count == 0)
                    currentTeacher.Id = 1;
                else
                    currentTeacher.Id = App.allTeachers.OrderByDescending(c => c.Id).First().Id + 1;
                App.allTeachers.Add(currentTeacher);
            }
            NavigationService.Navigate(new PagesTeachers());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PagesTeachers());
        }
    }

   
    
}
