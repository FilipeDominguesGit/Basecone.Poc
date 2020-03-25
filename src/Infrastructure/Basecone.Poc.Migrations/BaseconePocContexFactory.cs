using Basecone.Poc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Basecone.Poc.Migrations
{
    public class BaseconePocContexFactory : IDesignTimeDbContextFactory<BaseconePocContext>
    {
        public BaseconePocContext CreateDbContext(string[] args)
        {

            var builder = new DbContextOptionsBuilder<BaseconePocContext>();
            builder
                .UseMySql("server=localhost;port=3306;database=BaseconePoc;uid=root;password=rootpwd;",
                b => b.MigrationsAssembly("Basecone.Poc.Migrations"));

            return new BaseconePocContext(builder.Options);
        }
    }
}
