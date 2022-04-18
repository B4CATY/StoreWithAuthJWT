using API1.Models;
using API1.Repository.AdminCategoryRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API1.Controllers
{
    [Route("admin/categorise")]
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
        public async Task<IActionResult> CreateNewVideoCart(string name)
        {
            var isSucces = await _adminVideoCartRepository.AddCategory(name);
            if (isSucces)
                return Ok();

            return BadRequest();
        }

        // DELETE: /VideoCarts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoCart([FromBody] int id)
        {
            var isRemove = await _adminVideoCartRepository.RemoveCategoryById(id);
            if (!isRemove)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
