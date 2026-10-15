public static class 程序
{
    public static void Main(string[] args)
    {
        打印消息("你好，世界！");
    }

    public static void 打印消息(string 消息)
    {
        Console.WriteLine(消息);
    }
    public static T 如果<T>(bool 条件, T 值1, T 值2)
    {
        return 条件 ? 值1 : 值2;
    }
}
