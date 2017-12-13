using Android.App;
using Android.Widget;
using Android.OS;

namespace SpeerkMobileApp
{
    [Activity(Label = "SpeerkMobileApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button Pradeti = FindViewById<Button>(Resource.Id.Pradeti);
            Button VisaKomStatistika = FindViewById<Button>(Resource.Id.Statistika);

            Pradeti.Click += delegate
            {
                StartActivity(typeof(Komandos));
            };

            VisaKomStatistika.Click += delegate
            {
                StartActivity(typeof(VisaKomStatistika));
            };
        }
    }
}

