using System.Numerics;

namespace CalculatePi.PiStreamers;

internal static class BigIntegerStreamer
{
    public static IEnumerable<string> CalculatePi()
    {
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

        bool isFirstChar = true;
        while (true)
        {
            if ((FOUR * q + r - t).CompareTo(n * t) == -1)
            {
                yield return n.ToString();
                if (isFirstChar)
                {
                    isFirstChar = false;
                    yield return ".";
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
    }
}