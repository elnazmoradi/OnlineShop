using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace DataAccess
{
    public class UserRepository : IUserRepository
    {
        public User getUserByUsernameAndPassword(string username, string password)
        {

            User? user = null;

            SqlConnection connection = DbContext.Connection();
            using (connection)
            {
                connection.Open();
                SqlCommand sqlCommand = new($@"SELECT * FROM Account where Username = '{username}' AND Password = HASHBYTES('SHA2_256','{password}')", connection);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new(id: reader.GetGuid(0), firstName: reader.GetString(1), lastName: reader.GetString(2).Trim(), phoneNumber: reader.GetString(3).Trim(),
                    address: reader.GetString(4), userName: reader.GetString(5).Trim(), balance: reader.GetDecimal(7));
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
                string query = $@"INSERT INTO Account(
                                           Id,
                                           FirstName,
                                           LastName,
                                           PhoneNumber,
                                           Address,
                                           UserName,
                                           Password,
                                           Balance) 
                                    VALUES(
                                            '{user.Id}',
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
    public bool UsernameExistanceValidation(string username)
    {
      using (SqlConnection connection = DbContext.Connection())
      {
        connection.Open();
        string query = $@"SELECT * FROM Account WHERE Username = '{username}'";
        return connection.ExecuteReader(query).FieldCount > 0;
        connection.Close();
      }
    }
  }
}
