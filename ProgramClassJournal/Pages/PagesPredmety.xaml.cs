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
    /// Логика взаимодействия для PagesPredmety.xaml
    /// </summary>
    public partial class PagesPredmety : Page
    {
        public PagesPredmety()
        {
            InitializeComponent();
            dataPredmety.ItemsSource = App.allPredmety;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Pages.PagePredmetyAddEdit page = new Pages.PagePredmetyAddEdit();
            NavigationService.Navigate(page);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Classes.Predmety predmety = dataPredmety.SelectedItem as Classes.Predmety;
            if (predmety != null)
            {
                Pages.PagePredmetyAddEdit page = new Pages.PagePredmetyAddEdit(predmety);
                NavigationService.Navigate(page);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Classes.Predmety pt = dataPredmety.SelectedItem as Classes.Predmety;
            if (pt != null)
                App.allPredmety.Remove(pt);
            dataPredmety.ItemsSource = null;
            dataPredmety.ItemsSource = App.allClasses;
        }
    }
}
