using GaremtalApp_Api.DataContext;
using GaremtalApp_Api.Seeder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

builder.Services.AddDbContext<SchoolDBcontext>(options =>
	options.UseSqlServer(
		builder.Configuration.GetConnectionString("DefaultConnection"),
		sqlOptions => sqlOptions.EnableRetryOnFailure(
			maxRetryCount: 5,
			maxRetryDelay: TimeSpan.FromSeconds(10),
			errorNumbersToAdd: null
		)
	)
);

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(
		builder =>
		{
			builder.AllowAnyOrigin()
				   .AllowAnyHeader()
				   .AllowAnyMethod();
		});
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seeder’ý burada çaðýr
using (var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<SchoolDBcontext>();
	context.Database.EnsureCreated();

	StudentSeeder.Seed(context);
	TeacherSeeder.Seed(context);
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

Console.WriteLine("Uygulama baþlatýldý. Swagger için /swagger adresini ziyaret edin.");
