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


                // Check the input for the users next set
                string nextSet = Console.ReadLine();

                switch (nextSet)
                {
                    // If the input is new, the game will be reset
                    case "new":
                        t.Reset();
                        break;
                    case "quit":
                        Environment.Exit(0);
                        break;
                    default:
                        try
                        {
                            Int32.TryParse(nextSet, out int cell);
                            t.ChooseCell(cell);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                }

                // Update the status with a switch case
                switch (t.Status)
                {
                    case (TicTacToeEnginge.GameStatus.PlayerOWins):
                        Console.WriteLine("Congratulations, player O won!");
                        Console.WriteLine(t.Board());
                        Console.WriteLine(".............................. NEW GAME ..............................");
                        t.Reset();
                        break;
                    case (TicTacToeEnginge.GameStatus.PlayerXWins):
                        Console.WriteLine("Congratulations, player X won!");
                        Console.WriteLine(t.Board());
                        Console.WriteLine(".............................. NEW GAME ..............................");
                        t.Reset();
                        break;
                    case (TicTacToeEnginge.GameStatus.Equal):
                        Console.WriteLine("Tie!");
                        Console.WriteLine(t.Board());
                        Console.WriteLine(".............................. NEW GAME ..............................");
                        t.Reset();
                        break;
                }
            }
        }
    }
}
