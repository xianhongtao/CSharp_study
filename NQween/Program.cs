int n, soluations;
Console.WriteLine($"有几个皇后？");
n = Convert.ToInt32(Console.ReadLine());

Boolean[,] chessPlateAttacked = new Boolean[n, n];

soluations = 0;
Step(chessPlateAttacked, 0);
Console.WriteLine($"{soluations}");

void Step(Boolean[,] _chessPlateAttacked, int currentRow)
{
    for (int index = 0; index < n; index++)
    {
        if (!_chessPlateAttacked[currentRow, index])
        {
            Boolean[,] newPlate = _chessPlateAttacked;
            if (currentRow == n - 1)
            {
                soluations++;
            }
            else
            {
                Step(PlaceQween(newPlate, currentRow, index), currentRow + 1);
            }
        }
    }
}
static Boolean[,] PlaceQween(Boolean[,] chessPlateAttacked, int x, int y)
{
    for (int i = 0; i < chessPlateAttacked.GetLength(0); i++)
    {
        chessPlateAttacked[x, i] = true;
    }
    for (int i = 0; i < chessPlateAttacked.GetLength(1); i++)
    {
        chessPlateAttacked[i, y] = true;
    }
    int[] loc = [x, y];
    for (; loc[0] < chessPlateAttacked.GetLength(0) && loc[1] < chessPlateAttacked.GetLength(1);)
    {
        chessPlateAttacked[loc[0], loc[1]] = true;
        loc[0]++;
        loc[1]++;
    }
    loc = [x, y];
    for (; loc[0] >= 0 && loc[1] < chessPlateAttacked.GetLength(1);)
    {
        chessPlateAttacked[loc[0], loc[1]] = true;
        loc[0]--;
        loc[1]++;
    }
    loc = [x, y];
    for (; loc[0] < chessPlateAttacked.GetLength(0) && loc[1] >= 0;)
    {
        chessPlateAttacked[loc[0], loc[1]] = true;
        loc[0]++;
        loc[1]--;
    }
    loc = [x, y];
    for (; loc[0] >= 0 && loc[1] >= 0;)
    {
        chessPlateAttacked[loc[0], loc[1]] = true;
        loc[0]--;
        loc[1]--;
    }
    return chessPlateAttacked;
}
static void PrintChessPlate(Boolean[,] plate)
{
    for (int i = 0; i < plate.GetLength(0); i++)
    {
        for (int j = 0; j < plate.GetLength(1); j++)
        {
            Console.Write(plate[i, j] ? "1 " : "0 ");
        }
        Console.WriteLine();
    }
}
