using System;
using System.Data;
using System.Linq;
using DataAccess;
using LiveAgentAssetManagement.Common.Constants;
using LiveAgentAssetManagement.DAL.DataRepository;
using LiveAgentAssetManagement.Entity;

namespace LiveAgentAssetManagement.DAL
{
    public class AssetManagementRepository : IAssetManagementRepository
    {
        private readonly IDataAccess dataAccess;

        public AssetManagementRepository(IRepository repository)
        {
            dataAccess = repository.DataAccess;
        }

        public bool DeleteAsset(int assetId)
        {
            const string spName = StoredProcedures.DeleteAsset;

            var paramList = new DalParameterList
            {
                new DalParameter
                {
                    ParameterName = "AssetId",
                    ParameterDirection = ParameterDirection.Input,
                    ParameterValue = assetId,
                    ParameterType = DbType.Int32
                }
            };
            dataAccess.ExecuteNonQuery(spName, CommandType.StoredProcedure, paramList);
            return true;
        }

        public DataTable GetAsset(int assetId)
        {
            const string spName = StoredProcedures.GetAsset;

            var paramList = new DalParameterList
            {
                new DalParameter
                {
                    ParameterName = "AssetId",
                    ParameterDirection = ParameterDirection.Input,
                    ParameterValue = assetId,
                    ParameterType = DbType.Int32
                }
            };
            return dataAccess.GetDataTable(spName, CommandType.StoredProcedure, paramList);
        }

        public DataTable GetAssetByAssetCode(string assetCode)
        {
            const string spName = StoredProcedures.GetAssetByBarcode;

            var paramList = new DalParameterList
            {
                new DalParameter
                {
                    ParameterName = "Barcode",
                    ParameterDirection = ParameterDirection.Input,
                    ParameterValue = assetCode,
                    ParameterType = DbType.String,
                    ParameterSize = 100
                }
            };
            return dataAccess.GetDataTable(spName, CommandType.StoredProcedure, paramList);
        }

        public DataSet GetAssetPageLoadData()
        {
            const string spName = StoredProcedures.GetAssetPageLoadData;
            string[] tableNames = {Tables.Departments, Tables.Categories, Tables.Brands};
            return dataAccess.GetDataSet(spName, CommandType.StoredProcedure, tableNames);
        }

        public DataSet GetAssets()
        {
            const string spName = StoredProcedures.GetAssets;
            string[] tableNames = {Tables.Assets};
            return dataAccess.GetDataSet(spName, CommandType.StoredProcedure, tableNames);
        }

        public string SaveAsset(AssetModel assetModel)
        {
            const string spName = StoredProcedures.SaveAsset;

            var paramList = new DalParameterList
            {
                new DalParameter
                {
                    ParameterName = "AssetName",
                    ParameterDirection = ParameterDirection.Input,
                    ParameterValue = assetModel.AssetName,
                    ParameterType = DbType.String,
                    ParameterSize = 500
                },
                new DalParameter
                {
                    ParameterName = "Barcode",
                    ParameterDirection = ParameterDirection.Input,
                    ParameterValue = assetModel.AssetSrNo,
                    ParameterType = DbType.String,
                    ParameterSize = 100
                },

                new DalParameter
                {
                    ParameterName = "DepartmentId",
                    ParameterDirection = ParameterDirection.Input,
                    ParameterValue = assetModel.DepartmentId,
                    ParameterType = DbType.Int32
                },
                new DalParameter
                {
                    ParameterName = "CategoryId",
                    ParameterDirection = ParameterDirection.Input,
                    ParameterValue = assetModel.CategoryId,
                    ParameterType = DbType.Int32
                },
                new DalParameter
                {
                    ParameterName = "BrandId",
                    ParameterDirection = ParameterDirection.Input,
                    ParameterValue = assetModel.BrandId,
                    ParameterType = DbType.Int32
                },
                new DalParameter
                {
                    ParameterName = "Supplier",
                    ParameterDirection = ParameterDirection.Input,
                    ParameterValue = assetModel.Supplier,
                    ParameterType = DbType.String,
                    ParameterSize = 500
                },
                new DalParameter
                {
                    ParameterName = "PurchasedDate",
                    ParameterDirection = ParameterDirection.Input,
                    ParameterValue = assetModel.PurchasedDate,
                    ParameterType = DbType.DateTime
                },
                new DalParameter
                {
                    ParameterName = "Output",
                    ParameterDirection = ParameterDirection.Output,
                    ParameterValue = string.Empty,
                    ParameterType = DbType.String,
                    ParameterSize = 500
                }
            };


            dataAccess.ExecuteNonQuery(spName, CommandType.StoredProcedure, paramList);
            var procStatusParam = paramList.First(dalParameter => dalParameter.ParameterName == "Output");
            return Convert.ToString(procStatusParam.ParameterValue);
        }

        public string UpdateAsset(AssetModel assetModel)
        {
            const string spName = StoredProcedures.UpdateAsset;

            var paramList = new DalParameterList
            {
                new DalParameter
                {
                    ParameterName = "AssetId",
                    ParameterDirection = ParameterDirection.Input,
                    ParameterValue = assetModel.AssetId,
                    ParameterType = DbType.Int32
                },
                new DalParameter
                {
                    ParameterName = "AssetName",
                    ParameterDirection = ParameterDirection.Input,
                    ParameterValue = assetModel.AssetName,
                    ParameterType = DbType.String,
                    ParameterSize = 500
                },
                new DalParameter
                {
                    ParameterName = "Barcode",
                    ParameterDirection = ParameterDirection.Input,
                    ParameterValue = assetModel.AssetSrNo,
                    ParameterType = DbType.String,
                    ParameterSize = 100
                },

                new DalParameter
                {
                    ParameterName = "DepartmentId",
                    ParameterDirection = ParameterDirection.Input,
                    ParameterValue = assetModel.DepartmentId,
                    ParameterType = DbType.Int32
                },
                new DalParameter
                {
                    ParameterName = "CategoryId",
                    ParameterDirection = ParameterDirection.Input,
                    ParameterValue = assetModel.CategoryId,
                    ParameterType = DbType.Int32
                },
                new DalParameter
                {
                    ParameterName = "BrandId",
                    ParameterDirection = ParameterDirection.Input,
                    ParameterValue = assetModel.BrandId,
                    ParameterType = DbType.Int32
                },
                new DalParameter
                {
                    ParameterName = "Supplier",
                    ParameterDirection = ParameterDirection.Input,
                    ParameterValue = assetModel.Supplier,
                    ParameterType = DbType.String,
                    ParameterSize = 500
                },
                new DalParameter
                {
                    ParameterName = "PurchasedDate",
                    ParameterDirection = ParameterDirection.Input,
                    ParameterValue = assetModel.PurchasedDate,
                    ParameterType = DbType.DateTime
                },
                new DalParameter
                {
                    ParameterName = "Output",
                    ParameterDirection = ParameterDirection.Output,
                    ParameterValue = string.Empty,
                    ParameterType = DbType.String
                }
            };
            dataAccess.ExecuteNonQuery(spName, CommandType.StoredProcedure, paramList);
            var procStatusParam = paramList.First(dalParameter => dalParameter.ParameterName == "Output");
            return Convert.ToString(procStatusParam.ParameterValue);
        }
    }
}