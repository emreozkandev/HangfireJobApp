using Hangfire;

var builder = WebApplication.CreateBuilder(args);


// ✅SQL bağlantısı
var connectionString = builder.Configuration.GetConnectionString("HangfireConnection");

// ✅Hangfire konfigürasyonu
builder.Services.AddHangfire(config =>
    config.UseSqlServerStorage(connectionString));

builder.Services.AddHangfireServer();


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// ✅Hangfire dashboard
app.UseHangfireDashboard();

// ✅Örnek: Her dakika çalışan job 1
RecurringJob.AddOrUpdate<MyFirstJob>(
    "my-sql-job",
    job => job.Execute("Job 1"),
    Cron.Minutely);

// ✅Örnek: Her dakika çalışan job 2
RecurringJob.AddOrUpdate<MySecondJob>(
    "my-sql-job-2",
    job => job.Execute("Job 2"),
        "*/2 * * * *");

// ✅Örnek: Her dakika çalışan job 3
RecurringJob.AddOrUpdate<MyThirdJob>(
    "my-sql-job-3",
    job => job.Execute1("Job 3.1"),
    "*/3 * * * *");

// ✅Örnek: Her dakika çalışan job 4
RecurringJob.AddOrUpdate<MyThirdJob>(
    "my-sql-job-3",
    job => job.Execute2("Job 3.2"),
    "*/4 * * * *");

app.MapGet("/", () => "Hangfire .NET 8 projesi çalışıyor!");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}


public class MyFirstJob
{
    public void Execute(string msg)
    {
        // Job içeriği buraya gelecek
        Console.WriteLine("1. Job çalıştı: " + DateTime.Now);
    }
}

public class MySecondJob
{
    public void Execute(string msg)
    {
        // Job içeriği buraya gelecek
        Console.WriteLine("2. Job çalıştı: " + DateTime.Now);
    }
}

public class MyThirdJob
{
    public void Execute1(string msg)
    {
        // Job içeriği buraya gelecek
        Console.WriteLine("3.1. Job çalıştı: " + DateTime.Now);
    }

    public void Execute2(string msg)
    {
        // Job içeriği buraya gelecek
        Console.WriteLine("3.2. Job çalıştı: " + DateTime.Now);
    }
}