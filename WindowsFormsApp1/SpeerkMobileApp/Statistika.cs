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
        private List<Matches> items;
        private ListView StatisticsListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Statistika);

            /*Button GriztiAtgal = FindViewById<Button>(Resource.Id.GriztiAtgal);
            GriztiAtgal.Click += new EventHandler(this.GriztiAtgal_Click);*/


            items = new List<Matches>();
            

            StatisticsListView = FindViewById<ListView>(Resource.Id.StatisticsListView);
            StatsAdapter adapter = new StatsAdapter(this, items);

            StatisticsListView.Adapter = adapter;
        }

        /*private void GriztiAtgal_Click(object sender, EventArgs e)
        {
            Finish();
        }*/
    }
}