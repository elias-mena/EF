using Microsoft.EntityFrameworkCore;
using EF;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconection", async ([FromServices] TareasContext db) => 
{
    //await db.Database.EnsureCreatedAsync();
    db.Database.EnsureCreated();
    return Results.Ok( "Base de datos creada" + db.Database.IsInMemory() );
});


app.MapGet("/categorias", async (TareasContext db) => await db.Categorias.ToListAsync());

//app.MapGet("/tareas", async (TareasContext db) => await db.Tareas.ToListAsync());

app.Run();
