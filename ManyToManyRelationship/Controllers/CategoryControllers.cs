using ManyToManyRelationship.Models;
using ManyToManyRelationship.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManyToManyRelationship.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryControllers : Controller
    {
        private readonly MyDbContext dbContext;

        public CategoryControllers(MyDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await dbContext.Categories.Select(s => new {
                CategoryName = s.CategoryName,
                Description = s.Description,
                CategoryId=s.CategoryId,
                Products = dbContext.Products.Where(i => i.Categories.Any(l => l.CategoryId == s.CategoryId)).ToList()
            }
           ).ToListAsync();
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryView category)
        {
            var products = new List<Product>();
            if (category.ProductIds.Any())
            {
                products = dbContext.Products.Where(i => category.ProductIds.Contains(i.ProductId)).ToList();
            }
            var newCategory = new Category()
            {
                CategoryName = category.CategoryName,
                Description = category.Description,
                Products = products
            };
      
            await dbContext.Categories.AddAsync(newCategory);
            await dbContext.SaveChangesAsync();
            return Ok(category);

        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] Guid id, CategoryView category)
        {
            var newCategory = dbContext.Categories.Find(id);
            if (newCategory != null)
            {
                var products = new List<Product>();
                if (category.ProductIds.Any())
                {
                    products = dbContext.Products.Where(i => category.ProductIds.Contains(i.ProductId)).ToList();
                }
                newCategory.CategoryName = category.CategoryName;
                newCategory.Description = category.Description;
                newCategory.Products = products;

                await dbContext.SaveChangesAsync();
                return Ok(category);
            }
            return NotFound();

        }
    }
}