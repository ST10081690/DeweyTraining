using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;

/*
Name: Euluis Goncalves
App: Dewey Training App.
Last Modified: 21/11/2023.
 */

namespace DeweyTraining
{
    //----------------------------------------------START OF CLASS---------------------------------------------------//
    public partial class ReplacingBooks : Form
    {
        //random number generator
        static Random myRandom = new Random();

        //list to store call numbers
        static List<string> DeweyList = new List<string>();

        //string to store the generated surname initials
        public static string authorSurname;

        //bool to establish order result
        public bool correctOrder = false;

        //creating thread to play music
        public static Thread soundFxThread;

        //counting timer seconds
        public static int timerTicks;

        //integers for time elapsed
        int min = 00, sec;

        public ReplacingBooks()
        {
            InitializeComponent();

            //setting points source
            Lbl_points.Text = "Points: " + UserData.UserPoints;

            //setting background image
            this.BackgroundImage = Properties.Resources.dark_wood;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            //calling method to set up window content
            SetUpContent();
            
        }


        /// <summary>
        /// Method to set up content for the game
        /// </summary>
        private void SetUpContent()
        {
            //making media players invisible
            Plyr_winner.Visible = false;
            Plyr_loser.Visible = false;

            //resetting timer
            timerTicks = 0;

            //starting timer
            Tmr_gameTime.Start();

            //ensuring button is visible
            Btn_test.Visible = true;

            //ensuring timer is visible
            Lbl_timer.Visible = true;

            //loop to run 10 times (for 10 call numbers)
            for (int i = 0; i < 11; i++)
            {
                //calling method to initiate generating call numbers
                GenerateSurnameLetters();
            }

            //saving call numbers as buttons text
            SetButtonsText();

            //setting mouse controls for buttons (books)
            foreach (Button button in Pnl_bookShelf.Controls)
            {
                button.MouseDown += Button_MouseDown;
                button.DragEnter += Button_DragEnter;
                button.DragDrop += Button_DragDrop;
            }

            //referencing previous window
            Replacing_Instructions inst = new Replacing_Instructions();

            //closing previous window
            inst.Close();

        }
        //End of method


        /// <summary>
        /// Method to randomly generate the three letters of a surnname to use in the call number
        /// </summary>
        public static void GenerateSurnameLetters()
        {
            //Referencing:
            //ChatGPT helped with this one.

            //storing alphabet letters
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            //storing vowels
            string vowels = "AEIOU";

            //randomly picking three letters
            char firstLetter = alphabet[myRandom.Next(4, 26)];
            char secondLetter = vowels[myRandom.Next(2, 5)];
            char thirdLetter = alphabet[myRandom.Next(1, 26)];

            //storing the three letters
            authorSurname = firstLetter.ToString() + secondLetter.ToString() + thirdLetter.ToString();

            //calling number to generate the final call number
            GenerateCallNumber();
        }
        //End of Method


        /// <summary>
        /// Generating full call number for the book with random numbers and letters
        /// </summary>
        public static void GenerateCallNumber()
        {
            //Referencing:
            //ChatGPT helped with this one.

            //int to store classification number
            int classNumber = myRandom.Next(100, 1000);

            //storing cutter number
            int cutter = myRandom.Next(1, 1000);

            //string to store the generated book call number
            string bookDewey = classNumber.ToString() + "." + cutter.ToString() + " " + authorSurname;

            //adding call number to list
            DeweyList.Add(bookDewey);
        }
        //End of Method


        /// <summary>
        /// Method to set each button's text with call numbers that were generated
        /// </summary>
        public void SetButtonsText()
        {
            //populating buttons with list data
            Btn_book1.Text = DeweyList[0];
            Btn_book2.Text = DeweyList[1];
            Btn_book3.Text = DeweyList[2];
            Btn_book4.Text = DeweyList[3];
            Btn_book5.Text = DeweyList[4];
            Btn_book6.Text = DeweyList[5];
            Btn_book7.Text = DeweyList[6];
            Btn_book8.Text = DeweyList[7];
            Btn_book9.Text = DeweyList[8];
            Btn_book10.Text = DeweyList[9];
        }
        //End of Method


        /// <summary>
        /// Handling button (book) being clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            //Referencing:
            //ChatGPT helped with this one.
            if (e.Button == MouseButtons.Left)
            {
                Button button = (Button)sender;
                button.DoDragDrop(button, DragDropEffects.Move);
            }
        }
        //End of Method


