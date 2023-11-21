namespace DeweyTraining
{
    partial class WinnerMessage
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
            this.Btn_done = new System.Windows.Forms.Button();
            this.Lbl_correct = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_done
            // 
            this.Btn_done.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_done.BackColor = System.Drawing.Color.Silver;
            this.Btn_done.BackgroundImage = global::DeweyTraining.Properties.Resources.textured_background;
            this.Btn_done.Font = new System.Drawing.Font("Microsoft Uighur", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_done.Location = new System.Drawing.Point(144, 185);
            this.Btn_done.Name = "Btn_done";
            this.Btn_done.Size = new System.Drawing.Size(75, 35);
            this.Btn_done.TabIndex = 0;
            this.Btn_done.Text = "Done";
            this.Btn_done.UseVisualStyleBackColor = false;
            this.Btn_done.Click += new System.EventHandler(this.Btn_done_Click);
            // 
            // Lbl_correct
            // 
            this.Lbl_correct.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_correct.Dock = System.Windows.Forms.DockStyle.Top;
            this.Lbl_correct.Font = new System.Drawing.Font("Microsoft Uighur", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_correct.ForeColor = System.Drawing.Color.Black;
            this.Lbl_correct.Location = new System.Drawing.Point(0, 0);
            this.Lbl_correct.Name = "Lbl_correct";
            this.Lbl_correct.Size = new System.Drawing.Size(353, 68);
            this.Lbl_correct.TabIndex = 1;
            this.Lbl_correct.Text = "  Book Are In Correct Order.\r\nWell Done! \r\n";
            this.Lbl_correct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WinnerMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DeweyTraining.Properties.Resources.blue_stars;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(353, 232);
            this.Controls.Add(this.Lbl_correct);
            this.Controls.Add(this.Btn_done);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Uighur", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WinnerMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WinnerMessage_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_done;
        private System.Windows.Forms.Label Lbl_correct;
    }
}