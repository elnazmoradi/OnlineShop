using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace DataAccess
{
  public class UserRepository : IUserRepository
  {  
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
                                           Password) 
                                    VALUES(
                                            '{user.Id}',
                                            '{user.FirstName}',
                                            '{user.LastName}',
                                            '{user.PhoneNumber}',
                                            '{user.Address}',
                                            '{user.UserName}',
                                            HASHBYTES('SHA2_256','{user.Password}')  
                                            )";

        connection.Query(query);
      }
    }
  }
}
