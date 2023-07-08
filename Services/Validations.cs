using Domain.Interfaces;
using System.Text.RegularExpressions;

namespace Service
{
  public class Validation : IValidation
  {
    public bool NameValidation(string name)
    {
      Regex regex = new Regex("^[a-zA-Z]+$");
      return regex.IsMatch(name);
    }
    public bool AddressValidation(string email)
    {
      Regex regex = new Regex("^[a-zA-Z0-9\\s]+$");
      return regex.IsMatch(email);
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
  }
}
