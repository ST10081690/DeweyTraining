namespace DeweyTraining
{
    partial class Replacing_Instructions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Replacing_Instructions));
            this.Btn_ok = new System.Windows.Forms.Button();
            this.Lbl_instructions = new System.Windows.Forms.Label();
            this.Lbl_title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_ok
            // 
            this.Btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_ok.BackColor = System.Drawing.Color.Silver;
            this.Btn_ok.BackgroundImage = global::DeweyTraining.Properties.Resources.textured_background;
            this.Btn_ok.Font = new System.Drawing.Font("Microsoft Uighur", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ok.Location = new System.Drawing.Point(235, 284);
            this.Btn_ok.Name = "Btn_ok";
            this.Btn_ok.Size = new System.Drawing.Size(72, 37);
            this.Btn_ok.TabIndex = 1;
            this.Btn_ok.Text = "OK";
            this.Btn_ok.UseVisualStyleBackColor = false;
            this.Btn_ok.Click += new System.EventHandler(this.Btn_ok_Click);
            // 
            // Lbl_instructions
            // 
            this.Lbl_instructions.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_instructions.Dock = System.Windows.Forms.DockStyle.Top;
            this.Lbl_instructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_instructions.Location = new System.Drawing.Point(0, 0);
            this.Lbl_instructions.Name = "Lbl_instructions";
            this.Lbl_instructions.Size = new System.Drawing.Size(540, 281);
            this.Lbl_instructions.TabIndex = 2;
            this.Lbl_instructions.Text = resources.GetString("Lbl_instructions.Text");
            this.Lbl_instructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lbl_title
            // 
            this.Lbl_title.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_title.Font = new System.Drawing.Font("Microsoft Uighur", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_title.ForeColor = System.Drawing.Color.White;
            this.Lbl_title.Location = new System.Drawing.Point(181, 9);
            this.Lbl_title.Name = "Lbl_title";
            this.Lbl_title.Size = new System.Drawing.Size(180, 34);
            this.Lbl_title.TabIndex = 3;
            this.Lbl_title.Text = "INSTRUCTIONS\r\n";
            this.Lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Replacing_Instructions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DeweyTraining.Properties.Resources.textured_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(540, 333);
            this.Controls.Add(this.Btn_ok);
            this.Controls.Add(this.Lbl_title);
            this.Controls.Add(this.Lbl_instructions);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Replacing_Instructions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Replacing_Instructions_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_ok;
        private System.Windows.Forms.Label Lbl_instructions;
        private System.Windows.Forms.Label Lbl_title;
    }
}