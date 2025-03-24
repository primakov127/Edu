using System;

namespace MoneyManager.DataServices.DataTransferObjects
{
    public class UserBalanceInformationDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
    }
}
