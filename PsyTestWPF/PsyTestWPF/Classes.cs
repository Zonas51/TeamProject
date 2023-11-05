using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Spire.Xls;
using Spire.Xls.Core;

namespace PsyTestWPF
{
    public class User : IUser
    {
        public string Name;
        public string Grade;
        List<byte> Answers;
        public User(string name, string grade, List<byte> anwers)
        {
            Name = name;
            Grade = grade;
            Answers = anwers;
        }
        public List<byte> GetAnswers()
        {
            return Answers;
        }

        public string GetGrade()
        {
            return Grade;
        }

        public string GetName()
        {
            return Name;

        }
    } 

    public class ExelSaver : ISaver
    {
       
        public void SaveResult(IUser user)
        {
            //Workbook workbookResults = new Workbook();

            //Worksheet worksheet = workbookResults.Worksheets[0];

            //foreach(int i in user.GetAnswers())
            //{
            //    worksheet.Range[i, 1].Value = $"{user.GetName()}";
            //    worksheet.Range[i, 2].Value = $"{user.GetGrade()}";
            //}

            //workbookResults.SaveToFile("Результаты.xlsx", ExcelVersion.Version2016);
        }
    }
    
    public class TxtToListConverter
    {
        public static List<string> Convert(string file_name)
        {
            List<string> auestions = new List<string>();
            StreamReader sr = new StreamReader(file_name);
           
            while (!sr.EndOfStream)
            {
                auestions.Add(sr.ReadLine());
            }

            return auestions;
        }
    }
}
