namespace opExamen
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Введите размер массива: ");
			int arraySize = int.Parse(Console.ReadLine());

			MyClass[] myArray = new MyClass[arraySize];

			Random random = new Random();
			for (int i = 0; i < arraySize; i++)
			{
				int randomInt = random.Next(1, 101);
				string randomString = "String" + randomInt;
				myArray[i] = new MyClass(randomInt, randomString);
			}

			for (int i = 0; i < arraySize; i++)
			{
				Console.WriteLine($"Элемент {i}: Число = {myArray[i].Number}, Строка = {myArray[i].Text}");
			}
		}
	}

	class MyClass
	{
		public int Number { get; private set; }
		public string Text { get; private set; }

		public MyClass(int number, string text)
		{
			Number = number;
			Text = text;
		}
	}
}
