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
    public partial class Step3 : Page
    {
        private MainWindow mainWindow;

        public Step3(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;
            CalculatePrices();
        }

        private void CalculatePrices()
        {
            mainWindow.Config.BasePrice = mainWindow.Config.Model switch
            {
                "Model A" => 1000000,
                "Model B" => 1200000,
                "Model C" => 1500000,
                _ => 0
            };

            mainWindow.Config.EnginePrice = mainWindow.Config.Engine switch
            {
                "1.6L" => 0,
                "2.0L" => 100000,
                "3.0L" => 200000,
                _ => 0
            };

            mainWindow.Config.ColorPrice = mainWindow.Config.Color switch
            {
                "Белый" => 0,
                "Чёрный" => 5000,
                "Красный" => 10000,
                "Синий" => 10000,
                _ => 0
            };

            mainWindow.Config.OptionsPrice = mainWindow.Config.Options.Count * 20000;

            SummaryText.Text =
                $"Модель: {mainWindow.Config.Model} ({mainWindow.Config.BasePrice} руб.)\n" +
                $"Двигатель: {mainWindow.Config.Engine} ({mainWindow.Config.EnginePrice} руб.)\n" +
                $"Цвет: {mainWindow.Config.Color} ({mainWindow.Config.ColorPrice} руб.)\n" +
                $"Опции: {string.Join(", ", mainWindow.Config.Options)} ({mainWindow.Config.OptionsPrice} руб.)\n" +
                $"Итоговая стоимость: {mainWindow.Config.TotalPrice()} руб.";
        }

        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            mainWindow.NavigateNext(new Step2(mainWindow));
        }

        private void Next_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            mainWindow.NavigateNext(new Step4(mainWindow));
        }
    }
}
