using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using LogThemALL.Models;
using LogThemALL.Data;

namespace LogThemALL.Services;

public interface IAuditService
{
    Task LogAsync(AuditLog log);
    Task<AuditLog?> GetByIdAsync(Guid id);
    Task<List<AuditLog>> GetAllAsync();
    Task UpdateAsync(AuditLog log);
    Task DeleteAsync(Guid id);
    Task EnsureDatabaseCreatedAsync();
}

public class AuditService : IAuditService
{
    private readonly string _connectionString;
    private readonly string _serviceName;
    private bool _databaseChecked = false;
    private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

    public AuditService(string baseConnectionString, string serviceName)
    {
        _serviceName = serviceName;

        var builder = new SqlConnectionStringBuilder(baseConnectionString);
        builder.InitialCatalog = $"AuditLog_{serviceName}";
        _connectionString = builder.ConnectionString;
    }

    private AuditDbContext CreateContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AuditDbContext>();
        optionsBuilder.UseSqlServer(_connectionString);
        return new AuditDbContext(optionsBuilder.Options);
    }

    public async Task EnsureDatabaseCreatedAsync()
    {
        if (_databaseChecked) return;

        await _semaphore.WaitAsync();
        try
        {
            if (_databaseChecked) return;

            using var context = CreateContext();
            await context.Database.EnsureCreatedAsync();
            _databaseChecked = true;
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public async Task LogAsync(AuditLog log)
    {
        if (!_databaseChecked)
        {
            await EnsureDatabaseCreatedAsync();
        }

        if (string.IsNullOrEmpty(log.ServiceName))
        {
            log.ServiceName = _serviceName;
        }

        using var context = CreateContext();
        context.AuditLogs.Add(log);
        await context.SaveChangesAsync();
    }

    public async Task<AuditLog?> GetByIdAsync(Guid id)
    {
        using var context = CreateContext();
        return await context.AuditLogs.FindAsync(id);
    }

    public async Task<List<AuditLog>> GetAllAsync()
    {
        using var context = CreateContext();
        return await context.AuditLogs.ToListAsync();
    }

    public async Task UpdateAsync(AuditLog log)
    {
        using var context = CreateContext();
        context.AuditLogs.Update(log);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        using var context = CreateContext();
        var log = await context.AuditLogs.FindAsync(id);
        if (log != null)
        {
            context.AuditLogs.Remove(log);
            await context.SaveChangesAsync();
        }
    }
}
