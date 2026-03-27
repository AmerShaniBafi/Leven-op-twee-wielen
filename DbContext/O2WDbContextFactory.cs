using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace O2W.DbContext
{
    public class O2WDbContextFactory : IDesignTimeDbContextFactory<O2WDbContext>
    {
        public O2WDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<O2WDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=mssqlstud.fhict.local;Database=dbi535640_o2w;User Id=dbi535640_o2w;Password=00475779;TrustServerCertificate=True;"
            );

            return new O2WDbContext(optionsBuilder.Options);
        }
    }
}