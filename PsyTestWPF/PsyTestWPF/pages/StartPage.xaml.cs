﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PsyTestWPF.pages
{
    public partial class StartPage : Page 
    {
        public StartPage()
        {
            InitializeComponent();
        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new QuestionPage(new PsyTest()));
        }
    }
}
