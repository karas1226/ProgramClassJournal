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
    /// Логика взаимодействия для PagesStudents.xaml
    /// </summary>
    public partial class PagesStudents : Page
    {
        public PagesStudents()
        {
            InitializeComponent();
            dataStudents.ItemsSource = App.allStudents;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Pages.PagesStudentAddEdit page = new Pages.PagesStudentAddEdit();
            NavigationService.Navigate(page);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Classes.Students student = dataStudents.SelectedItem as Classes.Students;
            if (student != null)
            {
                Pages.PagesStudentAddEdit page = new Pages.PagesStudentAddEdit(student);
                NavigationService.Navigate(page);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Classes.Students st = dataStudents.SelectedItem as Classes.Students;
            if (st != null)
                App.allStudents.Remove(st);
            dataStudents.ItemsSource = null;
            dataStudents.ItemsSource = App.allStudents;
        }
    }
}
