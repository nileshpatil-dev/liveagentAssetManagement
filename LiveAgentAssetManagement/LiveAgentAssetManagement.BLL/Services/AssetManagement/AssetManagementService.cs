using System.Data;
using LiveAgentAssetManagement.DAL;

namespace LiveAgentAssetManagement.BLL
{
    public class AssetManagementService : IAssetManagementService
    {
        private readonly IAssetManagementRepository repository;
        public AssetManagementService(IAssetManagementRepository repository)
        {
            this.repository = repository;
        }

        public DataTable GetAssets()
        {
            return repository.GetAssets();
        }
    }
}
