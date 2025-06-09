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
    /// Логика взаимодействия для PagesTeachers.xaml
    /// </summary>
    public partial class PagesTeachers : Page
    {
        public PagesTeachers()
        {
            InitializeComponent();
            dataTeachers.ItemsSource = App.allTeachers;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Pages.PageTeachersAddEdit page = new Pages.PageTeachersAddEdit();
            NavigationService.Navigate(page);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Classes.Teacher teacher = dataTeachers.SelectedItem as Classes.Teacher;
            if (teacher != null)
            {
                Pages.PageTeachersAddEdit page = new Pages.PageTeachersAddEdit(teacher);
                NavigationService.Navigate(page);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Classes.Teacher teacher = dataTeachers.SelectedItem as Classes.Teacher;
            if (teacher != null)
                App.allTeachers.Remove(teacher);
            dataTeachers.ItemsSource = null;
            dataTeachers.ItemsSource = App.allTeachers;
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists("teachers.json"))
            {
                MessageBox.Show("Отсутствует файл для импорта", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Teacher.Load();
            dataTeachers.ItemsSource = App.allTeachers;
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            Teacher.Save();

        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = tbSearch.Text;
            ObservableCollection<Teacher> ggez = new ObservableCollection<Teacher>(
                App.allTeachers.Where(
                    c => c.FioTeacher.Contains(text) ||
                    c.NamePredmety.Contains(text)
                    ).ToList());
            dataTeachers.ItemsSource = ggez;
        }
    }
}
