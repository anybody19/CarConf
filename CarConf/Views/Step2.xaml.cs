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
using CarConf.Models;

namespace CarConf.Views
{
    public partial class Step2 : Page
    {
        private MainWindow mainWindow;

        public Step2(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;

            ColorComboBox.ItemsSource = new string[] { "Белый", "Чёрный", "Красный", "Синий" };
        }

        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            mainWindow.NavigateNext(new Step1(mainWindow));
        }

        private void Next_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            mainWindow.Config.Color = ColorComboBox.SelectedItem?.ToString();
            mainWindow.Config.Options.Clear();
            if (Option1.IsChecked == true) mainWindow.Config.Options.Add("Кожаный салон");
            if (Option2.IsChecked == true) mainWindow.Config.Options.Add("Сигнализация");
            if (Option3.IsChecked == true) mainWindow.Config.Options.Add("Навигация");
            mainWindow.NavigateNext(new Step3(mainWindow));
        }
    }
}

