using System;
using System.Collections.Generic;
using System.Data;
using AutoService_Order.Models;
using Microsoft.Extensions.Options;
using MySqlConnector;

namespace AutoService_Order.DB;

public class WorkRepository
{
    MySqlConnection connection;
    public WorkRepository(IOptions<DataBaseConnection> connect)
    {
        connection = new MySqlConnection(connect.Value.ConnectionString);
    }
    public List<Work> GetWorkAll()
    {
        List<Work> workList = new List<Work>();
        try
        {
            connection.Open();
            string sql = "SELECT * FROM Work";
            using (var mc = new MySqlCommand(sql, connection))
            using (var dr = mc.ExecuteReader())
            {
                while (dr.Read())
                {
                    workList.Add(new Work
                    {
                        Id = dr.GetInt32("id"),
                        ServiceId = dr.GetInt32("service_id"),
                        WorkName = dr.GetString("work_name"),
                        Price = dr.GetDecimal("price")
                    });
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
        return workList;
    }
}