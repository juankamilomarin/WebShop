using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebShop.DataAccess.AbstractClasses.Fakes;
using WebShop.DataAccess.Repositories.Database.Fakes;
using WebShop.DataAccess.Repositories.Database;
using WebShop.DataAccess.Repositories.Memory;
using WebShop.Models;
using WebShop.Services;
using WebShop.Services.Admin;

namespace WebShop.Tests.Services
{
    [TestClass]
    public class ProductServiceTest
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


        [TestCategory("Unit")]
        [TestMethod]
        public void ProductService_GetAll_FromMemory_ListOfProducts_NotEmpty()
        {
            using (ShimsContext.Create())
            {
                //Arrange
                ShimMemoryRepositoryBase<Product>.AllInstances.GetAll = repository => new List<Product>
                {
                    new Product {Number = "TEST1"},
                    new Product {Number = "TEST2"},
                };

                ProductService productService = new ProductService(new ProductDatabaseRepository(new SqlConnection(), null), new ProductMemoryRepository());

                // Act
                StorageService.DataStorage = DataStorageType.Memory;
                List<Product> productList = productService.GetAll();

                // Assert
                Assert.IsTrue(productList.Count == 2, "Number of products is not the expected");
            }
        }

        [TestCategory("Unit")]
        [TestMethod]
        public void ProductService_GetAll_FromDatabase_ListOfProducts_NotEmpty()
        {
            using (ShimsContext.Create())
            {
                //Arrange
                ShimProductDatabaseRepository.AllInstances.GetAll = repository => new List<Product>
                {
                    new Product {Number = "TEST1"},
                    new Product {Number = "TEST2"},
                };

                ProductService productService = new ProductService(new ProductDatabaseRepository(new SqlConnection(), null), new ProductMemoryRepository());

                // Act
                StorageService.DataStorage = DataStorageType.Persistent;
                List<Product> productList = productService.GetAll();

                // Assert
                Assert.IsTrue(productList.Count == 2, "Number of products is not the expected");
            }
        }

        [TestCategory("Unit")]
        [TestMethod]
        public void ProductService_GetAll_FromDefault_ListOfProducts_NotEmpty()
        {
            using (ShimsContext.Create())
            {
                //Arrange
                ShimProductDatabaseRepository.AllInstances.GetAll = repository => new List<Product>
                {
                    new Product {Number = "TEST1"},
                    new Product {Number = "TEST2"},
                };

                ProductService productService = new ProductService(new ProductDatabaseRepository(new SqlConnection(), null), new ProductMemoryRepository());

                // Act
                List<Product> productList = productService.GetAll();

                // Assert
                Assert.IsTrue(productList.Count == 2, "Number of products is not the expected");
            }
        }

        #endregion

        #region InsertOrUpdate

        [TestCategory("Unit")]
        [TestMethod]
        public void ProductService_InsertOrUpdate_ProductToDatabase_NotNull_OkInsertion()
        {
            using (ShimsContext.Create())
            {
                //Arrange
                ShimProductDatabaseRepository.AllInstances.InsertOrUpdateProduct = (repository, product) => { };
                ProductService productService = new ProductService(new ProductDatabaseRepository(new SqlConnection(), null), new ProductMemoryRepository());

                // Act
                bool result = productService.InsertOrUpdate(new Product());

                // Assert
                Assert.IsTrue(result, "Addition was not successful");
            }
        }

        [TestCategory("Unit")]
        [TestMethod]
        public void ProductService_InsertOrUpdate_ProductToDatabase_NotNull_InsertionError()
        {
            using (ShimsContext.Create())
            {
                //Arrange
                ShimProductDatabaseRepository.AllInstances.InsertOrUpdateProduct = (repository, product) => { throw new Exception("Error inserting data"); };
                ProductService productService = new ProductService(new ProductDatabaseRepository(new SqlConnection(), null), new ProductMemoryRepository());

                // Act
                bool result = productService.InsertOrUpdate(new Product());

                // Assert
                Assert.IsFalse(result, "Addition was successful");
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
