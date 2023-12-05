using System.Collections.Generic;

namespace PsyTestWPF
{
    public interface ITest
    {
        int GetNumOfQuestion();

        string GetCurQuestion();
        string GetNextQuestion();
        string GetPrevQuestion();

        void RemoveAnswer();
        void AddAnswer(byte answer);
        void PullQuestions();

        List<byte> GetAnswers();
        List<string> GetQuestions();
       
    }
    public interface IUser
    {
        string GetName();
        string GetGrade();
        List<byte> GetAnswers();
    }

    public interface ISaver
    {
        void SaveResult(IUser user);
    }
}
