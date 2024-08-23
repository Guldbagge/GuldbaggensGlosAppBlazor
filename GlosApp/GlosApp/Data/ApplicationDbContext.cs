//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using GlosApp.Models;

//namespace GlosApp.Data
//{
//    public class ApplicationDbContext : IdentityDbContext
//    {
//        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//            : base(options)
//        {
//        }

//        public DbSet<WordAnswer> WordAnswers { get; set; }
//    }
//}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GlosApp.Models;

namespace GlosApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WordAnswer> WordAnswers { get; set; }

        // Överskriv OnModelCreating om du behöver konfigurera entity mappings
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Ytterligare konfiguration om det behövs
        }
    }
}

