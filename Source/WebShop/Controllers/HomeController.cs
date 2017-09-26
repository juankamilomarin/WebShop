using System.Web.Mvc;

namespace WebShop.Controllers
{
    /// <summary>
    /// The Home controller.
    /// </summary>
    [Route("admin")]
    public class HomeController : Controller
    {
        #region Actions

        /// <summary>
        /// Routes to the Index view.
        /// </summary>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        #endregion
    }
}
