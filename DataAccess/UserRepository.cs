using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace DataAccess
{
    public class UserRepository : IUserRepository
    {
        public User getUserByUsername(string username)
        {

            User? user = null;

            SqlConnection connection = DbContext.Connection();
            using (connection)
            {
                connection.Open();
                SqlCommand sqlCommand = new("select * from Users where UserName = @UserName", connection);
                SqlParameter sqlParameter = new()
                {
                    ParameterName = "UserName",
                    Value = user.UserName
                };
                sqlCommand.Parameters.Add(sqlParameter);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new(id: reader.GetGuid(0), firstName: reader.GetString(1), lastName: reader.GetString(2).Trim(), phoneNumber: reader.GetString(3).Trim(),
                    address: reader.GetString(3), userName: reader.GetString(4).Trim(), password: reader.GetString(5), balance: reader.GetDecimal(6));
                    }

                    return user ?? null;
                }

            }
        }

        public void InsertUserInfo(User user)
        {
            using (SqlConnection connection = DbContext.Connection())
            {
                connection.Open();
                string query = $@"INSERT INTO Account(FirstName,
                                           LastName,
                                           PhoneNumber,
                                           Address,
                                           UserName,
                                           Password,
                                           Balance) 
                                    VALUES(
                                            '{user.FirstName}',
                                            '{user.LastName}',
                                            '{user.PhoneNumber}',
                                            '{user.Address}',
                                            '{user.UserName}',
                                            HASHBYTES('SHA2_256','{user.Password}'),
                                            '{user.Balance}'
                                            )";
                connection.Query(query);
            }
        }
    }
}
