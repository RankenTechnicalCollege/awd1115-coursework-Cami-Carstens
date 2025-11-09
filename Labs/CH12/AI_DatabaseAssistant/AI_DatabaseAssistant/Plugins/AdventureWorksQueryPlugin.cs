using AI_DatabaseAssistant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.SemanticKernel;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AI_DatabaseAssistant.Plugins
{
    internal class AdventureWorksQueryPlugin
    {
        private readonly AdventureWorksContext _database;
        public AdventureWorksQueryPlugin(AdventureWorksContext database)
        {
            _database = database;
        }

        [KernelFunction]
        [Description("Runs a SQL query on the Adventure Works sales database and returns results as Json. Available tables: SalesOrderHeader, SalesOrderDetail, Product, ProductCategory,ProductSubcategory. Do not use schema prefixes like 'Sales.' - use table names directly.")]

        public async Task<string> QueryDatabase([Description("The SQL query to execute. Use table names without schema prefixes:SalesOrderHeader, SalesOrderDetail, Product,ProductCategory, ProductSubcategory")] string sqlQuery)
        {
            try
            {
                var connection = _database.Database.GetDbConnection();
                await _database.Database.OpenConnectionAsync();

                using var command = connection.CreateCommand();
                command.CommandText = sqlQuery;
                using var reader = await command.ExecuteReaderAsync();

                var results = new List<object>();

                while(await reader.ReadAsync())
                {
                    var row = new Dictionary<string, object>();
                    for(int i = 0; i < reader.FieldCount; i++)
                    {
                        var value = reader.GetValue(i);
                        row[reader.GetName(i)] = value == DBNull.Value ? null : value;
                    }
                    results.Add(row);
                }
                return JsonSerializer.Serialize(results, new JsonSerializerOptions { WriteIndented = true });
            }
            catch(Exception ex)
            {
                return $"Oops! Something went wrong: {ex.Message}";
            }
        }
    }
}
