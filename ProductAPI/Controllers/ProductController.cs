using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1,
                    Estoque = 10,
                    Nome =  "Bolsa",
                    Valor  = 15
            },
            new Product { Id = 2,
                    Estoque = 10,
                    Nome =  "Teclado",
                    Valor  = 10
            }

        };

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = products.Find(x => x.Id == id);
            if (product == null)
                return BadRequest("Produto não encontrado!");

            return Ok(product);
        }

        //[HttpGet("{nome}")]
        //public async Task<ActionResult<Product>> Get(string nome)
        //{
        //    var product = products.Find(x => x.Nome == nome);
        //    if (product == null)
        //        return BadRequest("Produto não encontrado!");

        //    return Ok(product);
        //}

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddHeroes(Product product)
        {
            //if (product.Valor < 0)
            //{
            //return ErrorEventArgs
            //}

            products.Add(product);
            return Ok(products);
        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product request)
        {
            var product = products.Find(x => x.Id == request.Id);
            if (product == null)
                return BadRequest("Produto não encontrado!");

            product.Nome = request.Nome;
            product.Valor = request.Valor;
            product.Estoque = request.Estoque;

            return Ok(products);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = products.Find(x => x.Id == id);
            if (product == null)
                return BadRequest("Produto não encontrado!");

            products.Remove(product);

            return Ok(products);
        }


    }
}