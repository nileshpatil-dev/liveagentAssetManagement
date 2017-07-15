using LiveAgentAssetManagement.Entity;
using System.Data;

namespace LiveAgentAssetManagement.DAL
{
    public interface IAssetManagementRepository
    {
        DataSet GetAssets();

        DataSet GetAssetPageLoadData();

        DataTable GetAsset(int assetId);

        string SaveAsset(AssetModel assetModel);

        string UpdateAsset(AssetModel assetModel);

        bool DeleteAsset(int assetId);

        DataTable GetAssetByAssetCode(string assetCode);
    }
}
