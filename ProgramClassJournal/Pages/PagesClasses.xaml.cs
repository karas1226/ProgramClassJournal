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
    /// Логика взаимодействия для PagesClasses.xaml
    /// </summary>
    public partial class PagesClasses : Page
    {
        public PagesClasses()
        {
            InitializeComponent();
            dataClasses.ItemsSource = App.allClasses;
            App.allClasses.Add(new ClassPage(1, "5", "B", "Иванов Иван Иванович"));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Pages.PagesClassesAddEdit page = new Pages.PagesClassesAddEdit();
            NavigationService.Navigate(page);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassPage classPage= dataClasses.SelectedItem as Classes.ClassPage;
            if (classPage != null)
            {
                Pages.PagesClassesAddEdit page = new Pages.PagesClassesAddEdit(classPage);
                NavigationService.Navigate(page);
            }
        }
    }
}
