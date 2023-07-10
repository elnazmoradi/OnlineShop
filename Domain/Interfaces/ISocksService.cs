using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISocksService
    {
        ServiceResult<bool> AddSocksToDataBase(Socks socks);
        ServiceResult<Socks> GetSocksByID(Guid ID);
        ServiceResult<List<Socks>> GetAllSocks();
        ServiceResult<bool> DeleteSocksByID(Guid ID);

    }
}
