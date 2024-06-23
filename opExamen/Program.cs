using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace opExamen
{
	class Program
	{
		static void Main(string[] args)
		{
			using (UniversityContext db = new UniversityContext())
			{
				University university = db.Universities.Find(1);

				Student student = new Student() { name = "Daniel", university = university };
				db.Students.Add(student);
				var students = db.Students.ToList();

				Console.WriteLine(university.name + " " + university.students.FirstOrDefault().name);
			}

		}
	}

	public class UniversityContext : DbContext
	{
		public DbSet<Student> Students { get; set; }
		public DbSet<University> Universities { get; set; }

		public UniversityContext()
		{
			Database.EnsureCreated();
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=Example;Username=postgres;Password=1928");
			optionsBuilder.UseLazyLoadingProxies();
		}
	}

	public class Student
	{
		[Key]
		public int id { get; set; }

		public string name { get; set; }

		public virtual University university { get; set; }
	}

	public class University
	{
		[Key]
		public int id { get; set; }

		public string name { get; set; }

		public virtual List<Student> students { get; set; }
	}
}
