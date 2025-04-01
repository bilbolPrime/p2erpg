
using AutoMapper;
using BilbolStack.Boonamai.P2ERPG.Business;
using BilbolStack.Boonamai.P2ERPG.Common.Options;
using BilbolStack.Boonamai.P2ERPG.Domain;
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
            builder.Services.AddSingleton<IMapper>(s => config.CreateMapper());

            DomainBootstrapper.BootstrapDomain(builder.Services);
            BusinessBootstrapper.BootstrapBusiness(builder.Services);

            builder.Services.AddOptions<EnvironmentSettings>().BindConfiguration(EnvironmentSettings.Key);

            builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200");
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
                builder.AllowCredentials();
            }));

            var app = builder.Build();

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

            app.Run();
        }
    }
}
