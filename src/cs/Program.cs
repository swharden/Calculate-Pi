// Calculated Pi to 10,000 digits in 0.412 sec
// Calculated Pi to 100,000 digits in 31.108 sec
// This method does not use floating point arithmetic

using System.Diagnostics;
using System.Numerics;

BigInteger FOUR = new(4);
BigInteger SEVEN = new(7);
BigInteger TEN = new(10);
BigInteger THREE = new(3);
BigInteger TWO = new(2);

BigInteger k = new(1);
BigInteger l = new(3);
BigInteger n = new(3);
BigInteger q = new(1);
BigInteger r = new(0);
BigInteger t = new(1);

BigInteger nn;
BigInteger nr;

Stopwatch sw = Stopwatch.StartNew();
const int digits = 100_000;
for (int i = 0; i < digits; i++)
{
    if ((FOUR * q + r - t).CompareTo(n * t) == -1)
    {
        Console.Write(n);
        if (i == 1)
        {
            Console.Write(".");
        }
        nr = TEN * (r - (n * t));
        n = TEN * (THREE * q + r) / t - (TEN * n);
        q *= TEN;
        r = nr;
    }
    else
    {
        nr = (TWO * q + r) * l;
        nn = (q * (SEVEN * k) + TWO + r * l) / (t * l);
        q *= k;
        t *= l;
        l += TWO;
        k += BigInteger.One;
        n = nn;
        r = nr;
    }
}
Console.WriteLine();
Console.WriteLine($"Calculated Pi to {digits:N0} digits in {sw.Elapsed.TotalSeconds:F3} sec");