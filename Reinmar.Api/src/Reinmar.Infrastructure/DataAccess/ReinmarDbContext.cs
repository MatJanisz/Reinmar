using Microsoft.EntityFrameworkCore;
using Reinmar.Common.Entities;
using Reinmar.Infrastructure.Configurations;

namespace Reinmar.Infrastructure.DataAccess
{
    public class ReinmarDbContext : DbContext
    {
        public ReinmarDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statusses{ get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Waybill> Waybills{ get; set; }
        public DbSet<WaybillBody> WaybillBodies { get; set; }
        public DbSet<WaybillHeader> WaybillHeaders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new WaybillConfiguration());
            modelBuilder.ApplyConfiguration(new WaybillBodyConfiguration());
            modelBuilder.ApplyConfiguration(new WaybillHeaderConfiguration());
        }
    }
}