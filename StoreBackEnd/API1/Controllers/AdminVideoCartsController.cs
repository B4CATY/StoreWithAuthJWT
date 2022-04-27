using API1.Models;
using API1.Repository.AdminVideoCartRepository;
using API1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API1.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("admin/videocarts")]
    [ApiController]
    public class AdminVideoCartsController : ControllerBase
    {
        private readonly IAdminVideoCartRepository _adminVideoCartRepository;
        public AdminVideoCartsController(IAdminVideoCartRepository adminVideoCartRepository)
        {
            _adminVideoCartRepository = adminVideoCartRepository;
        }
        
        // POST: /VideoCarts/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateNewVideoCartAcync(CreateVideocartViewModel videoCart)
        {
            var isSucces =  await _adminVideoCartRepository.CreateVideoCartAcync(videoCart);
            if (!isSucces)
                return BadRequest();


            return NoContent();
        }

        // DELETE: /VideoCarts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoCartAcync(/*[FromBody]*/int id)
        {
            var isRemove = await _adminVideoCartRepository.RemoveVideocartCartAcync(id);
            if (!isRemove)
                return NotFound();

            return NoContent();
        }
    }
}
