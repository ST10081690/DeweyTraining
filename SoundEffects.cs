using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Name: Euluis Goncalves
App: Dewey Training App.
Last Modified: 21/11/2023.
 */

namespace DeweyTraining
{
    //----------------------------------------------START OF CLASS---------------------------------------------------//
    public class SoundEffects
    {
        //instantiating window
        ReplacingBooks books = new ReplacingBooks();

       
        /// <summary>
        /// Method to play winner sound if user got the correct book order
        /// </summary>
        public void PlayWinnerSound()
        {
            //Referencing:
            //Tech Expess by SRIJON (2017) How to play multiple sound
            //files in windows forms APP C# net at a same time playing sounds C#,
            //YouTube. Available at: https://www.youtube.com/watch?v=ikrIpZO10zs
            //(Accessed: 22 September 2023). 

            try 
            {
                //playing winning sound
                books.Plyr_winner.URL = "Sounds\\Winner_Trumpet.wav";
                books.Plyr_winner.Ctlcontrols.play();

            }
            catch //error handling
            {
                //skipping this sound
            }
            


        }
        //End of Method


        /// <summary>
        /// Method to play loser sound if user got the order incorrect
        /// </summary>
        public void PlayLoserSound()
        {
            //Referencing:
            //Tech Expess by SRIJON (2017) How to play multiple sound
            //files in windows forms APP C# net at a same time playing sounds C#,
            //YouTube. Available at: https://www.youtube.com/watch?v=ikrIpZO10zs
            //(Accessed: 22 September 2023). 

            try 
            {
                //playing loser sound
                books.Plyr_loser.URL = "Sounds\\Loser_Trumpet.wav";
                books.Plyr_loser.Ctlcontrols.play();

            }
            catch //error handling
            {
                //skipping this sound
            }

        }
        //End of Method

    }
}
//----------------------------------------------END OF CLASS---------------------------------------------------//
