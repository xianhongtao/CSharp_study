int[,] matrixToSolve = new int[,]
{
    { 2, 9, 3, 5, 7 },
    { 6, 1, 3, 6, 6 },
    { 9, 4, 7, 10, 12 },
    { 2, 1, 14, 4, 16 },
    { 9, 6, 2, 4, 6 }
};
matrixToSolve = RowReducing(matrixToSolve);
matrixToSolve = ColumnReducing(matrixToSolve);
int[,] backUpMatrix = (int[,])matrixToSolve.Clone();
int[,] toolMatrix = new int[5, 5];
while (HowManyMinusTwos(backUpMatrix) != 5)
{
    toolMatrix = new int[5, 5];
    backUpMatrix = (int[,])matrixToSolve.Clone();
    backUpMatrix = MatrixRowProcessing(backUpMatrix);
    backUpMatrix = MatrixColumnProcessing(backUpMatrix);
    int toolNumber = MinimumNotMinusNumber(backUpMatrix);
    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            matrixToSolve[i, j] += toolMatrix[i, j] * toolNumber;
        }
    }
}
for (int i = 0; i < 5; i++)
{
    for (int j = 0; j < 5; j++)
    {
        if (backUpMatrix[i, j] == -2)
        {
            toolMatrix[i, j] = 1;
        }
    }
}
PrintMatrix(matrixToSolve);
Console.WriteLine();
PrintMatrix(toolMatrix);
Console.WriteLine();

static int MinimumNotMinusNumber(int[,] matrix)
{
    int min = int.MaxValue;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] > 0 && matrix[i, j] < min)
            {
                min = matrix[i, j];
            }
        }
    }
    return min;
}

static int HowManyMinusTwos(int[,] matrix)
{
    int count = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] == -2)
            {
                count++;
            }
        }
    }
    return count;
}

int[,] MatrixRowProcessing(int[,] matrix)
{
    for (int i = 0; i < 5; i++)
    {
        for (int rowIndex = 0; rowIndex < 5; rowIndex++)
        {
            int zeroCount = 0;
            for (int columnIndex = 0; columnIndex < 5; columnIndex++)
            {
                if (matrix[rowIndex, columnIndex] == 0)
                {
                    zeroCount++;
                }
            }
            int zeroPosition = WhereIsTheZero(matrix, rowIndex, false);
            if (zeroCount == 1)
            {
                for (int k = 0; k < 5; k++)
                {
                    matrix[k, zeroPosition] = -1;
                    toolMatrix[k, zeroPosition] += 1;
                }
                matrix[rowIndex, zeroPosition] = -2;
            }
        }
    }
    return matrix;
}

int[,] MatrixColumnProcessing(int[,] matrix)
{
    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            toolMatrix[i, j] -= 1;
        }
    }
    for (int i = 0; i < 5; i++)
    {
        for (int columnIndex = 0; columnIndex < 5; columnIndex++)
        {
            int zeroCount = 0;
            for (int rowIndex = 0; rowIndex < 5; rowIndex++)
            {
                if (matrix[rowIndex, columnIndex] == 0)
                {
                    zeroCount++;
                }
            }
            int zeroPosition = WhereIsTheZero(matrix, columnIndex, true);
            if (zeroCount == 1)
            {
                for (int k = 0; k < 5; k++)
                {
                    matrix[zeroPosition, k] = -1;
                    toolMatrix[zeroPosition, k] += 1;
                }
                matrix[zeroPosition, columnIndex] = -2;
            }
        }
    }
    return matrix;
}

static int WhereIsTheZero(int[,] matrix, int row, bool isVertical)
{
    if (isVertical)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, row] == 0)
            {
                return i;
            }
        }
    }
    else
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[row, j] == 0)
            {
                return j;
            }
        }
    }
    return -1;
}

static int[,] RowReducing(int[,] matrix)
{
    for (int i = 0; i < 5; i++)
    {
        int minInRow = MinInRow(matrix, i);
        for (int j = 0; j < 5; j++)
        {
            matrix[i, j] -= minInRow;
        }
    }
    return matrix;
}

static int[,] ColumnReducing(int[,] matrix)
{
    for (int j = 0; j < 5; j++)
    {
        int minInColumn = MinInColumn(matrix, j);
        for (int i = 0; i < 5; i++)
        {
            matrix[i, j] -= minInColumn;
        }
    }
    return matrix;
}

static int MinInRow(int[,] matrix, int row)
{
    int min = matrix[row, 0];
    for (int j = 1; j < matrix.GetLength(1); j++)
    {
        if (matrix[row, j] < min)
        {
            min = matrix[row, j];
        }
    }
    return min;
}

static int MinInColumn(int[,] matrix, int column)
{
    int min = matrix[0, column];
    for (int i = 1; i < matrix.GetLength(0); i++)
    {
        if (matrix[i, column] < min)
        {
            min = matrix[i, column];
        }
    }
    return min;
}

static void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j]);
            if (j < matrix.GetLength(1) - 1)
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}