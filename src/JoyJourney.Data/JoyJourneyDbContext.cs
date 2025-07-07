using JoyJourney.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JoyJourney.Data;

public class JoyJourneyDbContext(DbContextOptions<JoyJourneyDbContext> options) : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply snake_case to Identity table names
        modelBuilder.Entity<ApplicationUser>(b => b.ToTable("asp_net_users"));
        modelBuilder.Entity<IdentityRole<Guid>>(b => b.ToTable("asp_net_roles"));
        modelBuilder.Entity<IdentityUserRole<Guid>>(b => b.ToTable("asp_net_user_roles"));
        modelBuilder.Entity<IdentityUserClaim<Guid>>(b => b.ToTable("asp_net_user_claims"));
        modelBuilder.Entity<IdentityUserLogin<Guid>>(b => b.ToTable("asp_net_user_logins"));
        modelBuilder.Entity<IdentityRoleClaim<Guid>>(b => b.ToTable("asp_net_role_claims"));
        modelBuilder.Entity<IdentityUserToken<Guid>>(b => b.ToTable("asp_net_user_tokens"));

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(JoyJourneyDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSnakeCaseNamingConvention();
    }
}
