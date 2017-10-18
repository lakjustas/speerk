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
using Emgu.CV.Cvb;
using System.Text.RegularExpressions;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Video : Form
    {
        VideoCapture capVideo = null;                  //original video source
        bool blnCapturingInProcess = false;             //check if video playing
        Image<Bgr, Byte> imgOriginal;
        Image<Gray, Byte> imgProcessed;
        
        string fileDir = "";

        public CapProp FrameWidth { get; private set; }
        public CapProp FrameHeight { get; private set; }

        //Capture capt;

        public Video()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (capVideo != null)
            {
                capVideo.Dispose();
            }
        }

        void processFrameAndUpdateGUI(object sender, EventArgs arg)
        {


            try
            {
                imgOriginal = capVideo.QueryFrame().ToImage<Bgr, Byte>();

            }
            catch (Exception)
            {
            }



            if (imgOriginal == null) return;

            imgProcessed = imgOriginal.InRange(new Bgr(0, 70, 220),
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

            gatesRecognition();


        }

        private void btnPauseOrResume_Click(object sender, EventArgs e)
        {
            if (blnCapturingInProcess == true)
            {
                Application.Idle -= processFrameAndUpdateGUI;
                blnCapturingInProcess = false;
                btnPauseOrResume.Text = "Tęsti";
            }
            else
            {
                Application.Idle += processFrameAndUpdateGUI;
                blnCapturingInProcess = true;
                btnPauseOrResume.Text = "Sustabdyti";
            }
        }

        private void button1_Click(object sender, EventArgs e)             //video file opening
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string formats = "*.MOV; *.dat; *.wmv; *.3g2; *.3gp; *.3gp2; *.3gpp; *.amv; *.asf;  *.avi; *.bin; *.cue; *.divx; *.dv; *.flv; *.gxf; *.iso; *.m1v; *.m2v; *.m2t; *.m2ts; *.m4v; " +
                      " *.mkv; *.mov; *.mp2; *.mp2v; *.mp4; *.mp4v; *.mpa; *.mpe; *.mpeg; *.mpeg1; *.mpeg2; *.mpeg4; *.mpg; *.mpv2; *.mts; *.nsv; *.nuv; *.ogg; *.ogm; *.ogv; *.ogx; *.ps; *.rec; *.rm; *.rmvb; *.tod; *.ts; *.tts; *.vob; *.vro; *.webm";

            string[] exts = formats.Split(';');
            string filter = string.Empty;
            foreach (string ext in exts)
            {

                filter += "Video Files (" + ext.Replace("*", "").Trim() + ")|" + ext + "|";
            }

            openFileDialog.Filter = filter.Remove(filter.Length - 1, 1);
            openFileDialog.ShowDialog();

            fileDir = openFileDialog.InitialDirectory + openFileDialog.FileName;

            txtXYRadius.AppendText("File:" + fileDir);
            
            try
            {
                capVideo = new VideoCapture(fileDir);               //Video playing
            }
            catch (NullReferenceException except)
            {
                txtXYRadius.Text = except.Message;
                return;
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
