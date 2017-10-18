using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Statistics
    {
        private String name1;
        private String name2;
        private int Score1;
        private int Score2;
        private DateTime date;

        public Statistics()
        {
            this.date = DateTime.Today;
        }
        
        public void SetScores(int score1, int score2)
        {
            this.Score1 = score1;
            this.Score2 = score2;
        }

        public void SetNames(String name1, String name2)
        {
            this.name1 = name1;
            this.name2 = name2;
        }

        public void WriteToFile()
    }
}
