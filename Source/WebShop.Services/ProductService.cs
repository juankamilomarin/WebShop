using System;
using System.Collections.Generic;
using System.Linq;
using WebShop.DataAccess.Interfaces;
using WebShop.Models;
using WebShop.Services.Admin;
using WebShop.Services.Interfaces;

namespace WebShop.Services
{
    /// <summary>
    /// The product service.
    /// </summary>
    public class ProductService : IProductService
    {
        #region Fields

        /// <summary>
        /// Database repository.
        /// </summary>
        private readonly IDatabaseRepository<Product> _databaseRepository;

        /// <summary>
        /// Memory repository.
        /// </summary>
        private readonly IMemoryRepository<Product> _memoryRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="databaseRepository">The database repository.</param>
        /// <param name="memoryRepository">The memory repository.</param>
        public ProductService(IDatabaseRepository<Product> databaseRepository, IMemoryRepository<Product> memoryRepository)
        {
            _databaseRepository = databaseRepository;
            _memoryRepository = memoryRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all the products in the repository.
        /// </summary>
        /// <returns>An list of products.</returns>
        public List<Product> GetAll()
        {
            //Data storage defines the reporitory to be used
            return StorageService.DataStorage == DataStorageType.Persistent
                ? _databaseRepository.GetAll().ToList()
                : _memoryRepository.GetAll().ToList();
        }

        /// <summary>
        /// Inserts a new product to the repository if it does not exist or updates it otherwise.
        /// </summary>
        /// <param name="product">Product to be inserted/updated.</param>
        /// <returns>True if the insertion/update was success.</returns>
        //TODO: implement error propagation (not just true or false)
        public bool InsertOrUpdate(Product product)
        {
            try
            {
                //Data storage type defines the reporitory to be used
                if (StorageService.DataStorage == DataStorageType.Persistent)
                {
                    _databaseRepository.InsertOrUpdate(product);
                }
                else
                {
                    _memoryRepository.InsertOrUpdate(product);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}
