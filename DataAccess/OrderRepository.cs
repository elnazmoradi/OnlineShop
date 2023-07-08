using Domain.Contracts;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderRepository : IOrderRepository
    {
        public int AddOrder(Order order)
        {
            using (var connection = DbContext.Connection())
            {
                connection.Open();
                string commandString = "INSERT INTO Orders (ID,SocksID,CartID,SocksNumber,OrderPrice) " +
                    "VALUES (@ID,@SocksID,@CartID,@SocksNumber,@OrderPrice)";
                var command = new SqlCommand(commandString, connection);
                command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@ID",order.ID),
                    new SqlParameter("@SocksID",order.SocksID),
                    new SqlParameter("@CartID",order.CartID),
                    new SqlParameter("@SocksNumber",order.SocksNumber),
                    new SqlParameter("@OrderPrice",order.OrderPrice),
                });
                var result = command.ExecuteNonQuery();
                return result;
            }
        }

        public int DeleteOrder(string id)
        {
            using (SqlConnection connection = DbContext.Connection())
            {
                string command = $"DELETE FROM Orders WHERE ID = {id};";
                using var cmd = new SqlCommand(command, connection);
                var result = cmd.ExecuteNonQuery();
                return result;
            }
            
        }

        public List<Order> GetOrdersByCartID(string cartID)
        {
            var orderList = new List<Order>();  
            using(var connection = DbContext.Connection())
            {
                connection.Open();
                var command = new SqlCommand($"SELECT * FROM Orders WHERE ID ={cartID}",connection);
                using(var reader = command.ExecuteReader()) 
                {
                    while(reader.Read())
                    {
                        var order = new Order()
                        {
                            ID = reader.GetInt32(0),
                            SocksID = reader.GetInt32(1),
                            CartID = reader.GetInt32(2),
                            SocksNumber= reader.GetInt32(3),
                            OrderPrice = reader.GetDouble(4),
                        };
                        orderList.Add(order);
                    }
                }
            }
            return orderList;   
            
        }

        public int UpdateOrder(Order order)
        {
            using (var connection = DbContext.Connection())
            {
                connection.Open();
                string commandString = $"UPDATE Orders SET ID=@ID , SocksID=@SocksID , CartID=@CatID , SocksNumber=@SocksNumber , OrderPrice=@OrderPrice" +
                    $"WHERE ID = {order.ID}";
                var command = new SqlCommand(commandString, connection);
                command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@ID",order.ID),
                    new SqlParameter("@CartID",order.CartID),
                    new SqlParameter("@SocksID",order.SocksID),
                    new SqlParameter("@SocksNumber",order.SocksNumber),
                    new SqlParameter("@OrderPrice",order.OrderPrice),
                });
                var result = command.ExecuteNonQuery();
                return result;
            }

        }
    }
}
