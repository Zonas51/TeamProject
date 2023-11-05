using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
    /// Логика взаимодействия для EndPage.xaml
    /// </summary>
    public partial class EndPage : Page
    {
        public EndPage()
        {
            InitializeComponent();
        }

        private void ButtonFin_Click(object sender, RoutedEventArgs e)
        {
            //ExelSaver saveUser = new ExelSaver();
            //saveUser.SaveResult();
            Workbook workbookResults = new Workbook();

            Worksheet worksheet = workbookResults.Worksheets[0];


            worksheet.Range[1, 1].Value = "Петя";
            worksheet.Range[1, 2].Value = "15 лет";

            workbookResults.SaveToFile("Результаты.xlsx", ExcelVersion.Version2016);
            App.Current.Shutdown();
        }
    }
}
