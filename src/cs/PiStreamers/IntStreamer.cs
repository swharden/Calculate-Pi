namespace CalculatePi.PiStreamers;

internal static class IntStreamer
{
    public static IEnumerable<string> CalculatePi()
    {
        // NOTE: This fails rapidly (after just a few digits of pi) due to integer overflow

        long FOUR = 4;
        long SEVEN = 7;
        long TEN = 10;
        long THREE = 3;
        long TWO = 2;
        long ONE = 1;

        long k = 1;
        long l = 3;
        long n = 3;
        long q = 1;
        long r = 0;
        long t = 1;

        long nn;
        long nr;

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
