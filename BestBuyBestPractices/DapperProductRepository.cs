using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BestBuyBestPractices
{
    public class DapperProductRepsitory : IProductRepository
    {
        private readonly IDbConnection _connection;
        

        public DapperProductRepsitory(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            var products = _connection.Query<Product>("SELECT * FROM products");

            return products;
        }

        public void InsertProduct(Product product)
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name) VALUES (@productName);",
            new { productName = product });
        }
    }
}
