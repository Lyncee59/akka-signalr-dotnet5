using Behelit.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Behelit.Data.Context
{
    public class BehelitDbContext : IdentityDbContext<ApplicationUser>
    {
        public BehelitDbContext(DbContextOptions<BehelitDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
