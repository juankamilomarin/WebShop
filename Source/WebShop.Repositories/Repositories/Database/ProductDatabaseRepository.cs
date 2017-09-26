using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebShop.DataAccess.AbstractClasses;
using WebShop.Models;

namespace WebShop.DataAccess.Repositories.Database
{
    /// <summary>
    /// The database repository for products.
    /// </summary>
    public class ProductDatabaseRepository : DatabaseRepositoryBase<Product>
    {
        #region Constructors

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="connection">Sql connection.</param>
        /// <param name="connectionString">String connection.</param>
        public ProductDatabaseRepository(SqlConnection connection, string connectionString)
        {
            _connection = connection;
            _connection.ConnectionString = connectionString;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all Products from the repository.
        /// </summary>
        /// <returns>An IEnumerable collection of Products.</returns>
        public override IEnumerable<Product> GetAll()
        {
            // Create the list
            List<Product> productList = new List<Product>();

            // Gets the sql connection
            using (SqlConnection connection = _connection)
            {

                // Defines the store procedure to be executed
                const string storeProcedure = "[dbo].[spGetAllProducts]";

                // Creates a command
                using (SqlCommand command = new SqlCommand(storeProcedure, connection))
                {
                    // Opens the connection
                    connection.Open();

                    // Creates the data reader
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        // Pulls the Models out of the datareader
                        productList.AddRange(MapDataReaderToList(dataReader));
                    }
                }
            }

            return productList;
        }

        /// <summary>
        /// Inserts a new product to the repository if it does not exist or updates it otherwise.
        /// </summary>
        /// <param name="product">Product to be inserted/updated.</param>
        public override void InsertOrUpdate(Product product)
        {
            // Setup Parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Add the parameters
            SqlParameter parameter = new SqlParameter
            {
                ParameterName = "@Number",
                SqlDbType = SqlDbType.VarChar,
                Value = product.Number
            };
            parameters.Add(parameter);
            parameter = new SqlParameter
            {
                ParameterName = "@Title",
                SqlDbType = SqlDbType.VarChar,
                Value = product.Title
            };
            parameters.Add(parameter);
            parameter = new SqlParameter
            {
                ParameterName = "@Description",
                SqlDbType = SqlDbType.VarChar,
                Value = product.Description
            };
            parameters.Add(parameter);
            parameter = new SqlParameter
            {
                ParameterName = "@Price",
                SqlDbType = SqlDbType.Decimal,
                Value = product.Price
            };
            parameters.Add(parameter);

            // Gets the sql connection
            using (SqlConnection connection = _connection)
            {
                // Defines the store procedure to be executed
                const string storeProcedure = "[dbo].[spInsertOrUpdateProduct]";

                // Creates a command
                using (SqlCommand command = new SqlCommand(storeProcedure, connection))
                {
                    // Sets up the command as store procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Adds the parameters to the command
                    command.Parameters.AddRange(parameters.ToArray());

                    // Opens the connection
                    connection.Open();

                    // Executes the query
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Maps each column from a data reader into a IEnumerable.
        /// </summary>
        /// <param name="dataReader">DataReader to be mapped.</param>
        /// <returns>An IEnumerable collection of type T.</returns>
        protected override IEnumerable<Product> MapDataReaderToList(IDataReader dataReader)
        {
            // Read column mappings
            int numberColumn = dataReader.GetOrdinal("Number");
            int titleColumn = dataReader.GetOrdinal("Title");
            int descriptionColumn = dataReader.GetOrdinal("Description");
            int priceColumn = dataReader.GetOrdinal("Price");

            List<Product> products = new List<Product>();

            // Add the product to the list
            while (dataReader.Read())
            {
                // Read the product data
                Product product = new Product
                {
                    Number = dataReader.GetString(numberColumn),
                    Title = dataReader.GetString(titleColumn),
                    Price = dataReader.GetDecimal(priceColumn)
                };

                // Handle possible null values
                if (!dataReader.IsDBNull(descriptionColumn)) { product.Description = dataReader.GetString(descriptionColumn); }

                products.Add(product);
            }

            return products;
        }

        #endregion
    }
}
