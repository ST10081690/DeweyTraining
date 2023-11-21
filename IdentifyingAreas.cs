using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

/*
Name: Euluis Goncalves
App: Dewey Training App.
Last Modified: 25/10/2023.
 */

namespace DeweyTraining
{
    //----------------------------------------------START OF CLASS---------------------------------------------------//
    public partial class IdentifyingAreas : Form
    {
        //private lists and hash sets to store data for the class
        private List<string> deweyCallNumbers = new List<string>();
        private HashSet<string> specificNumbers = new HashSet<string>();
        private HashSet<string> descriptions = new HashSet<string>();
        private List<string> callNumbers = new List<string>();
        private HashSet<string> randomCategories = new HashSet<string>();
        private List<Panel> rightColumnPanels;

        //int to store the amount of matches the user got correct
        private int correctMatchCount = 0;
        private int matchAttempts = 0;

        //bool variables for each round type
        private bool isDescriptionRound = false;
        private bool isCallNumRound = false;

        //button that determines the selected button while playing
        private Button selectedButton = null;

        //creating thread to play sound effects
        public static Thread soundFxThread;

        //bool variables to verify points have been granted for a match
        bool hundredGiven = false;
        bool twoHundredGiven = false;
        bool fiveHundredGiven = false;
        bool thousandGiven = false;

        //Dictionary to store dewey call numbers and categories (descriptions)
        protected Dictionary<string, string> deweyCategories = new Dictionary<string, string>
        {
            { "Technology", "600" },
            { "Mathematics", "500" },
            { "Social Sciences", "300" },
            { "Religion", "200" },
            { "Arts", "700" },
            { "Literature", "800" },
            { "History/Geography", "900" },
            { "Generalities", "000" },
            { "Philosophy/Psychology", "100" },
            { "Language", "400" },
        };


        public IdentifyingAreas()
        {
            InitializeComponent();

            //calling method to set up the columns and content
            SetUpContent();

            //setting background image
            this.BackgroundImage = Properties.Resources.dark_wood;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            //retrieving the amount of points the user has
            Lbl_points.Text = "Points: " + UserData.UserPoints;
        }
        //End of method



        /// <summary>
        /// Method to set up columns
        /// </summary>
        private void SetUpContent()
        {
            //Setting up a list of the right column panels
            rightColumnPanels = new List<Panel>
            {
                pnlRightColumn1,
                pnlRightColumn2,
                pnlRightColumn3,
                pnlRightColumn4,
                pnlRightColumn5,
                pnlRightColumn6,
                pnlRightColumn7
            };

            //enabling drag-and-drop for left column buttons
            foreach (Button button in pnlLeftColumn.Controls)
            {
                button.MouseDown += Button_MouseDown;
                button.MouseMove += Button_MouseMove;
                button.MouseUp += Button_MouseUp;
                button.AllowDrop = true;
            }

            //ensuring panels can handle drag and drop
            pnlLeftColumn.DragEnter += pnlLeftColumn_DragEnter;
            pnlLeftColumn.DragDrop += pnlLeftColumn_DragDrop;
            pnlLeftColumn.AllowDrop = true;

            pnlRightColumn1.DragEnter += rightPanel_DragEnter;
            pnlRightColumn1.DragDrop += rightPanel_DragDrop;
            pnlRightColumn1.AllowDrop = true;

            pnlRightColumn2.DragEnter += rightPanel_DragEnter;
            pnlRightColumn2.DragDrop += rightPanel_DragDrop;
            pnlRightColumn2.AllowDrop = true;

            pnlRightColumn3.DragEnter += rightPanel_DragEnter;
            pnlRightColumn3.DragDrop += rightPanel_DragDrop;
            pnlRightColumn3.AllowDrop = true;

            pnlRightColumn4.DragEnter += rightPanel_DragEnter;
            pnlRightColumn4.DragDrop += rightPanel_DragDrop;
            pnlRightColumn4.AllowDrop = true;

            pnlRightColumn5.DragEnter += rightPanel_DragEnter;
            pnlRightColumn5.DragDrop += rightPanel_DragDrop;
            pnlRightColumn5.AllowDrop = true;

            pnlRightColumn6.DragEnter += rightPanel_DragEnter;
            pnlRightColumn6.DragDrop += rightPanel_DragDrop;
            pnlRightColumn6.AllowDrop = true;

            pnlRightColumn7.DragEnter += rightPanel_DragEnter;
            pnlRightColumn7.DragDrop += rightPanel_DragDrop;
            pnlRightColumn7.AllowDrop = true;

            //calling method to set up the game round
            SetUpRound();

        }
        //End of method


