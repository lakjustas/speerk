using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;

namespace WindowsFormsApp1
{
    class BallTracker: IBallTracker
    {
        private int iLowH = 0;
        private int iHighH = 15;

        private int iLowS = 160;
        private int iHighS = 250;

        private int iLowV = 180;
        private int iHighV = 255;

        /// <summary>
        /// kamuoliuko išryškinimas kadre
        /// </summary>
        /// <param name="imgBgr"></param>
        /// <returns></returns>
        public Mat ProcessFrame(Mat imgBgr)
        {
            Mat imgHsv = new Mat();
            Mat imgProc = new Mat();

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

            return imgProc;

        }
        
        /// <summary>
        /// Kamuoliuko žymėjimas kadre
        /// </summary>
        /// <param name="img"></param>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        public Mat MarkBall(Mat img, Point coordinates)
        {
            CvInvoke.Circle(img, coordinates, 3, new MCvScalar(0, 255, 0), -1, LineType.AntiAlias, 0);

            return img;
        }

        /// <summary>
        /// Suskaičiuojamos kamuoliuko koordinatės
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public Point GetBallCoordinates(Mat img)
        {
            MCvMoments moments = CvInvoke.Moments(ProcessFrame(img));
            double dM01 = moments.M01;
            double dM10 = moments.M10;
            double dArea = moments.M00;

            int posX = (int)(dM10 / dArea);
            int posY = (int)(dM01 / dArea);

            return new Point(posX, posY);
        }
            
    }
}
