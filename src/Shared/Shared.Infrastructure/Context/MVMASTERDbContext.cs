using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Module.IdentityManagement.Domain.Entities;

namespace Shared.Infrastructure.Context
{
    public class MVMASTERDbContext : IdentityDbContext<ApplicationUser>
    {
        public MVMASTERDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
