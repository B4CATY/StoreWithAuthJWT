using API1.Data;
using API1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Repository.AdminCategoryRepository
{
    public class AdminCategoryRepository : IAdminCategoryRepository
    {
        private readonly StoreDbContext _context;
        public AdminCategoryRepository(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateCategoryAcync(string nameCategory)
        {
            if(nameCategory == null) return false;

            var categoryCheck = await GetCategoryByNameAsync(nameCategory);
            if (categoryCheck == null)
            {
                Category category = new Category { Name = nameCategory };

                _context.Categories.Add(category);
                await SaveChangesAsync();
                return true;
            }
            return false;
        }

        

        public async Task<bool> RemoveCategoryByIdAcync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null) 
                return false;

            _context.Categories.Remove(category);
            await SaveChangesAsync();
            return true;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task<Category> GetCategoryByNameAsync(string name)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Name == name);
            return category;
        }
    }
}
