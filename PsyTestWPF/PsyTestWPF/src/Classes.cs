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
    public class PsyTest :ITest 
    {
        private List<string> listQustions = new List<string>();
        private List<byte> listAnswers = new List<byte>();
        private int numOfQuestion = 0;

        public PsyTest()
        {
            PullQuestions();
        }
        public int GetNumOfQuestion()
        {
            return numOfQuestion;
        }
        public string GetCurQuestion()
        {
            return listQustions[numOfQuestion];
        }
        public string GetNextQuestion()
        {
            numOfQuestion++;
            return GetCurQuestion();
        }
        public string GetPrevQuestion()
        {
            numOfQuestion--;
            return listQustions[numOfQuestion];
        }
        public void RemoveAnswer()
        {
            listAnswers.RemoveAt(listAnswers.Count() - 1);
        }
        public void AddAnswer(byte answer)
        {
            listAnswers.Add(answer);
        }
        public List<byte> GetAnswers()
        {
            return listAnswers;
        }
        public List<string> GetQuestions()
        {
            return listQustions;
        }
        public void PullQuestions()
        {
            listQustions = TxtToListConverter.Convert("questions.txt");
        }
    }
    public class User : IUser
    {
        private string Name;
        private string Grade;
        private List<byte> Answers;
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
            Workbook workbook = new Workbook();
            if (File.Exists("Результаты.xlsx")) workbook.LoadTemplateFromFile("Результаты.xlsx");

            Worksheet worksheet = workbook.Worksheets[0];

            worksheet.InsertRow(1);
            worksheet.Range[1, 1].Value = $"{user.GetName()}";
            worksheet.Range[1, 2].Value = $"{user.GetGrade()}";
            worksheet.Range[1, 3].Value = $"{Analyzer.GetResult(user.GetAnswers())}";

            workbook.SaveToFile("Результаты.xlsx", ExcelVersion.Version2016); //TODO: make try
        }
    }

    public class TxtToListConverter
    {
        public static List<string> Convert(string file_name)
        {
            List<string> questions = new List<string>();
            string file_path = AppContext.BaseDirectory + "..\\..\\src\\" + file_name;
            StreamReader sr = new StreamReader(file_path);

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
