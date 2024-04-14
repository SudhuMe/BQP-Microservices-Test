using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Services;
using Infrastructure.Extensions;

namespace Infrastructure.Perception;

public class BaseDbContext : DbContext
{
    private readonly ICurrentUserService _currentUserService;

    public BaseDbContext(DbContextOptions options, ICurrentUserService currentUserService) : base(options)
    {
        _currentUserService = currentUserService;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ChangeTracker.SetAuditProperties(_currentUserService);
        return await base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        ChangeTracker.SetAuditProperties(_currentUserService);
        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
