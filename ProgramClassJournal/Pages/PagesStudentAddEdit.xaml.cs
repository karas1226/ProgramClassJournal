﻿using ProgramClassJournal.Classes;
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
    /// Логика взаимодействия для PagesStudentAddEdit.xaml
    /// </summary>
    public partial class PagesStudentAddEdit : Page
    {
        public PagesStudentAddEdit()
        {
            InitializeComponent();

            currentStudent = new Students(0, "", "", "");

            DataContext = this;
        }
        public Classes.Students currentStudent { get; set; }
        bool editOrAdd = false;
        public PagesStudentAddEdit(Classes.Students st)
        {
            InitializeComponent();
            DataContext = this;
            editOrAdd = true;
            currentStudent = st;

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currentStudent.FioStudent))
            {
                MessageBox.Show("Введите ФИО ученика");
                return;
            }
            if (string.IsNullOrWhiteSpace(currentStudent.NumberClass) && string.IsNullOrWhiteSpace(currentStudent.Parallell))
            {
                MessageBox.Show("Введите класс и параллель");
                return;
            }
            
            if (!editOrAdd)
            {
                if (App.allStudents.Any(p => p.FioStudent == currentStudent.FioStudent) && App.allStudents.Any(p => p.NumberClass == currentStudent.NumberClass) && App.allStudents.Any(p => p.Parallell == currentStudent.Parallell))
                {
                    MessageBox.Show("Такой ученик уже существует");
                    return;
                }
                if (App.allStudents.Count == 0)
                    currentStudent.Id = 1;
                else
                    currentStudent.Id = App.allStudents.OrderByDescending(c => c.Id).First().Id + 1;
                App.allStudents.Add(currentStudent);
            }
            NavigationService.Navigate(new PagesStudents());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PagesStudents());
        }
    }
}
