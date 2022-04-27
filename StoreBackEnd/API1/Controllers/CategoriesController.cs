using API1.Repository.CategoryRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[FormatFilter]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategoriesAcync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            if(categories == null)
                return NoContent();

            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryAcync(int id)
        {
            var videoCarts = await _categoryRepository.GetCategoryByIdAsync(id);
            if (videoCarts == null)
                return BadRequest();

            return Ok(videoCarts);
        }
        [HttpGet]
        [Route("count")]
        public IActionResult GetCategoryCountAcync(int id)
        {
            var categoryCount = _categoryRepository.GetCountVideoCartByCategoryAsync(id);
            var obCount = new
            {
                Count = categoryCount,
            };

            return Ok(obCount);
        }
    }
}
