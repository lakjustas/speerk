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
//using Android.Net.Uri;

namespace SpeerkMobileApp
{
    [Activity(Label = "Zaidimas")]
    
    public class Zaidimas : Activity
    {
        int count = 0, count2 = 0;

        Match matchStats = new Match();
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Zaidimas);

            TextView txt_Result = FindViewById<TextView>(Resource.Id.PavadinimasPirmos);
            TextView txt_Result2 = FindViewById<TextView>(Resource.Id.PavadinimasAntros);
           
            
            //Retrieve the data using Intent.GetStringExtra method  
            string name = Intent.GetStringExtra("Name");
            string name2 = Intent.GetStringExtra("Name2");

            bool isTournament = Intent.GetBooleanExtra("tournament", false);

            matchStats.scoreOne = 0;
            matchStats.scoreTwo = 0;


            txt_Result.Text = " " + name;
            txt_Result2.Text = " " + name2;

            //var videoView = FindViewById<VideoView>(Resource.Id.videoView1);
            //var uri = Android.Net.Uri.Parse ("https://www.facebook.com/aidas.vaiksnoras/videos/2101188579906876/"); //cia idedam URL nuoroda i video
            //videoView.SetVideoURI(uri);
            //videoView.Start();

            var btnShow = FindViewById<Button>(Resource.Id.MygtukasPirmai);
            var btnShow2 = FindViewById<Button>(Resource.Id.MygtukasAntrai);

            btnShow.Click += delegate
            {
                btnShow.Text = string.Format("{0}", ++count);
                matchStats.goalOne();

            };

            btnShow2.Click += delegate
            {
                btnShow2.Text = string.Format("{0}", ++count2);
                matchStats.goalTwo();
            };

            var Baigti = FindViewById<Button>(Resource.Id.Baigti);

            Baigti.Click += delegate
            {

                matchStats.teamOne = name;
                matchStats.teamTwo = name2;
                matchStats.date = DateTime.Now;

                WebServiceCall wsc = new WebServiceCall();

                wsc.POST(matchStats);


                if (isTournament)
                {
                    bool tournamentStarted = true;
                    Intent i = new Intent(this, typeof(Tournament));
                    i.PutExtra("scoreOne", matchStats.scoreOne.Value);
                    i.PutExtra("scoreTwo", matchStats.scoreTwo.Value);
                    i.PutExtra("tStarted", tournamentStarted);
                    i.PutExtra("Name", name);
                    i.PutExtra("Name2", name2);
                    StartActivity(i);
                }

                else
                {
                    Intent i = new Intent(this, typeof(MainActivity));
                    Finish();
                    StartActivity(i);
                }

                
            };

            Button GriztiAtgal = FindViewById<Button>(Resource.Id.GriztiAtgalZaidimas);

            GriztiAtgal.Click += delegate
            {
                StartActivity(typeof(Komandos));
            };

        }
    }
}