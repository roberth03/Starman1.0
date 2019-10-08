using System;

namespace Spaceman
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Game g = new Game();
                while (true)
                {
                    Console.Clear();
                    g.Display();
                    g.Ask();
                    if (g.DidWin() || g.DidLose())
                    {
                        break;
                    }
                }
                Console.WriteLine("Play again ? Press any key\nN to Quit");
                string response = Console.ReadLine();
                if (response.ToLower() == "n")
                {
                    break;
                }
                else 
                {
                    continue;
                }

            }
        }
    }
}