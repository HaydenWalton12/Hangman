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
        List<char> m_IncorrectLetters = new List<char>();
        List<char> m_CorrectLetters = new List<char>();
        string[] m_Words = {"Bath" , "Teach" };
        string m_Word;
        bool m_Won = false;
        char m_PlayAgain = 'n';
        char[] output_word;
        string text = "↓ Your word is ↓";
        char userInput;
        public Hangman()
        {

            Random rand = new Random();
            var ID = rand.Next(0, 2);
             m_Word = m_Words[ID];
            output_word = new char[m_Word.Length];

            for (int i = 0; i < m_Word.Length; i++)
            {
                output_word[i] = '*';
            }
            while (m_Won = true)
            {

                ShowHangman();
                Update();
                

                /*for(int i = 0; i < m_Word.Length; i++)
                 {
                     for(int j = 0; i < m_CorrectLetters.Count; j++)
                     {
                         if(m_Word[i] == m_CorrectLetters[j])
                         {

                         }
                     }
                 }*/




            }



        }

        public void Update()
        {

        Start:
            bool flag = false;
            Console.Write("Please enter your guess: ");
            userInput = Console.ReadLine()[0];
            userInput.ToString();
            if (m_IncorrectLetters.Contains(userInput))
            {
                
                Console.WriteLine(userInput +  ": has already been guessed");
                m_Lives--;


            }
            if (m_CorrectLetters.Contains(userInput))
            {
                Console.WriteLine(userInput + ": has already been guessed");
                goto Start;
            }
            for (int i = 0; i < m_Word.Length; i++)
            { 
                if (userInput == m_Word[i])
                {
                    
                    Console.WriteLine(userInput + " : was correct letter.");
                    m_CorrectLetters.Add(userInput);
                    
                }
                else
                {
                    flag = true;
                }

            
               /* else
                {
                    //Check to see if the user has used a value 
                    while (m_IncorrectLetters.Contains((userInput = Char.ToLower(Console.ReadKey().KeyChar))))

                    {

                    }
                }*/
        }
        After:
            if (flag)
            {
                m_IncorrectLetters.Add(userInput);
                Console.WriteLine(userInput + ": was incorrect");
                m_Lives--;
            }
            //Clear the screen

            for (int i = 0; i < m_Word.Length; i++)
            {
                if (userInput == m_Word[i])
                {
                    output_word[i] = userInput;
                }
            }
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
            Console.WriteLine(text);
            Console.WriteLine(output_word);



        }
    }
}