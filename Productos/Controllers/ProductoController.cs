using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Productos.Context;
using Productos.Models;

namespace Productos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        ProductoContext context;

        public ProductoController(ProductoContext contexto)
        {
            context = contexto;
        }

        [HttpPost]
        public ActionResult AgregarProducto([FromBody] Producto p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                context.Productos.Add(p);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> GetProductoById(int id)
        {
            var producto = context.Productos.Find(id);
            if(producto == null)
            {
                return BadRequest();
            }
            else
            {
                return producto;
            }
        }

        [HttpGet]
        public ActionResult<List<Producto>> GetProductos()
        {
            var productos = context.Productos.ToList();
            return Ok(productos);   
        }

        [HttpDelete("{id}")]
        public ActionResult BorrarProductoById(int id)
        {
            var producto = context.Productos.Find(id);
            if(producto != null)
            {
                context.Productos.Remove(producto);
                context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
