using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

using Pizzas.API.Models;
using Pizzas.API.Helpers;
using Pizzas.API.Utils;
using Pizzas.API.Services;

namespace Pizzas.API.Models{
    public static class BD{

        public static SqlConnection GetConnection(){
            SqlConnection db;
            string connectionString;

            connectionString = ConfigurationHelper.GetConfiguration().GetValue<string>("DatabaseSettings: ConnectionString");
            db = new SqlConnection(connectionString);
            return db;
        }
    }
}
