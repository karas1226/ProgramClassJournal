using ProgramClassJournal.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
using System.Xml.Linq;

namespace ProgramClassJournal.Pages
{
    /// <summary>
    /// Логика взаимодействия для PagesClassesAddEdit.xaml
    /// </summary>
    public partial class PagesClassesAddEdit : Page
    {
        public PagesClassesAddEdit()
        {
            InitializeComponent();
            
            currentClass = new ClassPage(0, "", "", "");
            
            DataContext = this;
        }
        public Classes.ClassPage currentClass { get; set; }
        bool editOrAdd = false;
        public PagesClassesAddEdit(Classes.ClassPage pc)
        {
            InitializeComponent();
            DataContext = this;
            editOrAdd = true;
            currentClass = pc;
            


        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(currentClass.ClassName))
            {
                MessageBox.Show("Введите класс");
                return;
            }
            if (string.IsNullOrWhiteSpace(currentClass.Parallel))
            {
                MessageBox.Show("Введите параллель");
                return;
            }

            if (!editOrAdd)
            {
                if (App.allClasses.Any(p => p.ClassName == currentClass.ClassName) && App.allClasses.Any(p => p.Parallel == currentClass.Parallel))
                {
                    MessageBox.Show("Предмет с таким названием уже существует");
                    return;
                }
                if (!App.allTeachers.Any(p => p.FioTeacher == currentClass.ClassTeacher))
                {
                    MessageBox.Show("Такого учителя не существует");
                    return;
                }
                    if (App.allClasses.Count == 0)
                    currentClass.Id = 1;
                else
                    currentClass.Id = App.allClasses.OrderByDescending(c => c.Id).First().Id + 1;
                App.allClasses.Add(currentClass);
            }
            NavigationService.Navigate(new PagesClasses());

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PagesClasses());
        }

    }
}
