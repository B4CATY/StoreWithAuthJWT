using API1.Models;
using System.Threading.Tasks;

namespace API1.Repository
{
    public interface IAdminRepository
    {
        Category GetCategoryByName(string name);
        Task<int> SaveChanges();
    }
}
