class TicTacToeBoard
{
    private char[,] board;

    public TicTacToeBoard()
    {
        board = new char[3, 3];
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = ' ';
            }
        }
    }

    public void PrintBoard()
    {
        Console.WriteLine(" 1 | 2 | 3 ");
        Console.WriteLine("-----------");
        Console.WriteLine(" 4 | 5 | 6 ");
        Console.WriteLine("-----------");
        Console.WriteLine(" 7 | 8 | 9 ");

        Console.WriteLine("\nCurrent Board:");

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($" {board[i, j]} ");
                if (j < 2) Console.Write("|");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("-----------");
        }
        Console.WriteLine();
    }

    public bool CheckForWin()
    {
        return CheckRow() || CheckColumn() || CheckDiagonal();
    }

    private bool CheckRow()
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                return true;
        }
        return false;
    }

    private bool CheckColumn()
    {
        for (int j = 0; j < 3; j++)
        {
            if (board[0, j] != ' ' && board[0, j] == board[1, j] && board[1, j] == board[2, j])
                return true;
        }
        return false;
    }

    private bool CheckDiagonal()
    {
        return (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) ||
               (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]);
    }

    public bool IsBoardFull()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == ' ')
                    return false;
            }
        }
        return true;
    }

    public bool IsMoveValid(int move)
    {
        int row = (move - 1) / 3;
        int col = (move - 1) % 3;

        return move >= 1 && move <= 9 && board[row, col] == ' ';
    }

    public void MakeMove(int move, char player)
    {
        int row = (move - 1) / 3;
        int col = (move - 1) % 3;

        board[row, col] = player;
    }

    public void UndoMove(int move)
    {
        int row = (move - 1) / 3;
        int col = (move - 1) % 3;

        board[row, col] = ' ';
    }

    public int GetBestMove()
    {
        int bestMove = -1;
        int bestScore = int.MinValue;

        for (int i = 1; i <= 9; i++)
        {
            if (IsMoveValid(i))
            {
                MakeMove(i, 'O');
                int score = Minimax(0, false);
                UndoMove(i);

                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = i;
                }
            }
        }

        return bestMove;
    }

    private int Minimax(int depth, bool isMaximizingPlayer)
    {
        if (CheckForWin())
            return isMaximizingPlayer ? -1 : 1;

        if (IsBoardFull())
            return 0;

        if (isMaximizingPlayer)
        {
            int maxEval = int.MinValue;
            for (int i = 1; i <= 9; i++)
            {
                if (IsMoveValid(i))
                {
                    MakeMove(i, 'O');
                    int eval = Minimax(depth + 1, false);
                    UndoMove(i);
                    maxEval = Math.Max(maxEval, eval);
                }
            }
            return maxEval;
        }
        else
        {
            int minEval = int.MaxValue;
            for (int i = 1; i <= 9; i++)
            {
                if (IsMoveValid(i))
                {
                    MakeMove(i, 'X');
                    int eval = Minimax(depth + 1, true);
                    UndoMove(i);
                    minEval = Math.Min(minEval, eval);
                }
            }
            return minEval;
        }
    }
}