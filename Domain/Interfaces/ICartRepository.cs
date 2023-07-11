using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ICartRepository
    {

        public Cart GetCart(string id);
        public int AddCart(Cart id);
    }
}
