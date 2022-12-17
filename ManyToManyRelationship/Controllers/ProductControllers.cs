using ManyToManyRelationship.Models;
using ManyToManyRelationship.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManyToManyRelationship.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductControllers : Controller
    {
        private readonly MyDbContext dbContext;

        public ProductControllers(MyDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await dbContext.Products.Select(s => new{
                    ProductName = s.ProductName,
                    Description = s.Description,
                    ProductId = s.ProductId,
                    Categories = dbContext.Categories.Where(i => i.Products.Any(l => l.ProductId == s.ProductId)).ToList()
                }
            ).ToListAsync();
            return Ok(list);
        }
        [HttpGet]
        [Route("GetWithPairs")]
        public async Task<IActionResult> GetWithPairs()
        {
            var response = new List<string>();
            await dbContext.Products.Select(s => new {
                ProductName = s.ProductName,
                Categories = dbContext.Categories.Where(i => i.Products.Any(l => l.ProductId == s.ProductId)).ToList()
            }
            ).ForEachAsync(s =>
            {
                if (s.Categories.Count>0)
                {
                    s.Categories.ForEach(l => {
                        response.Add($"«{s.ProductName} – {l.CategoryName}»");
                        });
                }
                else
                {
                    response.Add($"«{s.ProductName}»");
                }
            }
            );
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductView product)
        {
            if(product != null)
            {
                var categories = new List<Category>();
                if (product.CategoryIds.Any())
                {
                    categories = dbContext.Categories.Where(i => product.CategoryIds.Contains(i.CategoryId)).ToList();
                }
                var newProduct = new Product()
                {
                    ProductName = product.ProductName,
                    Description = product.Description,
                    Categories = categories
                };
                await dbContext.Products.AddAsync(newProduct);
                await dbContext.SaveChangesAsync();
                return Ok(product);
            }
            return BadRequest();

        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateProduct([FromRoute]Guid id,ProductView product)
        {
            var newProduct = dbContext.Products.Find(id);          
            if (newProduct != null)
            {
                var categories = new List<Category>();
                if (product.CategoryIds.Any())
                {
                    categories = dbContext.Categories.Where(i => product.CategoryIds.Contains(i.CategoryId)).ToList();
                }
                newProduct.ProductName = product.ProductName;
                newProduct.Description = product.Description;
                newProduct.Categories = categories;

                await dbContext.SaveChangesAsync();
                return Ok(product);
            }
            return NotFound();

        }
    }
}