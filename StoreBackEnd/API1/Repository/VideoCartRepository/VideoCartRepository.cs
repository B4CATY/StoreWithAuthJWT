using API1.Data;
using API1.Models;
using API1.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Repository.VideoCartRepository
{
    public class VideoCartRepository : IVideoCartRepository
    {
        private readonly VideoCardDbContext _context;
        public VideoCartRepository(VideoCardDbContext context)
        {
            _context = context;
        }

        public async Task<List<VideoCart>> GetAllVideoCarts()
        {
            var carts = await _context.Videocarts.ToListAsync();
            return carts;
        }

        public VideoCartViewModel GetVideoCart(int id)
        {
            var videoCart = _context.Videocarts
                .Join
                (_context.Categories, 
                v=>v.Categoryid, 
                c=>c.Id, 
                (v,c) => new VideoCartViewModel
                    {
                        Id = v.Id,
                        Name = v.NameProduct,
                        Price = v.Price,
                        Category = c.Name
                    })
                .Where(x => x.Id == id).FirstOrDefault();
            return videoCart;
        }
    }
}
