using QuadTreePiCalculation;
int layer = 0;
int targetLayer = 6;

Queue<Tile> tilesOnTheEdge = new Queue<Tile>();
tilesOnTheEdge.Enqueue(new Tile(0, 0, layer));
Queue<int> resultQueue = new Queue<int>();

while (layer < targetLayer)
{
    Queue<Tile> nextLayerTilesOnTheEdge = new Queue<Tile>();
    int currentLayerResultTiles = 0;
    Parallel.ForEach(tilesOnTheEdge, tile =>
    {
        if (tile.IsInCircle())
        {
            currentLayerResultTiles++;
        }
        else if (tile.IsOnEdge())
        {
            for (int i = 0; i < 4; i++)
            {
                int newX = tile.X * 2 + (i % 2);
                int newY = tile.Y * 2 + (i / 2);
                Tile newTile = new Tile(newX, newY, layer + 1);
                nextLayerTilesOnTheEdge.Enqueue(newTile);
            }
        }
    });
    resultQueue.Enqueue(currentLayerResultTiles);
    tilesOnTheEdge = nextLayerTilesOnTheEdge;
    layer++;
}

double result = 0;

for (double i = 1; resultQueue.Count > 0; i /= 2)
{
    result += resultQueue.Dequeue() * i;
}

Console.WriteLine($"pi = {result * 4}");