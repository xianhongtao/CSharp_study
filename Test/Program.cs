Console.WriteLine(GetLoopLength(32, 24));
static int GetLoopLength(int n, int x)
{
    if (n % x == 0 || x % n == 0)
    {
        if (n % x == 0 && n != 1)
        {
            n /= x;
        }
        if (x % n == 0 && x != 1)
        {
            x /= n;
        }
    }
    if (n > x)
    {
        return n;
    }
    else
    {
        return x;
    }
}