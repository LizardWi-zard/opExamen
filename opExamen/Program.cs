namespace opExamen
{
	class Program
	{
		static void Main(string[] args)
		{
			IMyInterface myObject = new MyClass();

			var obj = new IMyInterface[] {new  MyClass(), new MySecondClass(), new MyClass()};

			foreach (var i in obj) 
			{
				i.MethodA();
            }

		}
	}

	public interface IMyInterface
	{
		void MethodA();
		void MethodB();
		void MethodC();
	}

	public class MyClass : IMyInterface
	{
		public void MethodA() => Console.WriteLine("first MethodA");
		public void MethodB() => Console.WriteLine("first MethodB");
		public void MethodC() => Console.WriteLine("first MethodC");
	}

	public class MySecondClass : IMyInterface
	{
		public void MethodA() => Console.WriteLine("second MethodA");
		public void MethodB() => Console.WriteLine("second MethodB");
		public void MethodC() => Console.WriteLine("second MethodC");
	}
}