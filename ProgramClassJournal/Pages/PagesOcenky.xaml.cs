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
    /// Логика взаимодействия для PagesOcenky.xaml
    /// </summary>
    public partial class PagesOcenky : Page
    {
        public PagesOcenky()
        {
            InitializeComponent();
            dataGridOcenky.ItemsSource = App.allOcenky;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Pages.PagesOcenkyAddEdit page = new Pages.PagesOcenkyAddEdit();
            NavigationService.Navigate(page);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Classes.Ocenky ocenky = dataGridOcenky.SelectedItem as Classes.Ocenky;
            if (ocenky != null)
            {
                Pages.PagesOcenkyAddEdit page = new Pages.PagesOcenkyAddEdit(ocenky);
                NavigationService.Navigate(page);
            }
        }
            private void btnDelete_Click(object sender, RoutedEventArgs e)
            {
                Classes.Ocenky dg = dataGridOcenky.SelectedItem as Classes.Ocenky;
                if (dg != null)
                    App.allOcenky.Remove(dg);
                dataGridOcenky.ItemsSource = null;
                dataGridOcenky.ItemsSource = App.allOcenky;
            }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            Ocenky.Load();
            dataGridOcenky.ItemsSource = App.allOcenky;
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            Ocenky.Save();
        }
    }
}
