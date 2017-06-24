using System;
using System.Collections.Generic;
using System.Data;
using LiveAgentAssetManagement.DAL;
using LiveAgentAssetManagement.Entity;

namespace LiveAgentAssetManagement.BLL
{
    public class AssetManagementService : IAssetManagementService
    {
        private readonly IAssetManagementRepository repository;
        public AssetManagementService(IAssetManagementRepository repository)
        {
            this.repository = repository;
        }

        IEnumerable<AssetModel> IAssetManagementService.GetAssets()
        {
            DataTable dtAssets = repository.GetAssets();

            if (dtAssets == null)
            {
                return new List<AssetModel>();
            }

            return from drAsset in dtAssets.AsEnumerable()
                   select new AssetModel
                   {
                       AssetId = Convert.ToInt32(drAsset["AssetId"]),
                       AssetName = Convert.ToString(drAsset["AssetName"])
                   };
        }
    }
}
