class TictacToeBoard
{
    private char[,] board;

    public TictacToeBoard()
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
}