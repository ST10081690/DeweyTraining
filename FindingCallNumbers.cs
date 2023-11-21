using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

    /*
    Name: Euluis Goncalves
    App: Dewey Training App.
    Last Modified: 21/11/2023.
    */

namespace DeweyTraining
{
    //---------------------------------------------------START OF CLASS--------------------------------------------------------//

    public partial class FindingCallNumbers : Form
    {
        //root TreeNode
        private TreeNode root;

        //HashSet  for the four displayed options
        private HashSet<string> PossibleOptions;

        //int to keep track of the detail level reached
        private int levelReached = 0;

        //random variable for selecting a random node
        private Random nodeRandom = new Random();

        //int to store the amount of times user clicked on the correct option
        private int correctMatchCount = 0;

        //creating thread to play sound effects
        public static Thread soundFxThread;


        public FindingCallNumbers()
        {
            InitializeComponent();

            //initializing HashSet
            PossibleOptions = new HashSet<string>();

            //calling method to initialize tree and build structure
            InitializeTree();

            //calling method populate description and options
            PopulateRandomDescriptionAndOptions();

            //setting background image
            this.BackgroundImage = Properties.Resources.dark_wood;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            //retrieving the amount of points the user has and displaying it
            Lbl_points.Text = "Points: " + UserData.UserPoints;

        }
        //End of method


        /// <summary>
        /// Method to initialize the tree
        /// </summary>
        /// Referencing: ChatGPT assisted with this method.
        private void InitializeTree()
        {
            //path to dewey data text file (CallNumberTree.txt) from resources
            string file = Properties.Resources.CallNumberTree;

            //reading the text file content using a StringReader.
            using (StringReader reader = new StringReader(file))
            {
                List<string> lines = new List<string>();

                //reading lines from the StringReader.
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                        break;

                    //adding line of data
                    lines.Add(line);
                }

                //building and populating the tree.
                root = BuildTree(lines);

                //clearing then populating tree view
                treeView_Dewey.Nodes.Clear();
                PopulateTreeView(treeView_Dewey, root);
                PopulateTopLevelButtons(root);
            }
        }
        // End of method


        /// <summary>
        /// Method to build the tree using text file data
        /// </summary>
        /// <param name="lines"></param>
        /// <returns> rootNode </returns>
        /// Referencing: ChatGPT assisted with this method.
        private TreeNode BuildTree(List<string> lines)
        {
            //setting a root node for the tree
            TreeNode rootNode = new TreeNode("Dewey Decimal System");
            Stack<TreeNode> nodeStack = new Stack<TreeNode>();
            nodeStack.Push(rootNode);

            //looping through each line of the text file
            foreach (var line in lines)
            {
                //counting leading spaces to determine the indentation level
                int indentation = line.TakeWhile(char.IsWhiteSpace).Count();

                //trimming spaces from the beginning and end of the line
                string trimmedLine = line.Trim();

                //finding the appropriate parent node based on the indentation
                while (nodeStack.Count > indentation / 3 + 1)
                {
                    nodeStack.Pop();
                }

                TreeNode currentNode = nodeStack.Peek();

                //creating a new node for the current line
                TreeNode newNode = new TreeNode(trimmedLine);

                //adding the new node to the parent node
                currentNode.Nodes.Add(newNode);

                //pushing the new node to the stack for potential child nodes
                nodeStack.Push(newNode);
            }

            //returning rootNode
            return rootNode;
        }
        // End of method


        /// <summary>
        /// Method to populate TreeView with data
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="rootNode"></param>
        /// Referencing: ChatGPT assisted with this method.
        private void PopulateTreeView(TreeView treeView, TreeNode rootNode)
        {
            //adding rootNode
            treeView.Nodes.Add((TreeNode)rootNode.Clone());

            //calling method to expand tree nodes
            ExpandNodes(treeView.Nodes);
        }
        // End of method


