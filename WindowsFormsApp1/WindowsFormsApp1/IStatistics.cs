using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    interface IStatistics
    {
        void WriteToFile(List<Statistics> stats);
        List<Statistics> GetStatistics();

    }
}
