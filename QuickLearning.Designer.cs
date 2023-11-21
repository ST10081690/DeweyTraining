namespace DeweyTraining
{
    partial class QuickLearning
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
            this.Btn_no = new System.Windows.Forms.Button();
            this.Lbl_correctOrder = new System.Windows.Forms.Label();
            this.Btn_yes = new System.Windows.Forms.Button();
            this.Lbl_or = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_no
            // 
            this.Btn_no.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_no.BackgroundImage = global::DeweyTraining.Properties.Resources.textured_background;
            this.Btn_no.Font = new System.Drawing.Font("Microsoft Uighur", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_no.ForeColor = System.Drawing.Color.White;
            this.Btn_no.Location = new System.Drawing.Point(216, 174);
            this.Btn_no.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_no.Name = "Btn_no";
            this.Btn_no.Size = new System.Drawing.Size(66, 34);
            this.Btn_no.TabIndex = 1;
            this.Btn_no.Text = "Reset";
            this.Btn_no.UseVisualStyleBackColor = true;
            this.Btn_no.Click += new System.EventHandler(this.Btn_no_Click);
            // 
            // Lbl_correctOrder
            // 
            this.Lbl_correctOrder.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_correctOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.Lbl_correctOrder.Font = new System.Drawing.Font("Microsoft Uighur", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_correctOrder.ForeColor = System.Drawing.Color.White;
            this.Lbl_correctOrder.Location = new System.Drawing.Point(0, 0);
            this.Lbl_correctOrder.Name = "Lbl_correctOrder";
            this.Lbl_correctOrder.Size = new System.Drawing.Size(353, 170);
            this.Lbl_correctOrder.TabIndex = 2;
            this.Lbl_correctOrder.Text = "Do you want to view the correct order?";
            this.Lbl_correctOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_yes
            // 
            this.Btn_yes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_yes.BackgroundImage = global::DeweyTraining.Properties.Resources.textured_background;
            this.Btn_yes.Font = new System.Drawing.Font("Microsoft Uighur", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_yes.ForeColor = System.Drawing.Color.White;
            this.Btn_yes.Location = new System.Drawing.Point(76, 174);
            this.Btn_yes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_yes.Name = "Btn_yes";
            this.Btn_yes.Size = new System.Drawing.Size(66, 34);
            this.Btn_yes.TabIndex = 0;
            this.Btn_yes.Text = "Yes";
            this.Btn_yes.UseVisualStyleBackColor = true;
            this.Btn_yes.Click += new System.EventHandler(this.Btn_yes_Click);
            // 
            // Lbl_or
            // 
            this.Lbl_or.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_or.AutoSize = true;
            this.Lbl_or.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_or.Font = new System.Drawing.Font("Microsoft Uighur", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_or.ForeColor = System.Drawing.Color.White;
            this.Lbl_or.Location = new System.Drawing.Point(170, 178);
            this.Lbl_or.Name = "Lbl_or";
            this.Lbl_or.Size = new System.Drawing.Size(24, 27);
            this.Lbl_or.TabIndex = 3;
            this.Lbl_or.Text = "or";
            // 
            // QuickLearning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DeweyTraining.Properties.Resources.textured_background;
            this.ClientSize = new System.Drawing.Size(353, 220);
            this.Controls.Add(this.Lbl_or);
            this.Controls.Add(this.Lbl_correctOrder);
            this.Controls.Add(this.Btn_no);
            this.Controls.Add(this.Btn_yes);
            this.Font = new System.Drawing.Font("Microsoft Uighur", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QuickLearning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_yes;
        private System.Windows.Forms.Button Btn_no;
        private System.Windows.Forms.Label Lbl_correctOrder;
        private System.Windows.Forms.Label Lbl_or;
    }
}