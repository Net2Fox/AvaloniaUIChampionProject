using System;
using System.Data;
using System.Reflection;
using Microsoft.VisualBasic.CompilerServices;
using MySql.Data.MySqlClient;

namespace AvaloniaUIChampionProject.Classes;

public static class DatabaseConnection
{
    private static string _connectionString = "server=sql7.freemysqlhosting.net;user=sql7612567;password=HeC3RxhgLI;database=sql7612567";
    private static MySqlConnection _mySqlConnection;
    
    public static T RunQuery<T>(string query) where T : new()
    {
        _mySqlConnection = new MySqlConnection(_connectionString);
        _mySqlConnection.Open();
        MySqlCommand cmd = new MySqlCommand(query, _mySqlConnection);
        MySqlDataReader dataReader = cmd.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(dataReader);
        _mySqlConnection.Close();
        T instance = new T();
        
        if (dt.Rows.Count != 0)
        {
            foreach (DataColumn column in dt.Columns)
            {
                foreach (DataRow row in dt.Rows)
                {
                    object value = row[column];
                    PropertyInfo propertyInfo = instance.GetType().GetProperty(column.ColumnName);
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(instance, value);
                    }
                }
            }
        }
        return instance;
    }
}