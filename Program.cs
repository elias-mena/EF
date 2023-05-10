using Microsoft.EntityFrameworkCore;
using EF;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Conexion a Postgres
builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("PostgresConnection"));

var app = builder.Build();

// Verificar que la base de datos se haya creado
app.MapGet("/dbconection", async ([FromServices] TareasContext db) => 
{
    await db.Database.EnsureCreatedAsync();
    return Results.Ok( "Base de datos creada");
});


app.MapGet("/categorias", async (TareasContext db) => await db.Categorias.ToListAsync());

//app.MapGet("/tareas", async (TareasContext db) => await db.Tareas.ToListAsync());

app.Run();
