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
        public ServiceResult<User> Login(string username, string password)
        {
            User user = userRepository.getUserByUsernameAndPassword(username,password);
            try
            {
                //User user = userRepository.getUserByUsername(username);
                if (user != null )
                {
                    return new SuccessfulServiceResult<User>(user);
                }
                    
            }
            catch (Exception) { }
            return new ServiceResultError<User>("Username or password is wrong");
        }
        public ServiceResult<User> InsertUserInfo(User user)
        {
          if (!validation.NameValidation(user.FirstName))
            return new ServiceResultError<User>(new ErrorMessages().ShowMessages(Errors.InvalidFirstName));

          if (!validation.NameValidation(user.LastName))
            return new ServiceResultError<User>(new ErrorMessages().ShowMessages(Errors.InvalidLastName));

          if (!validation.AddressValidation(user.Address))
            return new ServiceResultError<User>(new ErrorMessages().ShowMessages(Errors.InvalidAddress));

          if (!validation.PhoneNumberValidation(user.PhoneNumber))
            return new ServiceResultError<User>(new ErrorMessages().ShowMessages(Errors.InvalidPhoneNumber));

          if (!validation.UsernameValidation(user.UserName))
            return new ServiceResultError<User>(new ErrorMessages().ShowMessages(Errors.InvalidUsername));

          if (!validation.UsernameExistanceValidation(user.UserName))
            return new ServiceResultError<User>(new ErrorMessages().ShowMessages(Errors.RepeatedUsername));

          if (!validation.PasswordValidation(user.Password))
            return new ServiceResultError<User>(new ErrorMessages().ShowMessages(Errors.InvalidPassword));

          user.Id = Guid.NewGuid();
          userRepository.InsertUserInfo(user);

          return new SuccessfulServiceResult<User>();
        }
  }
}
