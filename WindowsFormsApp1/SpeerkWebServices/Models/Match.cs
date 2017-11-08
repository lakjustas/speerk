using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeerkWebServices.Models
{
    public class Match
    {
        public int ID { get; set; }

        public string name1 { get; set; }

        public string name2 { get; set; }

        public int score1 { get; set; }

        public int score2 { get; set; }

        public DateTime date { get; set; }

    }
}