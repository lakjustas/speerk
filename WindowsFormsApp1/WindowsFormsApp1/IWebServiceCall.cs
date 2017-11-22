using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public interface IWebServiceCall
    {
        void POST(IStatistics statsToSave);
        List<Matches> GET();

    }
}
