using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public interface IStatistics
    {
        DateTime GetDate();

        void SetScores(int score1, int score2);

        void SetScores();

        int getScore1();

        int getScore2();

        void SetNames(String name1, String name2);

        string getName1();

        string getName2();

        void WriteToFile(List<Statistics> stats);

        List<Statistics> GetStatistics();
    }
}
