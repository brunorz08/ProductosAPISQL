using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Productos.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Precio { get; set; }
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]      
        public Categoria? Categoria { get; set; }
        
    }
}
