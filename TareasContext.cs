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

        public TareasContext(DbContextOptions<TareasContext> options) :base(options) { }

        // El método OnModelCreating es el que se encarga de crear el modelo de la base de datos.
        // Aquí se pueden agregar configuraciones adicionales para el modelo de la base de datos.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(categoria=>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(c=>c.CategoriaId);
                categoria.Property(c=>c.Nombre).HasMaxLength(150).IsRequired();
                categoria.Property(c=>c.Descripcion).HasMaxLength(500);

            });

            modelBuilder.Entity<Tarea>(tarea=>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(t=>t.TareaId);
                tarea.HasOne(t=>t.Categoria).WithMany(c=>c.Tareas).HasForeignKey(t=>t.CategoriaId);
                tarea.Property(t=>t.Titulo).HasMaxLength(150).IsRequired();
                tarea.Property(t=>t.Descripcion).HasMaxLength(500);
                tarea.Property(t=>t.PrioridadTarea).IsRequired();
                tarea.Property(t=>t.FechaCreacion).IsRequired();
            });
        }
    }
}