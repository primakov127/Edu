using MoneyManager.DataServices.DataTransferObjects;
using System;
using System.Collections.Generic;

namespace MoneyManager.DataServices.SeedWork
{
    public interface ITransactionService
    {
        IEnumerable<TransactionInformationDTO> GetUserTransactionsInformation(Guid userId);
        IEnumerable<TotalIncomeAndExpensesDTO> GetUserPeriodIncomeAndExpenses(Guid userId, DateTime startDate, DateTime endDate);
        void DeleteUserCurrentMonthTransactions(Guid userId);
    }
}
