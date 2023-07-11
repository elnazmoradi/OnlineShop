using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICartService
    {
        public ServiceResult<Cart> ShowAccountCart(string accountID);
        public ServiceResult<int> MakeCartForAccount(string accountID);
    }
}
