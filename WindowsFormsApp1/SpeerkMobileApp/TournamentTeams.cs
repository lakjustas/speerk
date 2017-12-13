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
    [Activity(Label = "Turnyro komandos")]
    public class TournamentTeams : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.TournamentTeams);

            Button Confirm = FindViewById<Button>(Resource.Id.BtnTeamNamesConfirm);
            EditText[] teamNames = new EditText[8];
            teamNames[0] = FindViewById<EditText>(Resource.Id.NameTeam1);
            teamNames[1] = FindViewById<EditText>(Resource.Id.NameTeam2);
            teamNames[2] = FindViewById<EditText>(Resource.Id.NameTeam3);
            teamNames[3] = FindViewById<EditText>(Resource.Id.NameTeam4);
            teamNames[4] = FindViewById<EditText>(Resource.Id.NameTeam5);
            teamNames[5] = FindViewById<EditText>(Resource.Id.NameTeam6);
            teamNames[6] = FindViewById<EditText>(Resource.Id.NameTeam7);
            teamNames[7] = FindViewById<EditText>(Resource.Id.NameTeam8);
        }
    }
}