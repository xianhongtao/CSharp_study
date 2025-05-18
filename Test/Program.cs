Boolean[,] a = new Boolean[8, 8], b = new Boolean[8, 8];
Boolean[,] cacheCPQ;
Boolean[,] cacheCPA;
PlaceQween(a, b, 7, 2);
PrintChessPlates(a, b);

void PlaceQween(Boolean[,] chessPlateQween, Boolean[,] chessPlateAttacked, int x, int y)
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
    chessPlateQween[x, y] = true;
    cacheCPA = chessPlateAttacked;
    cacheCPQ = chessPlateQween;
    Console.WriteLine($"{x} {y}");
}
static void PrintChessPlates(Boolean[,] a, Boolean[,] b)
{
    Console.WriteLine("Chess Plate A:");
    PrintChessPlate(a);
    Console.WriteLine("Chess Plate B:");
    PrintChessPlate(b);
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
