using System.Web.Mvc;

namespace LiveAgentAssetManagement.Controllers
{
    public class TicketManagementController : Controller
    {
        // GET: TicketManagement
        public ActionResult Index()
        {
            return View();
        }

        // GET: TicketManagement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TicketManagement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TicketManagement/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketManagement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TicketManagement/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketManagement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TicketManagement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}