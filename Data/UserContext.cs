using Microsoft.EntityFrameworkCore;
using MilesPerGallon.Models;

namespace MilesPerGallon.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
                    : base(options)
        {
        }

        public DbSet<Input> Input { get; set; }
    }
}
