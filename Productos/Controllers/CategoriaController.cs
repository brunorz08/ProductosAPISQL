using Microsoft.AspNetCore.Mvc;
using Productos.Context;
using Productos.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Productos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        ProductoContext context;
        public CategoriaController(ProductoContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public ActionResult AgregarCageoria([FromBody] Categoria c)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                context.Categorias.Add(c);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpGet]
        public ActionResult<List<Categoria>> GetCategorias()
        {
            var categorias = context.Categorias.ToList();
            return Ok(categorias);
        }

        
        [HttpGet("{id}")]
        public ActionResult<Categoria> GetCategoriaById(int id)
        {
            var categoria = context.Categorias.Find(id);
           
            return categoria;
        }

       
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var categoria = context.Categorias.Find(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            return Ok();

        }
    }
}
