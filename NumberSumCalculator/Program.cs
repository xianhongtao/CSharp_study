public class NumberSumCalculator
{
    public static void Main(string[] args)
    {
        long q = long.Parse(Console.ReadLine());
        for (long i = 0; i < q; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            long totalPages = long.Parse(input[0]);
            long divisor = long.Parse(input[1]);
            long sumResult, divisionResult;
            divisionResult = totalPages / divisor;
            sumResult = divisionResult / GetLoopLenth(divisor) * CalculateDigitSum(divisor);
            divisionResult = divisionResult % GetLoopLenth(divisor);
            for (long index = 1; divisionResult != 0; divisionResult--)
            {
                sumResult += GetDigit(index * divisor);
                index++;
            }
            Console.WriteLine(sumResult);
        }
    }

    static long CalculateDigitSum(long number)
    {
        long digit = 0, sum = 0;
        digit = GetDigit(number);
        long index = 1;
        for (; GetDigit(index * digit) != 0; index++)
        {
            sum += GetDigit(index * digit);
        }
        return sum;
    }
    static long GetDigit(long number)
    {
        long digit = 0;
        digit = Convert.ToInt64(number % 10);
        return digit;
    }
    static long GetLoopLenth(long number)
    {
        long digit = 0;
        long lenth = 1;
        digit = Convert.ToInt64(number % 10);
        digit = GetDigit(number);
        for (; ; )
        {
            if (GetDigit(lenth * digit) == 0)
            {
                break;
            }
            lenth++;
        }
        return lenth;
    }
}
