using Microsoft.EntityFrameworkCore;
using EF.Models;

namespace EF
{
    // El contexto es donde van a ir todas las relaciones de los modelos que nosotros tenemos para poder transformarlo en 
    // colecciones que van a representarse dentro de la base de datos.
    public class TareasContext: DbContext
    {
        // El DbSet es una colección de datos que va a representar una tabla dentro de la base de datos.
        public DbSet<Categoria> Categorias {get;set;}
        public DbSet<Tarea> Tareas {get;set;}


    }
}