        /// <summary>
        /// Method to set up game round with necessary items
        /// </summary>
        private void SetUpRound()
        {
            //Random variable
            var roundRandom = new Random();

            //Randomly generating an integer between 1 and 2, to set round type
            int roundType = roundRandom.Next(1, 3);

            //setting round type if result is 1
            if (roundType == 1)
            {
                isDescriptionRound = true;
                isCallNumRound = false;
            }
            else if (roundType == 2) //setting round type if result is 2
            {
                isCallNumRound = true;
                isDescriptionRound = false;
            }

            //Populating and setting up game for description round
            if (isDescriptionRound)
            {
                deweyCallNumbers = GenerateRandomCallNumbers();
                descriptions = GenerateSpecificDescriptions();

                PopulateLeftPanel(descriptions.Take(4).ToList());
                PopulateRightPanels(deweyCallNumbers.Take(7).ToList());
            }

            //Populating and setting up game for call number round
            if (isCallNumRound)
            {
                descriptions = GetRandomDeweyCategories(deweyCategories, 7);
                specificNumbers = GenerateSpecificCallNumbers();

                PopulateLeftPanel(specificNumbers.Take(4).ToList());
                PopulateRightPanels(descriptions.Take(7).ToList());              
            }           
        }
        // End of method

  
        /// <summary>
        /// Method to generate random call numbers (in a description round).
        /// </summary>
        /// <returns></returns>
        private List<string> GenerateRandomCallNumbers()
        {
            // Generate a list of random Dewey Call Numbers (3-digit numbers)
            Random random = new Random();

            //List to store the first digits (which must not be repeated)
            List<int> usedFirstDigits = new List<int>();

            //int for call numbers that have to be created
            int callNumbersToGenerate = 0;

            //ensuring it is a description round
            if (isDescriptionRound == true)
            {
                //setting amount of numbers to be generated
                callNumbersToGenerate = 7;

                //loop to run until set amount of numbers is reached
                while (callNumbers.Count < callNumbersToGenerate)
                {
                    int firstDigit;

                    do
                    {
                        firstDigit = random.Next(10); // Random first digit (0-9)

                    } while (usedFirstDigits.Contains(firstDigit));

                    //adding first digit to list
                    usedFirstDigits.Add(firstDigit);

                    int secondDigit = random.Next(10); // Random second digit (0-9)
                    int thirdDigit = random.Next(10);   // Random third digit (0-9)

                    //puting numbers together and saving them
                    callNumbers.Add($"{firstDigit}{secondDigit}{thirdDigit}");
                }
            }

            return callNumbers;
        }
        //End of method

  
        /// <summary>
        /// Method to generate specific call numbers to match descriptions (in a call number round).
        /// </summary>
        /// <returns></returns>
        public HashSet<string> GenerateSpecificCallNumbers()
        {
            //HashSet to store call number that match descriptions (they cannot be repeated).
            HashSet<string> specificCallNumbers = new HashSet<string>();

            //Random variable
            Random random = new Random();

            //Taking 4 descriptions out of the randomly generated ones
            List<string> selectedCategories = descriptions.Take(4).ToList();

            foreach (var description in selectedCategories)
            {
                //Finding the matching number based on the description
                string matchingNumber = FindMatchingNumber(description);

                //Checking if 
                if (!string.IsNullOrEmpty(matchingNumber))
                {
                    string theNum = matchingNumber[0].ToString();
                    int firstDigit = int.Parse(theNum);
                    int secondDigit = random.Next(10); // Random second digit (0-9)
                    int thirdDigit = random.Next(10);

                    //Putting number together and saving it
                    specificCallNumbers.Add($"{firstDigit}{secondDigit}{thirdDigit}");
                }
                else
                {
                    //No matching number found, you can handle this case accordingly
                    specificCallNumbers.Add("No Number Found");
                }
            }

            return specificCallNumbers;
        }
        //End of method


