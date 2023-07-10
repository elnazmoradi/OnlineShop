using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DbContext
    {
        private static readonly string connectionString = @"Server=localhost;Database=OnlineShop;Trusted_Connection=True;TrustServerCertificate=True;";
        public static SqlConnection Connection() => new SqlConnection(connectionString);
    }
}