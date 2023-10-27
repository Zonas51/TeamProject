using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsyTestWPF
{
    public  interface IUser
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
