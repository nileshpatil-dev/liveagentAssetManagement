using LiveAgentAssetManagement.Entity;
using System.Collections.Generic;
using System.Data;

namespace LiveAgentAssetManagement.BLL
{
    public interface IAssetManagementService
    {
        IEnumerable<AssetModel> GetAssets();
    }
}
