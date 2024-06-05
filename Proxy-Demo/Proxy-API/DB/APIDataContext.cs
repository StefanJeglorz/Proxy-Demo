using Microsoft.EntityFrameworkCore;
using Models;

namespace Proxy_API.DB
{
    public class APIDataContext(DbContextOptions<APIDataContext> options) : DbContext(options)
    {
        public DbSet<Projects> Projects { get; set; }
    }
}
