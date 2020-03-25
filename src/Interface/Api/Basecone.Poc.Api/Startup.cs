using AutoMapper;
using Basecone.Poc.Api.Mappers;
using Basecone.Poc.Application.Behaviors;
using Basecone.Poc.Application.Commands;
using Basecone.Poc.Application.Mappers;
using Basecone.Poc.Domain.OfficeAggregate;
using Basecone.Poc.Infrastructure;
using Basecone.Poc.Seedwork;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Basecone.Poc.Api
{
    public class Startup
    {
        public static readonly ILoggerFactory factory = LoggerFactory.Create(builder => { builder.AddSerilog(); });

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddControllers();

            services.AddScoped<IOfficeRepository, OfficeRepository>();

            services.AddMediatR(cfg => { }, typeof(CreateOfficeCommandHandler).Assembly);

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(PerformanceMeterBehavior<,>));


            services.AddDbContext<BaseconePocContext>((context, options) =>
            {
                var loggerFactory = context.GetService<ILoggerFactory>();
                if (Configuration.GetValue<bool>("UseInMemory"))
                    options.UseInMemoryDatabase("ExampleDatabase");
                else
                    options.UseMySql("server=localhost;port=3306;database=BaseconePoc;uid=root;password=rootpwd;");
                options.UseLoggerFactory(loggerFactory);
            });

            services.AddScoped<IUnitOfWork>(c => c.GetService<BaseconePocContext>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Basecone API", Version = "v1" });
            });

            services.AddAutoMapper(typeof(ApiProfile), typeof(ApplicationProfile));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Basecone API V1");
            });
        }
    }
}
