using System.Diagnostics;

namespace CalculatePi.PiStreamers;

public static class Compare
{
    public static void Run()
    {
        List<IEnumerator<string>> streamers = [
            BigIntegerStreamer.CalculatePi().GetEnumerator(),
            IntStreamer.CalculatePi().GetEnumerator(),
        ];

        Stopwatch sw = Stopwatch.StartNew();

        for (int stringIndex = 0; stringIndex < 1_000; stringIndex++)
        {
            streamers.ForEach(x => x.MoveNext());
            for (int i = 0; i < streamers.Count; i++)
            {
                if (streamers[0].Current != streamers[i].Current)
                {
                    throw new Exception($"Mismatch at digit {stringIndex}. " +
                        $"{streamers[i].GetType().DeclaringType!.Name} " +
                        $"got {streamers[i].Current} (expect {streamers[0].Current})");
                }
            }
            Console.Write(streamers[0].Current);
        }

        Console.WriteLine($"\nCompleted in {sw.Elapsed.TotalSeconds:F3} sec");
    }
}
