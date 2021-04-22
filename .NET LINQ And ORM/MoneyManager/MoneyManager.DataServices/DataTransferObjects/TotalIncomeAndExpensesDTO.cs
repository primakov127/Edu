namespace MoneyManager.DataServices.DataTransferObjects
{
    public class TotalIncomeAndExpensesDTO
    {
        public decimal Income { get; set; }
        public decimal Expense { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
