using Microsoft.EntityFrameworkCore;
using VueApp.Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var services = builder.Services;

services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ConnectionStrings"),
        o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));

    // Use it when you need to analyze EF Core performance
    //options.EnableSensitiveDataLogging();
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;

    var context = service.GetRequiredService<DatabaseContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
