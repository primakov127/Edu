using MoneyManager.DataServices.DataTransferObjects;
using System;
using System.Collections.Generic;

namespace MoneyManager.DataServices.SeedWork
{
    public interface IAssetService
    {
        IEnumerable<AssetBalanceInformationDTO> GetUserAssetsBalanceInformation(Guid userId);
    }
}
