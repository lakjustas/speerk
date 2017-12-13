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
        private readonly IBallTracker _ballTrack;
        private readonly IGateTracker _gateTrack;

        public Logic() : this(new WebServiceCall(), new Statistics(), new BallTracker(), new GateTracker())
        {
        }

        public Logic(IWebServiceCall wsc, IStatistics stat, IBallTracker ballTrack, IGateTracker gateTrack)
        {
            _wsc = wsc;
            _statistics = stat;
            _ballTrack = ballTrack;
            _gateTrack = gateTrack;
        }



        public int ImageProcessing(Mat imgBgr)
        {
            
            bool goal;
            int sk = 0;

            Point ballCoord = _ballTrack.GetBallCoordinates(imgBgr);

            LineSegment2D[] lines = _gateTrack.GetGates(imgBgr);

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
