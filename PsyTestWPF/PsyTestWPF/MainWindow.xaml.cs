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
        List<string> questions = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            questions.Add("Вы не зацикливаетесь на одной стороне проблемы, а стараетесь рассмотреть все возможные варианты ее решения.");
            questions.Add("вопрос 2");
            questions.Add("вопрос 3");
            //questions = TxtToListConverter.Convert("questions.txt");
            
            MainFrame.Content = new StartPage(new QuestionPage(questions[0], questions, 0));
        }
        
    }
}
