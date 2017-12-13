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
    [Activity(Label = "Tournament")]
    public class Tournament : Activity
    {

        List<string> teams = new List<string>();
        int index = 0;
        public string teamToPlayOne { get; set; }
        public string teamToPlayTwo { get; set; }
        Boolean isTournament = true;

        //TournamentModel tModel = new TournamentModel();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (Intent.GetBooleanExtra("tStarted", false))
            {
                eliminate();

            }
            else
            {

                TournamentModel.teams = Intent.GetStringArrayListExtra("names").ToList();
                randomize();
                TournamentModel.index = 0;
                tournamentMaking();
            }

            startMatch();
            
        }
        


        public Tournament() { }

        public void randomize()
        {
            teams = teams.OrderBy(a => Guid.NewGuid()).ToList();
        }

        public void startMatch()
        {

            Intent i = new Intent(this, typeof(Zaidimas));

            i.PutExtra("Name", teamToPlayOne);
            i.PutExtra("Name2", teamToPlayTwo);
            i.PutExtra("tournament", isTournament);

            StartActivity(i);

        }

        public void tournamentMaking()
        {
            
            if (TournamentModel.index < TournamentModel.teams.Count)
            {
                teamToPlayOne = TournamentModel.teams[TournamentModel.index];

                TournamentModel.index = TournamentModel.index + 1;
                teamToPlayTwo = TournamentModel.teams[TournamentModel.index];
            }
            else
            {
                TournamentModel.index = 0;

                teamToPlayOne = TournamentModel.teams[TournamentModel.index];

                TournamentModel.index = TournamentModel.index + 1;
                teamToPlayTwo = TournamentModel.teams[TournamentModel.index];
            }
            startMatch();

        }
        public void eliminate()
        {
            int scoreOne = Intent.GetIntExtra("scoreOne", 0);
            int scoreTwo = Intent.GetIntExtra("scoreTwo", 0);
            if (scoreOne > scoreTwo)
            {
                TournamentModel.teams.RemoveAt(TournamentModel.index);
            }
            else TournamentModel.teams.RemoveAt(TournamentModel.index-1);

            if (TournamentModel.teams.Count == 1)
            {
                Console.WriteLine("tournament end! WON: " +  TournamentModel.teams[0].ToString());
                return;
            }

            tournamentMaking();

        }
    }
}