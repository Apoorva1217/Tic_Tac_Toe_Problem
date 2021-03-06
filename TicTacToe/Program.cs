﻿using System;

namespace TicTacToe
{
    public class Program
    {
        /// <summary>
        /// Constants
        /// </summary>
        public const int HEAD = 0;
        public const int TAILS = 1;

        public enum Player { USER, COMPUTER };
        public enum GameStatus { WON, FULL_BOARD, CONTINUE };
        static void Main(string[] args)
        {
            PlayAgain: Console.WriteLine("Welcome to Tic Tac Toe Problem!");
            char[] board = CreateBoard();
            Player player = GetWhoStartFirst();
            char userLetter = ChooseUserLetter();
            char computerLetter = (userLetter == 'X') ? 'O' : 'X';
            Console.WriteLine("Check if Won " + IsWinner(board, userLetter));
            bool gameIsPlaying = true;
            GameStatus gameStatus;

            while (gameIsPlaying)
            {
                //Players Turn
                if (player.Equals(Player.USER))
                {
                    ShowBoard(board);
                    int userMove = GetUserMove(board);
                    string wonMessage = "Hurray! You have won the game!";
                    gameStatus = GetGameStatus(board, userMove, userLetter, wonMessage);
                    player = Player.COMPUTER;
                }
                else
                {
                    //Computer Turn
                    string wonMessage = "The Computer has beaten you! You lose.";
                    int computerMove = GetComputerMove(board, computerLetter, userLetter);
                    gameStatus = GetGameStatus(board, computerMove, computerLetter, wonMessage);
                    player = Player.USER;
                }
                if (gameStatus.Equals(GameStatus.CONTINUE)) 
                    continue;
                if (PlayAgain())
                    goto PlayAgain;
                gameIsPlaying = false;
            }
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

        /// <summary>
        /// UC5 Ability to check for the free space before making the desired move
        /// </summary>
        /// <param name="board"></param>
        /// <param name="index"></param>
        /// <param name="letter"></param>
        private static void MakeMove(char[] board, int index, char letter)
        {
            bool spaceFree = IsSpaceFree(board, index);
            if (spaceFree) 
                board[index] = letter;
        }

        /// <summary>
        /// UC6 As a User would like to do a toss to check who plays first.
        /// </summary>
        /// <returns></returns>
        private static Player GetWhoStartFirst()
        {
            int toss = GetOneFromRandomChoices(2);
            return (toss == HEAD) ? Player.USER : Player.COMPUTER;
        }

        /// <summary>
        /// Get the one from random choices
        /// </summary>
        /// <param name="choices"></param>
        /// <returns></returns>
        private static int GetOneFromRandomChoices(int choices)
        {
            Random random = new Random();
            return (int)(random.Next() * 10) % choices;
        }

        /// <summary>
        /// UC7 As player would expect the Tic Tac Toe App to determine after every move the winner or the tie or change the turn
        /// </summary>
        /// <param name="b"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        private static bool IsWinner(char[] b, char ch)
        {
            return ((b[1] == ch && b[2] == ch && b[3] == ch) ||
                (b[4] == ch && b[5] == ch && b[6] == ch) ||
                (b[7] == ch && b[8] == ch && b[9] == ch) ||
                (b[1] == ch && b[4] == ch && b[7] == ch) ||
                (b[2] == ch && b[5] == ch && b[8] == ch) ||
                (b[3] == ch && b[6] == ch && b[9] == ch) ||
                (b[1] == ch && b[5] == ch && b[9] == ch) ||
                (b[7] == ch && b[5] == ch && b[3] == ch));
        }

        /// <summary>
        /// UC8 On Computer getting its turn would like the computer to play like me
        /// UC9 Next thing I do is check if my Opponent can win then play to block it
        /// UC10 If neither of us are winning then My first choice would be to take one of the available corners
        /// UC11 My Subsequent Choices will be
        /// - If the corners are not available then take the Centre
        /// - Lastly any of the available sides
        /// </summary>
        /// <param name="board"></param>
        /// <param name="computterLetter"></param>
        /// <returns></returns>
        private static int GetComputerMove(char[] board, char computerLetter, char userLetter)
        {
            int winningMove = GetWinningMove(board, computerLetter);
            if (winningMove != 0)
                return winningMove;
            int userWinningMove = GetWinningMove(board, userLetter);
            if (userWinningMove != 0) 
                return userWinningMove;
            int[] cornerMoves = { 1, 3, 7, 9 };
            int computerMove = GetRandomMoveFromList(board, cornerMoves);
            if (computerMove != 0) 
                return computerMove;
            if (IsSpaceFree(board, 5)) return 5; //center move
            int[] sideMoves = { 2, 4, 6, 8 };
            computerMove = GetRandomMoveFromList(board, sideMoves);
            if (computerMove != 0) 
                return computerMove;
            return 0;
        }

        /// <summary>
        /// Get Winning Move
        /// </summary>
        /// <param name="board"></param>
        /// <param name="letter"></param>
        /// <returns></returns>
        private static int GetWinningMove(char[] board, char letter)
        {
            for(int index = 1; index < board.Length; index++)
            {
                char[] copyOfBoard = GetCopyOfBoard(board);
                if (IsSpaceFree(copyOfBoard, index))
                {
                    MakeMove(copyOfBoard, index, letter);
                    if (IsWinner(copyOfBoard, letter))
                        return index;
                }
            }
            return 0;
        }

        /// <summary>
        /// Get Copy of Board
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private static char[] GetCopyOfBoard(char[] board)
        {
            char[] boardCopy = new char[10];
            Array.Copy(board, 0, boardCopy, 0, board.Length);
            return boardCopy;
        }

        /// <summary>
        /// UC10 If neither of us are winning then My first choice would be to take one of the available corners
        /// </summary>
        /// <param name="board"></param>
        /// <param name="moves"></param>
        /// <returns></returns>
        public static int GetRandomMoveFromList(char[] board, int[] moves)
        {
            for (int index = 0; index < moves.Length; index++)
            {
                if (IsSpaceFree(board, moves[index])) 
                    return moves[index];
            }
            return 0;
        }

        /// <summary>
        /// UC12 As a Player would play till the game is over i.e Till the board is full or If one of the players win
        /// </summary>
        /// <param name="board"></param>
        /// <param name="move"></param>
        /// <param name="letter"></param>
        /// <param name="wonMessage"></param>
        /// <returns></returns>
        public static GameStatus GetGameStatus(char[] board, int move, char letter, string wonMessage)
        {
            MakeMove(board, move, letter);
            if (IsWinner(board, letter))
            {
                ShowBoard(board);
                Console.WriteLine(wonMessage);
                return GameStatus.WON;
            }
            if (IsBoardFull(board))
            {
                ShowBoard(board);
                Console.WriteLine("Game is Tie");
                return GameStatus.FULL_BOARD;
            }
            return GameStatus.CONTINUE;
        }

        /// <summary>
        /// Check Board is full
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static bool IsBoardFull(char[] board)
        {
            for (int index = 1; index < board.Length; index++)
            {
                if (IsSpaceFree(board, index)) 
                    return false;
            }
            return true;
        }

        /// <summary>
        /// UC13 Ability for the user to continue playing another Tic Tac Toe Game. Ask user for another game.
        /// </summary>
        /// <returns></returns>
        public static bool PlayAgain()
        {
            Console.WriteLine("Do you want to Play Again? (yes/no)");
            string option = Console.ReadLine().ToLower();
            if (option.Equals("yes"))
                return true;
            return false;
        }
    }
}