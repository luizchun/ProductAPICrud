using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static int _orderfilter;
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1,
                    Estoque = 10,
                    Nome =  "Teclado",
                    Valor  = 15
            },
            new Product { Id = 2,
                    Estoque = 10,
                    Nome =  "Mouse",
                    Valor  = 10
            },
            new Product { Id = 3,
                    Estoque = 10,
                    Nome =  "Fone de Ouvido",
                    Valor  = 10
            },
            new Product { Id = 4,
                    Estoque = 10,
                    Nome =  "Hd Sata",
                    Valor  = 10
            },
            new Product { Id = 5,
                    Estoque = 10,
                    Nome =  "Ssd",
                    Valor  = 10
            }

        };

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(products);
        }


        [HttpGet("id/{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = products.Find(x => x.Id == id);
            if (product == null)
                return BadRequest("Produto não encontrado!");

            return Ok(product);
        }


        [HttpGet("filter/{filterNum?}")]
        public async Task<ActionResult<Product>> GetFilter(int filterNum) 
        {
            var product = products;

            switch (filterNum)
            {
                case 1:
                    product = product.OrderBy(x => x.Id.ToString()).ToList();
                    break;
                case 2:
                    product = product.OrderBy(x => x.Nome.ToString()).ToList();
                    break;
                case 3:
                    product = product.OrderBy(x => x.Estoque.ToString()).ToList();
                    break;
                case 4:
                    product = product.OrderBy(x => x.Valor.ToString()).ToList();
                    break;

            }

            if (product == null)
                return BadRequest("Produto não encontrado!");

            return Ok(product);
        }

        [HttpGet("search/{nome}")]
        public async Task<ActionResult<Product>> GetName(string nome)
        {
            var product = products.Find(x => x.Nome == nome);
            if (product == null)
                return BadRequest("Produto não encontrado!");

            return Ok(product);
        }


        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddHeroes(Product product)
        {
            if (product.Valor < 0)
            {
                return BadRequest("Valor não pode ser negativo!");
            }
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

            return Ok(product);
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

        private int GetOrderFilter(int orderFilter)
        {
            return _orderfilter = orderFilter;
        }


    }
}