using Microsoft.AspNetCore.Mvc;
using Posts.Models;
using Posts.Repository;

namespace Posts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IRepository<Post> _repository;
        public PostsController(IRepository<Post> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Возвращает все записи.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var posts = await _repository.GetAll();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Возвращает запись с Id.
        /// </summary>
        /// <param name="guid">Id записи.</param>
        /// <returns></returns>
        [HttpGet("{guid}")]
        public async Task<IActionResult> GetById(Guid guid)
        {
            try
            {
                var post = await _repository.GetById(guid);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}