using CardsUsers.Models;
using Microsoft.EntityFrameworkCore;
using Users.Models;

namespace DatabaseR
{
    public class CardsApi : DbContext
    {
        public CardsApi(DbContextOptions<CardsApi> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CardsUser> CardsUsers { get; set; }
    }
}
