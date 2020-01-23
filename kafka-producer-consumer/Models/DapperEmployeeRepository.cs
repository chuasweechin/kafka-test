using System;
using Npgsql;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace kafka_producer.Models
{
  public class DapperEmployeeRepository : IEmployeeRepository
  {
    string _connectionString = "Host=localhost;Port=5432;Database=employeedb;Username=chuasweechin";

    public async Task<List<Employee>> GetAllEmployees() {
      using (var connection = new NpgsqlConnection(_connectionString))
      {
        connection.Open();
        var result = await connection.QueryAsync<Employee>("SELECT * from \"Employees\"");

        return result.ToList();
      }
		}
  }
}
