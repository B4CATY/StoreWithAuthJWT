using API1.Data;
using API1.Models;
using API1.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Repository.AdminVideoCartRepository
{
    public class AdminVideoCartRepository : IAdminVideoCartRepository
    {
        private readonly StoreDbContext _context;
        public AdminVideoCartRepository(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<bool> RemoveVideocartCartAcync(int id)
        {
            var videoCart = await _context.Videocarts.FirstOrDefaultAsync(x=>x.Id == id);
            if (videoCart != null)
            {
                _context.Videocarts.Remove(videoCart);
                await SaveChangesAsync();
                
                return true;
            }
            return false;

        }

        public async Task<bool> CreateVideoCartAcync(CreateVideocartViewModel videoCart)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x=> x.Id == videoCart.CategoryId);
            if (category != null)
            {
                var videoCartDb = await _context.Videocarts.FirstOrDefaultAsync(x => x.NameProduct == videoCart.Name);
                if (videoCartDb == null)
                {
                    VideoCart newVideoCartDb = new VideoCart
                    {
                        NameProduct = videoCart.Name,
                        Price = videoCart.Price,
                        Category = category,
                        Img = videoCart.Img,
                    };

                    _context.Videocarts.Add(newVideoCartDb);
                    await SaveChangesAsync();
                    return true;
                }
            }
            return false;

        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task<Category> GetCategoryByNameAsync(string name)
        {
            return await _context.Categories.FirstOrDefaultAsync(context => context.Name == name);
        }

        
    }
}
