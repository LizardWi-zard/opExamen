using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace opExamen
{
	class Program
	{
		public static void Main(string[] args)
		{
			using (ShopContext db = new ShopContext())
			{
				Car student = new Car { id = 1, brand = "mersedess" };

				db.Students.Add(student);
				db.SaveChanges();
			}
		}
	}

	public class ShopContext : DbContext
	{
		public DbSet<Car> Students { get; set; }

		public ShopContext()
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=Cars;Username=postgres;Password=1928");
		}
	}

	public class Car
	{
		[Key]
		public int id { get; set; }

		public string brand { get; set; }
	}
}
