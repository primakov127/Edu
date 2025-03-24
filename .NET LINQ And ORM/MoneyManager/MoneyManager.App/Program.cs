using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoneyManager.DataAccess;
using MoneyManager.DataAccess.Contexts;
using MoneyManager.DataAccess.Repositories;
using MoneyManager.DataAccess.SeedWork;
using MoneyManager.DataServices.SeedWork;
using MoneyManager.DataServices.Services;
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
                }, ServiceLifetime.Scoped)
                .AddHostedService<StartService>()
                .AddScoped<UnitOfWork>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IAssetRepository, AssetRepository>()
                .AddScoped<ITransactionRepository, TransactionRepository>()
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IAssetService, AssetService>()
                .AddScoped<ITransactionService, TransactionService>()
                .AddScoped<ICategoryService, CategoryService>();
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
