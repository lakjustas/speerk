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
    [Activity(Label = "SuvestosKomStatistika")]
    public class SuvestosKomStatistika : Activity
    {
        private ListView StatisticsListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SuvestosKomStatistika);

            TextView txt_Result = FindViewById<TextView>(Resource.Id.SuvestaKomanda);

            string name = Intent.GetStringExtra("Name");

            txt_Result.Text = " " + name;

            List<Match> items = GetItems(name);

            StatisticsListView = FindViewById<ListView>(Resource.Id.TeamStatsListView);
            StatsAdapter adapter = new StatsAdapter(this, items);

            StatisticsListView.Adapter = adapter;

            // Create your application here
        }

        private List<Match> GetItems(string name)
        {
            IWebServiceCall call = new WebServiceCall();
            return call.GET(name);
        }
    }
}