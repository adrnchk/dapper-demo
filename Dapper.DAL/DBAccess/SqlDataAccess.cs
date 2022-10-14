﻿using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace Dapper.DAL.DBAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(
            string storedProcedure,
            U parametrs,
            string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            return await connection.QueryAsync<T>(storedProcedure, parametrs,
                commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string storedProcedure, T parametrs, string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            await connection.ExecuteAsync(storedProcedure, parametrs, commandType: CommandType.StoredProcedure);
        }
    }
}