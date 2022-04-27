using API1.Models;
using System.Threading.Tasks;

namespace API1.Repository.AdminCategoryRepository
{
    public interface IAdminCategoryRepository : IAdminRepository
    {
        Task<bool> CreateCategoryAcync(string nameCategory);
        Task<bool> RemoveCategoryByIdAcync(int id);
    }
}
