using DataAccess;
using System.Configuration;

namespace LiveAgentAssetManagement.DAL.DataRepository
{
    public class Repository : IRepository
    {
        public IDataAccess dataAccess { get; }

        public Repository()
        {
            var provider = ConfigurationManager.AppSettings["Provider"];
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            if (string.IsNullOrWhiteSpace(provider) || string.IsNullOrWhiteSpace(connectionString))
            {
                throw new System.Exception("Missing data provider in App setting");
            }
            else
            {
                if (provider.Trim().ToUpper() == "MYSQL")
                {
                    var factoryDataAccess = new FactoryDataAccess(Provider.MySql, connectionString);
                    dataAccess = factoryDataAccess.GetDataAccess();
                }
                else
                {
                    throw new System.Exception("Invalid provider in App Setting");
                }
            }
        }
    }
}