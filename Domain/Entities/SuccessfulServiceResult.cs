using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SuccessfulServiceResult <T> : ServiceResult<T>
  {
    public SuccessfulServiceResult(T result)
    {
      this.IsSuccessfull = true;
      this.Result = result;
    }
    public SuccessfulServiceResult()
    {
      this.IsSuccessfull = true;
    }
  }
}
