using System;

class TicTacToe
{
    static void Main()
    {
        TicTacToeBoard board = new TicTacToeBoard();
        bool gameOver = false;

        do
        {
            Console.Clear();
            board.PrintBoard();

            if (board.CheckForWin())
            {
                Console.WriteLine("Congratulations! You won!");
                break;
            }

            if (board.IsBoardFull())
            {
                Console.WriteLine("It's a draw!");
                break;
            }

            Console.WriteLine("Enter your move (1-9):");
            int playerMove = int.Parse(Console.ReadLine());

            if (board.IsMoveValid(playerMove))
            {
                board.MakeMove(playerMove, 'X');

                if (board.CheckForWin())
                {
                    Console.Clear();
                    board.PrintBoard();
                    Console.WriteLine("Congratulations! You won!");
                    gameOver = true;
                    break;
                }

                if (board.IsBoardFull())
                {
                    Console.Clear();
                    board.PrintBoard();
                    Console.WriteLine("It's a draw!");
                    gameOver = true;
                    break;
                }

                Console.Clear();
                board.PrintBoard();
                Console.WriteLine("Bot is making a move...");

                int botMove = board.GetBestMove();
                board.MakeMove(botMove, 'O');

                Console.Clear();
                board.PrintBoard();

                if (board.CheckForWin())
                {
                    Console.WriteLine("Bot won!");
                    gameOver = true;
                    break;
                }
                
            }
            else
            {
                Console.WriteLine("Invalid move. Try again.");
            }

        } while (!gameOver);

        Console.WriteLine("Game Over. Press any key to exit.");
        Console.ReadKey();
    }
}