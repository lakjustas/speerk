using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;

namespace WindowsFormsApp1
{
    class Logic
    {
        /// <summary>
        /// 
        /// </summary>
        public static int WhatToDo(Mat imgBgr)
        {
            BallTracker ballTracker = new BallTracker();
            GateTracker gateTracker = new GateTracker();
            bool goal;
            int sk = 0;

            Point ballCoord = ballTracker.GetBallCoordinates(imgBgr);

            LineSegment2D[] lines = gateTracker.GetGates(imgBgr);

            int plusminus = 3;

            goal = false;

            foreach (LineSegment2D line in lines)
            {
                if ((line.P1.X - plusminus) <= ballCoord.X && line.P1.X >= ballCoord.X && line.P1.Y > ballCoord.Y && line.P2.Y < ballCoord.Y && goal == false && ballCoord.X > 400)
                { 
                    sk = 2;
                    goal = true;
                    break;
                }

                if ((line.P1.X + plusminus >= ballCoord.X) && line.P1.X <= ballCoord.X && line.P1.Y > ballCoord.Y && line.P2.Y < ballCoord.Y && goal == false && ballCoord.X < 400)
                {
                    sk = 1;
                    goal = true;
                    break;
                }
            }

            return sk;
        }

        /// <summary>
        /// prie esamos statistikos pridedama einamų rungtynių statistika
        /// </summary>
        /// <param name="teamLeft"></param>
        /// <param name="teamRight"></param>
        public static void DoStatistics(Team teamLeft, Team teamRight)
        {
            List<Statistics> stats;
            stats = new Statistics().GetStatistics();
            if (stats == null) stats = new List<Statistics>();

            Statistics statistics = new Statistics();
            statistics.SetNames(teamLeft.GetName(), teamRight.GetName());
            statistics.SetScores(teamLeft.Score, teamRight.Score);
            statistics.WriteToFile(stats);
        }


    }
}
