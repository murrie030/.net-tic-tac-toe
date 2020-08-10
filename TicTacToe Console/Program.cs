using System;
using TicTacToe_Library;

namespace TicTacToe_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeEnginge t = new TicTacToeEnginge();
            
            Console.WriteLine("Hello player O and player X.");

            /* While the Console application keeps running, call the methods
             * and play the game
             */
            while (true) 
            {
                Console.WriteLine(t.Board());
                t.CheckInputConsole();
                t.UpdateStatusConsole();
            }
        }
    }
}
