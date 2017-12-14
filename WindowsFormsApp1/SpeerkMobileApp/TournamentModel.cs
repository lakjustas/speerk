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
    public static class TournamentModel
    {
        /*static TournamentModel()
        {
            teams = new List<string>();
            index = new int();
            forElimination = new List<string>();
        }*/

        public static List<String> teams { get; set; }
        public static int index { get; set; }

        public static List<String> forElimination = new List<string>();

        
    }
}