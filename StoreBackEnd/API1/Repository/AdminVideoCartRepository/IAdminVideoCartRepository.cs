using API1.Models;
using API1.ViewModels;
using System.Threading.Tasks;

namespace API1.Repository.AdminVideoCartRepository
{
    public interface IAdminVideoCartRepository : IAdminRepository
    {
        Task<bool> RemoveVideocartCart(int id);
        Task<bool> AddVideoCart(VideoCartViewModel videoCart);
        Task<bool> UpdateVideoCart(VideoCartViewModel videoCart);
    }
}
