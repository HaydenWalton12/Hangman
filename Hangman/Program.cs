using System;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Hangman hangman = new Hangman();
            hangman.Update();
        }
    }

    class Hangman
    {
        //Member Variables
        int m_Lives = 6;
        int score = 0;


        List<char> H_IncorrectLetters = new List<char>();
        List<char> H_CorrectLetters = new List<char>();
        char[] H_output_word;
        char H_userInput;
        char H_PlayAgain;



        string[] H_Words = { "Ball", "Teach" , "Fox" , "Princess" , "Ghandi" };
        string H_Word;

        bool Playing = false;


        public Hangman()
        {



            Disguse_Word();
            while (Playing = true)
            {


                Update();
                //everytime we get a character or more right , updates score++ . Our score would equal length of Game_Word from this. If the score is same length of game world , we won
                if(score == H_Word.Length)
                {
                    //Via input of y or n , we exit or replay
                    Play_Again();
                }

            }



        }
        //Assigns Game Word Randomly
        public void Get_Word()
        {
            //Used to assign us a random number to "ID" , we pass ID in String Array parameter , giving us random word upon every execution.
            Random rand = new Random();
            var ID = rand.Next(0, 5);

            //Assigns Game Word
            H_Word = H_Words[ID];

            //Disgused word given lenght of word just chosen / E.G if word is "Ball" , out_put word = 4 
            H_output_word = new char[H_Word.Length];

        }

        public void Play_Again()
        {

            //Score should equal length of word , if does we win , if this is false, it is assumed player has lost , this is okay to do.
            if (score == H_Word.Length)
            {
                Console.Clear();
                Console.WriteLine("You win: Do you want to play again? y or n");
                H_PlayAgain = Console.ReadLine()[0];
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You Lost: Do you want to play again? y or n");
                H_PlayAgain = Console.ReadLine()[0];
            }
            //Switch calls upon two states , y (play again) or n (end)
            switch (H_PlayAgain)
            {
                //Restarts Values and Calls update to intialise another round
                case 'y':
                    Console.WriteLine("You wish to play again.");
                    score = 0;
                    m_Lives = 6;
                    H_IncorrectLetters.Clear();
                    H_CorrectLetters.Clear();
                    Disguse_Word();
                    Update();

                    break;
                //Ends Application
                case 'n':
                    Console.WriteLine("Game ended");
                    Playing = false;
                    Environment.Exit(0);

                    break;
                default:
                    break;
            }
        }
    
        

    
        public void Disguse_Word()
        {
            //Gets word
            Get_Word();
           //Uses word given it to generate for loop length, output word equals length of game / H_Word, hence we iterate same length
            for (int i = 0; i < H_Word.Length; i++)
            {
                //Replaces each char in outputword with '*' , to disguse it.
                //E.G bath = ****
                H_output_word[i] = '*';
            }

        }

        public void Update()
        {
        //Label C#
        Start:

            ShowHangman();
            //Flag Determines Life Taken
            bool deduct_life = false;
            //Get user input , convert to string to output 
            Console.Write("Please enter your guess: ");
            H_userInput = Console.ReadLine()[0];
            H_userInput.ToString();

            //Checks if inputted char is already a letter entered stored in previous incorrect letters
            if (H_IncorrectLetters.Contains(H_userInput))
            {

                Console.WriteLine(H_userInput + ": has already been guessed");
                
                //Take / Checks life
                m_Lives--;

                //Goes to start of update using label
                goto Start;

            }
            //Checks if letter is correct and already been entered , if so we use label to go back to start
            if (H_CorrectLetters.Contains(H_userInput))
            {
                Console.WriteLine(H_userInput + ": has already been guessed");
                //Go to start again to redo user input since this state has ended
                goto Start;
            }
            for (int i = 0; i < H_Word.Length; i++)
            {

                //iterates comparing user inputted char with current chracter in game word.
                if (H_userInput == H_Word[i])
                {
                    
                    Console.WriteLine(H_userInput + " : was correct letter.");
                    
                    //Update list
                    H_CorrectLetters.Add(H_userInput);
                    
                    //Move over deducting life since character inputted was correct,
                    goto After;
                }
                else
                {
                    deduct_life = true;
                }

            }

            //If flag is turned true if entered character wasnt contained in game word
            if (deduct_life)
            {
                H_IncorrectLetters.Add(H_userInput);
                Console.WriteLine(H_userInput + ": was incorrect");
                m_Lives--;
            }
            //Label used to jump to segment of code , referenced if letter is correct
        After:
            
            Update_Outputword();
            Check_Lives();



        }
        public void Check_Lives()
        {
            //If deducted lives are or hit belwo 0 , clear console , and call play_again indicating we lost
            if (m_Lives == 0)
            {
                Console.Clear();
                Play_Again();
                
            }
        }
         public void Update_Outputword()
            {
                for (int i = 0; i < H_Word.Length; i++)
                {
                    if (H_userInput == H_Word[i])
                    {
                    //Updates score , checked in gameloop , we add score here since it updates score when one character gets multiple characters correct
                    score++;
                    H_output_word[i] = H_userInput;
                    }
                }
            }
        
        //Draw Hangman , updates our disgused word
        void ShowHangman()
        {
            
            Console.WriteLine();
            Console.WriteLine("     ╔══════╗  ");
            Console.WriteLine("     ║      |  ");
            Console.WriteLine("     ║      " + (m_Lives < 6 ? "O" : ""));
            Console.WriteLine("     ║     " + (m_Lives < 4 ? "/" : "") + (m_Lives < 5 ? "|" : "") + (m_Lives < 3 ? @"\" : ""));
            Console.WriteLine("     ║     " + (m_Lives < 2 ? "/" : "") + " " + (m_Lives < 1 ? @"\" : ""));
            Console.WriteLine("     ║         ");
            Console.WriteLine("╔════╩══════╗");
            Console.WriteLine("╚═══════════╝");
            Console.WriteLine("↓ Your word is ↓");
            Console.WriteLine(H_output_word);



        }
    }
}
