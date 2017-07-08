using LiveAgentAssetManagement.Entity;
using System.Collections.Generic;
using System.Data;

namespace LiveAgentAssetManagement.BLL
{
    public interface IAssetManagementService
    {
        List<AssetModel> GetAssets();

        AssetPageLoadData GetAssetPageLoadData();

        AssetModel GetAsset(int AssetId);

        string SaveAsset(AssetModel assetModel);

        string UpdateAsset(AssetModel assetModel);

        bool DeleteAsset(int AssetId);

        List<AssetModel> GetAssetByAssetCode(string AssetCode);
    }
}
