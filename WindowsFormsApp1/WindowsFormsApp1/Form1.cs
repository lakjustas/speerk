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
        Mat imgHsv = new Mat();
        Mat imgProc = new Mat();
        VideoCapture capVideo = null;
        bool blnCapturingInProcess = false;
        Image<Gray, Byte> frame;

        int iLowH = 0;
        int iHighH = 15;

        int iLowS = 160;
        int iHighS = 250;

        int iLowV = 180;
        int iHighV = 255;


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
            CvInvoke.CvtColor(imgBgr, imgHsv, ColorConversion.Bgr2Hsv);

            CvInvoke.InRange(imgHsv, 
                             new ScalarArray(new MCvScalar(iLowH, iLowS, iLowV)), 
                             new ScalarArray(new MCvScalar(iHighH, iHighS, iHighV)), 
                             imgProc);

            CvInvoke.GaussianBlur(imgProc, imgProc, new Size(5, 5), 1, 0, BorderType.Default);

            Mat element = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));

            CvInvoke.Erode(imgProc, imgProc, element, new Point(-1, -1), 1, BorderType.Constant, default(MCvScalar));
            CvInvoke.Dilate(imgProc, imgProc, element, new Point(-1, -1), 1, BorderType.Constant, default(MCvScalar));
            CvInvoke.Dilate(imgProc, imgProc, element, new Point(-1, -1), 1, BorderType.Constant, default(MCvScalar));
            CvInvoke.Erode(imgProc, imgProc, element, new Point(-1, -1), 1, BorderType.Constant, default(MCvScalar));

            MCvMoments moments = CvInvoke.Moments(imgProc);

            double dM01 = moments.M01;
            double dM10 = moments.M10;
            double dArea = moments.M00;

            CvInvoke.Circle(imgBgr, new Point((int)(dM10 / dArea), (int)(dM01 / dArea)), 3, new MCvScalar(0, 255, 0), -1, LineType.AntiAlias, 0);


            //CvInvoke.Circle(imgBgr, new Point(posX, posY), 30, new MCvScalar(0, 0, 255), 3);
            /*VectorOfVectorOfPoint cntr = new VectorOfVectorOfPoint();

            CvInvoke.FindContours(imgProc, cntr, new Mat() , RetrType.Ccomp, ChainApproxMethod.ChainApproxNone, default(Point));
            Console.WriteLine(cntr.Size.ToString());*/
            //CircleF circles =  CvInvoke.MinEnclosingCircle(cntr);


            /*CircleF[] circles = CvInvoke.HoughCircles(imgProc, HoughType.Gradient, 1, 3);
            frame = imgProc.ToImage<Gray, Byte>();

            CircleF[] circles = frame.HoughCircles(new Gray(100),
                                                          new Gray(50),
                                                          2,
                                                          frame.Height / 4,
                                                          10,
                                                          400)[0];

            foreach (CircleF circle in circles)
            {
                if (txtXYRadius.Text != "") txtXYRadius.AppendText(Environment.NewLine);

                txtXYRadius.AppendText("ball position = x" + circle.Center.X.ToString().PadLeft(4) +
                                       ", y =" + circle.Center.Y.ToString().PadLeft(4) +
                                       ", radius =" + circle.Radius.ToString("###.000").PadLeft(7));
                txtXYRadius.ScrollToCaret();


                CvInvoke.Circle(imgBgr,
                                new Point((int)circle.Center.X, (int)circle.Center.Y),
                                3,
                                new MCvScalar(0, 255, 0),
                                -1,
                                LineType.AntiAlias,
                                0);


                //imgOriginal.Draw(circle, new Bgr(Color.Red), 3);
                CvInvoke.Circle(imgBgr, new Point((int)circle.Center.X, (int)circle.Center.Y), 30, new MCvScalar(0, 0, 255), 3);
            }*/


            ibOriginal.Image = imgBgr;
            ibProcessed.Image = imgProc;
            
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
