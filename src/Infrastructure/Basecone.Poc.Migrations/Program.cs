using Basecone.Poc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.IO;

namespace Basecone.Poc.Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);
            
            var configuration = configBuilder.Build();

            var serilogLogger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

            var serviceProvider = new ServiceCollection()
                .AddLogging(f =>
                {
                    f.AddSerilog(serilogLogger);
                })
               .AddDbContext<BaseconePocContext>(
                   (c, o) =>
                   {
                       o.UseMySql(configuration.GetConnectionString("MySql"), b => b.MigrationsAssembly("Basecone.Poc.Migrations"));
                   })
               .BuildServiceProvider();

            var context = serviceProvider.GetService<BaseconePocContext>();

            context.Database.Migrate();
        }
    }
}
