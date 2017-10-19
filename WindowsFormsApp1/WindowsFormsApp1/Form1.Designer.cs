namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ibOriginal = new Emgu.CV.UI.ImageBox();
            this.btnPauseOrResume = new System.Windows.Forms.Button();
            this.txtXYRadius = new System.Windows.Forms.TextBox();
            this.btnGoalLeft = new System.Windows.Forms.Button();
            this.btnGoalRight = new System.Windows.Forms.Button();
            this.teamLeftBox = new System.Windows.Forms.RichTextBox();
            this.teamRightBox = new System.Windows.Forms.RichTextBox();
            this.btnResetGoalCounter = new System.Windows.Forms.Button();
            this.btnSelectGameVideo = new System.Windows.Forms.Button();
            this.openGameVideo = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.leftResultBox = new System.Windows.Forms.RichTextBox();
            this.rightResultBox = new System.Windows.Forms.RichTextBox();
            this.endMatchBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ibOriginal
            // 
            this.ibOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ibOriginal.Location = new System.Drawing.Point(181, 64);
            this.ibOriginal.Margin = new System.Windows.Forms.Padding(4);
            this.ibOriginal.Name = "ibOriginal";
            this.ibOriginal.Size = new System.Drawing.Size(954, 423);
            this.ibOriginal.TabIndex = 2;
            this.ibOriginal.TabStop = false;
            // 
            // btnPauseOrResume
            // 
            this.btnPauseOrResume.Font = new System.Drawing.Font("Gill Sans MT Ext Condensed Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPauseOrResume.Location = new System.Drawing.Point(16, 222);
            this.btnPauseOrResume.Margin = new System.Windows.Forms.Padding(4);
            this.btnPauseOrResume.Name = "btnPauseOrResume";
            this.btnPauseOrResume.Size = new System.Drawing.Size(120, 39);
            this.btnPauseOrResume.TabIndex = 3;
            this.btnPauseOrResume.Text = "Pradėti";
            this.btnPauseOrResume.UseVisualStyleBackColor = true;
            this.btnPauseOrResume.Click += new System.EventHandler(this.BtnPauseOrResume_Click);
            // 
            // txtXYRadius
            // 
            this.txtXYRadius.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtXYRadius.Location = new System.Drawing.Point(417, 699);
            this.txtXYRadius.Margin = new System.Windows.Forms.Padding(0);
            this.txtXYRadius.Multiline = true;
            this.txtXYRadius.Name = "txtXYRadius";
            this.txtXYRadius.ReadOnly = true;
            this.txtXYRadius.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtXYRadius.Size = new System.Drawing.Size(498, 78);
            this.txtXYRadius.TabIndex = 4;
            // 
            // btnGoalLeft
            // 
            this.btnGoalLeft.Font = new System.Drawing.Font("Gill Sans MT Ext Condensed Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoalLeft.Location = new System.Drawing.Point(511, 645);
            this.btnGoalLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGoalLeft.Name = "btnGoalLeft";
            this.btnGoalLeft.Size = new System.Drawing.Size(120, 39);
            this.btnGoalLeft.TabIndex = 5;
            this.btnGoalLeft.Text = "Įvartis kairei";
            this.btnGoalLeft.UseVisualStyleBackColor = true;
            this.btnGoalLeft.Click += new System.EventHandler(this.GoalLeft_Click);
            // 
            // btnGoalRight
            // 
            this.btnGoalRight.Font = new System.Drawing.Font("Gill Sans MT Ext Condensed Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoalRight.Location = new System.Drawing.Point(701, 645);
            this.btnGoalRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGoalRight.Name = "btnGoalRight";
            this.btnGoalRight.Size = new System.Drawing.Size(120, 39);
            this.btnGoalRight.TabIndex = 6;
            this.btnGoalRight.Text = "Įvartis dešinei";
            this.btnGoalRight.UseVisualStyleBackColor = true;
            this.btnGoalRight.Click += new System.EventHandler(this.GoalRight_Click);
            // 
            // teamLeftBox
            // 
            this.teamLeftBox.BackColor = System.Drawing.Color.PaleTurquoise;
            this.teamLeftBox.Font = new System.Drawing.Font("Gill Sans MT Ext Condensed Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamLeftBox.Location = new System.Drawing.Point(417, 508);
            this.teamLeftBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.teamLeftBox.Name = "teamLeftBox";
            this.teamLeftBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.teamLeftBox.Size = new System.Drawing.Size(214, 50);
            this.teamLeftBox.TabIndex = 7;
            this.teamLeftBox.Text = "";
            // 
            // teamRightBox
            // 
            this.teamRightBox.BackColor = System.Drawing.Color.PaleTurquoise;
            this.teamRightBox.Font = new System.Drawing.Font("Gill Sans MT Ext Condensed Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamRightBox.Location = new System.Drawing.Point(701, 506);
            this.teamRightBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.teamRightBox.Name = "teamRightBox";
            this.teamRightBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.teamRightBox.Size = new System.Drawing.Size(214, 50);
            this.teamRightBox.TabIndex = 8;
            this.teamRightBox.Text = "";
            // 
            // btnResetGoalCounter
            // 
            this.btnResetGoalCounter.Font = new System.Drawing.Font("Gill Sans MT Ext Condensed Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetGoalCounter.Location = new System.Drawing.Point(16, 267);
            this.btnResetGoalCounter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnResetGoalCounter.Name = "btnResetGoalCounter";
            this.btnResetGoalCounter.Size = new System.Drawing.Size(120, 39);
            this.btnResetGoalCounter.TabIndex = 9;
            this.btnResetGoalCounter.Text = "Perkrauti";
            this.btnResetGoalCounter.UseVisualStyleBackColor = true;
            this.btnResetGoalCounter.Click += new System.EventHandler(this.ResetGoalCounter_Click);
            // 
            // btnSelectGameVideo
            // 
            this.btnSelectGameVideo.Font = new System.Drawing.Font("Gill Sans MT Ext Condensed Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectGameVideo.Location = new System.Drawing.Point(55, 20);
            this.btnSelectGameVideo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectGameVideo.Name = "btnSelectGameVideo";
            this.btnSelectGameVideo.Size = new System.Drawing.Size(120, 39);
            this.btnSelectGameVideo.TabIndex = 10;
            this.btnSelectGameVideo.Text = "Įkelti video";
            this.btnSelectGameVideo.UseVisualStyleBackColor = true;
            this.btnSelectGameVideo.Click += new System.EventHandler(this.SelectGameVideo_Click);
            // 
            // openGameVideo
            // 
            this.openGameVideo.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 21);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1023, 770);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 33);
            this.label1.TabIndex = 13;
            this.label1.Text = "SPEERK";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gill Sans MT Ext Condensed Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(652, 512);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 31);
            this.label3.TabIndex = 14;
            this.label3.Text = "VS";
            // 
            // leftResultBox
            // 
            this.leftResultBox.BackColor = System.Drawing.Color.PaleTurquoise;
            this.leftResultBox.Font = new System.Drawing.Font("Gill Sans MT Ext Condensed Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftResultBox.Location = new System.Drawing.Point(566, 578);
            this.leftResultBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.leftResultBox.Name = "leftResultBox";
            this.leftResultBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.leftResultBox.Size = new System.Drawing.Size(65, 50);
            this.leftResultBox.TabIndex = 15;
            this.leftResultBox.Text = "";
            // 
            // rightResultBox
            // 
            this.rightResultBox.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rightResultBox.Font = new System.Drawing.Font("Gill Sans MT Ext Condensed Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightResultBox.Location = new System.Drawing.Point(701, 578);
            this.rightResultBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rightResultBox.Name = "rightResultBox";
            this.rightResultBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rightResultBox.Size = new System.Drawing.Size(65, 50);
            this.rightResultBox.TabIndex = 16;
            this.rightResultBox.Text = "";
            // 
            // endMatchBtn
            // 
            this.endMatchBtn.Font = new System.Drawing.Font("Gill Sans MT Ext Condensed Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endMatchBtn.Location = new System.Drawing.Point(16, 310);
            this.endMatchBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.endMatchBtn.Name = "endMatchBtn";
            this.endMatchBtn.Size = new System.Drawing.Size(120, 39);
            this.endMatchBtn.TabIndex = 17;
            this.endMatchBtn.Text = "Baigti rungt.";
            this.endMatchBtn.UseVisualStyleBackColor = true;
            this.endMatchBtn.Click += new System.EventHandler(this.endMatchBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1179, 814);
            this.Controls.Add(this.endMatchBtn);
            this.Controls.Add(this.rightResultBox);
            this.Controls.Add(this.leftResultBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSelectGameVideo);
            this.Controls.Add(this.btnResetGoalCounter);
            this.Controls.Add(this.teamRightBox);
            this.Controls.Add(this.teamLeftBox);
            this.Controls.Add(this.btnGoalRight);
            this.Controls.Add(this.btnGoalLeft);
            this.Controls.Add(this.txtXYRadius);
            this.Controls.Add(this.btnPauseOrResume);
            this.Controls.Add(this.ibOriginal);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "SPEERK";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox ibOriginal;
        private System.Windows.Forms.Button btnPauseOrResume;
        private System.Windows.Forms.TextBox txtXYRadius;
        private System.Windows.Forms.Button btnGoalLeft;
        private System.Windows.Forms.Button btnGoalRight;
        private System.Windows.Forms.RichTextBox teamLeftBox;
        private System.Windows.Forms.RichTextBox teamRightBox;
        private System.Windows.Forms.Button btnResetGoalCounter;
        private System.Windows.Forms.Button btnSelectGameVideo;
        private System.Windows.Forms.OpenFileDialog openGameVideo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox leftResultBox;
        private System.Windows.Forms.RichTextBox rightResultBox;
        private System.Windows.Forms.Button endMatchBtn;
    }
}

