using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FunctionApp1.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FunctionApp1
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var response = 0;
            var sqlconnection = Environment.GetEnvironmentVariable("SqlConnectionString",EnvironmentVariableTarget.Process);
            using (SqlConnection conn=new SqlConnection(sqlconnection))
            {
                conn.Open();
                var text = "Insert into tblSample Values ('Suresh')";
                using (SqlCommand cmd=new SqlCommand(text, conn))
                {
                    response=await cmd.ExecuteNonQueryAsync();
                }
                conn.Close();
            }
            return new OkResult();
        }
    }
}
