public class LegendrePolynomials
{
    public static void Main()
    {
        Console.WriteLine("请输入一个整数n：");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("请输入一个实数x：");
        double x = Convert.ToDouble(Console.ReadLine());
        //计时
        DateTime startTime = DateTime.Now;
        double result = LegendrePolynomialF(n, x);
        DateTime endTime = DateTime.Now;
        TimeSpan timeSpan = endTime - startTime;
        Console.WriteLine($"计算时间：{timeSpan.TotalMilliseconds} 毫秒");
        Console.WriteLine($"P_{n}({x}) = {result}");
    }
    private static double LegendrePolynomialF(int n, double x)
    {
        if (n == 0) 
        {
            return 1;
        }
        else if (n == 1) 
        {
            return x;
        }
        else 
        {
            double P_n_minus_1 = LegendrePolynomialF(n - 1, x);
            double P_n_minus_2 = LegendrePolynomialF(n - 2, x);
            return ((2 * n - 1) * x * P_n_minus_1 - (n - 1) * P_n_minus_2) / n;
        }
    }
}