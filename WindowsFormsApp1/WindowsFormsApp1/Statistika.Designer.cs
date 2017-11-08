namespace WindowsFormsApp1
{
    partial class Statistika
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statsTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(330, 322);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "SPEERK";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 30);
            this.label2.TabIndex = 10;
            this.label2.Text = "Statistika";
            // 
            // statsTextBox
            // 
            this.statsTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.statsTextBox.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.statsTextBox.Location = new System.Drawing.Point(8, 43);
            this.statsTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.statsTextBox.Multiline = true;
            this.statsTextBox.Name = "statsTextBox";
            this.statsTextBox.ReadOnly = true;
            this.statsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.statsTextBox.Size = new System.Drawing.Size(631, 277);
            this.statsTextBox.TabIndex = 11;
            this.statsTextBox.TabStop = false;
            this.statsTextBox.Text = "Data          | Komanda kairėje      | Rezultatas  | Komanda dešinėje     \r\n-----" +
    "---------------------------------------------------------------------";
            this.statsTextBox.TextChanged += new System.EventHandler(this.statsTextBox_TextChanged);
            // 
            // Statistika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(647, 357);
            this.Controls.Add(this.statsTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Statistika";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistika";
            this.Load += new System.EventHandler(this.Statistika_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox statsTextBox;
    }
}