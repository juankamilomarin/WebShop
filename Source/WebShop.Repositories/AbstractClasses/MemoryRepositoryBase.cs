using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using WebShop.DataAccess.Interfaces;
using WebShop.Utilities.Extensions;

namespace WebShop.DataAccess.AbstractClasses
{
    /// <summary>
    /// The memory repository abstract class.
    /// </summary>
    public abstract class MemoryRepositoryBase<T>: IMemoryRepository<T> where T : class
    {
        #region Fields
        
        /// <summary>
        /// Memory storage
        /// </summary>
        private static readonly ObjectCache Cache = MemoryCache.Default;

        #endregion

        #region Methods

        /// <summary>
        /// Gets all objects of type T from the repository.
        /// </summary>
        /// <returns>An IEnumerable collection of type T.</returns>
        public IEnumerable<T> GetAll()
        {
            return Cache.GetAll<T>();
        }

        /// <summary>
        /// Inserts a new object of type T to the repository if it does not exist or updates it otherwise.
        /// </summary>
        /// <param name="entity">Entity to be inserted/updated.</param>
        //TODO: a policy expiration must be implemented. It should be defined according to business rules
        public void InsertOrUpdate(T entity)
        {
            //Key is of the form {EntityName}-EntityKey
            string key = "{" + typeof(T).Name + "}-" + GetEntityKey(entity);

            Cache[key] = entity;
        }

        /// <summary>
        /// Gets the entity key to be used as part of the memory cache key.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A string representing the entity key</returns>
        public abstract string GetEntityKey(T entity);

        /// <summary>
        /// Dispose the IDisposable types defined in this class
        /// </summary>
        public void Dispose() { }

        #endregion
    }
}
