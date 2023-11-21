using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class QuickLearning : Form
    {
        public QuickLearning()
        {
            InitializeComponent();

            //referencing previous window
            ReplacingBooks replace = new ReplacingBooks();

            //closing previous window
            replace.Close();
        }
        //End of method


        /// <summary>
        /// Button event handler for clicking RESET
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_no_Click(object sender, EventArgs e)
        {
            //referencing window
            ReplacingBooks replacing = new ReplacingBooks();

            //activating window
            replacing.Show();

            //closing window
            this.Hide();

        }
        //End of Method


        /// <summary>
        /// Button event handler for clicking YES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_yes_Click(object sender, EventArgs e)
        {
            //referencing window
            ReplacingBooks replacing = new ReplacingBooks();

            //activating window
            replacing.Show();

            //hiding test button in ReplacingBooks window
            replacing.Btn_test.Visible = false;

            //hiding timer in ReplacingBooks window
            replacing.Lbl_timer.Visible = false;

            //calling method to sort books correctly
            replacing.SortBooksCorrectly();

            //closing window
            this.Hide();
        }
        //End of Method

    }
}
//----------------------------------------------END OF CLASS---------------------------------------------------//
