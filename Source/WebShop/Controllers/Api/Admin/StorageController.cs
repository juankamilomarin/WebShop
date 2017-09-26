using System;
using System.Web.Http;
using WebShop.Services.Admin;

namespace WebShop.Controllers.Api.Admin
{
    /// <summary>
    /// The Admin controller.
    /// </summary>
    [RoutePrefix("api/admin/storage")]
    public class StorageController : ApiController
    {

        #region Methods

        /// <summary>
        /// Gets the current data storage 
        /// </summary>
        /// <returns>A string describing data storage type</returns>
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(StorageService.DataStorage.ToString());
        }

        /// <summary>
        /// Switch the current data storage from persistent to memory and vice versa
        /// </summary>
        /// <returns>A string describing the new data storage type</returns>
        [HttpGet]
        [Route("switch")]
        public IHttpActionResult Switch()
        {
            //Switch storage type
            StorageService.DataStorage = StorageService.DataStorage == DataStorageType.Persistent ? DataStorageType.Memory : DataStorageType.Persistent;

            return Ok(StorageService.DataStorage.ToString());
        }

        /// <summary>
        /// Sets the data storage type
        /// </summary>
        /// <param name="storage">The data storage type.</param>
        /// <returns>A string describing the new data storage type</returns>
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post([FromBody] string storage)
        {
            DataStorageType storateType;

            // Try to parse storateType
            if (Enum.TryParse(storage, true, out storateType) && Enum.IsDefined(typeof(DataStorageType), storateType))
            {
                StorageService.DataStorage = storateType;
                return Ok(StorageService.DataStorage.ToString());
            }
            else
            {
                return BadRequest("Storage type not defined");
            }
        }

        #endregion
    }
}
