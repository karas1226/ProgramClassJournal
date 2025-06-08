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
            cmbPredmet.ItemsSource = predmetName;
            
            currentTeacher = new Teacher(0, "", "", "", false);
            DataContext = this;
        }
        bool editOrAdd = false;
        public Classes.Teacher currentTeacher { get; set; }
        List<string> predmetName = App.allPredmety.Select(p => p.NamePredmet).ToList();
        public PageTeachersAddEdit(Classes.Teacher tc)
        {
            InitializeComponent();
            DataContext = this;
            editOrAdd = true;


            DataContext = this;
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!editOrAdd)
            {

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
