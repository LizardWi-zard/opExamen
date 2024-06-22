using System.Reflection;

namespace opExamen
{
	class Program
	{
		static void Main(string[] args)
		{
			// Создание экземпляра класса MyClass
			MyClass myObject = new MyClass();

			// Вызов приватного метода с использованием рефлексии
			MethodInfo privateMethod = typeof(MyClass).GetMethod("PrivateMethod", BindingFlags.NonPublic | BindingFlags.Instance);
			if (privateMethod != null)
			{
				// Передача сообщения в приватный метод
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
		// Приватный метод, выводящий сообщение на консоль
		private void PrivateMethod(string message)
		{
			Console.WriteLine(message);
		}
	}
}