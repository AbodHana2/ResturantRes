

using Microsoft.EntityFrameworkCore;
using ResturantRes.Models;

namespace ResturantReservation.Data
{
    public class AppContextDb : DbContext
    {
        public AppContextDb(DbContextOptions<AppContextDb> options) : base(options)
        {
        }

        public DbSet<Customer> customers { get; set; }
    }
}
