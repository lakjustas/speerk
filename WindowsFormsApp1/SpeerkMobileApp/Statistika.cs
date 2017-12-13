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
using System.Threading.Tasks;

namespace SpeerkMobileApp
{
    [Activity(Label = "Statistika")]
    public class Statistika : Activity
    {
        private ListView StatisticsListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Statistika);

            List<Match> items = GetItemsAsync();

            Button GoBack = FindViewById<Button>(Resource.Id.GriztiAtgal);
            GoBack.Click += new EventHandler(this.GoBack_Click);

            StatisticsListView = FindViewById<ListView>(Resource.Id.StatisticsListView);
            StatsAdapter adapter = new StatsAdapter(this, items);

            StatisticsListView.Adapter = adapter;
        }

        private List<Match> GetItemsAsync()
        {
            IWebServiceCall call = new WebServiceCall();
            return  call.GET();
        }

        private void GoBack_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}