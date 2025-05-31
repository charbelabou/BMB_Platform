using Application.DTO.Request;
using Application.Product.Command.Add;
using Application.Product.Command.Delete;
using Application.Product.Command.Update;
using Application.Product.Query.Get;
using Application.Product.Query.GetAll;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductDbContext>(option => option.UseNpgsql( Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddProductCommandHandler).Assembly));
builder.Services.AddHealthChecks();
builder.Services.AddHealthChecks()
    .AddNpgSql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")!);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var productsGroup = app.MapGroup("/products").WithTags("Products");
// Create
productsGroup.MapPost("/", async (IMediator mediator, AddProductCommand command) =>
{
    var newId = await mediator.Send(command);
    return Results.Created($"/products/{newId}", new { Id = newId });
});

// Get all
productsGroup.MapGet("/", async (IMediator mediator) =>
{
    var products = await mediator.Send(new GetAllProductsQuery());
    return Results.Ok(products);
});

// Get by ID
productsGroup.MapGet("/{id:int}", async (int id, IMediator mediator) =>
{
    var product = await mediator.Send(new GetProductByIdQuery { Id = id });
    return Results.Ok(product);
});

// Update
productsGroup.MapPut("/{id:int}", async (int id, IMediator mediator, UpdateProductRequestDto updatedDto) =>
{
    var command = new UpdateProductCommand
    {
        Id = id,
        Name = updatedDto.Name,
        Price = updatedDto.Price
    };

    await mediator.Send(command);
    return Results.NoContent();
});

// Delete
productsGroup.MapDelete("/{id:int}", async (int id, IMediator mediator) =>
{
    await mediator.Send(new DeleteProductCommand { Id = id });
    return Results.NoContent();
});

app.MapHealthChecks("/health");
app.Run();

