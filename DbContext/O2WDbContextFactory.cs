using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace O2W.DbContext;

public class O2WDbContextFactory : IDesignTimeDbContextFactory<O2WDbContext>
{
    public O2WDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<O2WDbContext>();

        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=o2wdb;Username=o2w;Password=o2w2026"
        );

        return new O2WDbContext(optionsBuilder.Options);
    }
}