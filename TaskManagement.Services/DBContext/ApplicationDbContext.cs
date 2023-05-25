using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Services.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
