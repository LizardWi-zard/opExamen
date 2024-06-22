using System.Diagnostics;

namespace opExamen
{
	class Program
	{
		static void Main(string[] args)
		{
			int X = 340; 

			var tasks = new Task<(int, TimeSpan)>[10];
			for (int i = 0; i < 10; i++)
			{
				tasks[i] = Task.Run(() => GenerateAndProcessArray(X));
			}

			Task.WaitAll(tasks);

			List<TimeSpan> times = tasks.Select(t => t.Result.Item2).ToList();
			TimeSpan minTime = times.Min();
			TimeSpan maxTime = times.Max();
			TimeSpan avgTime = TimeSpan.FromTicks((long)times.Average(t => t.Ticks));

			Console.WriteLine($"Минимальное время выполнения: {minTime}");
			Console.WriteLine($"Максимальное время выполнения: {maxTime}");
			Console.WriteLine($"Среднее время выполнения: {avgTime}");
		}

		static (int, TimeSpan) GenerateAndProcessArray(int X)
		{
			var random = new Random();
			int size = random.Next(10000000, 15000001);

            Console.WriteLine($"Размер массива: {size}");

            var array = new int[size];
			for (int i = 0; i < size; i++)
			{
				array[i] = random.Next(0, 1001);
			}

			var stopwatch = Stopwatch.StartNew();
			
			Array.Sort(array);

			int count = array.Count(n => n == X);

			stopwatch.Stop();
			return (count, stopwatch.Elapsed);
		}
	}
}