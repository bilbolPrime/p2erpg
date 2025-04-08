
using AutoMapper;
using BilbolStack.Boonamai.P2ERPG.Api.Filters;
using BilbolStack.Boonamai.P2ERPG.ApiMiddleware;
using BilbolStack.Boonamai.P2ERPG.Business;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Migrations;
using BilbolStack.Boonamai.P2ERPG.Common.Options;
using BilbolStack.Boonamai.P2ERPG.Crypto;
using BilbolStack.Boonamai.P2ERPG.Crypto.Crypto;
using BilbolStack.Boonamai.P2ERPG.Domain;
using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;

namespace BilbolStack.Boonamai.P2ERPG.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = new ConfigurationBuilder();

            
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            DomainBootstrapper.BootstrapDomain(builder.Services);
            BusinessBootstrapper.BootstrapBusiness(builder.Services);
            CryptoBootstrapper.BootstrapCrypto(builder.Services);


            builder.Services.AddScoped<AuthorizedAccountFilter>();

            builder.Services.AddSingleton<IMapper>(s => config.CreateMapper());
            builder.Services.AddOptions<EnvironmentSettings>().BindConfiguration(EnvironmentSettings.Key);
            builder.Services.AddOptions<DBSettings>().BindConfiguration(DBSettings.Key);
            builder.Services.AddOptions<CryptoJWTOptions>().BindConfiguration(CryptoJWTOptions.KEY);

            builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200");
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
                builder.AllowCredentials();
            }));

            var app = builder.Build();


            app.UseMiddleware<ErrorHandlerMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(options =>
                {
                    options
                        .WithTitle("P2E RPG")
                        .WithDownloadButton(true)
                        .WithTheme(ScalarTheme.Purple)
                        .WithDefaultHttpClient(ScalarTarget.JavaScript, ScalarClient.Axios);
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapControllers();
            
            // This is very bad
            using (var provider = builder.Services.BuildServiceProvider())
            {
                var migrator = provider.GetRequiredService<IDBMigrationManager>();
                migrator.Migrate();
            }

            app.Run();
        }
    }
}
