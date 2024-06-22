namespace opExamen
{
	class Program
	{
		public delegate void Delegate1(int number, string text, bool flag);
		public delegate int Delegate2(int[] numbers, double multiplier);

		static void Main(string[] args)
		{
			Delegate1 del1 = new Delegate1(Method1);
			Delegate2 del2 = new Delegate2(Method2);

			del1(42, "Hello, world!", true);
			int result = del2(new int[] { 1, 2, 3, 4, 5 }, 2.5);

			Console.WriteLine($"Результат выполнения делегата Delegate2: {result}");
		}

		public static void Method1(int number, string text, bool flag)
		{
			Console.WriteLine($"Number: {number}, Text: {text}, Flag: {flag}");
		}

		public static int Method2(int[] numbers, double multiplier)
		{
			int sum = 0;

			foreach (int number in numbers)
			{
				sum += (int)(number * multiplier);
			}

			return sum;
		}
	}
}
