using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BestBuyBestPractices
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        public ProductRepository(IDbConnection connection)
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
            _connection.Execute("INSERT INTO Products (Name, Price) VALUES (@name, @price);",
            new { name = product.Name, price = product.Price });
        }
    }
}
