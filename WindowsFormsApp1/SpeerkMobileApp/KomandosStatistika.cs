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
    [Activity(Label = "KomadosStatistika")]
    public class KomandosStatistika : Activity
    {
        EditText txt_Name;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.KomandosStatistika);

            txt_Name = FindViewById<EditText>(Resource.Id.IrasytasKomandosPavadinimas);

            if (txt_Name.Text != "")
            {

                Intent i = new Intent(this, typeof(Zaidimas));

                i.PutExtra("Name", txt_Name.Text.ToString());

                StartActivity(i);
            }

            /*Button GautiStatistika = FindViewById<Button>(Resource.Id.GautiStatistika);

            GautiStatistika.Click += delegate
            {
                StartActivity(typeof(KomandosStatistika2));
            };*/
            // Create your application here
        }
    }
}