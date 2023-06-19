using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Posts.Models;
using Posts.Models.ViewModels;
using Posts.Repository;
using Posts.Services.Logging;
using Posts.Services.Mapping;

namespace Posts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IRepository<Post> _repository;
        private readonly ILoggerService _logger;
        private readonly IMemoryCache _cache;
        public PostsController(IRepository<Post> repository, ILoggerService logger, IMemoryCache cache)
        {
            _cache = cache;
            _logger = logger;
            _repository = repository;
        }
        /// <summary>
        /// Возвращает все записи.
        /// </summary>
        /// <returns>Все записи.</returns>
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
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Возвращает запись с Id.
        /// </summary>
        /// <param name="guid">Id записи.</param>
        /// <returns>Запись.</returns>
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
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Создаёт запись в базе данных.
        /// </summary>
        /// <param name="postViewModel">Модель для ввода данных.</param>
        /// <returns>Результат выполнения.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostViewModel postViewModel)
        {
            if (ModelState.IsValid)
            {
                Post newPost = PostMapping.PostMapper(postViewModel);
                try
                {
                    await _repository.Create(newPost);
                    _logger.LogInfo($"{postViewModel.Title} was created.");
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }
            return BadRequest();
        }
        /// <summary>
        /// Обновляет данные записи.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="postViewModel"></param>
        /// <returns>Результат выполнения.</returns>
        [HttpPatch]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] PostViewModel postViewModel)
        {
            if (ModelState.IsValid)
            {
                Post post = PostMapping.PostMapper(postViewModel);
                post.Id = id;
                try
                {
                    await _repository.Update(post);
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }
            return BadRequest();
        }
        /// <summary>
        /// Удаляет запись
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            try
            {
                await _repository.Delete(id);
                _logger.LogInfo($"The Post with id - {id} was deleted.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}