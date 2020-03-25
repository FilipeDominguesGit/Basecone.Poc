using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Basecone.Poc.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                    .MinimumLevel.Information()
                    .MinimumLevel.Override(DbLoggerCategory.Database.Command.Name, Serilog.Events.LogEventLevel.Information)
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                );
    }
}
