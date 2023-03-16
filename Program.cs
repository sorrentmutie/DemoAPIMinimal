using DemoAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ToDoDbContext>(opzioni => opzioni.UseInMemoryDatabase("ToDolist"));
builder.Services.AddScoped<IDataService, DataService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/todoitems", async (IDataService service) => await service.GetAllAsync());
app.MapGet("/categories", async (IDataService service) => await service.GetAllCategoriesAsync());



app.MapGet("/todoitems/{id}", 
    async (int id, IDataService service) => await service.GetByIdAsync(id));

app.MapPost("/todoitems",
     async (ToDo toDo, IDataService service) =>
     { 
         var toDoDb = await service.CreateAsync(toDo);
         return Results.Created($"/todoitems/{toDo.Id}", toDoDb);
     });

app.MapPost("/categories",
     async (Category category, IDataService service) =>
     {
         var categoryDb = await service.CreateCategoryAsync(category);
         return Results.Ok(categoryDb);
     });



app.MapPut("/todoitems/{id}", async (int id, ToDo toDo, IDataService service) =>
{
    if (id != toDo.Id) return Results.BadRequest();
    var todoDb = await service.GetByIdAsync(id);
    if (todoDb == null) return Results.NotFound();
    await service.UpdateAsync(id, toDo);
    return Results.NoContent();
});





app.Run();


