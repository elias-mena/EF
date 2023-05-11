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


app.MapGet("/api/tareas", ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas.Include(p => p.Categoria).Where(p => p.PrioridadTarea == EF.Models.Prioridad.Baja));
});

app.Run();
