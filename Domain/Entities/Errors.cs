using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
  public class ErrorModel
  {
    public ErrorModel(string title, string description)
    {
      Title = title;
      Description = description;
    }
    public string Title { get; set; }
    public string Description { get; set; }
  }
}
