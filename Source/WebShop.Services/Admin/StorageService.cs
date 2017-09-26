using System.Runtime.Caching;

namespace WebShop.Services.Admin
{
    /// <summary>
    /// The storage service.
    /// </summary>
    public static class StorageService
    {
        #region Consts

        /// <summary>
        /// The name of the key to store the application data storage type
        /// </summary>
        private const string AppDataStorageTypeKey = "AppStorageType";

        #endregion

        #region Fields

        /// <summary>
        /// Memory storage
        /// </summary>
        private static readonly ObjectCache cache = MemoryCache.Default;

        #endregion

        #region Properties

        /// <summary>
        /// The application data storage
        /// </summary>
        //TODO: a policy expiration must be implemented. It should be defined according to business rules
        public static DataStorageType DataStorage
        {
            get
            {
                if (cache.Contains(AppDataStorageTypeKey))
                {
                    return (DataStorageType)cache[AppDataStorageTypeKey];
                }

                //Returns Persistent by default
                return DataStorageType.Persistent;
            }
            set
            {
                cache[AppDataStorageTypeKey] = value;
            }
        }

        #endregion
    }
}
