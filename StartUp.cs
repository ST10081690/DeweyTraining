using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

/*
Name: Euluis Goncalves
App: Dewey Training App.
Last Modified: 25/10/2023.
 */

namespace DeweyTraining
{
    //----------------------------------------------START OF CLASS---------------------------------------------------//
    public partial class StartUp : Form
    {
        public StartUp()
        {
            InitializeComponent();

            //setting background image
            this.BackgroundImage = Properties.Resources.blue_main_background;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            //updating points
            Lbl_points.Text = "Points: " + UserData.UserPoints;
        }


        /// <summary>
        /// Button event handler method to open replacing books instructions form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_replaceBooks_Click(object sender, EventArgs e)
        {
            //instantiating form
            Replacing_Instructions instructions = new Replacing_Instructions();

            //opening new form
            instructions.Show();

            //hiding current window
            this.Hide();
            
        }
        //End of Method


        /// <summary>
        /// Button event handler method to open identifying areas instructions form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_identify_Click(object sender, EventArgs e)
        {
            //instantiating form
            IdentifyingAreas_Instructions instructions = new IdentifyingAreas_Instructions();

            //opening new form
            instructions.Show();

            //hiding current window
            this.Hide();

        }
        //End of method


        //Start of method
        /// <summary>
        /// Button event handler method to exit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            //exiting app
            Environment.Exit(0);
        }
        //End of method


        //Start of method
        /// <summary>
        /// Button event handler method to open finding call numbers instructions form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_findingNum_Click(object sender, EventArgs e)
        {
            //instantiating form
            FindingCallNumbers_Instructions finding = new FindingCallNumbers_Instructions();

            //opening new form
            finding.Show();

            //hiding current window
            this.Hide();

        }
        //End of Method
    }
}
//----------------------------------------------END OF CLASS---------------------------------------------------//
