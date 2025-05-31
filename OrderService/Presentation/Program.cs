using Microsoft.EntityFrameworkCore;
using Persistance;
using Serilog;
using Serilog.Formatting.Compact;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .Enrich.WithEnvironmentName()
    .WriteTo.Console(new RenderedCompactJsonFormatter()) 
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OrderDbContext>(option => option.UseNpgsql( Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")));

// builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddProductCommandHandler).Assembly));
builder.Services.AddHealthChecks();
builder.Services.AddHealthChecks()
    .AddNpgSql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")!);

var app = builder.Build();

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