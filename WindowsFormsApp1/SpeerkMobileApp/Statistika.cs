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
    [Activity(Label = "Statistika")]
    public class Statistika : Activity
    {
        private List<Match> items;
        private ListView StatisticsListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Statistika);

            items = Make();
            

            StatisticsListView = FindViewById<ListView>(Resource.Id.StatisticsListView);
            StatsAdapter adapter = new StatsAdapter(this, items);

            StatisticsListView.Adapter = adapter;
        }

        public List<Match> Make()
        {
            Match match1 = new Match() { id = 1, teamOne = "Pirma", teamTwo = "Antra", scoreOne = 2, scoreTwo = 3 };
            Match match2 = new Match() { id = 2, teamOne = "melyna", teamTwo = "zalia", scoreOne = 4, scoreTwo = 7 };
            Match match3 = new Match() { id = 3, teamOne = "Sunys", teamTwo = "Katinai", scoreOne = 5, scoreTwo = 0 };
            List<Match> list = new List<Match>();
            list.Add(match1);
            list.Add(match2);
            list.Add(match3);

            return list;
        }
    }
}