
using Domain.Entities;

namespace Domain.Interfaces
{
  public interface IUserRepository
  {
        User getUserByUsernameAndPassword(string username, string password);
    void InsertUserInfo(User user);
    bool UsernameExistanceValidation(string user);
  }
}
