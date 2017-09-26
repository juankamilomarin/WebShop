using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebShop.DataAccess.Repositories.Database;
using WebShop.Models;

namespace WebShop.Tests.DataAccess.Repositories.Database
{
    [TestClass]
    public class ProductDatabaseRepositoryTest
    {
        #region Initialize

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {

        }

        [TestInitialize]
        public void TestInit()
        {
        }

        #endregion

        #region Properties

        public TestContext TestContext { get; set; }

        #endregion

        #region TestMethods

        #region GetAll

        [TestCategory("Integration")]
        [TestMethod]
        public void ProductDatabaseRepository_GetAll_TestProductIsReturned()
        {
            using (ShimsContext.Create())
            {

                // Arrange                
                string connectionString = ConfigurationManager.ConnectionStrings["WebShop"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                ProductDatabaseRepository productRepository = new ProductDatabaseRepository(sqlConnection, connectionString);

                // Act
                List<Product> productList = productRepository.GetAll().ToList();

                // Assert
                Assert.IsTrue(productList.Any(p => string.Compare(p.Number, "WS-TEST", StringComparison.Ordinal) == 0), "Test product does not exits");
            }
        }

        #endregion

        #endregion

        #region Cleanup

        [TestCleanup]
        public void TestCleanup()
        {

        }

        [ClassCleanup]
        public static void ClassCleanup()
        {

        }

        #endregion
    }
}
