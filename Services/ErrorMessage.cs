using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
  public class ErrorMessages
  {
    public string ShowMessages(Errors errors)
    {
      string message;
      IEnumerable<ErrorModel> errorsModels = ReadErrorMessagesFromFile().ToList();
      message = errorsModels.Where(r => r.Title.Equals(errors.ToString())).Select(r => r.Description).FirstOrDefault();
      return message;
    }
    private IEnumerable<ErrorModel> ReadErrorMessagesFromFile()
    {

      string filePath = Path.Combine("Utils", "Messages.csv");
      var errorMessages = File.ReadAllLines(filePath);

      foreach (var item in errorMessages)
      {
        var data = item.Split(',');
        yield return new ErrorModel(data[0], data[1]);
      }
    }

  }
}
