using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CMoney.DataAccess.Lib.Models
{
    public class CmoneyFactory : IDesignTimeDbContextFactory<CmoneyContext>
    {
        public CmoneyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CmoneyContext>();
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CMoney;Integrated Security=True");

            return new CmoneyContext(optionsBuilder.Options);
        }
    }
}
