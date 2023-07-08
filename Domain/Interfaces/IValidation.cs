namespace Domain.Interfaces
{
  public interface IValidation
  {
    bool NameValidation(string name);
    bool AddressValidation(string email);
    bool PhoneNumberValidation(string phoneNumber);
    bool PasswordValidation(string password);
    bool UsernameValidation(string username);
    //TODO: Username Existance Validation 
  }
}
