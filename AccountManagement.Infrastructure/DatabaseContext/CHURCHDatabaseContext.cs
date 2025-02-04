using AccountManagement.Application.Utils;
using AccountManagement.Domain.IdentityHub;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AccountManagement.Infrastructure.DatabaseContext
{
    public class CHURCHDatabaseContext : DbContext
    {
        public CHURCHDatabaseContext(DbContextOptions<CHURCHDatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Calls base.OnModelCreating(modelBuilder) to preserve EF Core's default behavior.
            base.OnModelCreating(modelBuilder);

            // Uses ApplyConfigurationsFromAssembly to automatically load all IEntityTypeConfiguration<T> classes from the current assembly.
            // This improves maintainability by keeping entity configurations in separate classes rather than cluttering CHURCHDatabaseContext.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CHURCHDatabaseContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Calls base.OnConfiguring(optionsBuilder) to ensure EF Core applies its default configurations.
            base.OnConfiguring(optionsBuilder);

            // Enables query logging in development mode by writing logs to the console at Information level.
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

            /*
             Checks if EF Core has been configured.
             Fetches the connection string from an environment variable (ApplicationConstants.CONNECTION_STRING).
             Uses UseSqlServer() to configure SQL Server as the database provider.
             Enables automatic retry (for handling transient failures):
                Retries: 5 times
                Retry Delay: 30 seconds
                Error Handling: Uses default SQL Server error handling (errorNumbersToAdd: null).
             */
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable(ApplicationConstants.CONNECTION_STRING),
                    sqlServerOptionsAction: sqlOptions => sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null
                        ));
            }
        }

        // User Management DbSet Entities
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
