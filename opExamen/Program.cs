using System.Diagnostics;

namespace opExamen
{
	class Program
	{
		static readonly Random random = new Random();
		static readonly object lockObject = new object();
		static long totalWaitTime = 0;
		static int countWaits = 0;
		static long minWaitTime = long.MaxValue;
		static long maxWaitTime = 0;

		static void Main()
		{
			int[] array = GenerateRandomArray();
			Array.Sort(array);

			int x = 500; // значение Х
			int threadCount = 10;
			Task[] tasks = new Task[threadCount];

			for (int i = 0; i < threadCount; i++)
			{
				tasks[i] = Task.Run(() => CountOccurrences(array, x));
			}

			Task.WaitAll(tasks);

			double averageWaitTime = countWaits > 0 ? totalWaitTime / (double)countWaits : 0;

			Console.WriteLine($"Минимальное время ожидания: {minWaitTime} мс");
			Console.WriteLine($"Максимальное время ожидания: {maxWaitTime} мс");
			Console.WriteLine($"Среднее время ожидания: {averageWaitTime} мс");

		}

		static int[] GenerateRandomArray()
		{
			int length = random.Next(10_000_000, 15_000_001);
			int[] array = new int[length];

			for (int i = 0; i < length; i++)
			{
				array[i] = random.Next(0, 1001);
			}

			return array;
		}

		static void CountOccurrences(int[] array, int x)
		{
			Stopwatch stopwatch = new Stopwatch();

			stopwatch.Start();
			int count = 0;

			lock (lockObject)
			{
				stopwatch.Stop();
				long waitTime = stopwatch.ElapsedMilliseconds;

				if (waitTime > 0)
				{
					Interlocked.Add(ref totalWaitTime, waitTime);
					Interlocked.Increment(ref countWaits);
					Interlocked.Exchange(ref minWaitTime, Math.Min(minWaitTime, waitTime));
					Interlocked.Exchange(ref maxWaitTime, Math.Max(maxWaitTime, waitTime));
				}

				count = array.Count(value => value == x);
			}

			Console.WriteLine($"Количество элементов, равных {x}: {count}");
		}
	}
}