﻿using ProgramClassJournal.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProgramClassJournal
{
    /// <summary>
    /// Логика взаимодействия для OcenkyOtchet.xaml
    /// </summary>
    public partial class OcenkyOtchet : Window
    {
        public ObservableCollection<Otchet> Otchety { get; set; } = new ObservableCollection<Otchet>();
        
        public OcenkyOtchet()
        {
            InitializeComponent();
            LoadData();
            DataContext = this;
        }
        private void LoadData()
        {
            var groupedOcenky = App.allOcenky
                .GroupBy(o => new { o.StudentName, o.PredmetName })
                .Select(g => new
                {
                    StudentFIO = g.Key.StudentName,
                    PredmetName = g.Key.PredmetName,
                    AverageOcenka = g.Average(o => o.Ocenka),
                    ItogovayaOcenka = CalculatingOcenki(g.Average(o => o.Ocenka)),
                    Ocenochki = string.Join(", ", g.Select(o => o.Ocenka))
                });
            Otchety.Clear();
            foreach (var item in groupedOcenky)
            {
                Otchety.Add(new Otchet(
                    id: Otchety.Count + 1,
                    studentFIO: item.StudentFIO,
                    predmetName: item.PredmetName,
                    ocenka: item.ItogovayaOcenka
                ));
            }
            dgItog.ItemsSource = Otchety;
        }
        
       
        private int CalculatingOcenki(double average)
        {
            //ggwp фича
            if (average >= 4.5) return 5;
            if (average >= 3.5) return 4;
            if (average >= 2.5) return 3;
            return 2;
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            Ocenky.Load();
            LoadData();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            string fileName = "OcenkyOtchet.json";
            string json = JsonSerializer.Serialize(Otchety, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
            File.WriteAllText(fileName, json, Encoding.UTF8);
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = tbSearch.Text.ToLower();

            var searching = Otchety.Where(o =>
                o.StudentFIO.Contains(text) ||
                o.PredmetName.Contains(text) ||
                (int.TryParse(text, out int ocenochki) && o.Ocenka == ocenochki)
            ).ToList();

            dgItog.ItemsSource = new ObservableCollection<Otchet>(searching);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
