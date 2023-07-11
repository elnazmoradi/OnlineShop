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
    public class CartRepository : ICartRepository
    {
        public int AddCart(Cart cart)
        {
            using(var connectin = DbContext.Connection())
            {
                connectin.Open();
                string commandString = "INSERT INTO Carts (ID,AccountID) VALUES (@ID,@AccountID)";
                var command = new SqlCommand(commandString, connectin);
                command.Parameters.Add(new SqlParameter[]
                {
                    new SqlParameter("@ID",cart.ID),
                    new SqlParameter("@AcccountID",cart.AccountID)
                }
                );
                return command.ExecuteNonQuery();
            }
        }

        public Cart GetCart(string id)
        {
            var cart = new Cart();
            using(var connectin = DbContext.Connection())
            {
                connectin.Open();
                string commandString = "SELECT * FROM Carts WHERE ID=@Id";
                var command = new SqlCommand(commandString, connectin);
                command.Parameters.Add(new SqlParameter("@Id", id));
                using(var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        cart.ID = Guid.Parse(dataReader.GetString(0));
                        cart.AccountID = Guid.Parse(dataReader.GetString(1));                        
                    }
                    return cart;
                }
            }
        }
    }
}
