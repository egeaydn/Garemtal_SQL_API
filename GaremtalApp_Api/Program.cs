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

// Seeder'ı burada çağır
try
{
	using (var scope = app.Services.CreateScope())
	{
		var context = scope.ServiceProvider.GetRequiredService<SchoolDBcontext>();
		Console.WriteLine("Veritabanı bağlantısı kuruluyor...");
		context.Database.EnsureCreated();
		Console.WriteLine("Veritabanı oluşturuldu/bağlandı.");

		Console.WriteLine("Öğrenci verileri ekleniyor...");
		StudentSeeder.Seed(context);
		Console.WriteLine("Öğrenci verileri eklendi.");

		Console.WriteLine("Öğretmen verileri ekleniyor...");
		TeacherSeeder.Seed(context);
		Console.WriteLine("Öğretmen verileri eklendi.");
	}
}
catch (Exception ex)
{
	Console.WriteLine($"Hata oluştu: {ex.Message}");
	Console.WriteLine($"Stack Trace: {ex.StackTrace}");
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

Console.WriteLine("Uygulama başlatıldı. Swagger için /swagger adresini ziyaret edin.");
Console.WriteLine("HTTP: http://localhost:5236");
Console.WriteLine("HTTPS: https://localhost:7167");

app.Run();
