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

        void gatesRecognition()
        {

            Image<Hsv, Byte> imgOriginalHsv;
            Image<Hsv, Byte> imgProcessedHsv;

            try
            {
                imgOriginal = capVideo.QueryFrame().ToImage<Bgr, Byte>();

            }
            catch (Exception)
            {
            }

            try
            {
                imgOriginalHsv = capVideo.QueryFrame().ToImage<Hsv, Byte>();

            }
            catch (Exception)
            {
                return;
            }
            if (imgOriginal == null) return;

            imgProcessedHsv = imgOriginalHsv.Convert<Hsv, byte>();



            if (imgOriginal == null) return;

            Hsv min = new Hsv(0, 5, 10);

            Hsv max = new Hsv(0, 10, 20);

            imgProcessed = imgProcessedHsv.InRange(min,
                                                    max);
            imgProcessed = imgProcessed.SmoothGaussian(9);
            imgProcessed = imgProcessed.SmoothBlur(9, 9);

            LineSegment2D[] lines = imgProcessed.HoughLines(10,
                                                          10,
                                                          5,
                                                          5,
                                                          100,
                                                          0,
                                                          0)[0];
            foreach (LineSegment2D line in lines)
            {
                if (txtXYRadius.Text != "") txtXYRadius.AppendText(Environment.NewLine);

                txtXYRadius.AppendText("Gates position Top =" + line.P2.ToString().PadLeft(4)/* +
                                       ", Bottom =" + line.P2.ToString().PadLeft(4)*/);
                txtXYRadius.ScrollToCaret();

                
                CvInvoke.Line(imgOriginal,
                                line.P1,
                                line.P2,
                                new MCvScalar(0, 255, 0),
                                1,
                                LineType.AntiAlias,
                                0);


                imgOriginal.Draw(line, new Bgr(Color.Blue), 3);
            }

            ibOriginal.Image = imgOriginal;
            ibProcessed.Image = imgProcessed;

        }

    }
}
