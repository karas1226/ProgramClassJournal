using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgramClassJournal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClasess_Click(object sender, RoutedEventArgs e)
        {
            Pages.PagesClasses page = new Pages.PagesClasses();
            mainFrame.Navigate(page);
        }

        private void btnOcenky_Click(object sender, RoutedEventArgs e)
        {
            Pages.PagesOcenky page = new Pages.PagesOcenky();
            mainFrame.Navigate(page);
        }

        private void btnPredmety_Click(object sender, RoutedEventArgs e)
        {
            Pages.PagesPredmety page = new Pages.PagesPredmety();
            mainFrame.Navigate(page);
        }

        private void btnTeacher_Click(object sender, RoutedEventArgs e)
        {
            Pages.PagesTeachers page = new Pages.PagesTeachers();
            mainFrame.Navigate(page);
        }

        private void btnStudents_Click(object sender, RoutedEventArgs e)
        {
            Pages.PagesStudents page = new Pages.PagesStudents();
            mainFrame.Navigate(page);
        }
    }
}