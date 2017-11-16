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

namespace WindowsFormsApp1

{
    public partial class Form1 : Form
    {
        enum Messages
        {
            Ivartis_kaireje, Ivartis_desineje, Laimejo_komanda_kaireje, Laimejo_komanda_Desineje, Lygiosios
        };

        Mat imgBgr = new Mat();
        VideoCapture capVideo = null;
        bool blnCapturingInProcess = false;
        Team teamLeft;
        Team teamRight;
        
        

        public Form1(String name1, String name2)
        {
            InitializeComponent();

            teamLeft = new Team(name1, 0);
            teamRight = new Team(name2, 0);

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            teamLeftBox.AppendText(teamLeft.GetName());
            teamRightBox.AppendText(teamRight.GetName());
            leftResultBox.AppendText(teamLeft.Score.ToString());
            rightResultBox.AppendText(teamRight.Score.ToString());
        }
        
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (capVideo != null)
            {
                capVideo.Dispose();
            }
        }

        void UpdateGUI(object sender, EventArgs arg)
        {
            try
            {
                imgBgr = capVideo.QueryFrame();
            }
            catch (NullReferenceException)
            {
                txtXYRadius.AppendText("Nepasirinktas failas \n");
                Application.Idle -= UpdateGUI;
                return;
            }

            if (imgBgr == null)
            {
                MatchEnd();
                return;
            }

            ibOriginal.Image = imgBgr;

            switch (Logic.WhatToDo(imgBgr))
            {
                case 1:
                    GoalLeft_Click(new object(), new EventArgs());
                    break;
                case 2:
                    GoalRight_Click(new object(), new EventArgs());
                    break;
                default:
                    break;
            }
            
        }

        private void GoalLeft_Click(object sender, EventArgs e)
        {
            string goalL = Enum.GetName(typeof(Messages), 0);
            txtXYRadius.AppendText(goalL + "\n");

            teamLeft.Goal();
            leftResultBox.Clear();
            leftResultBox.AppendText(teamLeft.Score.ToString());

        }

        private void GoalRight_Click(object sender, EventArgs e)
        {
            string goalR = Enum.GetName(typeof(Messages), 1);
            txtXYRadius.AppendText(goalR + "\n");

            teamRight.Goal();
            rightResultBox.Clear();
            rightResultBox.AppendText(teamRight.Score.ToString());
        }

        private void ResetGoalCounter_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnPauseOrResume_Click(object sender, EventArgs e)
        {
            if (blnCapturingInProcess == true)
            {
                Application.Idle -= UpdateGUI;
                blnCapturingInProcess = false;
                btnPauseOrResume.Text = "Tęsti";
            }
            else
            {
                Application.Idle += UpdateGUI;
                blnCapturingInProcess = true;
                btnPauseOrResume.Text = "Pauzė";
            }
        }

        private void SelectGameVideo_Click(object sender, EventArgs e)
        {
            String videoFileDir;
            openGameVideo.ShowDialog();
            videoFileDir = openGameVideo.InitialDirectory + openGameVideo.FileName;

            try
            {
                capVideo = new VideoCapture(videoFileDir);
            }
            catch (NullReferenceException except)
            {
                txtXYRadius.Text = except.Message;
                return;
            }
        }

        private void endMatchBtn_Click(object sender, EventArgs e)
        {
            MatchEnd();
            return;
        }

        private void MatchEnd()
        {
            Application.Idle -= UpdateGUI;
            capVideo = null;

            Logic.DoStatistics(teamLeft, teamRight);

            MessageBox.Show(teamLeft.GetName().ToString() + "  " +
                            teamLeft.Score.ToString() + " : " +
                            teamRight.Score.ToString() + "  " +
                            teamRight.GetName().ToString(),
                            "Rungtynių pabaiga",
                            MessageBoxButtons.OK);

            DialogResult dialogResult = MessageBox.Show("Grįžti i pagr. meniu?", "Rungtynių pabaiga", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                this.Close();
            }

        }
    }
}
