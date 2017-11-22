using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public partial class Statistika : Form
    {
        private readonly IWebServiceCall _wsc;

        public Statistika() : this(new WebServiceCall())
        {
            InitializeComponent();
        }

        public Statistika(IWebServiceCall wsc)
        {
            _wsc = wsc;
        }

        private void Statistika_Load(object sender, EventArgs e)
        {

            string txtToBox;
            List<Matches> matchStats = _wsc.GET();

            if (matchStats == null)
            {
                txtToBox = "Nėra duomenų";
                statsTextBox.AppendText(txtToBox);
            }
            else
            {
                foreach (Matches m in matchStats)
                {
                    statsTextBox.AppendText(Environment.NewLine);

                    txtToBox = String.Format("{0,-13} | {1,-20} | {2,4} : {3,-4} | {4,-20}", m.date.ToString(),
                                                                                             m.teamOne,
                                                                                             m.scoreOne.ToString(),
                                                                                             m.scoreTwo.ToString(),
                                                                                             m.teamTwo);
                    statsTextBox.AppendText(txtToBox);
                }
            }


        }
    }
}
