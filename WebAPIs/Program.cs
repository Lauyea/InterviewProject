using Microsoft.EntityFrameworkCore;
using WebAPIs.Data;
using WebAPIs.Models;

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

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
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

app.Run();
