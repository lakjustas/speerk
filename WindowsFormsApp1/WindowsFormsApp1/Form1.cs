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
        VideoCapture capWebcam = null;
        bool blnCapturingInProcess = false;
        Image<Bgr, Byte> imgOriginal;
        Image<Gray, Byte> imgProcessed;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                capWebcam = new VideoCapture();
            }
            catch (NullReferenceException except)
            {
                txtXYRadius.Text = except.Message;
                return;
            }

            Application.Idle += processFrameAndUpdateGUI;
            blnCapturingInProcess = true;

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (capWebcam != null)
            {
                capWebcam.Dispose();
            }
        }

        void processFrameAndUpdateGUI(object sender, EventArgs arg)
        {
            imgOriginal = capWebcam.QueryFrame().ToImage<Bgr, Byte>();
            if (imgOriginal == null) return;

            imgProcessed = imgOriginal.InRange(new Bgr(0, 70, 175),
                                               new Bgr(100, 160, 256));

            imgProcessed = imgProcessed.SmoothGaussian(9);

            CircleF[] circles = imgProcessed.HoughCircles(new Gray(100),
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

            ibOriginal.Image = imgOriginal;
            ibProcessed.Image = imgProcessed;

        }

        private void btnPauseOrResume_Click(object sender, EventArgs e)
        {
            if (blnCapturingInProcess == true)
            {
                Application.Idle -= processFrameAndUpdateGUI;
                blnCapturingInProcess = false;
                btnPauseOrResume.Text = "resume";
            }
            else
            {
                Application.Idle += processFrameAndUpdateGUI;
                blnCapturingInProcess = true;
                btnPauseOrResume.Text = "pause";
            }
        }
    }
}
