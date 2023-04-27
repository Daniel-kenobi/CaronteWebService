using Barsa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Tartaro.Data.Entities;

namespace Tartaro.Data;

public partial class ApplicationDbContext : DbContext
{
    private readonly IOptions<ConnectionString> _connectionString;

    public ApplicationDbContext(IOptions<ConnectionString> connectionString)
    {
        _connectionString = connectionString;
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IOptions<ConnectionString> connectionString)
        : base(options)
    {
        _connectionString = connectionString;
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql(_connectionString.ToString(), ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.LastActivicty)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Username).HasMaxLength(255);
            entity.Property(e => e.WindowsVersion).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
