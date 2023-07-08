namespace Domain.Interfaces
{
  public interface IValidation
  {
    bool NameValidation(string name);
    bool EmailValidation(string email);
    bool PhoneNumberValidation(string phoneNumber);
    bool PasswordValidation(string password);
    bool UsernameValidation(string username);
    bool UsernameExistanceValidation(string username); 
  }
}