        /// <summary>
        /// Method to expand tree nodes
        /// </summary>
        /// <param name="nodes"></param>
        /// Referencing: ChatGPT assisted with this method.
        private void ExpandNodes(TreeNodeCollection nodes)
        {
            //looping through each node
            foreach (TreeNode node in nodes)
            {
                ExpandNodes(node.Nodes);
                node.Expand();
            }
        }
        // End of method


        /// <summary>
        /// Method to populate a description and four initial options
        /// </summary>
        /// Referencing: ChatGPT assisted with this method.
        private void PopulateRandomDescriptionAndOptions()
        {
            //getting all top-level nodes
            List<TreeNode> topLevelNodes = GetAllTopLevelNodes(root);

            //randomly selecting a top-level node
            TreeNode randomTopLevelNode = topLevelNodes[nodeRandom.Next(topLevelNodes.Count)];

            //getting all third-level nodes under the randomly selected top-level node
            List<TreeNode> thirdLevelNodes = GetAllThirdLevelNodes(randomTopLevelNode); 

            //randomly selecting a third-level node
            TreeNode randomThirdLevelNode = thirdLevelNodes[nodeRandom.Next(thirdLevelNodes.Count)];

            //setting the description of the randomly selected third-level node to Lbl_Description
            Lbl_Description.Text = randomThirdLevelNode.Text.Substring(4); // Remove the first 4 characters

            //clearing the PossibleOptions HashSet before populating it
            PossibleOptions.Clear();

            //adding the call number and description of the randomly selected top-level node to the PossibleOptions HashSet
            PossibleOptions.Add($"{randomTopLevelNode.Text}");

            //selecting 3 more random top-level nodes and adding them to the PossibleOptions HashSet
            while (PossibleOptions.Count < 4)
            {
                int randomIndex = new Random().Next(root.Nodes.Count);
                TreeNode additionalRandomTopLevelNode = root.Nodes[randomIndex];

                if (additionalRandomTopLevelNode.Text != "Dewey Decimal System")
                {
                    PossibleOptions.Add($"{additionalRandomTopLevelNode.Text}");
                }
            }

            //ensuring that the fourth option matches the top-level node of the randomly selected third-level node
            PossibleOptions.Add($"{randomThirdLevelNode.Parent?.Parent?.Text}");

            //converting PossibleOptions HashSet to a list for easier access
            List<string> optionsList = PossibleOptions.ToList();

            //arranging optionsList in ascending order based on the first number
            optionsList.Sort((s1, s2) =>
            {
                int number1 = int.Parse(s1.Split(' ')[0]);
                int number2 = int.Parse(s2.Split(' ')[0]);
                return number1.CompareTo(number2);
            });

            //populating buttons with the ordered options
            btnOption1.Text = optionsList[0];
            btnOption2.Text = optionsList[1];
            btnOption3.Text = optionsList[2];
            btnOption4.Text = optionsList[3];
        }
        // End of method


        /// <summary>
        /// Method to gather all top level nodes from the tree
        /// </summary>
        /// <param name="rootNode"></param>
        /// <returns>topLevelNodes</returns>
        private List<TreeNode> GetAllTopLevelNodes(TreeNode rootNode)
        {
            List<TreeNode> topLevelNodes = new List<TreeNode>();

            //looping through each top level node from the tree
            foreach (TreeNode topLevelNode in rootNode.Nodes)
            {
                //ensuring it is not "Dewey Decimal System" only the other top level nodes
                if (topLevelNode.Text != "Dewey Decimal System")
                {
                    //adding nodes to list
                    topLevelNodes.Add(topLevelNode);
                }
            }

            //returning list
            return topLevelNodes;
        }
        // End of method


        /// <summary>
        /// Method to gather all third level nodes from the tree
        /// </summary>
        /// <param name="rootNode"></param>
        /// <returns>thirdLevelNodes</returns>
        private List<TreeNode> GetAllThirdLevelNodes(TreeNode rootNode)
        {
            List<TreeNode> thirdLevelNodes = new List<TreeNode>();

            //looping through second level nodes
            foreach (TreeNode secondLevelNode in rootNode.Nodes)
            {
                //loopong through nodes under each second level node
                foreach (TreeNode thirdLevelNode in secondLevelNode.Nodes)
                {
                    //adding nodes to list
                    thirdLevelNodes.Add(thirdLevelNode);
                }
            }

            //returning list
            return thirdLevelNodes;
        }
        // End of method


