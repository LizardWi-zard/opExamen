
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace opExamen
{
	class Program
	{
		static void Main(string[] args)
		{
			using (UniversityContext db = new UniversityContext())
			{
				long time = 0;
				float average = 0;
				for (int i = 0; i < 1000; i++)
				{
					Stopwatch stopwatch = new Stopwatch();
					Random rnd = new Random();
					int curId = rnd.Next(1, 1_000_001);
					stopwatch.Start();
					Student? student = db.Students.FirstOrDefault(s => s.id == curId);
					stopwatch.Stop();
					time += stopwatch.ElapsedMilliseconds;
				}
				average = (float)time / 1000;
				Console.WriteLine($"Поиск по PK: {average}");

				time = 0;
				for (int i = 0; i < 1000; i++)
				{
					Stopwatch stopwatch = new Stopwatch();
					stopwatch.Start();
					Student? student = db.Students.FirstOrDefault(s => s.name == "Allan");
					stopwatch.Stop();
					time += stopwatch.ElapsedMilliseconds;
				}
				average = (float)time / 1000;
				Console.WriteLine($"Поиск не по PK: {average}");
			}
		}
	}

	public class UniversityContext : DbContext
	{
		public DbSet<Student> Students { get; set; }

		public UniversityContext()
		{
			Database.EnsureCreated();
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=Cars;Username=postgres;Password=1928");
		}
	}

	public class Student
	{
		[Key]
		public int id { get; set; }

		public string name { get; set; }

	}
}
