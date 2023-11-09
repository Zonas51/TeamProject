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

namespace PsyTestWPF.pages
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
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
        private void DELETE_THIS(object sender, RoutedEventArgs e) //TODO: удалить после завршения проекта
        {
            NavigationService.Navigate(new EndPage(new ExelSaver(), new PsyTest()));
        }
    }
}
