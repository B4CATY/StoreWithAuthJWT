using API1.Models;
using API1.ViewModels;
using System.Threading.Tasks;

namespace API1.Repository.AdminVideoCartRepository
{
    public interface IAdminVideoCartRepository : IAdminRepository
    {
        Task<bool> RemoveVideocartCartAcync(int id);
        Task<bool> CreateVideoCartAcync(CreateVideocartViewModel videoCart);
    }
}
