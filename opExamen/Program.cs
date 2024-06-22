namespace opExamen
{
	class Program
	{
		static void Main(string[] args)
		{
			MyClass<int> intInstance = new MyClass<int>();
			MyClass<string> stringInstance = new MyClass<string>();
			MyClass<double> doubleInstance = new MyClass<double>();

			intInstance.PrintType();
			stringInstance.PrintType();
			doubleInstance.PrintType();
		}
	}

	class MyClass<T>
	{
		public void PrintType()
		{
			Console.WriteLine($"Тип данных: {typeof(T)}");
		}
	}
}