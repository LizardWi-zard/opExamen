namespace opExamen
{
	class Program
	{
		static void Main(string[] args)
		{
			MyClass myObject = new MyClass();

			myObject.MyEvent += MyMethod;

			// Вызов события
			myObject.RaiseEvent(50);

			myObject.MyEvent -= MyMethod;

			myObject.RaiseEvent(50);
		}

		// Метод, соответствующий сигнатуре void (int)
		public static void MyMethod(int value)
		{
			Console.WriteLine($"MyMethod вызван с параметром: {value}");
		}
	}

	class MyClass
	{
		private event Action<int> myEvent;

		public event Action<int> MyEvent
		{
			add
			{
				Console.WriteLine("Метод подписан на событие.");
				myEvent += value;
			}
			remove
			{
				Console.WriteLine("Метод отписан от события.");
				myEvent -= value;
			}
		}

		public void RaiseEvent(int value)
		{
			myEvent?.Invoke(value);
		}
	}
}