using Domain.Interfaces;
using System.Text.RegularExpressions;

namespace Service
{
  public class Validation : IValidation
  {
    private readonly IUserRepository userRepository;
    public Validation(IUserRepository userRepository)
    {
      this.userRepository = userRepository;
    }
    public bool NameValidation(string name)
    {
      Regex regex = new Regex("^[a-zA-Z]+$");
      return regex.IsMatch(name);
    }
    public bool AddressValidation(string address)
    {
      Regex regex = new Regex("^[a-zA-Z0-9\\s]+$");
      return regex.IsMatch(address);
    }
    public bool PhoneNumberValidation(string phoneNumber)
    {
      Regex regex = new Regex("^\\+?[1-9][0-9]{7,14}$");
      return regex.IsMatch(phoneNumber);
    }
    public bool PasswordValidation(string password)
    {
      Regex regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$");
      return regex.IsMatch(password);
    }
    public bool UsernameValidation(string username)
    {
      Regex regex = new Regex("^[a-zA-Z0-9]+$");
      return regex.IsMatch(username);
    }
    public bool UsernameExistanceValidation(string username) 
      => userRepository.UsernameExistanceValidation(username);

  }
}
