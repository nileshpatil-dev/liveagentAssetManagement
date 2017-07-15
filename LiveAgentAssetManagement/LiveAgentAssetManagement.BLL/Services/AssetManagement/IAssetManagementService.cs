using LiveAgentAssetManagement.Entity;
using System.Collections.Generic;

namespace LiveAgentAssetManagement.BLL
{
    public interface IAssetManagementService
    {
        List<AssetModel> GetAssets();

        AssetPageLoadData GetAssetPageLoadData();

        AssetModel GetAsset(int assetId);

        string SaveAsset(AssetModel assetModel);

        string UpdateAsset(AssetModel assetModel);

        bool DeleteAsset(int assetId);

        List<AssetModel> GetAssetByAssetCode(string assetCode);
    }
}
