using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Production.Models;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Line> Line { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<TypeLine> TypeLine { get; set; }
        public DbSet<Computer_Production> Computer_Production { get; set; }
    }
}
