namespace QuadTreePiCalculation;

/// <summary>
/// 表示一个用于四叉树π计算的瓦片。
/// </summary>
public struct Tile
{
    private int _x;
    private int _y;
    private int _tileSize;
    private Point _nearPoint;
    private Point _farPoint;

    /// <summary>
    /// 初始化一个新的瓦片实例。
    /// </summary>
    /// <param name="x">瓦片的X坐标索引。</param>
    /// <param name="y">瓦片的Y坐标索引。</param>
    /// <param name="layer">瓦片所在的层数，用于计算瓦片大小。</param>
    public Tile(int x, int y, int layer)
    {
        _x = x;
        _y = y;
        _tileSize = (int)Math.Pow(2, layer);

        double scale = 1.0 / _tileSize;
        _nearPoint = new Point(_x * scale, _y * scale);
        _farPoint = new Point((_x + 1) * scale, (_y + 1) * scale);
    }

    /// <summary>
    /// 获取瓦片的X坐标索引。
    /// </summary>
    public readonly int X => _x;

    /// <summary>
    /// 获取瓦片的Y坐标索引。
    /// </summary>
    public readonly int Y => _y;

    /// <summary>
    /// 获取瓦片的大小（边长）。
    /// </summary>
    public readonly int TileSize => _tileSize;

    /// <summary>
    /// 获取瓦片的近点（左上角点）。
    /// </summary>
    public readonly Point NearPoint => _nearPoint;

    /// <summary>
    /// 获取瓦片的远点（右下角点）。
    /// </summary>
    public readonly Point FarPoint => _farPoint;

    /// <summary>
    /// 打印瓦片的详细信息到控制台。
    /// </summary>
    public void PrintTile()
    {
        Console.WriteLine($"near:{NearPoint.X},{NearPoint.Y}");
        Console.WriteLine($"far:{FarPoint.X},{FarPoint.Y}");
        Console.WriteLine($"{X},{Y},{TileSize}");
    }

    /// <summary>
    /// 检查瓦片是否完全在单位圆内。
    /// </summary>
    /// <returns>如果瓦片的远点在单位圆内，则返回true；否则返回false。</returns>
    public bool IsInCircle()
    {
        return IsPointInCircle(FarPoint);
    }

    /// <summary>
    /// 检查瓦片是否完全在单位圆外。
    /// </summary>
    /// <returns>如果瓦片的近点在单位圆外，则返回true；否则返回false。</returns>
    public bool IsOutCircle()
    {
        return !IsPointInCircle(NearPoint);
    }

    /// <summary>
    /// 检查瓦片是否与单位圆边界相交。
    /// </summary>
    /// <returns>如果瓦片部分在圆内、部分在圆外，则返回true；否则返回false。</returns>
    public bool IsOnEdge()
    {
        return !IsInCircle() && !IsOutCircle();
    }

    /// <summary>
    /// 检查给定点是否在单位圆内（包括边界）。
    /// </summary>
    /// <param name="point">要检查的点。</param>
    /// <returns>如果点在单位圆内（包括边界），则返回true；否则返回false。</returns>
    private static bool IsPointInCircle(Point point)
    {
        return point.X * point.X + point.Y * point.Y <= 1.0;
    }
}
