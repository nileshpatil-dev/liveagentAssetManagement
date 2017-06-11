using LiveAgentAssetManagement.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiveAgentAssetManagement.Controllers
{
    public class HomeController : Controller
    {

        private readonly IAssetManagementService assetManagementService;
        public HomeController(IAssetManagementService assetManagementService)
        {
            this.assetManagementService = assetManagementService;
        }

        public ActionResult Index()
        {
            DataTable dt = assetManagementService.GetAssets();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}