using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace WebShop.Utilities.Extensions
{
    /// <summary>
    /// A class for including extensions methods to MemoryCache class
    /// </summary>
    public static class MemoryCacheExtensions
    {

        /// <summary>
        /// Get all the elements of type T
        /// </summary>
        /// <param name="cache">Cache object used in the search</param>
        public static IEnumerable<T> GetAll<T>(this ObjectCache cache)
        {
            //Filter only objects of type T
            IEnumerable<KeyValuePair<string, object>> filteredCache = cache.Where(c => string.Compare(c.Value.GetType().Name, typeof(T).Name, StringComparison.Ordinal) == 0);
            return filteredCache.Select(c => (T)c.Value);
        }

    }
}
