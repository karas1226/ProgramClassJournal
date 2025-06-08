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
            Classes.Teacher classPage = dataTeachers.SelectedItem as Classes.Teacher;
            if (classPage != null)
            {
                Pages.PageTeachersAddEdit page = new Pages.PageTeachersAddEdit(classPage);
                NavigationService.Navigate(page);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Classes.Teacher teacher = dataTeachers.SelectedItem as Classes.Teacher;
            if (teacher != null)
            {
                Pages.PageTeachersAddEdit page = new Pages.PageTeachersAddEdit(teacher);
                NavigationService.Navigate(page);
            }
        }
    }
}
