public class PrimeNumberChecker
{
    public static void Main()
    {
        for (; ; )
        {
            Console.WriteLine("请输入一个整数：");
            int n = int.Parse(Console.ReadLine());
            if (IsPrime(n))
            {
                Console.WriteLine($"{n}是素数");
            }
            else
            {
                Console.WriteLine($"{n}不是素数");
            }
        }
    }
    static Boolean IsPrime(int n)
    {
        int maxDivisorDigit = (int)Math.Ceiling(Math.Sqrt(n / 10));
        Boolean isPrime = true;
        if (n <= 1)
        {
            isPrime = false;
        }
        if (n % 2 == 0 ||
            n % 3 == 0 ||
            n % 5 == 0 ||
            n % 7 == 0)
        {
            isPrime = false;
        }
        for (int i = 2; i <= maxDivisorDigit; i++)
        {
            if (n % (i * 10 + 1) == 0 ||
                n % (i * 10 + 3) == 0 ||
                n % (i * 10 + 7) == 0 ||
                n % (i * 10 + 9) == 0)
            {
                isPrime = false;
            }
        }
        if (n == 2 ||
            n == 3 ||
            n == 5 ||
            n == 7 ||
            n == 11 ||
            n == 13 ||
            n == 17 ||
            n == 19 ||
            n == 23 ||
            n == 29)
        {
            isPrime = true;
        }
        return isPrime;
    }
}
