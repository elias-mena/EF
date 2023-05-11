using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EF.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public Guid CategoriaId {get;set;}
        [Required]
        [MaxLength(150)]
        public string Nombre {get;set;}
        public string Descripcion {get;set;}
        [JsonIgnore]
        public virtual ICollection<Tarea> Tareas {get;set;}
    }
}