using System.Diagnostics;

namespace opExamen
{
	class Program
	{
		static Random random = new Random();

		static void Main()
		{
			int X = 615;

			var tasks = new Task<double>[10];

			for (int i = 0; i < 10; i++)
			{
				tasks[i] = Task.Run(() => MeasureExecutionTime(X));
			}

			Task.WaitAll(tasks);

			var executionTimes = tasks.Select(t => t.Result).ToArray();
			double minTime = executionTimes.Min();
			double maxTime = executionTimes.Max();
			double avgTime = executionTimes.Average();

			Console.WriteLine($"Минимальное время выполнения: {minTime} мс");
			Console.WriteLine($"Максимальное время выполнения: {maxTime} мс");
			Console.WriteLine($"Среднее время выполнения: {avgTime} мс");
		}

		static double MeasureExecutionTime(int X)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			int[] array = GenerateArray();

			int count = array.Count(n => n == X);

			stopwatch.Stop();
			double elapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds;

			Console.WriteLine($"Время выполнения: {elapsedMilliseconds} мс, Найдено {count} элементов, равных {X}");

			return elapsedMilliseconds;
		}

		static int[] GenerateArray()
		{
			int length = random.Next(10_000_000, 15_000_001);
			int[] array = new int[length];

			for (int i = 0; i < length; i++)
			{
				array[i] = random.Next(0, 1001);
			}

			Array.Sort(array);
			
			return array;
		}
	}
}