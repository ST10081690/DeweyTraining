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
    //---------------------------------------------------START OF CLASS--------------------------------------------------------//
    public partial class IdentifyingAreas_Instructions : Form
    {
        public IdentifyingAreas_Instructions()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Button event handler for clicking OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ok_Click(object sender, EventArgs e)
        {
            //instantiating form
            IdentifyingAreas identifying = new IdentifyingAreas();

            //opening new form
            identifying.Show();

            //hiding current window
            this.Hide();
        }
        //End of Method

       
        /// <summary>
        /// Event handler for form closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IdentifyingAreas_Instructions_FormClosing(object sender, FormClosingEventArgs e)
        {
            //instantiating form
            IdentifyingAreas identifying = new IdentifyingAreas();

            //opening new form
            identifying.Show();

            //hiding current window
            this.Hide();
        }
        //End of Method
    }
}
//---------------------------------------------------END OF CLASS--------------------------------------------------------//

