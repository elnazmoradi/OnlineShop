using Domain.Entities;
using Domain.Interfaces;

namespace Service
{
  public class UserService : IUserService
  {
    private readonly IValidation validation;
    private readonly IUserRepository userRepository;
    public UserService(IValidation validation, IUserRepository userRepository)
    {
      this.validation = validation;   
      this.userRepository = userRepository;
    }
    public string InsertUserInfo(User user)
    {
      if (!validation.NameValidation(user.FirstName))
        return "Invalid First Name";

      if (!validation.NameValidation(user.LastName))
        return "Invalid Last Name";

      if (!validation.EmailValidation(user.Email))
        return "Invalid Email Address";

      if (!validation.PhoneNumberValidation(user.PhoneNumber))
        return "Invalid Phone Number";

      if (!validation.UsernameValidation(user.UserName))
        return "Invalid UserName";

      if (!validation.PasswordValidation(user.Password))
        return "Invalid Password";
      
      userRepository.InsertUserInfo(user);

      return "Registered";
    }
  }
}
