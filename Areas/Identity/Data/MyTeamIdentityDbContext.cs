using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyTeam.Areas.Identity.Data
{
    public class MyTeamIdentityDbContext : IdentityDbContext<MyTeamUser>
    {
        public MyTeamIdentityDbContext(DbContextOptions<MyTeamIdentityDbContext> options)
            : base(options)
        {
        }

        public DbSet<MyTeamUser> MyTeamUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
