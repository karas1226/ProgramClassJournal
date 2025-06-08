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
    /// Логика взаимодействия для PagePredmetyAddEdit.xaml
    /// </summary>
    public partial class PagePredmetyAddEdit : Page
    {
        public PagePredmetyAddEdit()
        {
            InitializeComponent();
            currentPredmet = new Predmety(0, "", "");
            DataContext = this;
            
            cmbTeacherName.ItemsSource = teacherName;


        }
        public Classes.Predmety currentPredmet { get; set; }
        bool editOrAdd = false;
        List<string> teacherName = App.allTeachers.Select(t => t.FioTeacher).ToList();
        public PagePredmetyAddEdit(Classes.Predmety pt)
        {
            InitializeComponent();
            DataContext = this;
            editOrAdd = true;
            currentPredmet = pt;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!editOrAdd)
            {

                if (App.allPredmety.Count == 0)
                    currentPredmet.Id = 1;
                else
                    currentPredmet.Id = App.allPredmety.OrderByDescending(c => c.Id).First().Id + 1;
                App.allPredmety.Add(currentPredmet);
            }
            NavigationService.Navigate(new PagesPredmety());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PagesPredmety());
        }
    } 

}
