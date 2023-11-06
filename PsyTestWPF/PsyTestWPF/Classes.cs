using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            Workbook workbookResults = new Workbook();

            Worksheet worksheet = workbookResults.Worksheets[0];

            worksheet.Range[1, 1].Value = $"{user.GetName()}";
            worksheet.Range[1, 2].Value = $"{user.GetGrade()}"; 
            worksheet.Range[1, 3].Value = $"{Analyzer.GetResult(user.GetAnswers())}";

            workbookResults.SaveToFile("Результаты.xlsx", ExcelVersion.Version2016);
        }
    }
    
    public class TxtToListConverter
    {
        public static List<string> Convert(string file_name)
        {
            List<string> questions = new List<string>();
            StreamReader sr = new StreamReader(file_name);
           
            while (!sr.EndOfStream)
            {
                string str = sr.ReadLine();
                str = str.Remove(0, 3).Trim();
                questions.Add(str);
            }

            return questions;
        }

        
    }
    public class Analyzer
    {
        public static int GetResult(List<byte> answers)
        {
            int result = 0;
            List<int> AnswersNO = new List<int> { 4, 5, 6, 16, 20, 28, 33, 35, 36 };
            for (int i = 0; i < answers.Count(); i++)
            {
                if (AnswersNO.Contains(i))
                {
                    if (answers[i] == 0)
                    {
                        result++;
                    }
                }
                else
                {
                    if (answers[i] == 1)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

    }
}
