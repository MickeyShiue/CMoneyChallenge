using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Configuration;

namespace CMoney.DataAccess.Lib.Models
{
    public class CmoneyFactory : IDesignTimeDbContextFactory<CmoneyContext>
    {
        public CmoneyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CmoneyContext>();
            optionsBuilder.UseSqlServer(ConfigurationManager.AppSettings["DefaultConnectionString"]);
            return new CmoneyContext(optionsBuilder.Options);
        }
    }
}
