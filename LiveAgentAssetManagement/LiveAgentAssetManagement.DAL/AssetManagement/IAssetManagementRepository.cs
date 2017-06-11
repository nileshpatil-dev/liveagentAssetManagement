
using System.Data;

namespace LiveAgentAssetManagement.DAL
{
    public interface IAssetManagementRepository
    {
        DataTable GetAssets();
    }
}
