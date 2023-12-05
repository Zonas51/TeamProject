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
            if (UserName.Text != "" && UserGrade.Text != "")
            {
                saveUser.SaveResult(new User(UserName.Text, UserGrade.Text, CreavityTest.GetAnswers()));

                var exitWin = new ExitWindow(Analyzer.GetResult(CreavityTest.GetAnswers()));
                exitWin.Show();

                ButtonFin.IsEnabled = false;
                ButtonFin.Background = Brushes.Gray;
            }
            else errorTextBlock.Text = "Введите имя пользователя и группу!";
        }
    }
}
