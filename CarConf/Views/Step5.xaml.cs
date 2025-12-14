using CarConf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CarConf.Views
{
    public partial class Step5 : Page
    {
        private MainWindow mainWindow;

        public Step5(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;
            UpdateSummary();
        }

        private void UpdateSummary()
        {
            SummaryText.Text =
                $"Вы выбрали: {mainWindow.Config.Model}, {mainWindow.Config.Engine}, {mainWindow.Config.Color}, " +
                $"Опции: {string.Join(", ", mainWindow.Config.Options)}\n" +
                $"Итоговая стоимость: {mainWindow.Config.TotalPrice()} руб.\n" +
                $"Ежемесячный платёж: {mainWindow.Config.MonthlyPayment:F2} руб.";
        }

        private bool Validate()
        {
            bool valid = !string.IsNullOrWhiteSpace(NameText.Text)
                         && Regex.IsMatch(PhoneText.Text, @"^\d+$")
                         && Regex.IsMatch(EmailText.Text, @"^\S+@\S+\.\S+$");
            SubmitBtn.IsEnabled = valid;
            return valid;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                mainWindow.Config.Name = NameText.Text;
                mainWindow.Config.Phone = PhoneText.Text;
                mainWindow.Config.Email = EmailText.Text;

                MessageBox.Show("Заявка оформлена!\nСпасибо!", "Успех");
                Application.Current.Shutdown();
            }
            else
            {
                MessageBox.Show("Проверьте введённые данные!", "Ошибка");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigateNext(new Step4(mainWindow));
        }
    }
}
