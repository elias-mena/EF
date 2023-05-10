using Microsoft.EntityFrameworkCore;
using EF;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//  Conexion a base de datos en memoria
// builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));

// Conexion a SQL Server
builder.Services.AddSqlServer<TareasContext>("Data Source=localhost;Initial Catalog=TareasDB; user id=sa; password=123; Integrated Security=True;");


var app = builder.Build();

// Verificar que la base de datos se haya creado
app.MapGet("/dbconection", async ([FromServices] TareasContext db) => 
{
    await db.Database.EnsureCreatedAsync();
    return Results.Ok( "Base de datos creada" + db.Database.IsInMemory() );
});


app.MapGet("/categorias", async (TareasContext db) => await db.Categorias.ToListAsync());

//app.MapGet("/tareas", async (TareasContext db) => await db.Tareas.ToListAsync());

app.Run();
