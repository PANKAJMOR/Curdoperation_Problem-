using Microsoft.EntityFrameworkCore;

namespace Curdoperation_Problem_.Models
{
	public class DemoContext:DbContext
	{
		public DemoContext(DbContextOptions<DemoContext>opt):base(opt) { }


		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }

	}
}
