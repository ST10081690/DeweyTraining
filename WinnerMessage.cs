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
    public partial class WinnerMessage : Form
    {
        public WinnerMessage()
        {
            InitializeComponent();

            //referencing previous window
            QuickLearning quick = new QuickLearning();

            //closing previous window
            quick.Close();
        }


        /// <summary>
        /// Button event handler for clicking DONE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_done_Click(object sender, EventArgs e)
        {
            //instatiating window 
            StartUp startForm = new StartUp();

            //opening start window
            startForm.Show();

            //closing window
            this.Hide();
        }

        //End of Method

        
        /// <summary>
        /// Event handler for form closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WinnerMessage_FormClosing(object sender, FormClosingEventArgs e)
        {
            //instatiating window 
            StartUp startForm = new StartUp();

            //opening start window
            startForm.Show();

            //closing window
            this.Hide();

        }
        //End of Method

    }
}
//----------------------------------------------END OF CLASS---------------------------------------------------//
