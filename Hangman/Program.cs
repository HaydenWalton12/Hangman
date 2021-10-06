using System;
using System.Collections.Generic;

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
        string[] m_Words = { };
        string m_Word;
        bool m_Won = false;
        char m_PlayAgain = 'n';

        public Hangman()
        {
            //init
        }

        public void Update()
        {
            char userInput;

            //Check to see if the user has used a value 
            while (m_IncorrectLetters.Contains((userInput = Char.ToLower(Console.ReadKey().KeyChar))))
            {
                Console.WriteLine(": has already been guessed");
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