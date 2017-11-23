using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeerkMobileApp
{
    public interface IWebServiceCall
    {
        void POST(Match statsToSave);
        List<Match> GET();

    }
}
