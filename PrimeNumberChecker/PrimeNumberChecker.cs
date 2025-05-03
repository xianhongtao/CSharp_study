using 
public class PrimeNumberChecker
{
    public static void Main()
    {
        for (; ; )
        {
            Console.WriteLine("请输入一个整数：");
            long userInput = long.Parse(Console.ReadLine());
            if (IsPrime(userInput))
            {
                Console.WriteLine($"{userInput}是素数");
            }
            else
            {
                Console.WriteLine($"{userInput}不是素数");
            }
            Console.WriteLine(sizeof (long));
        }
    }
    
    static Boolean IsPrime(long number)
    {
        long maxDivisorDigit = (long)Math.Ceiling(Math.Sqrt(number / 10));
        Boolean isNumberPrime = true;
        if (number <= 1)
        {
            isNumberPrime = false;
        }
        if ((number % 2 == 0) || (number % 3 == 0) || (number % 5 == 0) || (number % 7 == 0) )
        {
            isNumberPrime = false;
        }
        for (int divisorIndex = 1; divisorIndex <= maxDivisorDigit; divisorIndex++)
        {
            if ((number % (divisorIndex * 10 + 1) == 0) || (number % (divisorIndex * 10 + 3) == 0) || (number % (divisorIndex * 10 + 7) == 0) || (number % (divisorIndex * 10 + 9) == 0))
            {
                isNumberPrime = false;
            }
        }
        if ((number == 2) || (number == 3) || (number == 5) || (number == 7) || (number == 11) || (number == 13) || (number == 17) || (number == 19) || (number == 23) || (number== 29))
        {
            isNumberPrime = true;
        }
        return isNumberPrime;
    }
}