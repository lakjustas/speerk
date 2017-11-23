using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SpeerkMobileApp
{
    class Matches
    {
        public int id { get; set; }
        public string teamOne { get; set; }
        public string teamTwo { get; set; }
        public int? scoreOne { get; set; }
        public int? scoreTwo { get; set; }
        public DateTime? date { get; set; }

    }
}