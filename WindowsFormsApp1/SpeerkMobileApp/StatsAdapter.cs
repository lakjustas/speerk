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
    public class StatsAdapter : BaseAdapter<Match>
    {
        private List<Match> items;
        private Activity context;
        public StatsAdapter(Activity context, List<Match> items)
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override Match this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView; // re-use an existing view, if one is available
            if (row == null) // otherwise create a new one
                row = context.LayoutInflater.Inflate(Resource.Layout.RowListView, null, false);

            /*TextView textDate = row.FindViewById<TextView>(Resource.Id.text);
            text.Text = items[position].date;
            */

            TextView textName1 = row.FindViewById<TextView>(Resource.Id.textName1);
            textName1.Text = items[position].teamOne;

            TextView textName2 = row.FindViewById<TextView>(Resource.Id.textName2);
            textName2.Text = items[position].teamTwo;

            TextView textScore1 = row.FindViewById<TextView>(Resource.Id.textScore1);
            textScore1.Text = items[position].scoreOne.ToString();

            TextView textScore2 = row.FindViewById<TextView>(Resource.Id.textScore2);
            textScore2.Text = items[position].scoreTwo.ToString();

            return row;
        }


    }
}