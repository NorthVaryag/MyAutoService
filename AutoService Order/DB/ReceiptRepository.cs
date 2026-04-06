using System;
using Microsoft.Extensions.Options;
using MySqlConnector;

namespace AutoService_Order.DB;

public class ReceiptRepository
{
    MySqlConnection connection;
    public ReceiptRepository(IOptions<DataBaseConnection> connect)
    {
        connection = new MySqlConnection(connect.Value.ConnectionString);
    }
    
    /*public void InsertAllReceipt()
    {
        // создание транзакции
        using var transaction = connection.BeginTransaction();
        try
        {
            // какие-то запросы, которые должны быть выполненны в рамках одной транзакции
            using (var mc = new MySqlCommand(sql1, connection, transaction))
                mc.ExecuteNonQuery();
            using (var mc = new MySqlCommand(sql2, connection, transaction))
                mc.ExecuteNonQuery();
            for (int i = 0; i < 10; i++)
                using (var mc = new MySqlCommand(sql3 + i, connection, transaction))
                    mc.ExecuteNonQuery();
            // подтверждение транзации
            transaction.Commit();
        }
        catch (Exception e)
        {
            // отмена всех запросов в данной транзакции в случае ошибки
            transaction.Rollback();
        }
    }*/
}