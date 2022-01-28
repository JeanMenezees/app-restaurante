using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Contexto
{
    public class ContextoApi : DbContext
    {
        public ContextoApi(DbContextOptions<ContextoApi> options) : base(options)
        {
        }
        public DbSet<Mesa> Mesas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}