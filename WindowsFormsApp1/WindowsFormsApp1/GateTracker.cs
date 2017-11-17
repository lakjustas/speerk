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
    class GateTracker
    {
        /// <summary>
        /// vartu atskyrimas kadre
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        private Image<Gray, Byte> ProcessFrame(Mat img)
        {
            Image<Gray, Byte> image = img.ToImage<Bgr, Byte>().InRange(new Bgr(0, 2, 4), new Bgr(10, 20, 30));

            image = image.SmoothGaussian(9);
            image = image.SmoothBlur(9, 9);

            return image;
        }

        /// <summary>
        /// randamos linijos kurios yra vartų plote
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public LineSegment2D[] GetGates(Mat img)
        {
            Image<Gray, Byte> imgProc = ProcessFrame(img);

            LineSegment2D[] lines = imgProc.HoughLinesBinary(2.5,
                                                             2.5,
                                                             2,
                                                             imgProc.Height / 4,
                                                             10)[0];

            return lines;
        }

        /// <summary>
        /// pažymimi vartai kadre
        /// </summary>
        /// <param name="img"></param>
        /// <param name="lines"></param>
        /// <returns></returns>
        public Mat MarkGates(Mat img, LineSegment2D[] lines)
        {
            foreach (LineSegment2D line in lines)
            {
                CvInvoke.Line(img,
                              line.P1,
                              line.P2,
                              new MCvScalar(255, 0, 0),
                              1,
                              LineType.AntiAlias,
                              0);

            }

            return img;
        }

    }
}
