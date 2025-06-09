using ProgramClassJournal.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists("student.json"))
            {
                MessageBox.Show("Отсутствует файл для импорта", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Students.Load();
            dataStudents.ItemsSource = App.allStudents;
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            Students.Save();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = tbSearch.Text;
            ObservableCollection<Students> ggez = new ObservableCollection<Students>(
                App.allStudents.Where(
                    c => c.FioStudent.Contains(text) ||
                    c.NumberClass.Contains(text) ||
                    (c.NumberClass + c.Parallell).Contains(text) ||
                    c.Parallell.Contains(text)
                    ).ToList());
            dataStudents.ItemsSource = ggez;
        }
    }
}
