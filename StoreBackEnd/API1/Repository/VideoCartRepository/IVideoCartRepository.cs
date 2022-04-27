using API1.Models;
using API1.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API1.Repository.VideoCartRepository
{
    public interface IVideoCartRepository
    {
        Task<int> GetCountVideoCartAsync();
        Task<List<VideoCartViewModel>> GetAllVideoCartsAsync(int pageNumber, int pageSize);
        Task<List<GetVideocartBaseInfoViewModel>> GetListVideoCartsAsync();
        Task<VideoCartViewModel> GetVideoCartByIdAcync(int id);

    }
}
