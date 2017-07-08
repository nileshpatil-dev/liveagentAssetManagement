using LiveAgentAssetManagement.BLL;
using LiveAgentAssetManagement.Entity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LiveAgentAssetManagement.Controllers
{
    public class AssetController : Controller
    {
        private readonly IAssetManagementService assetManagementService;
        public AssetController(IAssetManagementService assetManagementService)
        {

            this.assetManagementService = assetManagementService;
        }

        // GET: Asset
        public ActionResult Index()
        {
            var data = assetManagementService.GetAssets();
            return View(data);
        }

        // GET: Asset/Details/5
        public ActionResult Details(int id)
        {
            return View(assetManagementService.GetAsset(id));
        }

        // GET: Asset/Create
        public ActionResult Create()
        {
            var data = assetManagementService.GetAssetPageLoadData();

            var model = new AssetModel();
            model.PurchasedDate = DateTime.Now;
            model.DepartmentList = data.DepartmentList;
            model.CategoryList = data.CategoryList;
            model.BrandList = data.BrandList;


            TempData["DepartmentList"] = data.DepartmentList;
            TempData["CategoryList"] = data.CategoryList;
            TempData["BrandList"] = data.BrandList;
            return View(model);
        }

        // POST: Asset/Create
        [HttpPost]
        public ActionResult Create(AssetModel model)
        {
            try
            {

                model.DepartmentList = TempData["DepartmentList"] as List<SelectListItem>;
                model.CategoryList = TempData["CategoryList"] as List<SelectListItem>;
                model.BrandList = TempData["BrandList"] as List<SelectListItem>;
                TempData.Keep();
                if (ModelState.IsValid)
                {
                    var message = assetManagementService.SaveAsset(model);
                    if (string.IsNullOrWhiteSpace(message))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in message.Split('`'))
                        {
                            ModelState.AddModelError(string.Empty, error);
                        }
                        return View(model);
                    }
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }

        // GET: Asset/Edit/5
        public ActionResult Edit(int id)
        {
            var assetModel = assetManagementService.GetAsset(id);
            if (assetModel == null)
            {
                ModelState.AddModelError(string.Empty, "Asset not found");
                return View(new AssetModel());
            }
            else
            {
                var data = assetManagementService.GetAssetPageLoadData();

                assetModel.DepartmentList = data.DepartmentList;
                assetModel.CategoryList = data.CategoryList;
                assetModel.BrandList = data.BrandList;

                TempData["DepartmentList"] = data.DepartmentList;
                TempData["CategoryList"] = data.CategoryList;
                TempData["BrandList"] = data.BrandList;
                return View(assetModel);
            }
        }

        // POST: Asset/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            try
            {
                var model = new AssetModel();
                model.AssetName = collection["AssetName"];
                model.AssetSrNo = collection["AssetSrNo"];
                model.DepartmentId = Convert.ToInt32(collection["DepartmentId"]);
                model.CategoryId = Convert.ToInt32(collection["CategoryId"]);
                model.BrandId = Convert.ToInt32(collection["BrandId"]);
                model.Supplier = Convert.ToString(collection["Supplier"]);
                model.PurchasedDate = Convert.ToDateTime(collection["PurchasedDate"]);
                model.AssetId = id;

                model.DepartmentList = TempData["DepartmentList"] as List<SelectListItem>;
                model.CategoryList = TempData["CategoryList"] as List<SelectListItem>;
                model.BrandList = TempData["BrandList"] as List<SelectListItem>;
                TempData.Keep();
                if (ModelState.IsValid)
                {
                    var message = assetManagementService.UpdateAsset(model);
                    if (string.IsNullOrWhiteSpace(message))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in message.Split('`'))
                        {
                            ModelState.AddModelError(string.Empty, error);
                        }
                        return View(model);
                    }
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        // GET: Asset/Delete/5
        public ActionResult Delete(int id)
        {
            var assetModel = assetManagementService.GetAsset(id);
            if (assetModel == null)
            {
                ModelState.AddModelError(string.Empty, "Asset not found");
                return View();
            }
            else
            {
                return View(assetModel);
            }
        }

        // POST: Asset/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (id == 0)
                {
                    ModelState.AddModelError(string.Empty, "Asset not found");
                    return View();
                }
                else
                {
                    var isSuccess = assetManagementService.DeleteAsset(id);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        [HttpGet]
        public JsonResult SearchAsset(string AssetCode) {
            return Json(assetManagementService.GetAssetByAssetCode(AssetCode), JsonRequestBehavior.AllowGet); ;
        }
    }
}
