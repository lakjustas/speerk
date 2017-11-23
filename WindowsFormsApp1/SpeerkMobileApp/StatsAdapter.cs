﻿using System;
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
    public class StatsAdapter : BaseAdapter<Matches>
    {
        private List<Matches> items;
        private Activity context;
        public StatsAdapter(Activity context, List<Matches> items) /*base(context, 0, list) */{
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override Matches this[int position]
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
                row = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null, false);
            //row.FindViewById<TextView>(Android.Resource.Id.Text1).Text = items[position];
            return row;
        }


    }
}