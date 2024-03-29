﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataLibrary.Models;

namespace DataLibrary.DataAccess
{
    public static class SqlDataAccess
    {
        public static string GetConnectionString(string connectionName = "DB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
             using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static T LoadSingleData<T>(string sql,string Id)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
       
                return cnn.QueryFirst<T>(sql,new {Id =Id});
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql,data);
            }
        }

        public static void DeleteData(string sql, string Id)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                 cnn.Execute(sql, new { Id = Id });
            }
        }

        public static bool IsExist(string sql, string Id)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
               return cnn.ExecuteScalar<bool>(sql, new { Id = Id });
            }
        }

    }
}
