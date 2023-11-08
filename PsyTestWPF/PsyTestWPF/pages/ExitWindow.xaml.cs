﻿using System;
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
using System.Windows.Shapes;

namespace PsyTestWPF.pages
{
    /// <summary>
    /// Логика взаимодействия для ExitWindow.xaml
    /// </summary>
    public partial class ExitWindow : Window
    {
        public static string CreavityQoutient { get; set; } = null;
        public static int ResultOfTest;
        public ExitWindow(User user)
        {
            

            ResultOfTest = Analyzer.GetResult(user.GetAnswers());
            if (ResultOfTest <= 24) CreavityQoutient = "У вас очень низкий уровень креативности";
            else if (ResultOfTest >= 25 & ResultOfTest <= 31) CreavityQoutient = "У вас низкий уровень креативности";
            else if (ResultOfTest >= 32 & ResultOfTest <= 39) CreavityQoutient = "У вас средний уровень креативности";
            else if (ResultOfTest >= 40 & ResultOfTest <= 46) CreavityQoutient = "У вас высокий уровень креативности";
            else if (ResultOfTest >= 47) CreavityQoutient = "У вас очень высокий уровень креативности";
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
