using PsyTestWPF.pages;
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

namespace PsyTestWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<byte> Answers = new List<byte>();
        static List<string> Questions = new List<string>();
        public MainWindow()
        {
            Questions.Add("Вы не зацикливаетесь на одной стороне проблемы, а стараетесь рассмотреть все возможные варианты ее решения.");
            Questions.Add("вопрос 2");
            Questions.Add("вопрос 3");
            // PullQuestions();
            InitializeComponent();
            MainFrame.Content = new StartPage();
        }
        public static void AddAnswer(byte num)
        {
            Answers.Add(num);
        }
        public static List<byte> GetAnswers()
        {
            return Answers;
        }
        public static List<string> GetQuestions()
        {
            return Questions;
        }
        public static void PullQuestions()
        {
            Questions = TxtToListConverter.Convert("questions.txt");
        }
    }
}
