using Microsoft.EntityFrameworkCore;
using musicapi_dotnet.Models;

namespace musicapi_dotnet.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext>options) : base(options)
        {

        }

        public DbSet<Song> Songs { get; set; }
    }
}
