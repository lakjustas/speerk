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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ibOriginal
            // 
            this.ibOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ibOriginal.Location = new System.Drawing.Point(12, 53);
            this.ibOriginal.Name = "ibOriginal";
            this.ibOriginal.Size = new System.Drawing.Size(488, 201);
            this.ibOriginal.TabIndex = 2;
            this.ibOriginal.TabStop = false;
            // 
            // btnPauseOrResume
            // 
            this.btnPauseOrResume.Font = new System.Drawing.Font("Gill Sans MT Ext Condensed Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPauseOrResume.Location = new System.Drawing.Point(12, 283);
            this.btnPauseOrResume.Name = "btnPauseOrResume";
            this.btnPauseOrResume.Size = new System.Drawing.Size(90, 32);
            this.btnPauseOrResume.TabIndex = 3;
            this.btnPauseOrResume.Text = "Pradėti";
            this.btnPauseOrResume.UseVisualStyleBackColor = true;
            this.btnPauseOrResume.Click += new System.EventHandler(this.BtnPauseOrResume_Click);
            // 
            // txtXYRadius
            // 
            this.txtXYRadius.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtXYRadius.Location = new System.Drawing.Point(315, 283);
            this.txtXYRadius.Margin = new System.Windows.Forms.Padding(0);
            this.txtXYRadius.Multiline = true;
            this.txtXYRadius.Name = "txtXYRadius";
            this.txtXYRadius.ReadOnly = true;
            this.txtXYRadius.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtXYRadius.Size = new System.Drawing.Size(188, 64);
            this.txtXYRadius.TabIndex = 4;
            // 
            // btnGoalLeft
            // 
            this.btnGoalLeft.Font = new System.Drawing.Font("Gill Sans MT Ext Condensed Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoalLeft.Location = new System.Drawing.Point(10, 358);
            this.btnGoalLeft.Margin = new System.Windows.Forms.Padding(2);
            this.btnGoalLeft.Name = "btnGoalLeft";
            this.btnGoalLeft.Size = new System.Drawing.Size(90, 32);
            this.btnGoalLeft.TabIndex = 5;
            this.btnGoalLeft.Text = "Įvartis kairei";
            this.btnGoalLeft.UseVisualStyleBackColor = true;
            this.btnGoalLeft.Click += new System.EventHandler(this.GoalLeft_Click);
            // 
            // btnGoalRight
            // 
            this.btnGoalRight.Font = new System.Drawing.Font("Gill Sans MT Ext Condensed Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoalRight.Location = new System.Drawing.Point(188, 358);
            this.btnGoalRight.Margin = new System.Windows.Forms.Padding(2);
            this.btnGoalRight.Name = "btnGoalRight";
            this.btnGoalRight.Size = new System.Drawing.Size(90, 32);
            this.btnGoalRight.TabIndex = 6;
            this.btnGoalRight.Text = "Įvartis dešinei";
            this.btnGoalRight.UseVisualStyleBackColor = true;
            this.btnGoalRight.Click += new System.EventHandler(this.GoalRight_Click);
            // 
            // teamLeftBox
            // 
            this.teamLeftBox.BackColor = System.Drawing.Color.DarkOrange;
            this.teamLeftBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.teamLeftBox.Location = new System.Drawing.Point(124, 635);
            this.teamLeftBox.Margin = new System.Windows.Forms.Padding(2);
            this.teamLeftBox.Name = "teamLeftBox";
            this.teamLeftBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.teamLeftBox.Size = new System.Drawing.Size(226, 41);
            this.teamLeftBox.TabIndex = 7;
            this.teamLeftBox.Text = "";
            // 
            // teamRightBox
            // 
            this.teamRightBox.BackColor = System.Drawing.Color.DarkOrange;
            this.teamRightBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.teamRightBox.Location = new System.Drawing.Point(556, 635);
            this.teamRightBox.Margin = new System.Windows.Forms.Padding(2);
            this.teamRightBox.Name = "teamRightBox";
            this.teamRightBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.teamRightBox.Size = new System.Drawing.Size(226, 41);
            this.teamRightBox.TabIndex = 8;
            this.teamRightBox.Text = "";
            // 
            // btnResetGoalCounter
            // 
            this.btnResetGoalCounter.Font = new System.Drawing.Font("Gill Sans MT Ext Condensed Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetGoalCounter.Location = new System.Drawing.Point(188, 283);
            this.btnResetGoalCounter.Margin = new System.Windows.Forms.Padding(2);
            this.btnResetGoalCounter.Name = "btnResetGoalCounter";
            this.btnResetGoalCounter.Size = new System.Drawing.Size(90, 32);
            this.btnResetGoalCounter.TabIndex = 9;
            this.btnResetGoalCounter.Text = "Perkrauti";
            this.btnResetGoalCounter.UseVisualStyleBackColor = true;
            this.btnResetGoalCounter.Click += new System.EventHandler(this.ResetGoalCounter_Click);
            // 
            // btnSelectGameVideo
            // 
            this.btnSelectGameVideo.Font = new System.Drawing.Font("Gill Sans MT Ext Condensed Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectGameVideo.Location = new System.Drawing.Point(41, 16);
            this.btnSelectGameVideo.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectGameVideo.Name = "btnSelectGameVideo";
            this.btnSelectGameVideo.Size = new System.Drawing.Size(90, 32);
            this.btnSelectGameVideo.TabIndex = 10;
            this.btnSelectGameVideo.Text = "Įkelti video";
            this.btnSelectGameVideo.UseVisualStyleBackColor = true;
            this.btnSelectGameVideo.Click += new System.EventHandler(this.SelectGameVideo_Click);
            // 
            // openGameVideo
            // 
            this.openGameVideo.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(398, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 26);
            this.label1.TabIndex = 11;
            this.label1.Text = "SPEERK";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(512, 401);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectGameVideo);
            this.Controls.Add(this.btnResetGoalCounter);
            this.Controls.Add(this.teamRightBox);
            this.Controls.Add(this.teamLeftBox);
            this.Controls.Add(this.btnGoalRight);
            this.Controls.Add(this.btnGoalLeft);
            this.Controls.Add(this.txtXYRadius);
            this.Controls.Add(this.btnPauseOrResume);
            this.Controls.Add(this.ibOriginal);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

