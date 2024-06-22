namespace opExamen
{
    class Program
	{
		static void Main(string[] args)
		{
			MyThirdClass<MyClass> genericInstance1 = new MyThirdClass<MyClass>(new MyClass(42, "Hello World"));
			MyThirdClass<MySecondClass> genericInstance2 = new MyThirdClass<MySecondClass>(new MySecondClass(24, "MySecondClass"));

			genericInstance1.PrintType();
			genericInstance2.PrintType();
		}
	}

	class MyThirdClass<T> where T : MyClass
	{
		private T _item;

		public MyThirdClass(T item)
		{
			_item = item;
		}

		public void PrintType()
		{
			Console.WriteLine($"Тип данных: {typeof(T)}");
			Console.WriteLine($"Значение: Number = {_item.Number}, Text = {_item.Text}");
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

	class MySecondClass : MyClass
	{
		public MySecondClass(int number, string text)
			: base(number, text)
		{
		}
	}
}	