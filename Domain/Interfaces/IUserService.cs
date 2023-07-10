using Domain.Entities;

namespace Domain.Interfaces
{
  public interface IUserService
  {
        ServiceResult<User> Login(string username, string password);
    ServiceResult<User> InsertUserInfo(User user);
  }
}
