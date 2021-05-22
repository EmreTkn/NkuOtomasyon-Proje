using System;
using Core.Entities;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity
{
    public class AppIdentityContext:IdentityDbContext<User>
    {
        public DbSet<User> User { get; set; }
        public AppIdentityContext(DbContextOptions<AppIdentityContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>()
                .Property(s => s.Type)
                .HasConversion(o => o.ToString(),
                    o => (Types)Enum.Parse(typeof(Types), o));
        }
    }
}
