using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
Name: Euluis Goncalves
App: Dewey Training App.
Last Modified: 25/10/2023.
 */

namespace DeweyTraining
{
    //----------------------------------------------START OF CLASS---------------------------------------------------//
    public partial class LoserMessage : Form
    {
        public LoserMessage()
        {
            InitializeComponent();

            //referencing previous window
            QuickLearning quick = new QuickLearning();

            //closing previous window
            quick.Close();
        }

        /// <summary>
        /// Button event handler for clicking OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ok_Click(object sender, EventArgs e)
        {
            //referencing windows
            QuickLearning learning = new QuickLearning();

            //showing Quick Learning window
            learning.Show();

            //closing current window and opening next form
            this.Hide();
            
        }
        //End of Method


        /// <summary>
        /// Event handler for form closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoserMessage_FormClosing(object sender, FormClosingEventArgs e)
        {
            //referencing windows
            QuickLearning learning = new QuickLearning();

            //showing Quick Learning window
            learning.Show();

            //closing current window and opening next form
            this.Hide();

        }
        //End of Method


    }
}
//----------------------------------------------END OF CLASS---------------------------------------------------//