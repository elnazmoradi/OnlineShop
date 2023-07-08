using Domain.Entities;

namespace Domain.Interfaces
{
  public interface IUserService
  {
        ServiceResult<User> Login(string username, string password);
    string InsertUserInfo(User user);
  }
}
