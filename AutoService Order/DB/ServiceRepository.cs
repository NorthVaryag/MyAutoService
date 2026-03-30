using System;
using System.Collections.Generic;
using AutoService_Order.Models;
using Microsoft.Extensions.Options;
using MySqlConnector;

namespace AutoService_Order.DB;

public class ServiceRepository
{
    
    MySqlConnection connection;
    public ServiceRepository(IOptions<DataBaseConnection> connect)
    {
        connection = new MySqlConnection(connect.Value.ConnectionString);
    }

    public List<Service> GetAllServces()
    {
        List<Service> serviceList = new List<Service>();
        string sql = "select * from services";
        try
        {
            connection.Open();
            using (var mc = new MySqlCommand(sql, connection))
            using (var dr = mc.ExecuteReader())
            {
                while (dr.Read())
                {
                    serviceList.Add(new Service
                    {
                        Id = dr.GetInt32("id"),
                        Title = dr.GetString("title"),
                        Description = dr.GetString("description")
                    });
                }
            }
            connection.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        return serviceList;
    }
    
    
}