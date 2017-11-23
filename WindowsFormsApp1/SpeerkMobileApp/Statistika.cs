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
        private List<string> items;
        private ListView StatisticsListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Statistika);

            /*Button GriztiAtgal = FindViewById<Button>(Resource.Id.GriztiAtgal);
            GriztiAtgal.Click += new EventHandler(this.GriztiAtgal_Click);*/


            items = new List<string>();
            items.Add("Komanda");
            items.Add("Melyna");
            items.Add("Katinai");

            StatisticsListView = FindViewById<ListView>(Resource.Id.StatisticsListView);
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);

            StatisticsListView.Adapter = adapter;
        }

        /*private void GriztiAtgal_Click(object sender, EventArgs e)
        {
            Finish();
        }*/
    }
}