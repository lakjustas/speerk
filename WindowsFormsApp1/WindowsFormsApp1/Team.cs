using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Team
    {
        private String name;
        private int score;

        public Team(String name, int score)
        {
            this.name = name;
            this.score = score;
        }

        public int Score { get => score; set => score = value; }

        public String GetName()
        {
            return name;
        }
        
        public void Goal()
        {
            score++;
        }

    }
}
