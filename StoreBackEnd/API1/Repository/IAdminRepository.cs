using API1.Models;
using System.Threading.Tasks;

namespace API1.Repository
{
    public interface IAdminRepository
    {
        Task<Category> GetCategoryByNameAsync(string name);
        Task<int> SaveChangesAsync();
    }
}
