namespace QuadTreePiCalculation;

/// <summary>
/// 表示一个用于四叉树π计算的瓦片。
/// </summary>
public struct Tile
{
    private int _x;
    private int _y;
    private int _tileSize;
    private Point _topLeftPoint;
    private Point _topRightPoint;
    private Point _bottomLeftPoint;
    private Point _bottomRightPoint;

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
        _topLeftPoint = new Point(_x * scale, _y * scale);
        _topRightPoint = new Point((_x + 1) * scale, _y * scale);
        _bottomLeftPoint = new Point(_x * scale, (_y + 1) * scale);
        _bottomRightPoint = new Point((_x + 1) * scale, (_y + 1) * scale);
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
    /// 获取瓦片的左上角点。
    /// </summary>
    public readonly Point TopLeftPoint => _topLeftPoint;

    /// <summary>
    /// 获取瓦片的右上角点。
    /// </summary>
    public readonly Point TopRightPoint => _topRightPoint;

    /// <summary>
    /// 获取瓦片的左下角点。
    /// </summary>
    public readonly Point BottomLeftPoint => _bottomLeftPoint;

    /// <summary>
    /// 获取瓦片的右下角点。
    /// </summary>
    public readonly Point BottomRightPoint => _bottomRightPoint;

    /// <summary>
    /// 打印瓦片的详细信息到控制台。
    /// </summary>
    public void PrintTile()
    {
        Console.WriteLine($"tlp:{TopLeftPoint.X},{TopLeftPoint.Y}");
        Console.WriteLine($"trp:{TopRightPoint.X},{TopRightPoint.Y}");
        Console.WriteLine($"blp:{BottomLeftPoint.X},{BottomLeftPoint.Y}");
        Console.WriteLine($"brp:{BottomRightPoint.X},{BottomRightPoint.Y}");
        Console.WriteLine($"{X},{Y},{TileSize}");
    }

    /// <summary>
    /// 检查瓦片是否完全在单位圆内。
    /// </summary>
    /// <returns>如果瓦片的四个角点都在单位圆内，则返回true；否则返回false。</returns>
    public bool IsInCircle()
    {
        return IsPointInCircle(TopLeftPoint) &&
               IsPointInCircle(TopRightPoint) &&
               IsPointInCircle(BottomLeftPoint) &&
               IsPointInCircle(BottomRightPoint);
    }

    /// <summary>
    /// 检查瓦片是否完全在单位圆外。
    /// </summary>
    /// <returns>如果瓦片的四个角点都在单位圆外，则返回true；否则返回false。</returns>
    public bool IsOutCircle()
    {
        return !IsPointInCircle(TopLeftPoint) &&
               !IsPointInCircle(TopRightPoint) &&
               !IsPointInCircle(BottomLeftPoint) &&
               !IsPointInCircle(BottomRightPoint);
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
