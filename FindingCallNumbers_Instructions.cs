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
Last Modified: 21/11/2023.
*/

namespace DeweyTraining
{
    //---------------------------------------------------START OF CLASS--------------------------------------------------------//
    public partial class FindingCallNumbers_Instructions : Form
    {
        public FindingCallNumbers_Instructions()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for form closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindingCallNumbers_Instructions_FormClosing(object sender, FormClosingEventArgs e)
        {
            //instantiating form
            FindingCallNumbers finding = new FindingCallNumbers();

            //opening new form
            finding.Show();

            //hiding current window
            this.Hide();

        }
        //End of method

        /// <summary>
        /// Button event handler for clicking OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ok_Click(object sender, EventArgs e)
        {
            //instantiating form
            FindingCallNumbers finding = new FindingCallNumbers();

            //opening new form
            finding.Show();

            //hiding current window
            this.Hide();

        }
        //End of method
    }
}
//---------------------------------------------------END OF CLASS--------------------------------------------------------//
