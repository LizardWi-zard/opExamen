namespace opExamen
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Введите размер массива: ");
			int arraySize = int.Parse(Console.ReadLine());

			int[] array = new int[arraySize];
			Random random = new Random();

			for (int i = 0; i < arraySize; i++)
			{
				array[i] = random.Next(0, arraySize + 1);
			}

			Console.WriteLine("Сгенерированный массив:");
			Console.WriteLine(string.Join(", ", array));

			double median = CalculateMedian(array);

			Console.WriteLine($"Медианное значение массива: {median}");
		}

		static double CalculateMedian(int[] array)
		{
			int[] sortedArray = (int[])array.Clone();
			Array.Sort(sortedArray);

			Console.WriteLine("Отсортированный массив:");
			Console.WriteLine(string.Join(", ", sortedArray));

			int middleIndex = sortedArray.Length / 2;

			if (sortedArray.Length % 2 == 0)
			{
				return (sortedArray[middleIndex - 1] + sortedArray[middleIndex]) / 2.0;
			}
			else
			{
				return sortedArray[middleIndex];
			}
		}
	}
}