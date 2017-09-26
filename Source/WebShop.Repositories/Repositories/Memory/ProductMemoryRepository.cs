using WebShop.DataAccess.AbstractClasses;
using WebShop.Models;

namespace WebShop.DataAccess.Repositories.Memory
{
    /// <summary>
    /// The memory repository for products.
    /// </summary>
    public class ProductMemoryRepository : MemoryRepositoryBase<Product>
    {
        /// <summary>
        /// Gets the product key to be used as part of the memory cache key.
        /// </summary>
        /// <param name="product">The Product.</param>
        /// <returns>A string representing the product key</returns>
        public override string GetEntityKey(Product product)
        {
            return product.Number;
        }
    }
}
