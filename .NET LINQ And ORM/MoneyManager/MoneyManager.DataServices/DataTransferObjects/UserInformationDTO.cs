using System;

namespace MoneyManager.DataServices.DataTransferObjects
{
    public class UserInformationDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
