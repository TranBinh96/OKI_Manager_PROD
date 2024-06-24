using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Production.DataAccess.Model;
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
        public DbSet<Tool> Tools { get; set; }
        public DbSet<MachineDelivery> MachineDeliverys { get; set; }
        public DbSet<Personnel> Personnel { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
