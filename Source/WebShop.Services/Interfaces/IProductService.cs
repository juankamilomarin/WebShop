using System.Collections.Generic;
using WebShop.Models;

namespace WebShop.Services.Interfaces
{
    /// <summary>
    /// The interface definition for a product service.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets all the products in the repository.
        /// </summary>
        /// <returns>An list of products.</returns>
        List<Product> GetAll();

        /// <summary>
        /// Inserts a new product to the repository if it does not exist or updates it otherwise.
        /// </summary>
        /// <param name="product">Product to be inserted/updated.</param>
        /// <returns>True if the insertion/update was success.</returns>
        //TODO: implement error propagation (not just true or false)
        bool InsertOrUpdate(Product product);
    }
}
