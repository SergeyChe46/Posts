using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Posts.Context;
using Posts.Models;
using Posts.Repository;
using Posts.Services.Logging;

namespace Posts.Services
{
    public static class RegisterService
    {
        public static void RegisterDI(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped(typeof(IRepository<Post>), typeof(PostRepository));
            services.AddSingleton<ILoggerService, LoggerManager>();
        }
    }
}