using Application;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services
	//.AddApplicationLayer(builder.Configuration)
	.AddEndpointsApiExplorer()
	.AddSwaggerGen()
	.AddApplicationLayer(builder.Configuration)
	.AddDbContext<DatabaseContext>(options =>
	{
		options.UseSqlite(builder.Configuration.GetConnectionString("DB"));
	});

WebApplication app = builder.Build();

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
