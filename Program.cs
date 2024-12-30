using Application;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Initialize SQLite provider
Batteries.Init();

builder.Services.AddControllers();
builder.Services
	.AddEndpointsApiExplorer()
	.AddSwaggerGen()
	.AddApplicationLayer(builder.Configuration)
	.AddDbContext<DatabaseContext>(options =>
	{
		options.UseSqlite(builder.Configuration.GetConnectionString("DB"));
	});

WebApplication app = builder.Build();

// Apply pending migrations
using (IServiceScope scope = app.Services.CreateScope())
{
	DatabaseContext dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
	dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
