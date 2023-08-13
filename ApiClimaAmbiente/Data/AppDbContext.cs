using ApiClimaAmbiente.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiClimaAmbiente.Data
{
    public class AppDbContext : DbContext
    {
       public DbSet<ClimaAmbiente> ClimaAmbientes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
    }
}
