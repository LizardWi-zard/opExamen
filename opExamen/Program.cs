namespace opExamen
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Введите размер массивов: ");
			int arraySize = int.Parse(Console.ReadLine());

			MySecondClass[] array1 = new MySecondClass[arraySize];
			MySecondClass[] array2 = new MySecondClass[arraySize];

			Random random = new Random();
			for (int i = 0; i < arraySize; i++)
			{
				array1[i] = new MySecondClass("String" + i.ToString(), random.Next(0, 2) == 0);
				array2[i] = new MySecondClass("String" + i.ToString(), random.Next(0, 2) == 0);
			}

			int falseCountArray1 = CountFalseValues(array1);
			int falseCountArray2 = CountFalseValues(array2);

			Console.WriteLine("Первый массив массив:");
			foreach (var item in array1)
			{
				Console.Write($"{item.BooleanValue}, ");
			}
			Console.WriteLine($"\nКоличество значений false в первом массиве: {falseCountArray1}");

			Console.WriteLine("Второй массив массив:");
			foreach (var item in array2)
			{
				Console.Write($"{item.BooleanValue}, ");
			}
			Console.WriteLine($"\nКоличество значений false во втором массиве: {falseCountArray2}");

			if (falseCountArray1 > falseCountArray2)
			{
				Console.WriteLine("Значение false чаще встречается в первом массиве.");
			}
			else if (falseCountArray1 < falseCountArray2)
			{
				Console.WriteLine("Значение false чаще встречается во втором массиве.");
			}
			else
			{
				Console.WriteLine("Значение false встречается одинаково часто в обоих массивах.");
			}
		}

		static int CountFalseValues(MySecondClass[] array)
		{
			int count = 0;
			foreach (var item in array)
			{
				if (!item.BooleanValue)
				{
					count++;
				}
			}
			return count;
		}
	}

	class MyClass
	{
		public string StringValue { get; private set; }
		public bool BooleanValue { get; private set; }

		public MyClass(string stringValue, bool booleanValue)
		{
			StringValue = stringValue;
			BooleanValue = booleanValue;
		}
	}

	class MySecondClass : MyClass
	{
		public MySecondClass(string stringValue, bool booleanValue)
			: base(stringValue, booleanValue)
		{
		}
	}
}