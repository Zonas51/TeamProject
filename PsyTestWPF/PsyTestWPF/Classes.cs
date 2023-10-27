using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
          //сохранение результатов в exel
        }
    }
    
    public class TxtToListConverter
    {
        public List<byte> Convert(string file_name)
        {
            List<byte> answers = new List<byte>();
            //коневертация из файла в лист

            return answers;
        }
    }
}
