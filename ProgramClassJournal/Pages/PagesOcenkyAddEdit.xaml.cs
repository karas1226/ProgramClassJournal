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
    /// Логика взаимодействия для PagesOcenkyAddEdit.xaml
    /// </summary>
    public partial class PagesOcenkyAddEdit : Page
    {
        public PagesOcenkyAddEdit()
        {
            InitializeComponent();
            cmbPredmetName.ItemsSource = predmetName;
            cmbTeacher.ItemsSource = teacherName;
            currentOcenky = new Ocenky(0, "", "", 0, "");
            DataContext = this;

        }
        bool editOrAdd = false;
        public Classes.Ocenky currentOcenky { get; set; }
        List<string> predmetName = App.allPredmety.Select(p => p.NamePredmet).ToList();
        List<string> teacherName = App.allTeachers.Select(t => t.FioTeacher).ToList();
        public PagesOcenkyAddEdit(Classes.Ocenky ock)
        {
            InitializeComponent();
            DataContext = this;
            editOrAdd = true;
            currentOcenky = ock;



        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currentOcenky.StudentName))
            {
                MessageBox.Show("Введите ФИО ученика");
                return;
            }
            if (string.IsNullOrWhiteSpace(currentOcenky.TeacherName))
            {
                MessageBox.Show("Введите ФИО учителя");
                return;
            }
            if (string.IsNullOrWhiteSpace(currentOcenky.PredmetName))
            {
                MessageBox.Show("Введите предмет");
                return;
            } 
            if (currentOcenky.Ocenka == 0)
            {
                MessageBox.Show("Введите оценку");
                return;
            }
            if ((currentOcenky.Ocenka >= 6))
            {
                MessageBox.Show("Введите оценку от 1 до 5");
                return;
            }
            if (!editOrAdd)
            {
                if (!App.allTeachers.Any(p => p.FioTeacher == currentOcenky.TeacherName))
                {
                    MessageBox.Show("Такого учителя не существует");
                    return;
                }
                
                if (App.allOcenky.Count == 0)
                    currentOcenky.Id = 1;
                else
                    currentOcenky.Id = App.allOcenky.OrderByDescending(c => c.Id).First().Id + 1;
                App.allOcenky.Add(currentOcenky);
            }
            NavigationService.Navigate(new PagesOcenky());
        }

        private void cmbPredmetName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            teacherName = App.allTeachers.Where(p => p.NamePredmety == cmbPredmetName.Text).Select(t => t.FioTeacher).ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PagesOcenky());
        }
    }
}
