using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Curdoperation_Problem_.Models
{
	public class DemoContext:IdentityDbContext<AppUser>//DbContext
	{
		public DemoContext(DbContextOptions<DemoContext>opt):base(opt) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }

	}
}
