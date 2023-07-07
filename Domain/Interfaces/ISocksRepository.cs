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
        Socks GetSocksByID(int ID);
        List<Socks> GetAllSocks();
        void UpdateSocksByID(int ID);
        void DeleteSocksByID(int ID);
    }
}