        /// <summary>
        /// Method to find the matching call numbers to selected descriptions (in a description round).
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public string FindMatchingNumber(string description)
        {
            //Finding the number that matches the description at hand
            if (deweyCategories.TryGetValue(description, out var matchingNumber))
            {
                return matchingNumber;
            }
            else
            {
                //Handling the case when no matching number is found.
                return "No Number Found";
            }
        }
        //End of method


        /// <summary>
        /// Method to generate random dewey descriptions/categories (in a call number round).
        /// </summary>
        /// <param name="categories"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        //Referencing: ChatGPT helped with this one.
        public HashSet<string> GetRandomDeweyCategories(Dictionary<string, string> categories, int count)
        {
            //Random variable
            var random = new Random();

            // Create a list of category keys to select from
            var categoryKeys = categories.Keys.ToList();

            //Running while list is less than count (which is set to 7)
            while (randomCategories.Count < count && categoryKeys.Count > 0)
            {
                int randomIndex = random.Next(categoryKeys.Count);
                string randomCategory = categoryKeys[randomIndex];

                // Add the randomly selected category to the HashSet
                randomCategories.Add(randomCategory);

                // Remove the selected category from the list to avoid duplicates
                categoryKeys.RemoveAt(randomIndex);
            }

            return randomCategories;
        }
        //End of method


        /// <summary>
        /// Method to generate matching descriptions (for description round).
        /// </summary>
        /// <returns></returns>
        private HashSet<string> GenerateSpecificDescriptions()
        {
            //HashSet to store the specific descriptions that match the call numbers (they cannot be repeated)
            HashSet<string> matchedDescriptions = new HashSet<string>();

            int descriptionsToGenerate = 0;

            //Ensuring it is a description round
            if (isDescriptionRound)
            {
                //Setting number of descriptions to be generated
                descriptionsToGenerate = 4;

                //Checking through each item in the call number list
                foreach (var callNumber in callNumbers.Take(descriptionsToGenerate))
                {
                    //Getting the three digits from the call number
                    string callNumberDigits = callNumber.Substring(0, 3);

                    //Finding the matching category (key) in deweyCategories based on the callNumberDigits
                    string matchingCategory = FindMatchingCategory(callNumberDigits);

                    //Ensuring a result is captured from the matching method
                    if (!string.IsNullOrEmpty(matchingCategory))
                    {
                        matchedDescriptions.Add(matchingCategory);
                    }
                    else
                    {
                        // No matching category found, you can handle this case accordingly
                        matchedDescriptions.Add("No Category Found");
                    }
                }

            }

            return matchedDescriptions;
        }
        //End of method


        /// <summary>
        /// Helper method to find the matching category to the call numbers generated 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        //Referencing: ChatGPT helped with this one.
        private string FindMatchingCategory(string value)
        {
            //looking through each key-value pair in dictionary
            foreach (var kvp in deweyCategories)
            {
                string categoryValue = kvp.Value;
                if (categoryValue.Length > 0)
                {
                    char firstDigit = categoryValue[0];
                    if (value.StartsWith(firstDigit.ToString()))
                    {
                        return kvp.Key; // Return the matching category (key).
                    }
                }
            }
            return "Not Found";
        }
        //End of method


        /// <summary>
        /// Method to shuffle elements within a list, to make it less predictable when data is presented
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        //Referencing: ChatGPT helped with this one
        public static void ShuffleList<T>(List<T> list)
        {
            //random variable
            Random random = new Random();
            int n = list.Count;

            //looping through list items
            for (int i = 0; i < n - 1; i++)
            {
                int j = random.Next(i, n);
                T temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
        //End of method


        /// <summary>
        /// Method to populate left column buttons with data
        /// </summary>
        /// <param name="data"></param>
        private void PopulateLeftPanel(List<string> data)
        {
            //Calling method to shuffle data
            ShuffleList(data);

            //Populating the left panel buttons with data
            btn_left1.Text = data[0];
            btn_left2.Text = data[1];
            btn_left3.Text = data[2];
            btn_left4.Text = data[3];

        }
        //End of method


        /// <summary>
        /// Handling button selection, for it to be moved 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //Referencing: ChatGPT helped with this one.
        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectedButton = (Button)sender;
                pnlLeftColumn.DoDragDrop(selectedButton, DragDropEffects.Move);
            }
        }
        //End of method