        /// <summary>
        /// Method to populate buttons with top level options
        /// </summary>
        /// <param name="rootNode"></param>
        /// Referencing: ChatGPT assisted with this method.
        private void PopulateTopLevelButtons(TreeNode rootNode)
        {
            //ensuring there are enough top level nodes
            if (rootNode.Nodes.Count >= 4)
            {
                //getting a list of top-level nodes
                List<TreeNode> topLevelNodes = new List<TreeNode>(rootNode.Nodes.Cast<TreeNode>());

                //sorting the first four nodes in ascending order
                topLevelNodes.Sort((node1, node2) => string.Compare(node1.Text, node2.Text, StringComparison.Ordinal));

                //setting buttons text based on the arranged top-level nodes
                btnOption1.Text = topLevelNodes[0].Text;
                btnOption2.Text = topLevelNodes[1].Text;
                btnOption3.Text = topLevelNodes[2].Text;
                btnOption4.Text = topLevelNodes[3].Text;
            }
        }
        // End of method


        /// <summary>
        /// Button event handler for clicking option 1 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOption1_Click_1(object sender, EventArgs e)
        {
            //checking which level user has reached and calling appropriate method to verify answer
            switch (levelReached)
            {
                case 0:
                    CheckAnswer(btnOption1.Text);
                    break;
                case 1:
                    CheckAnswerLevel2(btnOption1.Text);
                    break;
                case 2:
                    CheckAnswerLevel3(btnOption1.Text);
                    break;

            }
        }
        // End of method


        /// <summary>
        /// Button event handler for clicking option 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOption2_Click(object sender, EventArgs e)
        {
            //checking which level user has reached and calling appropriate method to verify answer
            switch (levelReached)
            {
                case 0:
                    CheckAnswer(btnOption2.Text);
                    break;
                case 1:
                    CheckAnswerLevel2(btnOption2.Text);
                    break;
                case 2:
                    CheckAnswerLevel3(btnOption2.Text);
                    break;

            }
        }
        // End of method


        /// <summary>
        /// Button event handler for clicking option 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOption3_Click(object sender, EventArgs e)
        {
            //checking which level user has reached and calling appropriate method to verify answer
            switch (levelReached)
            {
                case 0:
                    CheckAnswer(btnOption3.Text);
                    break;
                case 1:
                    CheckAnswerLevel2(btnOption3.Text);
                    break;
                case 2:
                    CheckAnswerLevel3(btnOption3.Text);
                    break;

            }
        }
        // End of method


        /// <summary>
        /// Button event handler for clicking option 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOption4_Click(object sender, EventArgs e)
        {
            //checking which level user has reached and calling appropriate method to verify answer
            switch (levelReached)
            {
                case 0:
                    CheckAnswer(btnOption4.Text);
                    break;
                case 1:
                    CheckAnswerLevel2(btnOption4.Text);
                    break;
                case 2:
                    CheckAnswerLevel3(btnOption4.Text);
                    break;

            }

        }
        // End of method


