using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Komandos : Form
    {
        public Komandos()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            String name1, name2;
            name1 = txtFirstTeam.Text;
            name2 = txtSecondTeam.Text;
            new Form1(name1, name2).Show();
            this.Close();
        }
    }
}
