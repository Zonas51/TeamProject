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
    /// Логика взаимодействия для QuestionPage.xaml
    /// </summary>
    public partial class QuestionPage : Page
    {
        static List<string> questions;
        public static string question_text { get; set; } = null;
        public static string NumOfQuestonStr { get; set; } = null;
        static int NumOfQueston;
        public QuestionPage(string question, List<string> _questions, int _numofques)
        {
            question_text = question;
            questions = _questions;
            NumOfQueston = _numofques;
            NumOfQuestonStr = $"{NumOfQueston+1}/{questions.Count()}";
            DataContext = this;
            InitializeComponent();
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            if (NumOfQueston + 1 < questions.Count())
            {
                NavigationService.Navigate(new QuestionPage(questions[NumOfQueston + 1], questions, NumOfQueston + 1));
            }
            else
            {
                NavigationService.Navigate(new EndPage());
            }
        }
        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            if (NumOfQueston + 1 < questions.Count())
            {
                NavigationService.Navigate(new QuestionPage(questions[NumOfQueston + 1], questions, NumOfQueston + 1));
            }
            else
            {
                NavigationService.Navigate(new EndPage());
            }
        }
        private void UserAnswered(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new QuestionPage(questions[NumOfQueston + 1], questions, NumOfQueston + 1));
        }
    }
}
