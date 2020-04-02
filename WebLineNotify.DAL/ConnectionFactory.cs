using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using MySql;
using MySql.Data.MySqlClient;

namespace WebLineNotify.DAL
{

    public class ConnectionFactory
    {

        public static DbConnection GetOpenConnection()
        {
            string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;
            //string connstr = @"server=127.0.0.1;uid=sa;pwd=321456852;database=test;CharSet=utf8;";
            var connection = new MySqlConnection(connstr);
            connection.Open();
            return connection;

        }

    }
}