        /// <summary>
        /// Handling button movement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //Referencing: ChatGPT helped with this one.
        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedButton != null && e.Button == MouseButtons.Left)
            {
                selectedButton.Left = e.X + selectedButton.Left - selectedButton.Width / 2;
                selectedButton.Top = e.Y + selectedButton.Top - selectedButton.Height / 2;
            }
        }
        //End of method


        /// <summary>
        /// Handle for when user lets go of the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //Referencing: ChatGPT helped with this one.
        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            selectedButton = null;
        }
        //End of method


        /// <summary>
        /// Event handler for allowing drag onto pnlLeftColumn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //Referencing: ChatGPT helped with this one.
        private void pnlLeftColumn_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Button)) && e.AllowedEffect == DragDropEffects.Move)
            {
                e.Effect = DragDropEffects.Move;
            }
        }
        //End of method


        /// <summary>
        /// Event handler for handling the drop operation into the left column panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //Referencing: ChatGPT helped with this one.
        private void pnlLeftColumn_DragDrop(object sender, DragEventArgs e)
        {
            if (selectedButton != null)
            {
                Panel targetPanel = (Panel)sender;

                //Setting the location inside the target panel
                selectedButton.Location = new Point(0, 0); 
                targetPanel.Controls.Add(selectedButton);
                selectedButton = null;
                
            }
        }
        //End of method


        /// <summary>
        /// Event handler for allowing drag onto right column panels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //Referencing: ChatGPT helped with this one.
        private void rightPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Button)) && e.AllowedEffect == DragDropEffects.Move)
            {
                e.Effect = DragDropEffects.Move;
            }
        }
        //End of method


        /// <summary>
        /// Method to handle drop into the right column panels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //Referencing: ChatGPT helped with this one.
        private void rightPanel_DragDrop(object sender, DragEventArgs e)
        {
            Button button = (Button)e.Data.GetData(typeof(Button));
            Panel targetPanel = (Panel)sender;

            if (selectedButton != null)
            {
                // Ensure the target panel does not have more than one control (the label)
                if (targetPanel.Controls.Count == 1)
                {
                    targetPanel.Controls.Add(selectedButton);
                    selectedButton = null;
                }
                
            }
        }
        //End of method


        /// <summary>
        /// Method to populate the right column with data
        /// </summary>
        /// <param name="data"></param>
        private void PopulateRightPanels(List<string> data)
        {
            ShuffleList(data);

            // Populate the right labels with data
            lbl_RightText1.Text = data[0];
            lbl_RightText2.Text = data[1];
            lbl_RightText3.Text = data[2];
            lbl_RightText4.Text = data[3];
            lbl_RightText5.Text = data[4];
            lbl_RightText6.Text = data[5];
            lbl_RightText7.Text = data[6];

        }
        //End of method


        /// <summary>
        /// Method to check if items within panel match based on the dictionary
        /// </summary>
        /// <param name="callNumber"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        //Referencing: ChatGPT helped with this one.
        private bool IsMatch(string callNumber, string description)
        {
            //Extracting the first digit from the call number
            string callNumberDigit = callNumber.Substring(0, 1);

            //Checking if the call number is in the dictionary
            if (deweyCategories.TryGetValue(description, out string categoryValue)) 
            {
                //Extracting the first digit from the dictionary value
                string categoryFirstDigit = categoryValue.Substring(0, 1);

                //Comparing the first digit of the callNumber with the first digit of the dictionary value
                if (callNumberDigit == categoryFirstDigit)
                {
                    return true; //First digit matches
                }
            }

            return false; //No match found
        }
        //End of method


        /// <summary>
        /// Method to test if the user is right or wrong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            //Resetting count
            correctMatchCount = 0;
            matchAttempts = 0;

            //checking each panel in the right column
            foreach (Panel rightPanel in rightColumnPanels)
            {
                //cheking if the panel has a label (all of them should have)
                if (rightPanel.Controls.Count > 0 && rightPanel.Controls[0] is Label)
                {
                    //getting the text from the label (needed to check if it is matching)
                    Label label = (Label)rightPanel.Controls[0];
                    string labelText = label.Text;

                    //checking if there is a button inside the panel
                    if (rightPanel.Controls.Count > 1 && rightPanel.Controls[1] is Button)
                    {
                        //getting button text 
                        Button button = (Button)rightPanel.Controls[1];
                        string buttonText = button.Text;

                        
                        if (isDescriptionRound)//proceeding with description round matching
                        {
                            //Check if the button text matches the label text
                            if (IsMatch(labelText, buttonText))
                            {
                                correctMatchCount++;
                            }

                        }

                        if (isCallNumRound)//proceeding with call number round matching
                        {
                            //Check if the button text matches the label text
                            if (IsMatch(buttonText, labelText))
                            {
                                correctMatchCount++;
                            }

                        }
                        
                        //adding to match attempt count (user has dragged buttons to the right column)
                        matchAttempts++;
                    }               
                }
            }

            //calling method to show user a result message 
            ShowMessage();

        }
        //End of method


        /// <summary>
        /// Method to show user messages based on the amount of correct matches
        /// </summary>
        public void ShowMessage()
        {
            //referencing class
            SoundEffects soundFx = new SoundEffects();

            //checking if the user tried to match items (if right column has buttons)
            if (matchAttempts == 0)//no attempts
            {
                //showing message
                MessageBox.Show("There are 0 Match Attempts Present. \nDrag and Drop Items From The Left Column To The Right To Match Them.");

            }

            //checking if the user tried to match items (if right column has buttons)
            if (matchAttempts >= 1) //attempts were made
            {
                //showing user message based on the number of correct matches
                switch (correctMatchCount)
                {
                    case 0:
                        //starting thread to play sound effect
                        soundFxThread = new Thread(soundFx.PlayLoserSound);
                        soundFxThread.Start();

                        MessageBox.Show("Oh No... None of the items match. Try Again!");
                        break;
                    case 1:
                        MessageBox.Show("You Got 1 Correct Match! \nKeep Trying");
                        break;
                    case 2:
                        MessageBox.Show("Nice! 2 Correct Matches. \nLet's Keep Going");
                        break;
                    case 3:
                        MessageBox.Show("Wow! 3 Correct Matches. \nOnly 1 Missing!");
                        break;
                    case 4:

                        //starting thread to play sound effect
                        soundFxThread = new Thread(soundFx.PlayWinnerSound);
                        soundFxThread.Start();

                        MessageBox.Show("Super Well Done! 4 Correct Matches.");

                        break;
                }

                //calling method to grant necessary points
                AllocatePoints();

            }
        }
        //End of method


        /// <summary>
        /// Method to allocate points to user
        /// </summary>
        public void AllocatePoints()
        {
            //switch to allocate points based on the amount of correct matches
            switch (correctMatchCount)
            {
                case 1:
                    if (!hundredGiven)
                    {
                        //100 points
                        UserData.UserPoints = UserData.UserPoints + 100;

                        //updating points
                        Lbl_points.Text = "Points: " + UserData.UserPoints;

                        //user does not get points for the same match more than once
                        hundredGiven = true;
                    }
                    break;
                case 2:
                    if (!twoHundredGiven)
                    {
                        //200 points
                        UserData.UserPoints = UserData.UserPoints + 200;

                        //updating points
                        Lbl_points.Text = "Points: " + UserData.UserPoints;

                        //user does not get points for the same match more than once
                        twoHundredGiven = true;
                    }
                    break;
                case 3:
                    if (!fiveHundredGiven)
                    {
                        //500 points
                        UserData.UserPoints = UserData.UserPoints + 500;

                        //updating points
                        Lbl_points.Text = "Points: " + UserData.UserPoints;

                        //user does not get points for the same match more than once
                        fiveHundredGiven = true;
                    }
                    break;
                case 4:
                    if (!thousandGiven)
                    {
                        //1000 points
                        UserData.UserPoints = UserData.UserPoints + 1000;

                        //updating points
                        Lbl_points.Text = "Points: " + UserData.UserPoints;

                        //user does not get points for the same match more than once
                        thousandGiven = true;
                    }
                    break;
            }
        }
        //End of Method


        /// <summary>
        /// Button event handler to go back to main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            //instatiating window 
            StartUp startForm = new StartUp();

            //opening start window
            startForm.Show();

            //hiding this window
            this.Hide();
        }
        //End of method


        /// <summary>
        /// Button event handler to restart window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            //instantiating form
            IdentifyingAreas identifying = new IdentifyingAreas();

            //opening new form
            identifying.Show();

            //hiding current window
            this.Hide();
        }
        //End of method


        /// <summary>
        /// Button event handler to exit application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            //exiting app
            Environment.Exit(0);
        }
        //End of method
    }
}
//----------------------------------------------END OF CLASS---------------------------------------------------//