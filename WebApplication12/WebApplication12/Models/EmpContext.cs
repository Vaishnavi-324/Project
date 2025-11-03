using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace WebApplication12.Models
{
    public class EmpContext : DbContext

    {
        public EmpContext(DbContextOptions<EmpContext> options) : base(options)
        {
        }
        public DbSet<EmpModel> Employees { get; set; }
    }

}
