using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TicTacToe_Library
{
    public class TicTacToeEnginge
    {

        // Make a constructor to let Player O begin
        public TicTacToeEnginge()
        {
            this.Status = GameStatus.PlayerOPlays;
        }


        /* Make a property to access and update the value
         * of a private field
         * In this case: status
         */
        public GameStatus Status { get; private set; }


        // Make an array of strings of the cells
        public string[] cellNumbers1 = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };


        /* This method returns a string representation of the Board that
         * will be used in the Console app
         * Source of string format: https://docs.microsoft.com/en-us/dotnet/api/system.string.format?view=netcore-3.1
         */
        public string Board()
        {
            Console.WriteLine("Type a number from 1 to 9.");
            Console.WriteLine("Status: " + Status);
            string board = string.Format("------------\n"     +
                                         " {0} | {1} | {2}\n" + 
                                         "------------\n"     + 
                                         " {3} | {4} | {5}\n" +
                                         "------------\n"     +
                                         " {6} | {7} | {8}\n" +
                                         "------------" ,
                                         cellNumbers1[0], cellNumbers1[1], cellNumbers1[2],
                                         cellNumbers1[3], cellNumbers1[4], cellNumbers1[5],
                                         cellNumbers1[6], cellNumbers1[7], cellNumbers1[8]);

            return board;
        }


        /* This method gives the client the option to choose
        * a cell for each player
        * Source equals: https://docs.microsoft.com/en-us/dotnet/api/system.object.equals?view=netcore-3.1
        */
        public bool ChooseCell(int cellNumber)
        {
            // Use an indexer to associate this with the cell numbers
            int indexer = cellNumber - 1;        

            try
            {
                // Gives a message when a player tries to choose an invalid cell
                if (Equals(cellNumbers1[indexer], "O") || Equals(cellNumbers1[indexer], "X"))
                {
                    Console.WriteLine("Invalid choice.");
                    return false;
                }

                // Update the cell and status
                switch (Status)
                {
                    case GameStatus.PlayerOPlays:
                        cellNumbers1[indexer] = "O";
                        Status = GameStatus.PlayerXPlays;
                        break;
                    case GameStatus.PlayerXPlays:
                        cellNumbers1[indexer] = "X";
                        Status = GameStatus.PlayerOPlays;
                        break;
                }

                /* This method checks if all three the cell combinations occur
                 * and decides which player won the game
                 */
                bool DecideWinner(string cell1, string cell2, string cell3)
                {
                    if (Equals(cell1, cell2) && Equals(cell1, cell3) && !Equals(cell1, ""))
                    {
                        switch (cell1)
                        {
                            case "O":
                                Status = GameStatus.PlayerOWins;
                                break;
                            case "X":
                                Status = GameStatus.PlayerXWins;
                                break;
                        }
                    }

                    return false;
                }

                // Make a second array of string of the cells
                string[] cellNumbers2 = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

                /* If there are no matching cells, set the GameStatus to Equal
                 * Source combinations: https://lemmoscripts.com/wp/2018/09/03/creating-a-simple-tic-tac-toe-or-naughts-and-crosses-game-in-javascript-and-jquery/
                 */
                if (!(DecideWinner(cellNumbers1[0], cellNumbers1[1], cellNumbers1[2]) ||
                      DecideWinner(cellNumbers1[3], cellNumbers1[4], cellNumbers1[5]) ||
                      DecideWinner(cellNumbers1[6], cellNumbers1[7], cellNumbers1[8]) ||

                      DecideWinner(cellNumbers1[0], cellNumbers1[4], cellNumbers1[8]) ||
                      DecideWinner(cellNumbers1[2], cellNumbers1[4], cellNumbers1[6]) ||

                      DecideWinner(cellNumbers1[0], cellNumbers1[3], cellNumbers1[6]) ||
                      DecideWinner(cellNumbers1[1], cellNumbers1[4], cellNumbers1[7]) ||
                      DecideWinner(cellNumbers1[2], cellNumbers1[5], cellNumbers1[8])) &&
                      !cellNumbers2.Any(cellNumbers1.Contains))
                {
                    Status = GameStatus.Equal;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message + "\nInvalid choice.");
                return false;
            }

            return true;
        }


        /* This method checks whether the input in the console
         * is correct or not
         */
        public void CheckInputConsole()
        {
            string nextSet = Console.ReadLine();

            // Check the input for the users next set
            switch (nextSet)
            {
                // If the input is new, the game will be reset
                case "new":
                    Reset();
                    break;
                case "quit":
                    Environment.Exit(0);
                    break;
                default:
                    try
                    {
                        Int32.TryParse(nextSet, out int cell);
                        ChooseCell(cell);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
            }
        }


        /* This method updates the status for the console
         * application
         */
        public void UpdateStatusConsole()
        {
            // Update the status with a switch case
            switch (Status)
            {
                case (GameStatus.PlayerOWins):
                    Console.WriteLine("Congratulations, player O won!");
                    Console.WriteLine(Board());
                    Console.WriteLine(".............................. NEW GAME ..............................");
                    Reset();
                    break;
                case (GameStatus.PlayerXWins):
                    Console.WriteLine("Congratulations, player X won!");
                    Console.WriteLine(Board());
                    Console.WriteLine(".............................. NEW GAME ..............................");
                    Reset();
                    break;
                case (GameStatus.Equal):
                    Console.WriteLine("Tie!");
                    Console.WriteLine(Board());
                    Console.WriteLine(".............................. NEW GAME ..............................");
                    Reset();
                    break;
            }
        }


        /* This method resets the board when the game has ended
         * You can also reset the game while you are not finished yet
         */
        public void Reset()
        {
            string[] reset = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            cellNumbers1 = reset;
            Status = GameStatus.PlayerOPlays;
        }


        // The enum
        public enum GameStatus
        {
            PlayerOPlays,
            PlayerXPlays,
            Equal,
            PlayerOWins,
            PlayerXWins
        }
    }
}
