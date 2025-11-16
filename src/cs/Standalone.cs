using System.Diagnostics;
using System.Numerics;

namespace CalculatePi;

public static class Standalone
{
    public static void Run(int maxDigits)
    {
        // Calculated Pi to 1,000 digits in about 100 ms
        // Calculated Pi to 10,000 digits in about 5 sec

        BigInteger FOUR = new(4);
        BigInteger SEVEN = new(7);
        BigInteger TEN = new(10);
        BigInteger THREE = new(3);
        BigInteger TWO = new(2);
        BigInteger ONE = new(1);

        BigInteger k = new(1);
        BigInteger l = new(3);
        BigInteger n = new(3);
        BigInteger q = new(1);
        BigInteger r = new(0);
        BigInteger t = new(1);

        BigInteger nn;
        BigInteger nr;

        Stopwatch sw = Stopwatch.StartNew();

        int charsPrinted = 0;
        while (charsPrinted < maxDigits)
        {
            if ((FOUR * q + r - t).CompareTo(n * t) == -1)
            {
                charsPrinted++;
                Console.Write(n);
                if (charsPrinted == 1)
                {
                    Console.Write(".");
                    charsPrinted++;
                }
                if (charsPrinted - 2 >= maxDigits)
                {
                    break;
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
                k += ONE;
                n = nn;
                r = nr;
            }
        }

        Console.WriteLine($"\nCalculated Pi to {maxDigits:N0} digits in {sw.Elapsed.TotalSeconds:F3} sec");
    }
}
