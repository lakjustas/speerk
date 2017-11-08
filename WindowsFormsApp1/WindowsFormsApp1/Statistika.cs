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

        public Statistika()
        {
            InitializeComponent();
        }

        private void Statistika_Load(object sender, EventArgs e)
        {
            List<Statistics> stats = new Statistics().GetStatistics();
            String txtToBox;

            if(stats == null)
            {
                txtToBox = "Nėra duomenų";
                statsTextBox.AppendText(txtToBox);
            }
            else
            {
                foreach (Statistics s in stats)
                {
                    statsTextBox.AppendText(Environment.NewLine);
                    txtToBox = String.Format("{0,-13} | {1,-20} | {2,4} : {3,-4} | {4,-20}", s.date.ToString(@"MM - dd HH:mm"), 
                                                                                             s.name1,
                                                                                             s.score1.ToString(),
                                                                                             s.score2.ToString(),
                                                                                             s.name2);
                    statsTextBox.AppendText(txtToBox);
                }
            }
        }

        private void statsTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
