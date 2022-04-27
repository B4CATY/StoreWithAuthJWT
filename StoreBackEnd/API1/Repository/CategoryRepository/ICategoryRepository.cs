using API1.Models;
using API1.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API1.Repository.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<VideoCartViewModel>> GetCategoryByIdAsync(int id);
        int GetCountVideoCartByCategoryAsync(int id);
        Task<List<Category>> GetAllCategoriesAsync();
    }
}
