using Barsa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Tartaro.ServerApp.Data.Entities;

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

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Clientfile> Clientfiles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql(_connectionString.Value.ToString(), ServerVersion.Parse("8.0.32-mysql"));


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PRIMARY");

            entity.ToTable("client");

            entity.Property(e => e.ClientId).HasColumnName("clientId");
            entity.Property(e => e.ClientName).HasMaxLength(255);
            entity.Property(e => e.ExternalIp).HasMaxLength(40);
            entity.Property(e => e.LastActivicty)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.LocalIp).HasMaxLength(40);
            entity.Property(e => e.Osversion)
                .HasMaxLength(255)
                .HasColumnName("OSVersion");
            entity.Property(e => e.ProcessorIdentifier).HasMaxLength(255);
        });

        modelBuilder.Entity<Clientfile>(entity =>
        {
            entity.HasKey(e => e.ClientFileId).HasName("PRIMARY");

            entity.ToTable("clientfiles");

            entity.HasIndex(e => e.ClientId, "clientId");

            entity.Property(e => e.ClientFileId).HasColumnName("clientFileId");
            entity.Property(e => e.ClientId).HasColumnName("clientId");
            entity.Property(e => e.FilePath).HasMaxLength(350);

            entity.HasOne(d => d.Client).WithMany(p => p.Clientfiles)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("clientfiles_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.LastActivicty)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Username).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
