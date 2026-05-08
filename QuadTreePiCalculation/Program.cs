using QuadTreePiCalculation;
int layer = 0;
int targetLayer = Convert.ToInt32(Console.ReadLine());

Queue<Tile> tilesOnTheEdge = new();
tilesOnTheEdge.Enqueue(new Tile(0, 0, layer));
Queue<int> resultQueue = new();

while (layer < targetLayer)
{
#if DEBUG
    Console.WriteLine($"当前Layer：{layer} 当前层任务负担：{tilesOnTheEdge.Count} 瓦片");
#endif
    Queue<Tile> nextLayerTilesOnTheEdge = new();
    int currentLayerResultTiles = 0;
    foreach (var tile in tilesOnTheEdge) {
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
                Tile newTile = new(newX, newY, layer + 1);
                nextLayerTilesOnTheEdge.Enqueue(newTile);
            }
        }
    };
    resultQueue.Enqueue(currentLayerResultTiles);
    tilesOnTheEdge = nextLayerTilesOnTheEdge;
    layer++;
}

double result = 0;

for (double i = 1; resultQueue.Count > 0; i /= 4)
{
    result += resultQueue.Dequeue() * i;
}

Console.WriteLine($"pi = {result * 4}");