        /// <summary>
        /// Method to check if user selected the right option - for the top level options
        /// </summary>
        /// <param name="selectedOption"></param>
        /// Referencing: ChatGPT assisted with this method.
        private void CheckAnswer(string selectedOption)
        {
            //getting the top-level node for the Lbl_Description text
            TreeNode descriptionTopLevelNode = GetTopLevelNode(Lbl_Description.Text);

            TreeNode secondLevelNode = null;

            //checking if the description matches a third-level node under the selected top-level node
            TreeNode thirdLevelNode = GetThirdLevelNode(descriptionTopLevelNode, Lbl_Description.Text);

            //checking if the selected option matches the top-level node
            if (descriptionTopLevelNode != null && descriptionTopLevelNode.Text == selectedOption)
            {
                    if (thirdLevelNode != null)
                    {
                        //increasing level reached
                        levelReached++;

                        //increasing match count and allocating points
                        correctMatchCount++;
                        AllocatePoints();
                        
                        //gathering the second-level node that Lbl_Description.text - thirdLevelNode belongs to
                        secondLevelNode = thirdLevelNode.Parent;

                        //gathering three other secondLevelNodes under the found topLevelNode
                        List<TreeNode> otherSecondLevelNodes = GetThreeOtherSecondLevelNodes(descriptionTopLevelNode, secondLevelNode);

                        //adding the gathered secondLevelNodes to the PossibleOptions HashSet
                        PossibleOptions.Clear();
                        PossibleOptions.Add(secondLevelNode.Text);

                        //looping through each of the other second level nodes gathered
                        foreach (TreeNode otherNode in otherSecondLevelNodes)
                        {
                            //adding node text to HashSet
                            PossibleOptions.Add(otherNode.Text);
                        }

                        //converting PossibleOptions HashSet to a list for easier access
                        List<string> optionsList = PossibleOptions.ToList();

                        //arranging optionsList in ascending order based on the first number
                        optionsList.Sort((s1, s2) =>
                        {
                            int number1 = int.Parse(s1.Split(' ')[0]);
                            int number2 = int.Parse(s2.Split(' ')[0]);
                            return number1.CompareTo(number2);
                        });

                        //populating btnOption1 - 4 with the ordered options
                        btnOption1.Text = optionsList[0];
                        btnOption2.Text = optionsList[1];
                        btnOption3.Text = optionsList[2];
                        btnOption4.Text = optionsList[3];
                    }
                
            }
            else //wrong answer
            {
                //resetting level reached and matchCount
                levelReached = 0;
                correctMatchCount = 0;

                //calling method to play sound effect
                PlaySoundEffect(2);

                //notifying user
                MessageBox.Show("Wrong Call Number, Try Again!");

                //continuing the game by updating the question
                PopulateRandomDescriptionAndOptions();
            }
        }
        // End of method


        /// <summary>
        /// Method to check if user selected the right option - for the second level options
        /// </summary>
        /// <param name="selectedOption"></param>
        /// Referencing: ChatGPT assisted with this method.
        private void CheckAnswerLevel2(string selectedOption)
        {
            //getting the top-level node for the Lbl_Description text
            TreeNode descriptionTopLevelNode = GetTopLevelNode(Lbl_Description.Text);

            //checking if the description matches a third-level node under the selected top-level node
            TreeNode thirdLevelNode = GetThirdLevelNode(descriptionTopLevelNode, Lbl_Description.Text);

            //gathering 4 thirdLevelNodes under the found secondLevelNode
            List<TreeNode> gatheredThirdLevelNodes = GetSiblingThirdLevelNodes(thirdLevelNode);

            //verifying level reached
            if (levelReached == 1)
            {
                //validating if the selected btnOption.Text matches the secondLevelNode
                if (selectedOption == thirdLevelNode.Parent.Text)
                {

                    //adding the gathered thirdLevelNodes to the PossibleOptions HashSet
                    PossibleOptions.Clear();

                    //converting PossibleOptions HashSet to a list for easier access
                    List<string> optionsList = PossibleOptions.ToList();

                    //looping through gathered third level nodes
                    foreach (TreeNode siblingNode in gatheredThirdLevelNodes)
                    {
                        PossibleOptions.Add(siblingNode.Text);
                    }

                    //converting PossibleOptions HashSet to a list after populating it
                    optionsList = PossibleOptions.ToList();

                    //adding node to list (node that matches description in question)
                    optionsList.Add(thirdLevelNode.Text);

                    //arranging optionsList in ascending order based on the first number
                    optionsList.Sort((s1, s2) =>
                    {
                        int number1 = int.Parse(s1.Split(' ')[0]);
                        int number2 = int.Parse(s2.Split(' ')[0]);
                        return number1.CompareTo(number2);
                    });

                    //populating btnOption1 - 4 with the ordered options
                    btnOption1.Text = optionsList[0];
                    btnOption2.Text = optionsList[1];
                    btnOption3.Text = optionsList[2];
                    btnOption4.Text = optionsList[3];

                    //increasing level reached
                    levelReached++;

                    //increasing match count and allocating points
                    correctMatchCount++;
                    AllocatePoints();
                }
                else //wrong answer
                {
                    //resetting level reached and matchCount
                    levelReached = 0;
                    correctMatchCount = 0;

                    //calling method to play sound effect
                    PlaySoundEffect(2);

                    //notifying user
                    MessageBox.Show("Wrong Call Number, Try Again!");

                    //continuing the game by updating the question
                    PopulateRandomDescriptionAndOptions();
                }
            }
        }
        // End of method


