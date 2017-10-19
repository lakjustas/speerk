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

using System.Xml.Serialization;

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

            /*try
            {
                capVideo = new VideoCapture("C:\\Users\\Šarūnas\\Desktop\\video.mp4");
            }
            catch (NullReferenceException except)
            {
                txtXYRadius.Text = except.Message;
                return;
            }*/

            teamLeftBox.AppendText(teamLeft.GetName() + "" + teamLeft.Score.ToString());
            teamRightBox.AppendText(teamRight.GetName() + "" + teamRight.Score.ToString());

            /*Application.Idle += ProcessFrameAndUpdateGUI;
            blnCapturingInProcess = true;*/

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
                txtXYRadius.AppendText("File not chosen");
                Application.Idle -= ProcessFrameAndUpdateGUI;
                return;
            }

            if (imgBgr == null)
            {
                MessageBox.Show("Match ended", "End", MessageBoxButtons.OK);
                Application.Idle -= ProcessFrameAndUpdateGUI;
                DoStatistics();
                return;
            }
            

            Point ballCoord = ballTracker.GetBallCoordinates(imgBgr);
            ballTracker.MarkBall(imgBgr, ballCoord);

            LineSegment2D[] lines = gateTracker.GetGates(imgBgr);
            gateTracker.MarkGates(imgBgr, lines);
            
            /*if (txtXYRadius.Text != "") txtXYRadius.AppendText(Environment.NewLine);
            txtXYRadius.AppendText("Ball position: x= " + ballCoord.X.ToString().PadLeft(4) +
                                       "  y= " + ballCoord.Y.ToString().PadLeft(4));
            txtXYRadius.ScrollToCaret();*/
            
            int plusminus = 3;

            goal = false;

            foreach (LineSegment2D line in lines)
            {
                /*if (txtXYRadius.Text != "") txtXYRadius.AppendText(Environment.NewLine);

                txtXYRadius.AppendText("Gates position Top =" + line.P1.ToString().PadLeft(4) +
                                       ", Bottom =" + line.P2.ToString().PadLeft(4));
                txtXYRadius.ScrollToCaret();*/


                if ((line.P1.X - plusminus) <= ballCoord.X && line.P1.X >= ballCoord.X  && line.P1.Y > ballCoord.Y && line.P2.Y < ballCoord.Y && goal == false && ballCoord.X > 400)
                {
                    Goal(teamRight);

                    string goalR = Enum.GetName(typeof(Messages), 1);

                    txtXYRadius.AppendText(goalR + "\n");
                    txtXYRadius.ScrollToCaret();
                    goal = true;
                    break;
                }

                if ((line.P1.X + plusminus >= ballCoord.X) && line.P1.X <= ballCoord.X && line.P1.Y > ballCoord.Y && line.P2.Y < ballCoord.Y && goal == false && ballCoord.X < 400)
                {
                    Goal(teamLeft);

                    string goalL = Enum.GetName(typeof(Messages), 0);

                    txtXYRadius.AppendText(goalL + "\n");
                    txtXYRadius.ScrollToCaret();
                    goal = true;
                    break;
                }
            }
            ibOriginal.Image = imgBgr;
        }

        private void GoalLeft_Click(object sender, EventArgs e)
        {
            teamLeft.Goal();
            teamLeftBox.Clear();
            teamLeftBox.AppendText(teamLeft.GetName() + ": " + teamLeft.Score.ToString());
        }

        private void GoalRight_Click(object sender, EventArgs e)
        {
            teamRight.Goal();
            teamRightBox.Clear();
            teamRightBox.AppendText(teamRight.GetName() + ": " + teamRight.Score.ToString());
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

            teamRightBox.Clear();
            teamRightBox.AppendText(teamRight.GetName() + ": " + teamRight.Score.ToString());

            teamLeftBox.Clear();
            teamLeftBox.AppendText(teamLeft.GetName() + ": " + teamLeft.Score.ToString());
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

        void GetStatistics()
        {
            /*/-----------
            FileStream fileStream;
            try
            {
                fileStream = new FileStream("Statistics.xml", FileMode.Open);
            }
            catch (FileNotFoundException)
            {
                return;
            }
            StreamReader streamReader = new StreamReader(fileStream);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Statistics>));
            stats = (List<Statistics>) xmlSerializer.Deserialize(fileStream);
            fileStream.Close();
            streamReader.Close();
            foreach(Statistics s in stats)
            {
                txtXYRadius.AppendText(s.name1 + " " + s.name2 + " " + s.score1.ToString() + " " + s.score2.ToString() + " " + s.date.ToString());
                txtXYRadius.ScrollToCaret();
            }*/
        }

        void teamLeftBox_TextChanged(object sender, EventArgs e)
        {



        }
    }
}
