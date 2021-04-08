using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoneyManager.DataAccess.Contexts;
using System;
using System.IO;

namespace MoneyManager.App
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        static void BuildConfig(HostBuilderContext host, IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        }

        static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services
                .AddDbContext<AppDbContext>(options =>
                {
                    options.UseSqlServer(host.Configuration.GetConnectionString("DefaultConnection"));
                }, ServiceLifetime.Singleton)
                .AddHostedService<StartService>();
        }

        static IHostBuilder CreateHostBuilder(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(BuildConfig)
                .ConfigureServices(ConfigureServices);

            return host;
        }
    }
}
