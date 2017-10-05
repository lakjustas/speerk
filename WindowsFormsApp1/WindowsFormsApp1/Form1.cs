using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Mat imgBgr = new Mat();
        VideoCapture capVideo = null;
        BallTracker ballTracker = new BallTracker();
        bool blnCapturingInProcess = false;
        bool goal, goal2;
        //Image<Gray, Byte> frame

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                capVideo = new VideoCapture("C:\\Users\\Šarūnas\\Desktop\\video.mp4");
            }
            catch (NullReferenceException except)
            {
                txtXYRadius.Text = except.Message;
                return;
            }

            Application.Idle += ProcessFrameAndUpdateGUI;
            blnCapturingInProcess = true;

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
            imgBgr = capVideo.QueryFrame();
            if (imgBgr == null) return;
            Point ballCoord = ballTracker.GetBallCoordinates(imgBgr);
            ballTracker.MarkBall(imgBgr, ballCoord);
            //-----
            Image<Gray, Byte> imgGate = imgBgr.ToImage<Bgr, Byte>().InRange(new Bgr(0, 2, 4), new Bgr(10, 20, 30));
            //-----
            
            if (txtXYRadius.Text != "") txtXYRadius.AppendText(Environment.NewLine);
            txtXYRadius.AppendText("Ball position: x= " + ballCoord.X.ToString().PadLeft(4) +
                                       "  y= " + ballCoord.Y.ToString().PadLeft(4));
            txtXYRadius.ScrollToCaret();
            //--------------------------------------------------------------------------------------------------------------------

            imgGate = imgGate.SmoothGaussian(9);
            imgGate = imgGate.SmoothBlur(9, 9);

            LineSegment2D[] lines = imgGate.HoughLinesBinary(2.5,
                                                          2.5,
                                                          2,
                                                          imgGate.Height / 4,
                                                          10)[0];
            //goal = false;
            int plusminus = 3;

            foreach (LineSegment2D line in lines)
            {
                if (txtXYRadius.Text != "") txtXYRadius.AppendText(Environment.NewLine);

                txtXYRadius.AppendText("Gates position Top =" + line.P1.ToString().PadLeft(4) +
                                       ", Bottom =" + line.P2.ToString().PadLeft(4));
                txtXYRadius.ScrollToCaret();


                CvInvoke.Line(imgBgr,
                                line.P1,
                                line.P2,
                                new MCvScalar(255, 0, 0),
                                1,
                                LineType.AntiAlias,
                                0);
                if (line.P1.X <= (ballCoord.X + plusminus) && line.P1.Y > ballCoord.Y && line.P2.Y < ballCoord.Y && goal == false)
                {
                    txtXYRadius.AppendText("GOAL!!!!--------------------------------------------------------------------");
                    txtXYRadius.ScrollToCaret();
                    goal = true;
                }

                if (line.P1.X >= (ballCoord.X - plusminus) && line.P1.Y > ballCoord.Y && line.P2.Y < ballCoord.Y && goal2 == false)
                {
                    txtXYRadius.AppendText("GOAL!!!!----------------------------------------------------------------------");
                    txtXYRadius.ScrollToCaret();
                    goal2 = true;
                }


            }
            ibOriginal.Image = imgBgr;
            //ibProcessed.Image = imgGate;
            
        }

        private void BtnPauseOrResume_Click(object sender, EventArgs e)
        {
            if (blnCapturingInProcess == true)
            {
                Application.Idle -= ProcessFrameAndUpdateGUI;
                blnCapturingInProcess = false;
                btnPauseOrResume.Text = "resume";
            }
            else
            {
                Application.Idle += ProcessFrameAndUpdateGUI;
                blnCapturingInProcess = true;
                btnPauseOrResume.Text = "pause";
            }
        }
     
    }
}
