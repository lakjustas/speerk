﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Matches
    {
        public int id { get; set; }
        public string teamOne { get; set; }
        public string teamTwo { get; set; }
        public int? scoreOne { get; set; }
        public int? scoreTwo { get; set; }
        public DateTime? date { get; set; }
    }
}
