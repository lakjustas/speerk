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
    [Activity(Label = "Komandos")]
    public class Komandos : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Komandos);

            //Button Issaugoti = FindViewById<Button>(Resource.Id.Issaugoti);
            //Issaugoti.Click += new EventHandler(this.Issaugoti_Click);
            //Button GriztiAtgal = FindViewById<Button>(Resource.Id.GriztiAtgal);



            // Create your application here
        }
    }
}