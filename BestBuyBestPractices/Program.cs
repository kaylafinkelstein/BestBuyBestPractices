using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
         
            IDbConnection conn = new MySqlConnection(connString);

            IDepartmentRepository repo = new DapperDepartmentRepsitory(conn);
            IProductRepository prod = new DapperProductRepsitory(conn);

            Console.WriteLine("Please press enter...");
            Console.ReadLine();
            Console.WriteLine("Hello user, here are the current departments:");
            

            var depos= repo.GetAllDepartments();

            foreach(var depo in depos)
            {
                Console.WriteLine($"Id: {depo.DepartmentId} Name: {depo.Name}");
            }
            Console.WriteLine("Pleasee press enter again to see current products");
            Console.ReadLine();

            var products = prod.GetAllProducts();

            foreach(var product in products)
            {
                Console.WriteLine($"ID: {product.ProductID} Name:{product.Name} Price:{product.Price}");
            }
        }
    }
}
