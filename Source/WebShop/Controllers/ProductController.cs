using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebShop.Models;
using WebShop.Services.Interfaces;

namespace WebShop.Controllers
{
    /// <summary>
    /// The product controller.
    /// </summary>
    public class ProductController : Controller
    {

        #region Fields

        /// <summary>
        /// The product service.
        /// </summary>
        private readonly IProductService _productService;

        #endregion

        #region Constructors

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="productService">The product service.</param>
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        #region Actions


        /// <summary>
        /// Gets the list of existent products and routes to the Index view
        /// </summary>
        [HttpGet]
        public ActionResult Index()
        {
            List<Product> productList;
            try
            {
                productList = _productService.GetAll().ToList();
            }
            catch (Exception e)
            {
                ViewData["Error"] = e.Message;
                return View("Error");
            }

            return View("Index", productList);
        }

        /// <summary>
        /// Routes to the Create view
        /// </summary>
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        /// <summary>
        /// Inserts a new product. If it already exists updates its attributes. When done routes to the Index view
        /// </summary>
        /// <param name="product">The product to be inserted.</param>
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", product);
            }

            if (_productService.InsertOrUpdate(product)){ 
                return RedirectToAction("Index");
            }
            ViewData["Error"] = "There was an error adding the product";
            return View("Error");
        }

        #endregion
    }
}
