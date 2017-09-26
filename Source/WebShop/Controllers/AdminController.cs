using System.Web.Mvc;
using WebShop.Services.Admin;

namespace WebShop.Controllers
{
    /// <summary>
    /// The Admin controller.
    /// </summary>
    [Route("admin")]
    public class AdminController : Controller
    {
        #region Actions

        /// <summary>
        /// Gets the current data storage and routes to the Index view.
        /// </summary>
        [Route("index")]
        public ActionResult Index()
        {
            ViewData["Storage"] = StorageService.DataStorage;
            return View();
        }

        #endregion
    }
}