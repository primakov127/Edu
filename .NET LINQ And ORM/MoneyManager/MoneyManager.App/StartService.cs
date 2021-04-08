using Microsoft.Extensions.Hosting;
using MoneyManager.DataAccess;
using MoneyManager.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoneyManager.App
{
    public class StartService : IHostedService
    {
        private readonly UnitOfWork _unitOfWork;

        public StartService(AppDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //Console.WriteLine(_context.Users.First().Name);
            Console.WriteLine(_unitOfWork.Users.GetAll().Count());
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
