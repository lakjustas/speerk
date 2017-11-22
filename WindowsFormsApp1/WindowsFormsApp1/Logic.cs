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
    public class Logic
    {
        /// <summary>
        /// 
        /// </summary>
        /// 


        private readonly IWebServiceCall _wsc;
        private readonly IStatistics _statistics;

        public Logic() : this(new WebServiceCall(), new Statistics())
        {
        }

        public Logic(IWebServiceCall wsc, IStatistics stat)
        {
            _wsc = wsc;
            _statistics = stat;
        }



        public int ImageProcessing(Mat imgBgr)
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
        public void DoStatistics(Team teamLeft, Team teamRight)
        {

            _statistics.GetDate();
            _statistics.SetNames(teamLeft.GetName(), teamRight.GetName());
            _statistics.SetScores(teamLeft.Score, teamRight.Score);

            _wsc.POST(_statistics);


        }


    }
}
