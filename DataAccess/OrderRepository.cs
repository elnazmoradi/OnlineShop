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
                    new SqlParameter("@SocksNumber",order.SocksNumber),
                    new SqlParameter("@OrderPrice",order.OrderPrice),
                });
                var result = command.ExecuteNonQuery();
                return result;
            }
        }

        public int DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrdersByCartID(string cartID)
        {
            throw new NotImplementedException();
        }

        public int UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
