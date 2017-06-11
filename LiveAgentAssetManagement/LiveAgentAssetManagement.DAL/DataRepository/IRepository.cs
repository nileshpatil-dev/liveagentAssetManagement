using DataAccess;

namespace LiveAgentAssetManagement.DAL.DataRepository
{
    public interface IRepository
    {
        IDataAccess dataAccess { get;}
    }
}
