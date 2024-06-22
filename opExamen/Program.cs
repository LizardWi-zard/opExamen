namespace opExamen
{
	class Program
	{
		static void Main(string[] args)
		{
			MySecondClass derivedObject = new MySecondClass();

			derivedObject.VirtualMethod();
			derivedObject.AbstractMethod();
		}
	}

	abstract class MyClass
	{
		public virtual void VirtualMethod()
		{
			Console.WriteLine("Виртуальный метод базового класса");
		}

		public abstract void AbstractMethod();
	}

	class MySecondClass : MyClass
	{
		public override void VirtualMethod()
		{
			Console.WriteLine("Переопределенный виртуальный метод класса наследника");
		}

		public override void AbstractMethod()
		{
			Console.WriteLine("Реализованный абстрактный метод класса наследника");
		}
	}
}