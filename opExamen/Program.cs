using System.Reflection;

namespace opExamen
{
	class Program
	{
		static void Main(string[] args)
		{
			// Ввод размерности массива с клавиатуры
			Console.Write("Введите размер массива: ");
			int arraySize = int.Parse(Console.ReadLine());

			// Создание массива элементов класса MyClass
			MyClass[] myArray = new MyClass[arraySize];

			// Заполнение массива произвольными значениями
			Random random = new Random();
			for (int i = 0; i < arraySize; i++)
			{
				int randomInt = random.Next(1, 101); // случайное целое число от 1 до 100
				string randomString = "String" + randomInt; // случайная строка
				myArray[i] = new MyClass(randomInt, randomString);
			}

			// Вывод значений элементов массива на консоль
			for (int i = 0; i < arraySize; i++)
			{
				Console.WriteLine($"Элемент {i}: Число = {myArray[i].Number}, Строка = {myArray[i].Text}");
			}
		}
	}

	class MyClass
	{
		// Автоматически реализуемые свойства
		public int Number { get; private set; }
		public string Text { get; private set; }

		// Конструктор, принимающий 2 параметра (целочисленный и строковый)
		public MyClass(int number, string text)
		{
			Number = number;
			Text = text;
		}
	}
}