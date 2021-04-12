using MoneyManager.DataAccess.Models;
using MoneyManager.DataServices.DataTransferObjects;
using System;
using System.Collections.Generic;

namespace MoneyManager.DataServices.SeedWork
{
    public interface ICategoryService
    {
        IEnumerable<CategoryAmountInformationDTO> GetUserCategoriesAmountInformationByType(Guid userId, CategoryType categoryType);
    }
}
