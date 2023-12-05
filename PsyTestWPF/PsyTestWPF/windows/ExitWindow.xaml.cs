using System.Windows;
using System.Windows.Input;

namespace PsyTestWPF.pages
{
    public partial class ExitWindow : Window
    {
        public static string CreavityQoutient { get; set; } = null;
        public static int ResultOfTest;
        public ExitWindow(int result_of_test)
        {
            ResultOfTest = result_of_test;
            if (ResultOfTest <= 24) CreavityQoutient = "У вас очень низкий уровень креативности";
            else if (ResultOfTest >= 25 & ResultOfTest <= 31) CreavityQoutient = "У вас низкий уровень креативности";
            else if (ResultOfTest >= 32 & ResultOfTest <= 39) CreavityQoutient = "У вас средний уровень креативности";
            else if (ResultOfTest >= 40 & ResultOfTest <= 46) CreavityQoutient = "У вас высокий уровень креативности";
            else if (ResultOfTest >= 47) CreavityQoutient = "У вас очень высокий уровень креативности";
            DataContext = this;
            InitializeComponent();
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
