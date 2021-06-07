using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace APIdotnet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SqlConnectionStringBuilder sqlsb = new SqlConnectionStringBuilder();
            sqlsb.ApplicationName = "sqlServerExample";
            sqlsb.DataSource = "localhost";
            sqlsb.UserID = "sa";
            sqlsb.Password = "senha0406%";
            sqlsb.InitialCatalog = "sqlServerExample";
            SqlConnection sqlConnection = new SqlConnection(sqlsb.ConnectionString);
            sqlConnection.Open();
            CreateHostBuilder(args).Build().Run();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}