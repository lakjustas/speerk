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
                    txtToBox = s.date.ToString() + " " + s.name1 + " " + s.score1.ToString() + " - " + s.score2.ToString() + " " + s.name2;
                    statsTextBox.AppendText(txtToBox);
                    statsTextBox.AppendText(Environment.NewLine);
                }
            }
        }
    }
}
