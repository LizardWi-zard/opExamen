using System.Reflection;

namespace opExamen
{
	class Program
	{
		static void Main(string[] args)
		{
			MyClass myObject = new MyClass();

			MethodInfo privateMethod = typeof(MyClass).GetMethod("PrivateMethod", BindingFlags.NonPublic | BindingFlags.Instance);
			if (privateMethod != null)
			{
				privateMethod.Invoke(myObject, new object[] { "Hello from the private method!" });
			}
			else
			{
				Console.WriteLine("Не удалось найти приватный метод.");
			}
		}
	}
	class MyClass
	{
		private void PrivateMethod(string message)
		{
			Console.WriteLine(message);
		}
	}
}