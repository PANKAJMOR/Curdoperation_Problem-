using Curdoperation_Problem_.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
	
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentity<AppUser, IdentityRole>(
	opt =>
		{
			opt.Password.RequireNonAlphanumeric = false;
			opt.Password.RequiredLength = 5;
			opt.Password.RequireUppercase = true;
			opt.Password.RequireLowercase = true;

		}
	
	).AddEntityFrameworkStores<DemoContext>();
builder.Services.AddDbContextPool<DemoContext>(
	opt=> opt.UseSqlServer(builder.Configuration.GetConnectionString("Scon")));
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
