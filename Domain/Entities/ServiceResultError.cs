using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ServiceResultError<T> : ServiceResult<T>
    {
        public ServiceResultError(string errorMessage)
        {
            this.IsSuccessfull = false;
            this.ErrorMessage = errorMessage;
        }
    }
}
