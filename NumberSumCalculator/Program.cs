public class NumberSumCalculator
{
    public static void Main(string[] args)
    {
        for (; ; )
        {
            string inputLine = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputLine))
            {
                Console.WriteLine("0");
                continue;
            }
            string[] input = inputLine.Split(' ');
            if (input.Length < 2)
            {
                Console.WriteLine("0");
                continue;
            }
            long totalPages = long.Parse(input[0]);
            int divisor = int.Parse(input[1]);
            long sumResult, divisionResult;
            divisionResult = totalPages / divisor;
            sumResult = divisionResult / GetLoopLenth(divisor) * CalculateDigitSum(divisor);
            divisionResult = divisionResult % GetLoopLenth(divisor);
            for (int index = 1; divisionResult != 0; divisionResult--)
            {
                sumResult += GetDigit(index * divisor);
                index++;
            }
            Console.WriteLine(sumResult);
        }
    }

    static int CalculateDigitSum(long number)
    {
        int digit = 0, sum = 0;
        digit = GetDigit(number);
        int index = 1;
        for (; GetDigit(index * digit) != 0; index++)
        {
            sum += GetDigit(index * digit);
        }
        return sum;
    }
    static int GetDigit(long number)
    {
        int digit = 0;
        digit = Convert.ToInt32(number % 10);
        return digit;
    }
    static long GetLoopLenth(long number)
    {
        int digit = 0;
        int lenth = 1;
        digit = Convert.ToInt32(number % 10);
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