using Dapper;
using Posts.Context;
using Posts.Models;

namespace Posts.Repository
{
    public class PostRepository : IRepository<Post>
    {
        private readonly DapperContext _context;
        public PostRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task Create(Post entity)
        {
            var query = "INSERT INTO Post(title, content) VALUES (@title, @content)";
            using (var cursor = _context.Connect)
            {
                var result = await cursor.ExecuteAsync(query, new { entity.Title, entity.Content });
            }
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            string query = "SELECT * FROM Post";
            using (var cursor = _context.Connect)
            {
                var posts = await cursor.QueryAsync<Post>(query);
                return posts.ToList();
            }
        }

        public async Task<Post> GetById(Guid guid)
        {
            string query = "SELECT * FROM Post WHERE Id = @guid";
            using (var cursor = _context.Connect)
            {
                var post = await cursor.QueryFirstAsync<Post>(query, new { guid });
                return post;
            }
        }

        public async Task Update(Post entity)
        {
            string query = "UPDATE Post SET Title = @title, Content = @content, UpdatedAt = current_timestamp WHERE Id = @Id";
            using (var cursor = _context.Connect)
            {
                await cursor.ExecuteAsync(query, new { entity.Title, entity.Content, entity.Id });
            }
        }
    }
}