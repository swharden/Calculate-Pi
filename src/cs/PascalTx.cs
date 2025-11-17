using System.Diagnostics;

namespace CalculatePi;

internal class PascalTx
{
    public static void StreamPiDigits(int maxDigits)
    {
        Stopwatch sw = Stopwatch.StartNew();

        int len = (10 * maxDigits) / 3;

        int[] a = new int[len + 1];
        int nines = 0;
        int predigit = 0;

        for (int j = 1; j <= len; j++)
            a[j] = 2;

        for (int j = 1; j <= maxDigits; j++)
        {
            int q = 0;

            for (int i = len; i >= 1; i--)
            {
                int x = 10 * a[i] + q * i;
                a[i] = x % (2 * i - 1);
                q = x / (2 * i - 1);
            }

            a[1] = q % 10;
            q /= 10;

            if (q == 9)
            {
                nines++;
            }
            else if (q == 10)
            {
                Console.Write(predigit + 1);

                for (int k = 1; k <= nines; k++)
                    Console.Write(0);

                predigit = 0;
                nines = 0;
            }
            else
            {
                if (j > 1)
                    Console.Write(predigit);
                if (j == 2)
                    Console.Write(".");

                predigit = q;

                if (nines != 0)
                {
                    for (int k = 1; k <= nines; k++)
                        Console.Write(9);

                    nines = 0;
                }
            }
        }

        Console.WriteLine($"\nCalculated {maxDigits:N0} digits of pi in {sw.Elapsed.TotalSeconds:F3} sec");
    }
}
