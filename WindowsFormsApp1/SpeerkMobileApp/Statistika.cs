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

            items = GetItems();
            

            StatisticsListView = FindViewById<ListView>(Resource.Id.StatisticsListView);
            StatsAdapter adapter = new StatsAdapter(this, items);

            StatisticsListView.Adapter = adapter;
        }

        public List<Match> GetItems()
        {
            IWebServiceCall call = new WebServiceCall();
            return call.GET();
        }
    }
}