using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PsyTestWPF.pages
{
    public partial class EndPage : Page
    {
        ISaver saveUser;
        ITest CreavityTest;
        public EndPage(ISaver saver, ITest _CreavityTest)
        {
            CreavityTest = _CreavityTest;
            saveUser = saver;
            DataContext = this;
            InitializeComponent();
        }
        private void ButtonFin_Click(object sender, RoutedEventArgs e)
        {
            int check = UserNameAndGradeCheck();
            if (check == 0)
            {
                saveUser.SaveResult(new User(UserName.Text, UserGrade.Text, CreavityTest.GetAnswers()));

                var exitWin = new ExitWindow(Analyzer.GetResult(CreavityTest.GetAnswers()));
                exitWin.Show();

                ButtonFin.IsEnabled = false;
                ButtonFin.Background = Brushes.Gray;
            }
            else
            {
                switch (check)
                {
                    case 1: errorTextBlock.Text = "Введите имя пользователя!"; break;
                    case 2: errorTextBlock.Text = "Введите группу!"; break;
                    case 3: errorTextBlock.Text = "Имя пользователя слишком длинное!"; break;
                    case 4: errorTextBlock.Text = "Название группы слишком длинное!"; break;
                }
            }
        }
        private int UserNameAndGradeCheck()
        {
            if (UserName.Text == "") return 1;
            if (UserGrade.Text == "") return 2;
            if (UserName.Text.Length > 100) return 3;
            if (UserGrade.Text.Length > 100) return 4;
            return 0;
        }
    }
}
