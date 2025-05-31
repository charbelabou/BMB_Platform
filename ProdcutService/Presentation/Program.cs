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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Create a new product
app.MapPost("/products", async (IMediator mediator, AddProductCommand command) =>
{
    var newId = await mediator.Send(command);
    return Results.Created($"/products/{newId}", new { Id = newId });
});

// Get all products
app.MapGet("/products", async (IMediator mediator) =>
{
    var products = await mediator.Send(new GetAllProductsQuery());
    return Results.Ok(products);
});

// Get a specific product by ID
app.MapGet("/products/{id:int}", async (int id, IMediator mediator) =>
{
    var product = await mediator.Send(new GetProductByIdQuery { Id = id });
    return Results.Ok(product);
});

// Update an existing product
app.MapPut("/products/{id:int}", async (int id, IMediator mediator, UpdateProductRequestDto updatedDto) =>
{
    // Map DTO to command
    var command = new UpdateProductCommand
    {
        Id = id,
        Name = updatedDto.Name,
        Price = updatedDto.Price
    };

    await mediator.Send(command);
    return Results.NoContent();
});

// Delete a product
app.MapDelete("/products/{id:int}", async (int id, IMediator mediator) =>
{
    await mediator.Send(new DeleteProductCommand { Id = id });
    return Results.NoContent();
});
app.Run();