        /// <summary>
        /// Method to check if user selected the right option - for the third level options
        /// </summary>
        /// <param name="selectedOption"></param>
        private void CheckAnswerLevel3(string selectedOption)
        {
            //getting the top-level node for the Lbl_Description text
            TreeNode descriptionTopLevelNode = GetTopLevelNode(Lbl_Description.Text);

            //checking if the description matches a third-level node under the selected top-level node
            TreeNode thirdLevelNode = GetThirdLevelNode(descriptionTopLevelNode, Lbl_Description.Text);

            //verifying level reached
            if (levelReached == 2)
            {
                //resetting level reached as this is the furthest level
                levelReached = 0;

                //validate if the selected btnOption.Text matches the thirdLevelNode
                if (selectedOption == thirdLevelNode.Text)
                {
                    //calling method to play sound effect
                    PlaySoundEffect(1);

                    //notifying user
                    MessageBox.Show("You found the call number! Well Done.");

                    //increasing match count and allocating points
                    correctMatchCount++;
                    AllocatePoints();

                    //continuing the game by updating the question
                    PopulateRandomDescriptionAndOptions();
                }
                else //wrong answer
                {

                    //calling method to play sound effect
                    PlaySoundEffect(2);

                    //notifying user
                    MessageBox.Show("Wrong Call Number, Try Again!");

                    //continuing the game by updating the question
                    PopulateRandomDescriptionAndOptions();
                }

            }
            
        }
        // End of method


        /// <summary>
        /// Method to find the third level node matching description in question
        /// </summary>
        /// <param name="topLevelNode"></param>
        /// <param name="description"></param>
        /// <returns>thirdLevelNode</returns>
        /// Referencing: ChatGPT assisted with this method.
        private TreeNode GetThirdLevelNode(TreeNode topLevelNode, string description)
        {
            //finding the third-level node that contains the description under the given top-level node
            foreach (TreeNode secondLevelNode in topLevelNode.Nodes)
            {
                foreach (TreeNode thirdLevelNode in secondLevelNode.Nodes)
                {
                    //checking if node description (without call number) matche
                    if (thirdLevelNode.Text.Substring(4) == description)
                    {
                        //returning node
                        return thirdLevelNode;
                    }
                }
            }

            //returning null if not found
            return null; 
        }
        // End of method


        /// <summary>
        /// Method to gather second level nodes siblings to selectedNode
        /// </summary>
        /// <param name="topLevelNode"></param>
        /// <param name="selectedNode"></param>
        /// <returns>otherSecondLevelNodes</returns>
        /// Referencing: ChatGPT assisted with this method.
        private List<TreeNode> GetThreeOtherSecondLevelNodes(TreeNode topLevelNode, TreeNode selectedNode)
        {
            //getting three other second-level nodes under the given top-level node
            List<TreeNode> otherSecondLevelNodes = new List<TreeNode>();

            //looping through each second level node under top level node
            foreach (TreeNode secondLevelNode in topLevelNode.Nodes)
            {
                //ensuring it is not the same item already added 
                if (secondLevelNode != selectedNode)
                {
                    //adding node to list
                    otherSecondLevelNodes.Add(secondLevelNode);

                    if (otherSecondLevelNodes.Count == 3)
                    {
                        //stopping after gathering three nodes
                        break; 
                    }
                }
            }
            //returning nodes
            return otherSecondLevelNodes;
        }
        // End of method


