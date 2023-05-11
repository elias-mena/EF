using Microsoft.EntityFrameworkCore;
using EF;
using Microsoft.AspNetCore.Mvc;
using EF.Models;

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

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea)=>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.AddAsync(tarea);
    //await dbContext.Tareas.AddAsync(tarea);

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});