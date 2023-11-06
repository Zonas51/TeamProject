using PsyTestWPF.pages;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Spire.Xls.Core;

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
            PullQuestions();
            InitializeComponent();
            MainFrame.Content = new StartPage();
        }
        public static void AddAnswer(byte num)
        {
            Answers.Add(num);
        }
        public static void RemoveAnswer()
        {
            Answers.RemoveAt(Answers.Count - 1);
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
