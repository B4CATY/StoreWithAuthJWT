using API1.Data;
using API1.Models;
using API1.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Repository.VideoCartRepository
{
    public class VideoCartRepository : IVideoCartRepository
    {
        private readonly StoreDbContext _context;
        public VideoCartRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<VideoCartViewModel>> GetAllVideoCartsAsync(int pageNumber, int pageSize)
        {
            pageNumber--;
            var videoCarts = await _context.Videocarts
               .Where(x => x.Id > pageNumber * pageSize && x.Id <= pageNumber * pageSize + pageSize)
               .Join
               (_context.Categories,
               v => v.Categoryid,
               c => c.Id,
               (v, c) => new VideoCartViewModel
               {
                   Id = v.Id,
                   Name = v.NameProduct,
                   Price = v.Price,
                   Category = c.Name,
                   Img = v.Img,
               })
               .ToListAsync();
            return videoCarts;
        }

        public async Task<int> GetCountVideoCartAsync()
        {
            var videoCart = await _context.Videocarts.CountAsync();
            return videoCart;
        }

        public async Task<List<GetVideocartBaseInfoViewModel>> GetListVideoCartsAsync()
        {
            var videocarts = await _context.Videocarts.Select(x => new GetVideocartBaseInfoViewModel { Id = x.Id, Name = x.NameProduct }).ToListAsync();
            return videocarts;
        }

        public async Task<VideoCartViewModel> GetVideoCartByIdAcync(int id)
        {
            var videoCart = await _context.Videocarts
              .Where(x => x.Id == id)
              .Join
              (_context.Categories,
              v => v.Categoryid,
              c => c.Id,
              (v, c) => new VideoCartViewModel
              {
                  Id = v.Id,
                  Name = v.NameProduct,
                  Price = v.Price,
                  Category = c.Name,
                  Img = v.Img,
              })
              .FirstOrDefaultAsync();

            return videoCart;
        }

    }
}
