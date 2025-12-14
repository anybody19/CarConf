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
    public partial class Step4 : Page
    {
        private MainWindow mainWindow;

        public Step4(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;
        }

        private void CalculateCredit()
        {
            if (decimal.TryParse(InitialPaymentText.Text, out decimal percent) &&
                int.TryParse(MonthsText.Text, out int months))
            {
                mainWindow.Config.InitialPaymentPercent = percent;
                mainWindow.Config.CreditMonths = months;

                decimal C = mainWindow.Config.TotalPrice();
                decimal P = C * (percent / 100);
                decimal S = C - P;
                decimal r = 12; // ставка 12% годовых
                decimal i = r / 12 / 100;
                int n = months;
                decimal A = S * (i * (decimal)Math.Pow(1 + (double)i, n)) / (decimal)(Math.Pow(1 + (double)i, n) - 1);

                mainWindow.Config.MonthlyPayment = A;
                MonthlyText.Text = $"Ежемесячный платёж: {A:F2} руб.";
            }
            else
            {
                MonthlyText.Text = "Введите корректные значения!";
            }
        }

        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            mainWindow.NavigateNext(new Step3(mainWindow));
        }

        private void Next_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CalculateCredit();
            mainWindow.NavigateNext(new Step5(mainWindow));
        }
    }
}
