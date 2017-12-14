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
    [Activity(Label = "VisaStatistika")]
    public class VisaStatistika : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.VisaStatistika);

            Button Statistika = FindViewById<Button>(Resource.Id.VisaStatistika);

            Statistika.Click += delegate
            {
                StartActivity(typeof(Statistika));
            };

            Button KomandosStatistika = FindViewById<Button>(Resource.Id.VienosKomandosStatistika);

            KomandosStatistika.Click += delegate
            {
                StartActivity(typeof(KomStatistika));
            };

            Button GriztiAtgal = FindViewById<Button>(Resource.Id.GriztiAtgalVisaStatistika);
            
            GriztiAtgal.Click += delegate
            {
                StartActivity(typeof(MainActivity));
            };

            // Create your application here
        }
    }
} 