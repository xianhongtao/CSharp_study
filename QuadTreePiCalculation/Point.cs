namespace QuadTreePiCalculation;

/// <summary>
/// 表示一个二维点。
/// </summary>
public struct Point
{
    private double _x;
    private double _y;

    /// <summary>
    /// 初始化一个新的点实例。
    /// </summary>
    /// <param name="x">点的X坐标。</param>
    /// <param name="y">点的Y坐标。</param>
    public Point(double x, double y)
    {
        _x = x;
        _y = y;
    }

    /// <summary>
    /// 获取点的X坐标。
    /// </summary>
    public readonly double X => _x;

    /// <summary>
    /// 获取点的Y坐标。
    /// </summary>
    public readonly double Y => _y;
}
