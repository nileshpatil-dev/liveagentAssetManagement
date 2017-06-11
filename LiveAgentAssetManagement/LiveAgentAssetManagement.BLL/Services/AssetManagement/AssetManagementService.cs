using LiveAgentAssetManagement.DAL.DataRepository;

namespace LiveAgentAssetManagement.BLL
{
    public class AssetManagementService : IAssetManagementService
    {
        private readonly IAssetManagementRepository repository;
        public AssetManagementService(IAssetManagementRepository repository)
        {
            this.repository = repository;
        }   
    }
}
