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
            int userMove = GetUserMove(board);
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
        /// <param name="board"></param>
        private static void ShowBoard(char[] board)
        {
            Console.WriteLine("\n " + board[1] + " | " + board[2] + " | " + board[3]);
            Console.WriteLine("-----------");
            Console.WriteLine(" " + board[4] + " | " + board[5] + " | " + board[6]);
            Console.WriteLine("-----------");
            Console.WriteLine(" " + board[7] + " | " + board[8] + " | " + board[9]);
        }

        /// <summary>
        /// UC4 Ability for user to make a move to a desired location in the board
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private static int GetUserMove(char[] board)
        {
            int[] validCells = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            while (true)
            {
                Console.WriteLine("\nWhat is your next move? (1-9) : ");
                int index = Convert.ToInt32(Console.ReadLine());
                if (Array.Find<int>(validCells, element => element == index) != 0 && IsSpaceFree(board, index));
                return index;
            }
        }

        /// <summary>
        /// Check whether space is free
        /// </summary>
        /// <param name="board"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private static bool IsSpaceFree(char[] board, int index)
        {
            return board[index] == ' ';
        }
    }
}
