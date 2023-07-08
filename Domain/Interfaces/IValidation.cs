namespace Domain.Interfaces
{
  public interface IValidation
  {
    bool NameValidation(string name);
    bool AddressValidation(string address);
    bool PhoneNumberValidation(string phoneNumber);
    bool PasswordValidation(string password);
    bool UsernameValidation(string username);
    bool UsernameExistanceValidation(string username); 
  }
}
