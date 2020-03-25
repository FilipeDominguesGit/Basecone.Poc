using Basecone.Poc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Serilog;
using Microsoft.Extensions.Logging;

namespace Basecone.Poc.Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            var serilogLogger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

            var serviceProvider = new ServiceCollection()
                .AddLogging(f =>
                {
                    f.AddSerilog(serilogLogger);

                })

               //.AddLogging(c => c.AddConsole())
               .AddDbContext<BaseconePocContext>(
                   (c, o) =>
                   {
                       var loggerFactory = c.GetService<ILoggerFactory>();
                       o.UseMySql("server=localhost;port=3306;database=BaseconePoc;uid=root;password=rootpwd;", b => b.MigrationsAssembly("Basecone.Poc.Migrations"))
                       .UseLoggerFactory(loggerFactory);
                   })
               .BuildServiceProvider();

            var context = serviceProvider.GetService<BaseconePocContext>();

            context.Database.Migrate();
        }
    }
}
