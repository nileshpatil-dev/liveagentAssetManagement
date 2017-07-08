using System;
using System.Collections.Generic;
using System.Data;
using LiveAgentAssetManagement.DAL;
using LiveAgentAssetManagement.Entity;
using System.Web.Mvc;
using System.Linq;
using LiveAgentAssetManagement.Common.Constants;

namespace LiveAgentAssetManagement.BLL
{
    public class AssetManagementService : IAssetManagementService
    {
        private readonly IAssetManagementRepository repository;
        public AssetManagementService(IAssetManagementRepository repository)
        {
            this.repository = repository;
        }

        public bool DeleteAsset(int AssetId)
        {
            return repository.DeleteAsset(AssetId);
        }

        public AssetModel GetAsset(int AssetId)
        {
            var dtAsset = repository.GetAsset(AssetId);
            if (dtAsset != null && dtAsset.Rows.Count > 0)
            {
                var drAsset = dtAsset.Rows[0];
                return new AssetModel
                {
                    AssetId = Convert.ToInt32(drAsset["AssetId"]),
                    AssetName = Convert.ToString(drAsset["AssetName"]),
                    Supplier = Convert.ToString(drAsset["Supplier"]),
                    PurchasedDate = Convert.ToDateTime(drAsset["PurchasedDate"]),
                    AssetSrNo = Convert.ToString(drAsset["Barcode"]),
                    DepartmentId = Convert.ToInt32(drAsset["DepartmentId"]),
                    DepartmentName = Convert.ToString(drAsset["DepartmentName"]),
                    CategoryId = Convert.ToInt32(drAsset["CategoryId"]),
                    CategoryName = Convert.ToString(drAsset["CategoryName"]),
                    BrandId = Convert.ToInt32(drAsset["BrandId"]),
                    BrandName = Convert.ToString(drAsset["BrandName"]),
                };
            }
            return null;
        }

        public List<AssetModel> GetAssetByAssetCode(string AssetCode)
        {
            var dtAsset = repository.GetAssetByAssetCode(AssetCode);
            if (dtAsset != null && dtAsset.Rows.Count > 0)
            {
                return (from drAsset in dtAsset.AsEnumerable()
                            select new AssetModel
                            {
                                AssetId = Convert.ToInt32(drAsset["AssetId"]),
                                AssetName = Convert.ToString(drAsset["AssetName"]),
                                Supplier = Convert.ToString(drAsset["Supplier"]),
                                PurchasedDate = Convert.ToDateTime(drAsset["PurchasedDate"]),
                                AssetSrNo = Convert.ToString(drAsset["Barcode"]),
                                DepartmentName = Convert.ToString(drAsset["DepartmentName"]),
                                CategoryName = Convert.ToString(drAsset["CategoryName"]),
                                BrandName = Convert.ToString(drAsset["BrandName"]),
                            }).ToList();
            }
            return new List<AssetModel>();
        }

        public AssetPageLoadData GetAssetPageLoadData()
        {
            var dsAssetPageLoad = repository.GetAssetPageLoadData();
            if (dsAssetPageLoad != null)
            {
                var departmentList = (from drAsset in dsAssetPageLoad.Tables[Tables.Departments].AsEnumerable()
                                      select new SelectListItem
                                      {
                                          Value = Convert.ToString(drAsset["Id"]),
                                          Text = Convert.ToString(drAsset["Name"]),
                                      }).ToList();

                var categoryList = (from drAsset in dsAssetPageLoad.Tables[Tables.Categories].AsEnumerable()
                                    select new SelectListItem
                                    {
                                        Value = Convert.ToString(drAsset["Id"]),
                                        Text = Convert.ToString(drAsset["Name"]),
                                    }).ToList();

                var brandList = (from drAsset in dsAssetPageLoad.Tables[Tables.Brands].AsEnumerable()
                                 select new SelectListItem
                                 {
                                     Value = Convert.ToString(drAsset["Id"]),
                                     Text = Convert.ToString(drAsset["Name"]),
                                 }).ToList();
                return new AssetPageLoadData()
                {
                    DepartmentList = departmentList,
                    CategoryList = categoryList,
                    BrandList = brandList,
                };
            }
            return new AssetPageLoadData()
            {
                DepartmentList = new List<SelectListItem>() {
                    new SelectListItem(){
                        Text = "-- Select Department --",
                        Value = "0"
                    }
                },
                BrandList = new List<SelectListItem>() {
                    new SelectListItem(){
                        Text = "-- Select Brand --",
                        Value = "0"
                    }
                },
                CategoryList = new List<SelectListItem>() {
                    new SelectListItem(){
                        Text = "-- Select Category --",
                        Value = "0"
                    }
                },
            };
        }

        public List<AssetModel> GetAssets()
        {
            var list = new List<AssetModel>();
            var dsAssets = repository.GetAssets();
            if (dsAssets != null)
            {
                list = (from drAsset in dsAssets.Tables[Tables.Assets].AsEnumerable()
                        select new AssetModel
                        {
                            AssetId = Convert.ToInt32(drAsset["AssetId"]),
                            AssetName = Convert.ToString(drAsset["AssetName"]),
                            Supplier = Convert.ToString(drAsset["Supplier"]),
                            PurchasedDate = Convert.ToDateTime(drAsset["PurchasedDate"]),
                            AssetSrNo = Convert.ToString(drAsset["Barcode"]),
                            DepartmentName = Convert.ToString(drAsset["DepartmentName"]),
                            CategoryName = Convert.ToString(drAsset["CategoryName"]),
                            BrandName = Convert.ToString(drAsset["BrandName"]),
                        }).ToList();
            }
            return list;
        }

        public string SaveAsset(AssetModel assetModel)
        {
            return repository.SaveAsset(assetModel);
        }

        public string UpdateAsset(AssetModel assetModel)
        {
            return repository.UpdateAsset(assetModel);
        }
    }
}
