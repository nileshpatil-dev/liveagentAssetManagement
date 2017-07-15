using System;
using System.Configuration;
using DataAccess;

namespace LiveAgentAssetManagement.DAL.DataRepository
{
    public class Repository : IRepository
    {
        public Repository()
        {
            var provider = ConfigurationManager.AppSettings["Provider"];
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            if (string.IsNullOrWhiteSpace(provider) || string.IsNullOrWhiteSpace(connectionString))
            {
                throw new Exception("Missing data provider in App setting");
            }
            if (provider.Trim().ToUpper() == "MYSQL")
            {
                var factoryDataAccess = new FactoryDataAccess(Provider.MySql, connectionString);
                DataAccess = factoryDataAccess.GetDataAccess();
            }
            else
            {
                throw new Exception("Invalid provider in App Setting");
            }
        }

        public IDataAccess DataAccess { get; }
    }
}