        /// <summary>
        /// Handling button (book) being dragged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_DragEnter(object sender, DragEventArgs e)
        {
            //Referencing:
            //ChatGPT helped with this one.
            if (e.Data.GetDataPresent(typeof(Button)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }
        //End of Method


        /// <summary>
        /// Handling button (book) being dropped elsewhere on the panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_DragDrop(object sender, DragEventArgs e)
        {
            //Referencing:
            //ChatGPT helped with this one.
            if (e.Data.GetDataPresent(typeof(Button)))
            {

                Button sourceButton = (Button)e.Data.GetData(typeof(Button));
                Button targetButton = (Button)sender;

                // Swap the button positions within the FlowLayoutPanel
                int sourceIndex = Pnl_bookShelf.Controls.IndexOf(sourceButton);
                int targetIndex = Pnl_bookShelf.Controls.IndexOf(targetButton);
                Pnl_bookShelf.Controls.SetChildIndex(sourceButton, targetIndex);
                Pnl_bookShelf.Controls.SetChildIndex(targetButton, sourceIndex);
            } 
        }
        //End of Method


        /// <summary>
        /// Button event handler to return to main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_back_Click(object sender, EventArgs e)
        {
            //instatiating window 
            StartUp startForm = new StartUp();

            //stopping timer
            Tmr_gameTime.Stop();

            //clearing dewey call number list
            DeweyList.Clear();

            //opening start window
            startForm.Show();

            //closing this window
            this.Close();  
        }
        //End of Method


        /// <summary>
        /// Button event handler to test book order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_test_Click(object sender, EventArgs e)
        {
            //calling method to check the order
            CheckBookOrder(sender, e);
        }
        //End of Method


        /// <summary>
        /// Method to sort books in ascending order to show user the solution
        //if they lose and want to learn. Method is called from "Quick Learning" form
        /// </summary>
        public void SortBooksCorrectly()
        {
            //Referencing:
            //ChatGPT helped with this one.

            //list of buttons in panel
            List<Button> buttons = Pnl_bookShelf.Controls.OfType<Button>().ToList();
            int n = buttons.Count;

            //sorting algorithm to sort the books in order
            for (int i = 0; i < n - 1; i++)
            {
                //int holding i assuming that i is the lowest number 
                int minIndex = i;

                //loop to compare buttons
                for (int j = i + 1; j < n; j++)
                {
                    //if the comparison's result is negative
                    if (CompareButtons(buttons[j], buttons[minIndex]) < 0)
                    {
                        //lowest index is changed
                        minIndex = j;
                    }
                }

                //if the lowest index changes 
                if (minIndex != i)
                {
                    //swapping buttons, to move lowest number to the correct spot
                    Button temp = buttons[i];
                    buttons[i] = buttons[minIndex];
                    buttons[minIndex] = temp;
                }
            }

            //updating the button order in the FlowLayoutPanel
            Pnl_bookShelf.Controls.Clear();
            Pnl_bookShelf.Controls.AddRange(buttons.ToArray());
        }
        //End of Method


        /// <summary>
        /// This method check if the bool method is true (verifying that the book order is correct)
        //and directs the app accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBookOrder(object sender, EventArgs e)
        {
            //Referencing:
            //ChatGPT helped with this one.

            //referencing windows
            LoserMessage lost = new LoserMessage();
            WinnerMessage won = new WinnerMessage();
            SoundEffects soundFx = new SoundEffects();

            // Check if buttons are in ascending order
            bool isAscending = CheckAscendingOrder();

            if (isAscending)
            {
                //calling method to calculate and allocate points
                AllocatePoints();

                //starting thread to play sound effect
                soundFxThread = new Thread(soundFx.PlayWinnerSound);
                soundFxThread.Start();

                //opening winner message window
                won.Show();

                //closing this window
                this.Close();

            }
            else
            {
                //starting thread to play sound effect
                soundFxThread = new Thread(soundFx.PlayLoserSound);
                soundFxThread.Start();


                //opening loser message window
                lost.Show();

                //closing current window
                this.Close();

            }
        }
        //End of Method


        /// <summary>
        /// Method setting point requirement and checking
        //the amount of points the user got and storing them
        /// </summary>
        public void AllocatePoints()
        {
            //over 5 minutes
            if (ReplacingBooks.timerTicks > 300)
            {
                //10 points
                UserData.UserPoints = UserData.UserPoints + 10;

                //updating points
                Lbl_points.Text = "Points: " + UserData.UserPoints;
            }

            //under 5 minutes
            if (ReplacingBooks.timerTicks > 120 && ReplacingBooks.timerTicks < 300)
            {
                //100 points
                UserData.UserPoints = UserData.UserPoints + 10;

                //updating points
                Lbl_points.Text = "Points: " + UserData.UserPoints;
            }

            //under 2 minutes
            if (ReplacingBooks.timerTicks > 60 && ReplacingBooks.timerTicks < 121)
            {
                //500 points
                UserData.UserPoints = UserData.UserPoints + 500;

                //updating points
                Lbl_points.Text = "Points: " + UserData.UserPoints;
            }

            //under 1 minute
            if (ReplacingBooks.timerTicks < 61)
            {
                UserData.UserPoints = UserData.UserPoints + 1000;

                //updating points
                Lbl_points.Text = "Points: " + UserData.UserPoints;
            }
        }
        //End of Method


        /// <summary>
        /// Method to compare buttons through their call numbers
        //this method inspect the button's texts 
        /// </summary>
        /// <param name="button1"></param>
        /// <param name="button2"></param>
        /// <returns></returns>
        private int CompareButtons(Button button1, Button button2)
        {
            //Referencing:
            //ChatGPT helped with this one.

            //saving call numbers from two buttons, to compare them
            string text1 = button1.Text;
            string text2 = button2.Text;

            //splitting the text into parts based on the space character
            string[] parts1 = text1.Split(' ');
            string[] parts2 = text2.Split(' ');

            //extracting the numeric parts before and after the "."
            string[] numericParts1 = parts1[0].Split('.');
            string[] numericParts2 = parts2[0].Split('.');

            //comparing the numeric parts before the "."
            int numericBefore1 = int.Parse(numericParts1[0]);
            int numericBefore2 = int.Parse(numericParts2[0]);
            int numericComparison = numericBefore1.CompareTo(numericBefore2);

            if (numericComparison == 0)
            {
                //if the numeric parts before the "." are the same, compare the numeric parts after the "."
                if (numericParts1.Length > 1 && numericParts2.Length > 1)
                {
                    int numericAfter1 = int.Parse(numericParts1[1]);
                    int numericAfter2 = int.Parse(numericParts2[1]);

                    numericComparison = numericAfter1.CompareTo(numericAfter2);
                }
                else if (numericParts1.Length > 1)
                {
                    //button1 has a numeric part after the ".", but button2 doesn't
                    return -1; 
                }
                else if (numericParts2.Length > 1)
                {
                    //button2 has a numeric part after the ".", but button1 doesn't
                    return 1;
                }

                if (numericComparison == 0)
                {
                    //if both numeric parts are the same, compare the letters
                    return string.Compare(parts1[1], parts2[1]);
                }
            }

            return numericComparison; 
        }
        //End of Method


        /// <summary>
        /// Method to verify if book call numbers are in ascending order
        /// </summary>
        /// <returns></returns>
        private bool CheckAscendingOrder()
        {
            //Referencing:
            //ChatGPT helped with this one.

            //list of buttons within flowLayoutPanel
            List<Button> buttons = Pnl_bookShelf.Controls.OfType<Button>().ToList();
            int n = buttons.Count;

            //comparison function to compare two call numbers
            int CompareCallNumbers(Button btn1, Button btn2)
            {
                //the call number is stored as the button's text
                string callNumber1 = btn1.Text;
                string callNumber2 = btn2.Text;

                //splitting the call numbers into numeric and alphabetical parts
                string[] parts1 = callNumber1.Split(' ');
                string[] parts2 = callNumber2.Split(' ');

                //comparing the numeric parts first
                var numericComparison = string.Compare(parts1[0], parts2[0]);
                if (numericComparison != 0)
                {
                    return numericComparison;
                }

                //if the numeric parts are the same, compare the alphabetical parts
                return string.Compare(parts1[1], parts2[1]);
            }

            //selection sort algorithm
            for (int i = 0; i < n - 1; i++)
            {
                if (CompareCallNumbers(buttons[i], buttons[i + 1]) > 0)
                {
                    //buttons are not in ascending order
                    return false; 
                }
            }

            //buttons are in ascending order
            return true;
        }
        //End of Method


        /// <summary>
        /// Method to save numeric part of call number
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private int ExtractNumericPart(string text)
        {
            //Referencing:
            //ChatGPT helped with this one.

            //string formatting to store numeric part
            string numericPart = new string(text.Where(char.IsDigit).ToArray());

            //returning numeric part
            return int.Parse(numericPart);
        }
        //End of Method


        /// <summary>
        /// Link label click-event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Link_lblReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //opening new instance of this window
            ReplacingBooks reset = new ReplacingBooks();
            reset.Show();

            //hiding older instance
            this.Close();
        }
        //End of Method


        /// <summary>
        /// Button event handler to handle app closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            //exiting app
            Environment.Exit(0);
        }

        //End of Method


        /// <summary>
        /// Method to count seconds and handle timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tmr_gameTime_Tick(object sender, EventArgs e)
        {
            //Referencing:
            //IT School Online (2022) How to use timer in C# windows forms, YouTube.
            //Available at: https://www.youtube.com/watch?v=iY9az1-l81k
            //(Accessed: 20 September 2023). 

            //adding to int
            timerTicks++;

            //setting int to equal the ticks in the timer (elapsed seconds)
            sec = timerTicks;

            //establishing minutes
            if (sec == 60)
            {
                min = min + 1;
                timerTicks = 00;
            }

            //displaying time
            Lbl_timer.Text = min.ToString() + " : " + sec.ToString();

        }
        //End of Method
    }
}
//----------------------------------------------END OF CLASS---------------------------------------------------//