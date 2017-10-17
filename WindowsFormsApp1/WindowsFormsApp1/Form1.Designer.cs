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
            this.ibOriginal = new Emgu.CV.UI.ImageBox();
            this.btnPauseOrResume = new System.Windows.Forms.Button();
            this.txtXYRadius = new System.Windows.Forms.TextBox();
            this.goalLeft = new System.Windows.Forms.Button();
            this.goalRight = new System.Windows.Forms.Button();
            this.teamLeftBox = new System.Windows.Forms.RichTextBox();
            this.teamRightBox = new System.Windows.Forms.RichTextBox();
            this.resetGoalCounter = new System.Windows.Forms.Button();
            this.selectGameVideo = new System.Windows.Forms.Button();
            this.openGameVideo = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).BeginInit();
            this.SuspendLayout();
            // 
            // ibOriginal
            // 
            this.ibOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ibOriginal.Location = new System.Drawing.Point(20, 20);
            this.ibOriginal.Margin = new System.Windows.Forms.Padding(4);
            this.ibOriginal.Name = "ibOriginal";
            this.ibOriginal.Size = new System.Drawing.Size(1140, 590);
            this.ibOriginal.TabIndex = 2;
            this.ibOriginal.TabStop = false;
            // 
            // btnPauseOrResume
            // 
            this.btnPauseOrResume.Location = new System.Drawing.Point(1181, 20);
            this.btnPauseOrResume.Margin = new System.Windows.Forms.Padding(4);
            this.btnPauseOrResume.Name = "btnPauseOrResume";
            this.btnPauseOrResume.Size = new System.Drawing.Size(160, 70);
            this.btnPauseOrResume.TabIndex = 3;
            this.btnPauseOrResume.Text = "Start";
            this.btnPauseOrResume.UseVisualStyleBackColor = true;
            this.btnPauseOrResume.Click += new System.EventHandler(this.BtnPauseOrResume_Click);
            // 
            // txtXYRadius
            // 
            this.txtXYRadius.Location = new System.Drawing.Point(166, 642);
            this.txtXYRadius.Margin = new System.Windows.Forms.Padding(0);
            this.txtXYRadius.Multiline = true;
            this.txtXYRadius.Name = "txtXYRadius";
            this.txtXYRadius.ReadOnly = true;
            this.txtXYRadius.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtXYRadius.Size = new System.Drawing.Size(876, 103);
            this.txtXYRadius.TabIndex = 4;
            // 
            // goalLeft
            // 
            this.goalLeft.Location = new System.Drawing.Point(1181, 116);
            this.goalLeft.Name = "goalLeft";
            this.goalLeft.Size = new System.Drawing.Size(160, 70);
            this.goalLeft.TabIndex = 5;
            this.goalLeft.Text = "Goal left";
            this.goalLeft.UseVisualStyleBackColor = true;
            this.goalLeft.Click += new System.EventHandler(this.GoalLeft_Click);
            // 
            // goalRight
            // 
            this.goalRight.Location = new System.Drawing.Point(1181, 211);
            this.goalRight.Name = "goalRight";
            this.goalRight.Size = new System.Drawing.Size(160, 70);
            this.goalRight.TabIndex = 6;
            this.goalRight.Text = "Goal right";
            this.goalRight.UseVisualStyleBackColor = true;
            this.goalRight.Click += new System.EventHandler(this.GoalRight_Click);
            // 
            // teamLeftBox
            // 
            this.teamLeftBox.BackColor = System.Drawing.Color.DarkOrange;
            this.teamLeftBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.teamLeftBox.Location = new System.Drawing.Point(166, 782);
            this.teamLeftBox.Name = "teamLeftBox";
            this.teamLeftBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.teamLeftBox.Size = new System.Drawing.Size(300, 50);
            this.teamLeftBox.TabIndex = 7;
            this.teamLeftBox.Text = "";
            // 
            // teamRightBox
            // 
            this.teamRightBox.BackColor = System.Drawing.Color.DarkOrange;
            this.teamRightBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.teamRightBox.Location = new System.Drawing.Point(742, 782);
            this.teamRightBox.Name = "teamRightBox";
            this.teamRightBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.teamRightBox.Size = new System.Drawing.Size(300, 50);
            this.teamRightBox.TabIndex = 8;
            this.teamRightBox.Text = "";
            // 
            // resetGoalCounter
            // 
            this.resetGoalCounter.Location = new System.Drawing.Point(1181, 307);
            this.resetGoalCounter.Name = "resetGoalCounter";
            this.resetGoalCounter.Size = new System.Drawing.Size(160, 70);
            this.resetGoalCounter.TabIndex = 9;
            this.resetGoalCounter.Text = "Reset";
            this.resetGoalCounter.UseVisualStyleBackColor = true;
            this.resetGoalCounter.Click += new System.EventHandler(this.ResetGoalCounter_Click);
            // 
            // selectGameVideo
            // 
            this.selectGameVideo.Location = new System.Drawing.Point(1181, 397);
            this.selectGameVideo.Name = "selectGameVideo";
            this.selectGameVideo.Size = new System.Drawing.Size(160, 70);
            this.selectGameVideo.TabIndex = 10;
            this.selectGameVideo.Text = "Select game video";
            this.selectGameVideo.UseVisualStyleBackColor = true;
            this.selectGameVideo.Click += new System.EventHandler(this.SelectGameVideo_Click);
            // 
            // openGameVideo
            // 
            this.openGameVideo.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1373, 877);
            this.Controls.Add(this.selectGameVideo);
            this.Controls.Add(this.resetGoalCounter);
            this.Controls.Add(this.teamRightBox);
            this.Controls.Add(this.teamLeftBox);
            this.Controls.Add(this.goalRight);
            this.Controls.Add(this.goalLeft);
            this.Controls.Add(this.txtXYRadius);
            this.Controls.Add(this.btnPauseOrResume);
            this.Controls.Add(this.ibOriginal);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "SPEERK";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox ibOriginal;
        private System.Windows.Forms.Button btnPauseOrResume;
        private System.Windows.Forms.TextBox txtXYRadius;
        private System.Windows.Forms.Button goalLeft;
        private System.Windows.Forms.Button goalRight;
        private System.Windows.Forms.RichTextBox teamLeftBox;
        private System.Windows.Forms.RichTextBox teamRightBox;
        private System.Windows.Forms.Button resetGoalCounter;
        private System.Windows.Forms.Button selectGameVideo;
        private System.Windows.Forms.OpenFileDialog openGameVideo;
    }
}

