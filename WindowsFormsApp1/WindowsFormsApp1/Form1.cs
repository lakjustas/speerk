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
    public partial class Form1 : Form
    {
        enum Messages
        {
            Ivartis_kaireje, Ivartis_desineje, Laimejo_komanda_kaireje, Laimejo_komanda_Desineje, Lygiosios
        };

        Mat imgBgr = new Mat();
        VideoCapture capVideo = null;
        BallTracker ballTracker = new BallTracker();
        GateTracker gateTracker = new GateTracker();
        bool blnCapturingInProcess = false;
        Team teamLeft;
        Team teamRight;
        bool goal = false;
        String videoFileDir;
        List<Statistics> stats;

        public Form1(String name1, String name2)
        {
            InitializeComponent();

            teamLeft = new Team(name1, 0);
            teamRight = new Team(name2, 0);

            stats = new Statistics().GetStatistics();
            if (stats == null) stats = new List<Statistics>();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            teamLeftBox.AppendText(teamLeft.GetName());
            teamRightBox.AppendText(teamRight.GetName());
            leftResultBox.AppendText(teamLeft.Score.ToString());
            rightResultBox.AppendText(teamRight.Score.ToString());
        }
        
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (capVideo != null)
            {
                capVideo.Dispose();
            }
        }

        void ProcessFrameAndUpdateGUI(object sender, EventArgs arg)
        {
            
            try
            {
                imgBgr = capVideo.QueryFrame();
            }
            catch (NullReferenceException)
            {
                txtXYRadius.AppendText("Nepasirinktas failas \n");
                Application.Idle -= ProcessFrameAndUpdateGUI;
                return;
            }

            if (imgBgr == null)
            {
                MatchEnd();
                return;
            }
            

            Point ballCoord = ballTracker.GetBallCoordinates(imgBgr);
            //ballTracker.MarkBall(imgBgr, ballCoord); // pazymet kamuoliuka

            LineSegment2D[] lines = gateTracker.GetGates(imgBgr);
            //gateTracker.MarkGates(imgBgr, lines); // pazymeti vartus
            
            int plusminus = 3;

            goal = false;

            foreach (LineSegment2D line in lines)
            {
                if ((line.P1.X - plusminus) <= ballCoord.X && line.P1.X >= ballCoord.X  && line.P1.Y > ballCoord.Y && line.P2.Y < ballCoord.Y && goal == false && ballCoord.X > 400)
                {
                    Goal(teamRight);

                    string goalR = Enum.GetName(typeof(Messages), 1);

                    txtXYRadius.AppendText(goalR + "\n");
                    goal = true;
                    break;
                }

                if ((line.P1.X + plusminus >= ballCoord.X) && line.P1.X <= ballCoord.X && line.P1.Y > ballCoord.Y && line.P2.Y < ballCoord.Y && goal == false && ballCoord.X < 400)
                {
                    Goal(teamLeft);

                    string goalL = Enum.GetName(typeof(Messages), 0);

                    txtXYRadius.AppendText(goalL + "\n");
                    goal = true;
                    break;
                }
            }
            ibOriginal.Image = imgBgr;
        }

        private void GoalLeft_Click(object sender, EventArgs e)
        {
            string goalL = Enum.GetName(typeof(Messages), 0);
            txtXYRadius.AppendText(goalL + "\n");

            teamLeft.Goal();
            leftResultBox.Clear();
            leftResultBox.AppendText(teamLeft.Score.ToString());

        }

        private void GoalRight_Click(object sender, EventArgs e)
        {
            string goalR = Enum.GetName(typeof(Messages), 1);
            txtXYRadius.AppendText(goalR + "\n");

            teamRight.Goal();
            rightResultBox.Clear();
            rightResultBox.AppendText(teamRight.Score.ToString());
        }

        private void ResetGoalCounter_Click(object sender, EventArgs e)
        {
            goal = false;
        }

        private void BtnPauseOrResume_Click(object sender, EventArgs e)
        {
            if (blnCapturingInProcess == true)
            {
                Application.Idle -= ProcessFrameAndUpdateGUI;
                blnCapturingInProcess = false;
                btnPauseOrResume.Text = "Tęsti";
            }
            else
            {
                Application.Idle += ProcessFrameAndUpdateGUI;
                blnCapturingInProcess = true;
                btnPauseOrResume.Text = "Pauzė";
            }
        }

        private void Goal(Team team)
        {
            team.Goal();

            leftResultBox.Clear();
            leftResultBox.AppendText(teamLeft.Score.ToString());

            rightResultBox.Clear();
            rightResultBox.AppendText(teamRight.Score.ToString());
        }

        private void SelectGameVideo_Click(object sender, EventArgs e)
        {
            openGameVideo.ShowDialog();

            videoFileDir = openGameVideo.InitialDirectory + openGameVideo.FileName;

            try
            {
                capVideo = new VideoCapture(videoFileDir);
            }
            catch (NullReferenceException except)
            {
                txtXYRadius.Text = except.Message;
                return;
            }
        }

        void DoStatistics()
        {
            Statistics statistics = new Statistics();
            statistics.SetNames(teamLeft.GetName(), teamRight.GetName());
            statistics.SetScores(teamLeft.Score, teamRight.Score);
            statistics.WriteToFile(stats);
        }

        private void endMatchBtn_Click(object sender, EventArgs e)
        {
            MatchEnd();
            return;
        }
        private void MatchEnd()
        {
            Application.Idle -= ProcessFrameAndUpdateGUI;
            DoStatistics();
            capVideo = null;

            MessageBox.Show(teamLeft.GetName().ToString() + "  " +
                            teamLeft.Score.ToString() + " : " +
                            teamRight.Score.ToString() + "  " +
                            teamRight.GetName().ToString(),
                            "Rungtynių pabaiga",
                            MessageBoxButtons.OK);

            DialogResult dialogResult = MessageBox.Show("Grįžti i pagr. meniu?", "Rungtynių pabaiga", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                this.Close();
            }

        }
    }
}
