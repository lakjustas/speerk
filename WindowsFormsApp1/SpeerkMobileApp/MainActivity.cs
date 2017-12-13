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
            Button VisaStatistikaButton = FindViewById<Button>(Resource.Id.Statistika);
            Button Turnyras = FindViewById<Button>(Resource.Id.BtnStartTournament);

            Pradeti.Click += delegate
            {
                StartActivity(typeof(Komandos));
            };

            VisaStatistikaButton.Click += delegate
            {
                StartActivity(typeof(VisaStatistika));
            };

            Turnyras.Click += delegate
            {
                StartActivity(typeof(TournamentTeams));
            };
        }
    }
}

