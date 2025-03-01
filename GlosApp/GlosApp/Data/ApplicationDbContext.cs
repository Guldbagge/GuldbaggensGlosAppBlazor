

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GlosApp.Models;
using GlosApp.Models.Horse;

namespace GlosApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WordAnswer> WordAnswers { get; set; }

        public DbSet<HorseHealthStatus> HorseHealthStatuses { get; set; }
        public DbSet<HorseDiaryEntry> HorseDiaryEntries { get; set; }

        public DbSet<SurveyResponse> SurveyResponses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}

