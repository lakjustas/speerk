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
using System.Text.RegularExpressions;

namespace SpeerkMobileApp
{
    [Activity(Label = "Komandos")]
    public class Komandos : Activity
    {
        Matches matchStats = new Matches();

        EditText txt_Name, txt_Name2;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Komandos);

            txt_Name = FindViewById<EditText>(Resource.Id.PirmosiosKomandosPavadinimas);
            txt_Name2 = FindViewById<EditText>(Resource.Id.AntrosiosKomandosPavadinimas);

            Button Issaugoti = FindViewById<Button>(Resource.Id.Issaugoti);
            Issaugoti.Click += new EventHandler(this.Issaugoti_Click);

            Button GriztiAtgal = FindViewById<Button>(Resource.Id.GriztiAtgalKomandos);
            //GriztiAtgal.Click += new EventHandler(this.GriztiAtgal_Click);

            GriztiAtgal.Click += delegate
            {
                StartActivity(typeof(MainActivity));
            };
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

            if (txt_Name.Text != "" && txt_Name2.Text != "")
            {
                
                Intent i = new Intent(this, typeof(Zaidimas));
                
                i.PutExtra("Name", txt_Name.Text.ToString());
                i.PutExtra("Name2", txt_Name2.Text.ToString());
                                 
                StartActivity(i);
            }
           
        }

        /*private void GriztiAtgal_Click(object sender, EventArgs e)
        {
            Finish();
        }*/
    }
}