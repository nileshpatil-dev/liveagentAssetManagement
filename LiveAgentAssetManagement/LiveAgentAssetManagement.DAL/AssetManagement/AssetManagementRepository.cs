using System;
using System.Data;
using DataAccess;
using LiveAgentAssetManagement.DAL.DataRepository;
using LiveAgentAssetManagement.Common.Constants;

namespace LiveAgentAssetManagement.DAL
{
    public class AssetManagementRepository : IAssetManagementRepository
    {
        private readonly IDataAccess dataAccess;
        public AssetManagementRepository(IRepository repository)
        {
            dataAccess = repository.dataAccess;
        }

        public DataTable GetAssets()
        {
            const string spName = StoredProcedures.GetAssets;
            return dataAccess.GetDataTable(spName, CommandType.StoredProcedure, Tables.Assets);
        }
    }
}


