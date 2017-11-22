using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public interface IBallTracker
    {
        Mat ProcessFrame(Mat imgBgr);

        Mat MarkBall(Mat img, Point coordinates);

        Point GetBallCoordinates(Mat img);
    }
}
