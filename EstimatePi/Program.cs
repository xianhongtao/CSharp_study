using System.Diagnostics;

Console.WriteLine("蒙特卡洛圆周率估算（按ESC退出）");

long totalPoints = 0;
long pointsInsideCircle = 0;
var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 2 };

// 使用线程安全的Random生成器
ThreadLocal<Random> randomGenerator = new ThreadLocal<Random>(() =>
    new Random(Guid.NewGuid().GetHashCode()));

var stopwatch = Stopwatch.StartNew();
long lastOutputPoints = 0;
var lastOutputTime = stopwatch.Elapsed;
long startTime = stopwatch.ElapsedMilliseconds;

while (true)
{
    // 检查退出按键
    if (Console.KeyAvailable)
    {
        var key = Console.ReadKey(true);
        if (key.Key == ConsoleKey.Escape) break;
    }

    Parallel.For(0, 100000000, parallelOptions, () => (0L, 0L), (i, loop, localState) =>
    {
        var random = randomGenerator.Value;
        double x = random.NextDouble();
        double y = random.NextDouble();

        double dx = x - 0.5;
        double dy = y - 0.5;
        double distanceToCenter = dx * dx + dy * dy;
        if (distanceToCenter <= 0.25)
        {
            localState.Item1++; // 圆内点数
        }
        localState.Item2++; // 总点数
        return localState;
    },
    localState =>
    {
        Interlocked.Add(ref pointsInsideCircle, localState.Item1);
        Interlocked.Add(ref totalPoints, localState.Item2);
    });

    // 每秒输出一次结果
    if (stopwatch.Elapsed - lastOutputTime > TimeSpan.FromSeconds(1))
    {
        long currentPoints = totalPoints;
        long pointsSinceLast = currentPoints - lastOutputPoints;
        double pointsPerSecond = pointsSinceLast / (stopwatch.Elapsed - lastOutputTime).TotalSeconds;
        double piEstimate = 4.0 * (double)pointsInsideCircle / totalPoints;
        double error = Math.Abs(piEstimate - Math.PI);
        double progress = (double)totalPoints / 10_000_000_000; // 100亿点目标

        Console.WriteLine($"点数: {totalPoints:N0} | π估值: {piEstimate:F8} | 误差: {error:E2} | " +
                          $"速度: {pointsPerSecond:N0}点/秒 | 进度: {progress:P2} | 用时: {stopwatch.Elapsed:mm\\:ss}");

        lastOutputTime = stopwatch.Elapsed;
        lastOutputPoints = currentPoints;
    }
}

// 最终结果输出
double finalPiEstimate = 4.0 * (double)pointsInsideCircle / totalPoints;
Console.WriteLine("\n最终结果:");
Console.WriteLine($"总点数: {totalPoints:N0}");
Console.WriteLine($"π估值: {finalPiEstimate:F15}");
Console.WriteLine($"真实π值: {Math.PI:F15}");
Console.WriteLine($"绝对误差: {Math.Abs(finalPiEstimate - Math.PI):E15}");
Console.WriteLine($"相对误差: {Math.Abs(finalPiEstimate - Math.PI) / Math.PI:P6}");
Console.WriteLine($"总用时: {stopwatch.Elapsed:h\\:mm\\:ss}");
