using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ServiceResult<T>
    {
        public bool IsSuccessfull { get; set; }
        public T Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}
