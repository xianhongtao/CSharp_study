程序.运行八皇后();

public static class 程序
{
    public static void 运行八皇后()
    {
        int[] 皇后位置 = new int[8];
        int 解数 = 放置皇后(皇后位置, 0, 0);
        打印一行($"八皇后共有 {解数} 个解。");
    }

    private static int 放置皇后(int[] 皇后位置, int 当前行, int 解数)
    {
        如果(当前行 == 皇后位置.Length, () =>
        {
            解数++;
            打印棋盘(皇后位置, 解数);
        }, () =>
        {
            循环(0, 皇后位置.Length, 当前列 =>
            {
                如果(可以放置(皇后位置, 当前行, 当前列), () =>
                {
                    皇后位置[当前行] = 当前列;
                    解数 = 放置皇后(皇后位置, 当前行 + 1, 解数);
                });
            });
        });

        return 解数;
    }

    private static bool 可以放置(int[] 皇后位置, int 当前行, int 当前列)
    {
        bool 允许放置 = true;

        循环(0, 当前行, 已放置行 =>
        {
            int 行差 = 当前行 - 已放置行;
            int 列差 = 当前列 - 皇后位置[已放置行];

            如果(列差 == 0 || 列差 == 行差 || 列差 == -行差, () =>
            {
                允许放置 = false;
            });
        });

        return 允许放置;
    }

    private static void 打印棋盘(int[] 皇后位置, int 解编号)
    {
        打印一行($"第 {解编号} 个解：");

        循环(0, 皇后位置.Length, 行 =>
        {
            循环(0, 皇后位置.Length, 列 =>
            {
                打印(皇后位置[行] == 列 ? "Q " : ". ");
            });

            打印一行();
        });

        打印一行();
    }

    private static void 循环(int 起始值, int 结束值, Action<int> 执行)
    {
        for (int 索引 = 起始值; 索引 < 结束值; 索引++)
        {
            执行(索引);
        }
    }

    private static void 如果(bool 条件, Action 成立时执行, Action? 否则执行 = null)
    {
        if (条件)
        {
            成立时执行();
        }
        else
        {
            否则执行?.Invoke();
        }
    }

    private static void 打印(string 内容)
    {
        Console.Write(内容);
    }

    private static void 打印一行(string 内容 = "")
    {
        Console.WriteLine(内容);
    }
}
