using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Personal_Finance_Manager.Model.Enitities;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Budget> Budgets { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Goal> Goals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Customize the default Identity table names, schema, etc. if needed
        // Configure additional relationships, constraints, etc.
        modelBuilder.Entity<Budget>()
         .Property(b => b.AmountAllocated)
         .HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<Goal>()
        .Property(g => g.CurrentAmountSaved)
        .HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<Goal>()
        .Property(g => g.TargetAmount)
        .HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<Transaction>()
        .Property(g => g.Amount)
        .HasColumnType("decimal(18, 2)");


        // Example: Rename the Identity tables
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
        modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
        modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
        modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
    }
}


