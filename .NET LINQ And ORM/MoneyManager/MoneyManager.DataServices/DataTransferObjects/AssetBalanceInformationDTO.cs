using System;

namespace MoneyManager.DataServices.DataTransferObjects
{
    public class AssetBalanceInformationDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
