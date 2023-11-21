using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading;
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
    internal static class Program
    {
        //list to store song locations
        public static List<string> backgroundSongs = new List<string>
        {
         "Sounds\\Background_Song1.wav",
         "Sounds\\Background_Song2.wav"
        };

        //creating thread to play music
        public static Thread songThread;

        //sound player to play the files
        public static SoundPlayer myPlayer = new SoundPlayer();


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        ///
        [STAThread]
        static void Main()
        {
            //starting song thread
            songThread = new Thread(PlaySongs);
            songThread.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartUp());

        }
        //End of method

 
        /// <summary>
        /// Method will play the background music in a loop
        /// </summary>
        private static void PlaySongs()
        {
            //loop to repeat the playlist as long as the app is running
            while (true) 
            {
                foreach (string song in backgroundSongs)
                {
                    //loading songs from location
                    myPlayer.SoundLocation = song; 

                    //playing the songs synchronously
                    myPlayer.PlaySync(); 
                }
            }           
        }
        //End of method

    }
}
//----------------------------------------------END OF CLASS---------------------------------------------------//
