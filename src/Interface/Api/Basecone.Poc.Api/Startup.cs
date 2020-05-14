using AutoMapper;
using Basecone.Poc.Api.Mappers;
using Basecone.Poc.Api.MultiTenant;
using Basecone.Poc.Application.Behaviors;
using Basecone.Poc.Application.Commands;
using Basecone.Poc.Application.Mappers;
using Basecone.Poc.Domain.OfficeAggregate;
using Basecone.Poc.Infrastructure;
using Basecone.Poc.Infrastructure.MultiTenant;
using Basecone.Poc.Seedwork;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.IO;
using System.Reflection;
using System.Text;

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

            services.AddAuthentication(cfg =>
            {

                cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.Audience = Configuration["Jwt:Audience"];
                x.ClaimsIssuer = Configuration["Jwt:Issuer"];
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Jwt:Key"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddHttpContextAccessor();

            // repositories IoC
            services.AddScoped<IOfficeRepository, OfficeRepository>();
            // --

            // Mediatr IoC
            services.AddMediatR(cfg => { }, typeof(CreateOfficeCommandHandler).Assembly);

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(PerformanceMeterBehavior<,>));
            // --


            // Database IoC
            services.AddScoped<ITenantResolutionStrategy, MultiTenantJwtStrategy>();
            services.AddScoped<ITenantStore, TenantStore>();
            services.AddScoped<IConnectionStringProvider, ConnectionStringProvider>();
            services.AddScoped<TenantDbContext>(context =>
            {
                return new TenantDbContext(new DbContextOptionsBuilder<TenantDbContext>()
                    .UseMySql(Configuration.GetConnectionString("MySqlTenant"))
                    .Options);
            });

            services.AddScoped<DbContextOptionsBuilder<BaseconePocContext>>();

            services.AddScoped<BaseconePocContextFactory>();

            services.AddScoped<BaseconePocContext>((context) =>
            {
                var factory = context.GetService<BaseconePocContextFactory>();

                return  factory.CreateDbContext().GetAwaiter().GetResult();

            });

            services.AddScoped<IUnitOfWork>(c => c.GetService<BaseconePocContext>());
            // --

            // swagger ioc
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Basecone API",
                    Version = "v1",
                    Contact = new OpenApiContact()
                    {
                        Email = "support@basecone.com",
                        Name = "Basecone Support",
                        Url = new Uri("https://support.basecone.com/"),
                    },
                    Description = "Basecone Poc Example template",
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            // -- 

            // AutoMapper IoC
            services.AddAutoMapper(typeof(ApiProfile), typeof(ApplicationProfile));
            // --
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseAuthorization();
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
