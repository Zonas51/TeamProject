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
    public partial class QuestionPage : Page
    {
        static List<string> questions;
        public static string question_text { get; set; } = null;
        public static string NumOfQuestonStr { get; set; } = null;
        static int NumOfQueston;
        public QuestionPage(int _numofques)
        {
            questions = MainWindow.GetQuestions();
            question_text = questions[_numofques];
            NumOfQueston = _numofques;
            NumOfQuestonStr = $"{NumOfQueston + 1}/{questions.Count()}";

            DataContext = this;
            InitializeComponent();

            if (_numofques == 0)
            {
                BackButton.IsEnabled = false;
                BackButton.Background = Brushes.Gray;
            }
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AddAnswer(0);
            GoNextPage();
        }
        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AddAnswer(1);
            GoNextPage();
        }
        private void GoNextPage()
        {
            if (NumOfQueston + 1 < questions.Count())
            {
                NavigationService.Navigate(new QuestionPage(NumOfQueston + 1));
            }
            else NavigationService.Navigate(new EndPage(""));
        }

        private void GoPrevPage()
        {
            if (NumOfQueston != 0)
            {
                NavigationService.Navigate(new QuestionPage(NumOfQueston - 1));
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.RemoveAnswer();
            GoPrevPage();
        }
    }
}
