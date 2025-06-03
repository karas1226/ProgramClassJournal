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
            pgclass = true;
            currentClass = new ClassPage(0, "", "", "");
            currentClass = new Classes.ClassPage(1, "5", "B", "Иванов Иван Иванович");
        }
        private Classes.ClassPage currentClass;
        ClassPage classpg;
        bool pgclass;
        public PagesClassesAddEdit (ClassPage pc)
        {
            InitializeComponent();
            pgclass = false;
            currentClass = pc;
            tbNumber.Text = classpg.ClassName;
            tbParallel.Text = classpg.Parallel;
            tbTeacher.Text = classpg.ClassTeacher;


        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (currentClass.Id == 0) 
            {
                string classNumber = tbNumber.Text;
                string parallelClass = tbParallel.Text;
                string teacherCls = tbTeacher.Text;
                currentClass = new Classes.ClassPage(classNumber, parallelClass teacherCls);
            }
           
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PagesClasses());
        }
     
}
