using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public Task Create(Post entity)
        {
            throw new NotImplementedException();
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
    }
}