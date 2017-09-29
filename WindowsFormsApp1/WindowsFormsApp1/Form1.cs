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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        VideoCapture capVideo = null;
        bool blnCapturingInProcess = false;
        Image<Bgr, Byte> imgOriginal;
        Image<Gray, Byte> imgProcessed;
        Image<Gray, Byte> imgBlack;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                capVideo = new VideoCapture("C:\\Users\\Šarūnas\\Desktop\\video.MOV");
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
            imgOriginal = capVideo.QueryFrame().ToImage<Bgr, Byte>();
            if (imgOriginal == null) return;

            imgProcessed = imgOriginal.InRange(new Bgr(0, 70, 220),
                                               new Bgr(100, 160, 256));
            /*
            imgBlack = imgOriginal.InRange(new Bgr(0, 0, 0),
                                           new Bgr(20, 20, 20));

            imgProcessed = imgProcessed.SmoothGaussian(9);

            imgBlack = imgBlack.SmoothGaussian(9);

            /*CircleF[] circles = imgProcessed.HoughCircles(new Gray(100),
                                                          new Gray(50),
                                                          2,
                                                          imgProcessed.Height / 4,
                                                          10,
                                                          400)[0];
            
            foreach (CircleF circle in circles)
            {
                if (txtXYRadius.Text != "") txtXYRadius.AppendText(Environment.NewLine);

                txtXYRadius.AppendText("ball position = x" + circle.Center.X.ToString().PadLeft(4) +
                                       ", y =" + circle.Center.Y.ToString().PadLeft(4) +
                                       ", radius =" + circle.Radius.ToString("###.000").PadLeft(7));
                txtXYRadius.ScrollToCaret();


                CvInvoke.Circle(imgOriginal,
                                new Point((int)circle.Center.X, (int)circle.Center.Y),
                                3,
                                new MCvScalar(0, 255, 0),
                                -1,
                                LineType.AntiAlias,
                                0);


                imgOriginal.Draw(circle, new Bgr(Color.Red), 3);
            }
            */

            ibOriginal.Image = imgOriginal;
            ibProcessed.Image = imgProcessed;

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
