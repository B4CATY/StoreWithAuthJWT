using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API1.Repository.VideoCartRepository;
using Microsoft.AspNetCore.Authorization;

namespace API1.Controllers
{
    //[Authorize]
    [ApiController]
    public class VideoCartsController : ControllerBase
    {
        private readonly IVideoCartRepository _videoCartRepository;

        public VideoCartsController(IVideoCartRepository videoCartRepository)
        {
            _videoCartRepository = videoCartRepository;
        }

        // GET: /VideoCarts/pageNum
        [HttpGet]
        [Route("[controller]/{pageNumber:int}/{pageSize?}")]
        public async Task<IActionResult> GetVideocartsAsync(int pageNumber, int pageSize = 5)
        {

            var videoCarts = (pageNumber-1) * pageSize + 1 > await _videoCartRepository.GetCountVideoCartAsync() ? null : await _videoCartRepository.GetAllVideoCartsAsync(pageNumber, pageSize);
            if(videoCarts == null)
                return NoContent();

            return Ok(videoCarts);
        }

        [HttpGet]
        [Route("videocart/{id}")]
        public async Task<IActionResult> GetVideocartAsync(int id)
        {

            var videoCart = await _videoCartRepository.GetVideoCartByIdAcync(id); 
            if (videoCart == null)
                return NoContent();

            return Ok(videoCart);
        }

        //[Authorize(Roles = "admin")]
        // GET: /VideoCarts/5
        [HttpGet]
        [Route("[controller]/count")]
        public async Task<IActionResult> GetCountVideoCartAsync()
        {
            var videoCart = await _videoCartRepository.GetCountVideoCartAsync();
             var obCount = new
             {
                 Count = videoCart,
             };
            return Ok(obCount);
        }
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllVideocartsAsync()
        {

            var videoCarts = await _videoCartRepository.GetListVideoCartsAsync();
            if (videoCarts == null)
                return NoContent();

            return Ok(videoCarts);
        }




    }
}
