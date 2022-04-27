using API1.Models;
using API1.Repository.AdminCategoryRepository;
using API1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API1.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("admin/categories")]
    [ApiController]
    public class AdminCategoriesController : ControllerBase
    {
        private readonly IAdminCategoryRepository _adminVideoCartRepository;
        public AdminCategoriesController(IAdminCategoryRepository adminVideoCartRepository)
        {
            _adminVideoCartRepository = adminVideoCartRepository;
        }
        // POST: /VideoCarts/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateNewVideoCartAcync(CreateCategoryViewModel model)
        {
            var isSucces = await _adminVideoCartRepository.CreateCategoryAcync(model.Name);
            if (isSucces)
                return NoContent();

            return BadRequest(new{ error = "This category has already exist" });
        }

        // DELETE: /VideoCarts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoCartAcync(/*[FromBody] */int id)
        {
            var isRemove = await _adminVideoCartRepository.RemoveCategoryByIdAcync(id);
            if (!isRemove)
                return NotFound();
            
            return NoContent();
        }
    }
}
