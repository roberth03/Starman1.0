using System;
using System.Globalization;
using System.Collections.Generic;

namespace Spaceman
{

    class Game
    {
        // CONSTRUCTOR	
        public Game()
        {
            // list of codewords
            Codewords = new string[] {"avocado", "pineapple", "crocodile", "zebra", "forest", "mexican", "rock", "moose", "evangelist", "airplane",
"magnificent", "shave", "expensive", "education", "passenger", "secret", "grass", "strenghten", "fix", "unit", "memory", "log", "grandiose", "roof" };
            var rand = new Random();
            // get a random number up to the number of words in codewords
            int codewordIndex = rand.Next(Codewords.Length);
            Codeword = Codewords[codewordIndex];

            // Set max guess to 5
            MaxGuesses = 5;
            // set wrong guesses to 0
            CurrentNumWrongGuesses = 0;

            // Set current word to the same number of "_" as the number of leters in the codeword
            CurrentWord = "";
            for (int i = 0; i < Codeword.Length; i++)
            {
                CurrentWord += "_";
            }
        } // Constructor END


        public string Codeword
        { get; set; }
        public string CurrentWord
        { get; set; }
        public int MaxGuesses
        { get; set; }
        public int CurrentNumWrongGuesses
        { get; set; }
        public string[] Codewords
        { get; set; }
        List<string> letterList = new List<string>();
        public Ufo ufo = new Ufo();

        // Method prints the game title and instructions to play
        public void Greet()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==============");
            Console.WriteLine("UFO : The Game");
            Console.WriteLine("==============");
            Console.WriteLine("Save your friend from being abducted by aliend by guessing the letters in the codeword.\nPress any letter and hit Enter key.");
            Console.ResetColor();
        }

        // Method checks if the player won & prints a congrats message
        public bool DidWin()
        {
            // return true/false
            if (Codeword.Equals(CurrentWord))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Good job, you win!\nThe passcode was: {0}", Codeword);
                Console.ResetColor();
            }
            //test only
            //Console.WriteLine(Codeword);
            //Console.WriteLine(CurrentWord);
            return Codeword.Equals(CurrentWord);
        }

        // check if player lost
        public bool DidLose()
        {
            if (CurrentNumWrongGuesses <= MaxGuesses)
            {
                return false;
            }
            // prompt user that he/she lost
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n Game over. You lose.");
            Console.ResetColor();
            return true;
        }

        // Display current UFO animation
        //	and	a placeholder for codeword and its length
        public void Display()
        {
            Greet();
            // Print the ufo
            Console.WriteLine(ufo.Stringify());

            // Print the placeholder word (current word)
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("{0}", CurrentWord);
            Console.ResetColor();

            // Print the number of letters in the codeword
            Console.Write(" - ({0} letters)\n", CurrentWord.Length);
            Console.Write("Guesses left: ");

            // Print current number of guesses left
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("{0}", MaxGuesses - CurrentNumWrongGuesses);
            Console.ResetColor();

            // Print the letters used so far
            Console.Write("\nUsed letters: ");
            foreach (string letter in letterList)
            {
                Console.Write("{0 }", letter);
            }
        }

        public void Ask()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nPlease type a letter.");
            Console.ResetColor();
            string input = Console.ReadLine();

            // check and tell user to enter ONLY 1 letter
            if (input.Length > 1)
            {
                Console.WriteLine("Please only type ONE letter at a time!\nPress Enter to continue...");
                Console.ReadLine();
                return;
            }

            // check if the input is a letter and prompt the user if not
            if (!char.IsLetter(input[0]))
            {
                Console.WriteLine("Please only enter letters!\nPress Enter to continue...");
                Console.ReadLine();
                return;
            }
            
            // convert input to lower letter
            string letter = input[0].ToString().ToLower();

            // if the letter has already been inclear
            if (letterList.Contains(letter))
            {
                Console.WriteLine("'{0}' has already been found.\nPlease insert another letter\nPress Enter to continue...", letter);
                Console.ReadLine();
                return;
            }
            letterList.Add(letter);

            // check if the word contains the inserted letter
            if (Codeword.Contains(letter))
            {
                // prompt the user
                Console.WriteLine("Good guess. The codeword contains '{0}'.", letter);
                // loop thru codeword for inserted letter
                // if found replace '_' with letter in current word
                for (int i = 0; i < Codeword.Length; i++)
                {
                    if (Codeword[i].ToString() == letter)
                    {
                        CurrentWord = CurrentWord.Remove(i, 1).Insert(i, letter);
                    }
                }
            }
            // increase the wrong guesses by 1 and Update ufo image
            else
            {
                CurrentNumWrongGuesses += 1;
                ufo.AddPart();
            }

        }


    }

}