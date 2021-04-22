using MoneyManager.DataServices.DataTransferObjects;
using System;
using System.Collections.Generic;

namespace MoneyManager.DataServices.SeedWork
{
    public interface IUserService
    {
        UserDTO GetUser(string email);
        IEnumerable<UserInformationDTO> GetUsersInformationSortedByName();
        UserBalanceInformationDTO GetUserBalanceInformation(Guid userId);
    }
}
