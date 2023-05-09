using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models
{
[Table("Tareas")]
public class Tarea
{
    [Key]
    public Guid TareaId {get;set;}

    [ForeignKey("CategoriaId")]
    public Guid CategoriaId {get;set;} // Foreign Key

    [Required]
    [MaxLength(200)]
    public string Titulo {get;set;}

    public string Descripcion {get;set;}

    public Prioridad PrioridadTarea {get;set;}

    public DateTime FechaCreacion {get;set;}
    
    public virtual Categoria Categoria {get;set;}

    [NotMapped] // No se va a mapear en la base de datos
    public string Resumen {get;set;}

    
}

public enum Prioridad
{
    Baja,
    Media,
    Alta
}
}