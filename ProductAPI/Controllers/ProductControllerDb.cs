using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductControllerDb : ControllerBase
    {
        private readonly Database _context;

        public ProductControllerDb(Database context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<Product>> GetId(string id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return BadRequest("Produto não encontrado!");
            return Ok(product);
        }

        [HttpGet("search/{nome}")]
        public async Task<ActionResult<Product>> GetName(string nome)
        {
            var product = await _context.Products.FindAsync(nome);
            if (product == null)
                return BadRequest("Produto não encontrado!");
            return Ok(product);
        }


        [HttpGet("filter/{filterNum?}")]
        public async Task<ActionResult<Product>> GetFilter(int filterNum)
        {
            var product = await _context.Products.ToListAsync();

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

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddHeroes(Product product)
        {
            if (product.Valor < 0)
            {
                return BadRequest("Valor não pode ser negativo!");
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product request)
        {
            var productDb = await _context.Products.FindAsync(request.Id);
            if (productDb == null)
                return BadRequest("Produto não encontrado!");

            productDb.Nome = request.Nome;
            productDb.Valor = request.Valor;
            productDb.Estoque = request.Estoque;

            await _context.SaveChangesAsync();

            return Ok(productDb);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return BadRequest("Produto não encontrado!");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
        }


    }
}
