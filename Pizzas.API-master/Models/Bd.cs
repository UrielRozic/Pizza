using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;
using Dapper;
using System.Data.Client;

namespace Pizzas.API.Models
{
    public class Bd
    {
        private static string _connectionString=@"Server=A-LUM-06\SQLEXPRESS;
        DataBase=DAI-Pizzas;Trusted_Connection=True;";
    }
}
