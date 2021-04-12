using Microsoft.Extensions.Hosting;
using MoneyManager.DataServices.SeedWork;
using System.Threading;
using System.Threading.Tasks;

namespace MoneyManager.App
{
    public class StartService : IHostedService
    {
        private readonly IUserService _userService;
        private readonly IAssetService _assetService;
        private readonly ITransactionService _transactionService;
        private readonly ICategoryService _categoryService;

        public StartService(IUserService userService, IAssetService assetService, ITransactionService transactionService, ICategoryService categoryService)
        {
            _userService = userService;
            _assetService = assetService;
            _transactionService = transactionService;
            _categoryService = categoryService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
