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
    public partial class Replacing_Instructions : Form
    {
        public Replacing_Instructions()
        {
            InitializeComponent();

            //referencing previous window
            StartUp start = new StartUp();

            //closing previous window
            start.Close();
        }

        
        /// <summary>
        /// Button event handler for clicking OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ok_Click(object sender, EventArgs e)
        {          
            //opening replacing books window
            ReplacingBooks replacing = new ReplacingBooks();
            replacing.Show();

            //hiding this window
            this.Hide();
        }
        //End of Method


        /// <summary>
        /// Event handler for form closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Replacing_Instructions_FormClosing(object sender, FormClosingEventArgs e)
        {
            //opening replacing books window
            ReplacingBooks replacing = new ReplacingBooks();
            replacing.Show();

            //hiding this window
            this.Hide();

        }
        //End of Method
    }
}
//----------------------------------------------END OF CLASS---------------------------------------------------//
