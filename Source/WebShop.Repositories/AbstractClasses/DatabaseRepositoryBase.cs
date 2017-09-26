using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebShop.DataAccess.Interfaces;

namespace WebShop.DataAccess.AbstractClasses
{
    /// <summary>
    /// The database repository abstract class.
    /// </summary>
    public abstract class DatabaseRepositoryBase<T>: IDatabaseRepository<T> where T : class
    {

        #region Fields

        /// <summary>
        /// Sql connection.
        /// </summary>
        protected SqlConnection _connection = null;

        #endregion

        #region Methods

        /// <summary>
        /// Gets all objects of type T from the repository.
        /// </summary>
        /// <returns>An IEnumerable collection of type T.</returns>
        public abstract IEnumerable<T> GetAll();

        /// <summary>
        /// Inserts a new object of type T to the repository if it does not exist or updates it otherwise.
        /// </summary>
        /// <param name="entity">Entity to be inserted/updated.</param>
        public abstract void InsertOrUpdate(T entity);

        /// <summary>
        /// Maps each column from a data reader into a IEnumerable.
        /// </summary>
        /// <param name="dataReader">DataReader to be mapped.</param>
        /// <returns>An IEnumerable collection of type T.</returns>
        protected abstract IEnumerable<T> MapDataReaderToList(IDataReader dataReader);

        /// <summary>
        /// Dispose the IDisposable types defined in this class
        /// </summary>
        public void Dispose()
        {
            _connection?.Dispose();
        }

        #endregion
    }
}
