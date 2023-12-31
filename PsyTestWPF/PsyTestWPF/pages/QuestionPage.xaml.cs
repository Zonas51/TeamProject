﻿using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace PsyTestWPF.pages
{
    public partial class QuestionPage : Page
    {
        public string question_text { get; set; } = null;
        public string NumOfQuestonStr { get; set; } = null;

        private ITest CreavityTest;
        public QuestionPage(ITest _CreavityTest)
        {
            CreavityTest = _CreavityTest;
            question_text = _CreavityTest.GetCurQuestion();
            NumOfQuestonStr = $"{CreavityTest.GetNumOfQuestion() + 1}/{CreavityTest.GetQuestions().Count()}";

            DataContext = this;
            InitializeComponent();

            if (CreavityTest.GetNumOfQuestion() == 0)
            {
                BackButton.IsEnabled = false;
                BackButton.Background = Brushes.Gray;
            }
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            CreavityTest.AddAnswer(0);
            GoNextPage();
        }
        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            CreavityTest.AddAnswer(1);
            GoNextPage();
        }
        private void GoNextPage()
        {
            if (CreavityTest.GetNumOfQuestion() + 1 < CreavityTest.GetQuestions().Count())
            {
                question_text = CreavityTest.GetNextQuestion();
                this.Refresh();
            }
            else NavigationService.Navigate(new EndPage(new ExelSaver(), CreavityTest));
        }

        private void GoPrevPage()
        {
            question_text = CreavityTest.GetPrevQuestion();
            this.Refresh();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            CreavityTest.RemoveAnswer();
            GoPrevPage();
        }
        private void Refresh()
        {
            ButtonYes.IsChecked = false;
            ButtonNo.IsChecked = false;

            NumOfQuestonStr = $"{CreavityTest.GetNumOfQuestion() + 1}/{CreavityTest.GetQuestions().Count()}";
            questionTextBlock.Text = question_text;
            numOfQuesTextBlock.Text = NumOfQuestonStr;

            if (CreavityTest.GetNumOfQuestion() == 0)
            {
                BackButton.IsEnabled = false;
                BackButton.Background = Brushes.Gray;
            }
            else
            {
                BackButton.IsEnabled = true;
                BackButton.Background = (Brush)new BrushConverter().ConvertFrom("#1E2C3A");
            }
        }
    }
}
