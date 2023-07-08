using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ISocksRepository
    {
        void CreateSocks(Socks TheSocks);
        Socks GetSocksByID(Guid ID);
        List<Socks> GetAllSocks();
        void UpdateSocksByID(Guid ID);
        void DeleteSocksByID(Guid ID);
    }
}
