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
    [Activity(Label = "KomStatistika")]
    public class KomStatistika : Activity
    {
        EditText txt_Name;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.KomStatistika);

            txt_Name = FindViewById<EditText>(Resource.Id.IrasytasKomandosPavadinimas);

            Button GautiStatistika = FindViewById<Button>(Resource.Id.GautiStatistika);

            GautiStatistika.Click += delegate
            {
                if (txt_Name.Text != "")
                {

                    Intent i = new Intent(this, typeof(SuvestosKomStatistika));

                    i.PutExtra("Name", txt_Name.Text.ToString());

                    StartActivity(i);
                }
            };
            // Create your application here
        }
    }
} 