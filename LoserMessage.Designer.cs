namespace DeweyTraining
{
    partial class LoserMessage
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
            this.Btn_ok = new System.Windows.Forms.Button();
            this.Lbl_oops = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_ok
            // 
            this.Btn_ok.BackgroundImage = global::DeweyTraining.Properties.Resources.textured_background;
            this.Btn_ok.Font = new System.Drawing.Font("Microsoft Uighur", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ok.ForeColor = System.Drawing.Color.White;
            this.Btn_ok.Location = new System.Drawing.Point(151, 160);
            this.Btn_ok.Name = "Btn_ok";
            this.Btn_ok.Size = new System.Drawing.Size(75, 32);
            this.Btn_ok.TabIndex = 0;
            this.Btn_ok.Text = "OK";
            this.Btn_ok.UseVisualStyleBackColor = true;
            this.Btn_ok.Click += new System.EventHandler(this.Btn_ok_Click);
            // 
            // Lbl_oops
            // 
            this.Lbl_oops.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_oops.Dock = System.Windows.Forms.DockStyle.Top;
            this.Lbl_oops.Font = new System.Drawing.Font("Microsoft Uighur", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_oops.ForeColor = System.Drawing.Color.White;
            this.Lbl_oops.Location = new System.Drawing.Point(0, 0);
            this.Lbl_oops.Name = "Lbl_oops";
            this.Lbl_oops.Size = new System.Drawing.Size(381, 157);
            this.Lbl_oops.TabIndex = 1;
            this.Lbl_oops.Text = "Oops... Books are not in ascending order.";
            this.Lbl_oops.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoserMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DeweyTraining.Properties.Resources.textured_background;
            this.ClientSize = new System.Drawing.Size(381, 204);
            this.Controls.Add(this.Lbl_oops);
            this.Controls.Add(this.Btn_ok);
            this.Font = new System.Drawing.Font("Microsoft Uighur", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LoserMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoserMessage_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_ok;
        private System.Windows.Forms.Label Lbl_oops;
    }
}