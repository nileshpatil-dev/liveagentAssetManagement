using DataAccess;
using LiveAgentAssetManagement.DAL.DataRepository;

namespace LiveAgentAssetManagement.DAL
{
    public class AssetManagementRepository : IAssetManagementRepository
    {
        private readonly IDataAccess dataAccess;
        public AssetManagementRepository(IRepository repository)
        {
            dataAccess = repository.dataAccess;
        }
    }
}


