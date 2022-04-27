using API1.Data;
using API1.Models;
using API1.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Repository.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _context;
        public CategoryRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }
       
        public async Task<List<VideoCartViewModel>> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Categories
                .Where(c => c.Id == id)
                .Join(
                _context.Videocarts,
                c => c.Id,
                v=> v.Categoryid,
                (c, v) => new VideoCartViewModel
                {
                    Id = v.Id,
                    Name = v.NameProduct,
                    Price = v.Price,
                    Category = c.Name,
                    Img = v.Img,
                })
               .ToListAsync();
            return category;
        }

        public int GetCountVideoCartByCategoryAsync(int id)
        {
            var categoryCount = _context.Videocarts.Where(c => c.Categoryid == id).Count();
            return categoryCount;
        }
    }
}
