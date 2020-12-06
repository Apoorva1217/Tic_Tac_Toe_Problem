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
    }
}
