using Microsoft.EntityFrameworkCore;

namespace VSStudioTestPRJ.Models
{
    public class NoelDBContext : DbContext
    {
        public NoelDBContext(DbContextOptions<NoelDBContext> options)
        : base(options)
        {

        }

        //entities
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<ContactInformation> ContactInformation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
