using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Text;


namespace BestBuyBestPractices
{
    public class DapperDepartmentRepsitory : IDepartmentRepository
    {
        private readonly IDbConnection _connection;
        public DapperDepartmentRepsitory(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            var depos = _connection.Query<Department>("SELECT * FROM departments");

            return depos;
        }

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
            new   { departmentName = newDepartmentName });
        }
    }
}
