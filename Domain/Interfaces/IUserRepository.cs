
using Domain.Entities;

namespace Domain.Interfaces
{
  public interface IUserRepository
  {
    void InsertUserInfo(User user);
    bool UsernameExistanceValidation(string user);
  }
}
