﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace WindowsFormsApp1
{
    public class Statistics
    {
        public String name1;
        public String name2;
        public int score1;
        public int score2;
        public DateTime date;

        public Statistics()
        {
            this.date = DateTime.Now;
        }
        
        public void SetScores(int score1, int score2)
        {
            this.score1 = score1;
            this.score2 = score2;
        }
        
        public void SetScores() {} // For tests, if values ar not given

        public int getScore1()
        {
            return score1;
        }

        public int getScore2()
        {
            return score2;
        }


        public void SetNames(String name1, String name2)
        {
            this.name1 = name1;
            this.name2 = name2;
        }

        public string getName1()
        {
            return name1;
        }

        public string getName2()
        {
            return name2;
        }

        public void WriteToFile(List<Statistics> stats)
        {
            stats.Add(this);
            FileStream fileStream = new FileStream("Statistics.xml", FileMode.OpenOrCreate);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Statistics>));
            xmlSerializer.Serialize(streamWriter, stats);
            streamWriter.Close();
            fileStream.Close();
        }
    }
}
