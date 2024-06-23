using System;
using System.Threading;

namespace opExamen
{

	class Program
	{
		private static AutoResetEvent enterPressed = new AutoResetEvent(false);
		static void Main(string[] args)
		{
			ThreadPool.QueueUserWorkItem(new WaitCallback(RunInfiniteLoop));

			Console.WriteLine("Press Enter to trigger the message. Press 'q' and Enter to quit.");

			while (true)
			{
				string input = Console.ReadLine();
			
				if (input.ToLower() == "q")
				{
					break;

				}

				enterPressed.Set();
			}
		}

		static void RunInfiniteLoop(object state)
		{
			while (true)
			{
				enterPressed.WaitOne();

				Console.WriteLine("Enter key pressed. Message displayed.");
			}
		}
	}
}