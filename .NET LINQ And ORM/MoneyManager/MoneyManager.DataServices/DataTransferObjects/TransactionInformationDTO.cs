using System;

namespace MoneyManager.DataServices.DataTransferObjects
{
    public class TransactionInformationDTO
    {
        public string AssetName { get; set; }
        public string CategoryName { get; set; }
        public string ParentCategoryName { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}
