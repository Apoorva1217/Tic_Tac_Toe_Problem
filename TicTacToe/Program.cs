using System;

namespace TicTacToe
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe Problem!");
            char[] board = CreateBoard();
            char userLetter = ChooseUserLetter();
            ShowBoard(board);
        }

        /// <summary>
        /// UC1 As a Player would like to start fresh by creating a tic tac toe board
        /// </summary>
        private static char[] CreateBoard()
        {
            char[] board = new char[10];
            for (int index = 0; index < board.Length; index++)
            {
                board[index] = ' ';
            }
            return board;
        }

        /// <summary>
        /// UC2 Ability to allow the player to choose a letter X or O
        /// </summary>
        private static char ChooseUserLetter()
        {
            Console.WriteLine("Choose your letter X or O : ");
            string userLetter = Console.ReadLine();
            return char.ToUpper(userLetter[0]);
        }

        /// <summary>
        /// UC3 Write a method showBoard to display the current Board
        /// </summary>
        /// <param name="board">The board.</param>
        private static void ShowBoard(char[] board)
        {
            Console.WriteLine("\n " + board[1] + " | " + board[2] + " | " + board[3]);
            Console.WriteLine("-----------");
            Console.WriteLine(" " + board[4] + " | " + board[5] + " | " + board[6]);
            Console.WriteLine("-----------");
            Console.WriteLine(" " + board[7] + " | " + board[8] + " | " + board[9]);
        }
    }
}
