using Microsoft.EntityFrameworkCore;
using LogThemALL.Models;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LogThemALL.Data;

public class AuditDbContext : DbContext
{
    public AuditDbContext(DbContextOptions<AuditDbContext> options) : base(options)
    {
    }

    public DbSet<AuditLog> AuditLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var jsonDocumentConverter = new ValueConverter<JsonDocument?, string?>(
            v => v == null ? null : JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
            v => v == null ? null : JsonDocument.Parse(v, default)
        );

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.OwnsOne(e => e.Actor, actor =>
            {
                actor.ToJson();
            });

            entity.OwnsOne(e => e.Target, target =>
            {
                target.ToJson();
            });

            entity.OwnsOne(e => e.Http, http =>
            {
                http.ToJson();
            });

            entity.OwnsOne(e => e.Error, error =>
            {
                error.ToJson();
                error.Property(p => p.Details).HasConversion(jsonDocumentConverter);
            });

            entity.OwnsMany(e => e.Changes, changes =>
            {
                changes.ToJson();
            });

            entity.Property(e => e.Before).HasConversion(jsonDocumentConverter);
            entity.Property(e => e.After).HasConversion(jsonDocumentConverter);
            entity.Property(e => e.Metadata).HasConversion(jsonDocumentConverter);

            entity.Property(e => e.Tags)
                .HasConversion(
                    v => v == null ? null : JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => v == null ? null : JsonSerializer.Deserialize<Dictionary<string, string>>(v, (JsonSerializerOptions?)null)
                );
        });
    }
}
