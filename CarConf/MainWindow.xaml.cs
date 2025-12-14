using System;
using CarConf.Models;
using CarConf.Views;
using System.Windows;
using System.Windows.Controls;

namespace CarConf
{
    public partial class MainWindow : Window
    {
        public CarConfiguration Config { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // ← ВОТ ЗДЕСЬ создаётся объект
            Config = new CarConfiguration();

            MainFrame.Navigate(new Step1(this));
        }

        public void NavigateNext(Page page)
        {
            MainFrame.Navigate(page);
        }
    }
}