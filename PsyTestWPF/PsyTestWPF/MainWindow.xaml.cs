using PsyTestWPF.pages;
using System.Windows;
using System.Windows.Input;

namespace PsyTestWPF
{
    public partial class MainWindow : Window 
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new StartPage();
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
