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
    public partial class Step1 : Page
    {
        private MainWindow mainWindow;

        public Step1(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;

            ModelComboBox.ItemsSource = new string[] { "Model A", "Model B", "Model C" };
            EngineComboBox.ItemsSource = new string[] { "1.6L", "2.0L", "3.0L" };
        }

        private void Next_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            mainWindow.Config.Model = ModelComboBox.SelectedItem?.ToString();
            mainWindow.Config.Engine = EngineComboBox.SelectedItem?.ToString();
            mainWindow.NavigateNext(new Step2(mainWindow));
        }
    }
}

