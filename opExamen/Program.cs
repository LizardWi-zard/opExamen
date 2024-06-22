namespace opExamen
{
	class Program
	{
		static void Main(string[] args)
		{
			MyClass obj1 = new MyClass { Num1 = 5, Num2 = 10 };
			MyClass obj2 = new MyClass { Num1 = 15, Num2 = 20 };

			MyClass result = obj1 + obj2;

			Console.WriteLine($"Результат сложения: Property1 = {result.Num1}, Property2 = {result.Num2}");
		}
	}

	class MyClass
	{
		public int Num1 { get; set; }
		public int Num2 { get; set; }

		public static MyClass operator +(MyClass a, MyClass b)
		{
			return new MyClass
			{
				Num1 = a.Num1 + b.Num1,
				Num2 = a.Num2 + b.Num2
			};
		}
	}
}