using System;
using System.Collections.Generic;
using System.Linq;

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
        List<char> m_IncorrectLetters;
        List<char> m_CorrectLetters;
        string[] m_Words = {"Bath" , "Toaster"};
        string m_Word;
        bool m_Won = false;
        char m_PlayAgain = 'n';

        public Hangman()
        {

            Random rand = new Random();
            var ID = rand.Next(0, 2);
             m_Word = m_Words[ID];
            m_CorrectLetters = m_Word.ToList();

        }

        public void Update()
        {
            ShowHangman();
            char userInput;
            Console.Write("Please enter your guess: ");
            userInput = Console.ReadLine()[0];
            
            //Checks to see if the user had a correct letter
            if(m_CorrectLetters.Contains()
            {
                Console.WriteLine(userInput.ToString(), ": was a correct answer");


            }
            //Check to see if the user has used a value 
            while (m_IncorrectLetters.Contains((userInput = Char.ToLower(Console.ReadKey().KeyChar))))
            {
                Console.WriteLine(userInput.ToString() , ": has already been guessed");
            }

            //Clear the screen
            Console.Clear();
        }

        //Draw Hangman
        void ShowHangman()
        {
            Console.WriteLine("     |------+  ");
            Console.WriteLine("     |      |  ");
            Console.WriteLine("     |      " + (m_Lives < 6 ? "O" : ""));
            Console.WriteLine("     |     " + (m_Lives < 4 ? "/" : "") + (m_Lives < 5 ? "|" : "") + (m_Lives < 3 ? @"\" : ""));
            Console.WriteLine("     |     " + (m_Lives < 2 ? "/" : "") + " " + (m_Lives < 1 ? @"\" : ""));
            Console.WriteLine("     |         ");
            Console.WriteLine("===============");
        }
    }
}