        /// <summary>
        /// Method to gather third level nodes siblings to selectedNode
        /// </summary>
        /// <param name="selectedNode"></param>
        /// <returns>siblings</returns>
        /// Referencing: ChatGPT assisted with this method.
        private List<TreeNode> GetSiblingThirdLevelNodes(TreeNode selectedNode)
        {
            //getting the parent node of the selected node
            TreeNode parentNode = selectedNode?.Parent;

            //getting all nodes under the parent
            List<TreeNode> siblings = new List<TreeNode>();

            //looking through the nodes under the parentNode
            foreach (TreeNode child in parentNode.Nodes)
            {
                //checking if the selected node has a parent
                if (parentNode != null)
                {
                    //ensuring it is not the same item already added 
                    if (child != selectedNode)
                    {
                        //adding node to list
                        siblings.Add(child);

                        //ensuring the list only gathers 3 items
                        if (siblings.Count == 3)
                        {
                            break;
                        }

                    }

                }

            }
            //returning the nodes
            return siblings;

        }
        // End of method


        /// <summary>
        /// Method to find the top level node that the description falls under
        /// </summary>
        /// <param name="description"></param>
        /// <returns>topLevelNode</returns>
        /// Referencing: ChatGPT assisted with this method.
        private TreeNode GetTopLevelNode(string description)
        {
            //finding the top-level node that contains the description
            foreach (TreeNode topLevelNode in root.Nodes)
            {
                //going into the second level nodes
                foreach (TreeNode secondLevelNode in topLevelNode.Nodes)
                {
                    foreach (TreeNode thirdLevelNode in secondLevelNode.Nodes)
                    {
                        //checking if the node that was found equals the description (excluding the numbers)
                        if (thirdLevelNode.Text.Substring(4) == description)
                        {
                            //returning the top level node
                            return topLevelNode;
                        }
                    }
                }
            }

            //returning null if not found
            return null; 
        }
        // End of method


        /// <summary>
        /// Method to allocate points to user
        /// </summary>
        public void AllocatePoints()
        {
            //switch to allocate points based on the amount of correct matches
            switch (correctMatchCount)
            {
                case 1:
                   
                    //200 points
                    UserData.UserPoints = UserData.UserPoints + 200;

                    //updating points
                    Lbl_points.Text = "Points: " + UserData.UserPoints;

                    
                    break;
                case 2:
                    
                    //500 points
                    UserData.UserPoints = UserData.UserPoints + 500;

                    //updating points
                    Lbl_points.Text = "Points: " + UserData.UserPoints;

                    
                    break;
                case 3:

                    //500 points
                    UserData.UserPoints = UserData.UserPoints + 500;

                    //updating points
                    Lbl_points.Text = "Points: " + UserData.UserPoints;

                    //resetting match count
                    correctMatchCount = 0;
                    
                    break;
            }
        }
        //End of Method


        /// <summary>
        /// Method to play sound effect based on the integer value
        /// </summary>
        /// <param name="soundType"></param>
        private void PlaySoundEffect(int soundType)
        {
            //referencing class
            SoundEffects soundFx = new SoundEffects();
            
            //switch based on parameter
            switch(soundType)
            {
                case 1:
                    //starting thread to play sound effect
                    soundFxThread = new Thread(soundFx.PlayWinnerSound);
                    soundFxThread.Start();
                    break;

                case 2:
                    //starting thread to play sound effect
                    soundFxThread = new Thread(soundFx.PlayLoserSound);
                    soundFxThread.Start();
                    break;
            }

        }
        // End of method


        /// <summary>
        /// Event handler for back button
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
        // End of method


        /// <summary>
        /// Event handler for exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            //exiting app
            Environment.Exit(0);
        }
        // End of method
    }
}
//---------------------------------------------------END OF CLASS--------------------------------------------------------//