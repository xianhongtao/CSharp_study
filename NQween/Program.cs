int queenCount, solutions;
Console.WriteLine($"有几个皇后？");
queenCount = Convert.ToInt32(Console.ReadLine());
Boolean[,] chessPlate = new Boolean[queenCount, queenCount];
solutions = 0;
Step(chessPlate, 0);
Console.WriteLine($"{solutions}");
void Step(Boolean[,] chessPlate, int currentRow)
{
    for (int currentColumn = 0; currentColumn < queenCount; currentColumn++)
    {
        if (!chessPlate[currentRow, currentColumn])
        {
            Boolean[,] newPlate = (Boolean[,])chessPlate.Clone();
            if (currentRow == queenCount - 1)
            {
                solutions++;
            }
            else
            {
                Step(MarkQueenAttacks(newPlate, currentRow, currentColumn), currentRow + 1);
            }
        }
    }
}
static Boolean[,] MarkQueenAttacks(Boolean[,] chessPlate, int x, int y)
{
    for (int i = 0; i < chessPlate.GetLength(0); i++)
    {
        chessPlate[x, i] = true;
    }
    for (int i = 0; i < chessPlate.GetLength(1); i++)
    {
        chessPlate[i, y] = true;
    }
    int[] position = [x, y];
    for (; position[0] < chessPlate.GetLength(0) && position[1] < chessPlate.GetLength(1);)
    {
        chessPlate[position[0], position[1]] = true;
        position[0]++;
        position[1]++;
    }
    position = [x, y];
    for (; position[0] >= 0 && position[1] < chessPlate.GetLength(1);)
    {
        chessPlate[position[0], position[1]] = true;
        position[0]--;
        position[1]++;
    }
    position = [x, y];
    for (; position[0] < chessPlate.GetLength(0) && position[1] >= 0;)
    {
        chessPlate[position[0], position[1]] = true;
        position[0]++;
        position[1]--;
    }
    position = [x, y];
    for (; position[0] >= 0 && position[1] >= 0;)
    {
        chessPlate[position[0], position[1]] = true;
        position[0]--;
        position[1]--;
    }
    return chessPlate;
}
