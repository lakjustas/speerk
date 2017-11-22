using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public interface IGateTracker
    {
        Image<Gray, Byte> ProcessFrame(Mat img);

        LineSegment2D[] GetGates(Mat img);

        Mat MarkGates(Mat img, LineSegment2D[] lines);
    }
}
