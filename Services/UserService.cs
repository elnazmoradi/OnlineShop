using Domain.Entities;
using Domain.Enums;
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
        return new ErrorMessages().ShowMessages(Errors.InvalidFirstName);

      if (!validation.NameValidation(user.LastName))
        return new ErrorMessages().ShowMessages(Errors.InvalidLastName);

      if (!validation.EmailValidation(user.Email))
        return new ErrorMessages().ShowMessages(Errors.InvalidEmail);

      if (!validation.PhoneNumberValidation(user.PhoneNumber))
        return new ErrorMessages().ShowMessages(Errors.InvalidPhoneNumber);

      if (!validation.UsernameValidation(user.UserName))
        return new ErrorMessages().ShowMessages(Errors.InvalidUsername);

      if (!validation.PasswordValidation(user.Password))
        return new ErrorMessages().ShowMessages(Errors.InvalidPassword);

      userRepository.InsertUserInfo(user);

      return new ErrorMessages().ShowMessages(Errors.Welcome);
    }
  }
}
