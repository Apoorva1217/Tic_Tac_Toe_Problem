using System;

namespace TicTacToe
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe Problem!");
            char[] board = CreateBoard();
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
    }
}
