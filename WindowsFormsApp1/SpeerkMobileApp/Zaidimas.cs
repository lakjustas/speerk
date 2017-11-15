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
    [Activity(Label = "Zaidimas")]
    public class Zaidimas : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Zaidimas);

            var videoView = FindViewById<VideoView>(Resource.Id.videoView1);


            // Create your application here
        }
    }
}