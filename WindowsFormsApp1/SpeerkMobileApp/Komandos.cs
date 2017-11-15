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
using System.Text.RegularExpressions;

namespace SpeerkMobileApp
{
    [Activity(Label = "Komandos")]
    public class Komandos : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Komandos);

            Button Issaugoti = FindViewById<Button>(Resource.Id.Issaugoti);
            Issaugoti.Click += new EventHandler(this.Issaugoti_Click);
            Button GriztiAtgal = FindViewById<Button>(Resource.Id.GriztiAtgal);
            GriztiAtgal.Click += new EventHandler(this.GriztiAtgal_Click);
        }

        private void Issaugoti_Click(object sender, EventArgs e)
        {
            if((((EditText)FindViewById(Resource.Id.PirmosiosKomandosPavadinimas)).Text == string.Empty))
            {
                Toast.MakeText(Application.Context, "Įveskite pirmosios komandos pavadinimą", ToastLength.Long).Show();
                return;
            }

            if(!Regex.IsMatch(((EditText)FindViewById(Resource.Id.PirmosiosKomandosPavadinimas)).Text, @"^[a-zA-Z0-9 ]*$"))
            {
                Toast.MakeText(Application.Context, "Pavadinime gali būti tik raidės, skaičiai bet tarpai", ToastLength.Long).Show();
                return;
            }

            if ((((EditText)FindViewById(Resource.Id.AntrosiosKomandosPavadinimas)).Text == string.Empty))
            {
                Toast.MakeText(Application.Context, "Įveskite antrosios komandos pavadinimą", ToastLength.Long).Show();
                return;
            }

            if (!Regex.IsMatch(((EditText)FindViewById(Resource.Id.AntrosiosKomandosPavadinimas)).Text, @"^[a-zA-Z0-9 ]*$"))
            {
                Toast.MakeText(Application.Context, "Pavadinime gali būti tik raidės, skaičiai bet tarpai", ToastLength.Long).Show();
                return;
            }

            StartActivity(typeof(Zaidimas));
        }

        private void GriztiAtgal_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}