using Microsoft.EntityFrameworkCore;
using Productos.Models;

namespace Productos.Context
{
    public class ProductoContext : DbContext
    {
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }

        public ProductoContext(DbContextOptions<ProductoContext> options) : base(options) { }


    }
}
