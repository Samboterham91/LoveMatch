using Microsoft.EntityFrameworkCore;
using ProfileApi.Models;

namespace ProfileApi.Data
{
    public class ProfileDb(DbContextOptions<ProfileDb> options) : DbContext(options)
    {
        public DbSet<Profile> Profiles => Set<Profile>();
    }
}
