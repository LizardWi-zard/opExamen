using System.Collections.Concurrent;
using System.Diagnostics;

namespace opExamen
{
	class Program
	{

		static object _lock = new object();

		static public long ProcessArray(int NumberToFind)
		{
			Stopwatch time = new Stopwatch();
			Random rnd = new Random();

			int size = rnd.Next(10000000, 15000001);

			int[] arr = new int[size];

			for (int i = 0; i < size; i++)
			{
				arr[i] = rnd.Next(0, 1001);
			}

			Array.Sort(arr);

			time.Start();

			lock (_lock)
			{
				int count = Array.FindAll(arr, (item => item == NumberToFind)).Length;
			}

			time.Stop();

			return time.ElapsedMilliseconds;

		}

		static void Main(string[] args)
		{

			int NumberToFind = 431, NumberOfThreads = 10;
			long[] time = new long[NumberOfThreads];
			ConcurrentBag<long> times = new ConcurrentBag<long>();
			Thread[] threads = new Thread[NumberOfThreads];


			for (int i = 0; i < NumberOfThreads; i++)
			{
				threads[i] = new Thread(new ThreadStart(() => times.Add(ProcessArray(NumberToFind))));
				threads[i].Start();
			}

			foreach (var thread in threads)
			{
				thread.Join();
			}

			time = times.Where(x => x != 0).ToArray();

			for (int i = 0; i < NumberOfThreads; i++)
			{
				Console.WriteLine(time[i]);
			}

			Console.WriteLine("\n");
			Console.WriteLine($"Минимальное время выполнения: {time.Max()}");
			Console.WriteLine($"Максимальное время выполнения: {time.Min()}");
			Console.WriteLine($"Среднее время выполнения: {time.Sum() / NumberOfThreads}");

		}

	}

}